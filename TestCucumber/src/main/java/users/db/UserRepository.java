package users.db;

import users.model.User;
import java.io.IOException;
import java.util.List;

public interface UserRepository
{
  List<User> findAll() throws IOException, InterruptedException;
  User findById(String username) throws IOException, InterruptedException;
  User save(User u);
  void deleteById(String username);
}
