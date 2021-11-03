package users.model.customExceptions;

public class InvalidPasswordException extends RuntimeException
{
  public InvalidPasswordException()
  {
    super("Invalid Password");
  }
}
