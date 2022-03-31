using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class WalkerFormModel
    {
        public Walker Walker { get; set; }
        public List<Walks> Walks { get; set; }
        public int TotalWalkTime
        {
            get
            {
                int sum = 0;
                foreach (Walks walk in Walks)
                {
                    return sum += walk.Duration;
                }
                return sum;
            }
        }
        
    }
}