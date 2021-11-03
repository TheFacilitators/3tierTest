using System;

namespace WebClient.Models
{
    public class Status
    {
        public int Health;
        private readonly int max = 100;
        private readonly int death = 0;

        public Status(int i)
        {
            Health = i;
            
        }

        public void Increment(int i)
        {
            for (int j = 0; j < i; j++)
            {
                Health = Health++;
                if (Health == max)
                {
                    
                    break;
                }
            }
        }

        public void Decrement(int i)
        {
            for (int j = 0; j < i; j++)
            {
                Health = Health--;
                if (Health == death)
                {
                    throw new Exception("You are dead.");
                }
            }
        }
        
    }
}