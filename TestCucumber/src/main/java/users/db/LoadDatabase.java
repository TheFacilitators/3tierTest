package users.db;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import users.model.User;

@Configuration public class LoadDatabase
{

  private static final Logger log = LoggerFactory.getLogger(LoadDatabase.class);

  @Bean
  CommandLineRunner initDatabase(UserRepository userRepository/*, OrderRepository orderRepository*/) {

    return args -> {
      userRepository.save(new User("BilboBaggins", "Baggins"));
      userRepository.save(new User("FrodoBaggins", "Baggins"));

      userRepository.findAll().forEach(user -> log.info("Preloaded " + user));


/*      orderRepository.save(new Order("MacBook Pro", Status.COMPLETED));
      orderRepository.save(new Order("iPhone", Status.IN_PROGRESS));

      orderRepository.findAll().forEach(order -> {
        log.info("Preloaded " + order);
      });*/
    };
  }
}
