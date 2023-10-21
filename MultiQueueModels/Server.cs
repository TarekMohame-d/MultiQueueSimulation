using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Server
    {
        public Server()
        {
            this.TimeDistribution = new List<TimeDistribution>();
        }

        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; } 
        public decimal Utilization { get; set; }

        public List<TimeDistribution> TimeDistribution;

        //optional if needed use them
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }

        public Server(int iD, decimal idleProbability, decimal averageServiceTime, decimal utilization, List<TimeDistribution> timeDistribution, int finishTime, int totalWorkingTime)
        {
            ID = iD;
            IdleProbability = idleProbability;
            AverageServiceTime = averageServiceTime;
            Utilization = utilization;
            TimeDistribution = timeDistribution;
            FinishTime = finishTime;
            TotalWorkingTime = totalWorkingTime;
        }
    }
}
