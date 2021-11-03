package users.model.customExceptions;

public class UserNotFoundException extends RuntimeException
{
  public UserNotFoundException(String id)
  {
    super("User not found; "+id);
  }
}
