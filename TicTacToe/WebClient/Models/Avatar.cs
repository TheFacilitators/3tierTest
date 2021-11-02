namespace WebClient.Models
{
    public class Avatar
    {
        public Status health = new Status(100);

        public int GetStatus()
        {
            return health.Health;
        }
    }
}