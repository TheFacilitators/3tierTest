package mediator;

import com.google.gson.Gson;
import db.UserDAO;
import model.User;

public class RequestHandler
{
  private UserDAO dao;
  private Gson json;

  public RequestHandler()
  {
    this.dao = new UserDAO();
    this.json = new Gson();
  }

  public String filterRequest(String requestJson)
  {
    DataRequest dataRequest = json.fromJson(requestJson, DataRequest.class);
    String response = "";
    switch (dataRequest.getType())
    {
      case "findById":
         response = json.toJson(dao.readOne(dataRequest.getBody()));
        break;
      case "findAll":
        response = json.toJson(dao.readAll());
        break;
      case "save":
        User u = json.fromJson(dataRequest.getBody(), User.class);
        response = json.toJson(dao.create(u.getUsername(),u.getPassword()));
        break;
    }
    return response;
  }
}
