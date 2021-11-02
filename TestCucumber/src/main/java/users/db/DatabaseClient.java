package users.db;
import com.google.gson.Gson;
import com.rabbitmq.client.AMQP;
import com.rabbitmq.client.Channel;
import com.rabbitmq.client.Connection;
import com.rabbitmq.client.ConnectionFactory;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import users.model.User;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;
import java.util.UUID;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.TimeoutException;

@Configuration
public class DatabaseClient implements AutoCloseable, UserRepository {

  private Connection connection;
  private Channel channel;
  private String requestQueueName = "data_queue";
  private Gson json;


 public DatabaseClient() throws IOException, TimeoutException {
    ConnectionFactory factory = new ConnectionFactory();
    factory.setHost("localhost");

    connection = factory.newConnection();
    channel = connection.createChannel();
    json = new Gson();
  }

  @Bean
  @Override public List<User> findAll() throws IOException, InterruptedException
  {
    String response = sendRequest("findAll", "");
    String resultJson = response;
    User[] resultArray = json.fromJson(resultJson,User[].class);
    List<User> result = Arrays.asList(resultArray.clone());
    return result;
  }

  @Override public User findById(String username) throws IOException, InterruptedException
  {
    String response = sendRequest("findById",username);
    String resultJson = response;
    User result = json.fromJson(resultJson,User.class);
    return result;  }

  @Override public User save(User u) throws IOException, InterruptedException
  {
    String uJson = json.toJson(u);

    String response = sendRequest("save",uJson);
    String resultJson = response;
    User result = json.fromJson(resultJson,User.class);
    return result;
  }

  @Override public void deleteById(String username)
  {

  }

  public void close() throws IOException {
    connection.close();
  }

  private String sendRequest(String type, String message)
      throws IOException, InterruptedException
  {
    final String corrId = UUID.randomUUID().toString();

    String replyQueueName = channel.queueDeclare().getQueue();
    AMQP.BasicProperties props = new AMQP.BasicProperties
        .Builder()
        .correlationId(corrId)
        .replyTo(replyQueueName)
        .build();

    DataRequest request = new DataRequest(type, message);
    String requestJson = json.toJson(request);

    channel.basicPublish("", requestQueueName, props, requestJson.getBytes("UTF-8"));

    final BlockingQueue<String> response = new ArrayBlockingQueue<>(1);

    String ctag = channel.basicConsume(replyQueueName, true, (consumerTag, delivery) -> {
      if (delivery.getProperties().getCorrelationId().equals(corrId)) {
        response.offer(new String(delivery.getBody(), "UTF-8"));
      }
    }, consumerTag -> {
    });
     String resp = response.take();
    channel.basicCancel(ctag);
    return resp;
  }
}