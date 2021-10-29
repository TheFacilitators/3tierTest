package users.model;

public class InvalidPasswordException extends RuntimeException
{
  public InvalidPasswordException()
  {
    super("Invalid Password");
  }
}
