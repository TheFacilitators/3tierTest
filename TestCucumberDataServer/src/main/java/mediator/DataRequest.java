package mediator;

public class DataRequest
{
  private String type;
  private String body;

  public DataRequest(String type, String body)
  {
    this.type = type;
    this.body = body;
  }

  public String getType()
  {
    return type;
  }

  public String getBody()
  {
    return body;
  }
}
