using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class CalculationsHelper
    {
        public List<TimeDistribution> timeDistributions(int serverID)
        {
            RawData rawData = ExtraxtData.rawData;
            List<double> cumulativeProbability = new List<double>() { 0 };
            List<TimeDistribution> timeDistributionsList = new List<TimeDistribution>();
            cumulativeProbability[0] = rawData.serviceDistributions[0].serverProbability[0] + 0;
            for (int i = 1; i < rawData.serviceDistributions[serverID].serverProbability.Count; i++)
            {

                cumulativeProbability.Add(rawData.serviceDistributions[serverID].serverProbability[i] +
                    cumulativeProbability[i - 1]);
            }
            int min = 0, max = 0;
            for (int i = 0; i < rawData.serviceDistributions[serverID].serverTime.Count; i++)
            {
                if (i == 0)
                {
                    min = 1;
                    max = (int)(cumulativeProbability[0] * 100);
                }
                else
                {
                    min = max + 1;
                    if (i == rawData.serviceDistributions[serverID].serverTime.Count - 1)
                    {
                        max = 100;
                    }
                    else
                    {
                        max = (int)(cumulativeProbability[i] * 100);
                    }
                }
                TimeDistribution timeDistribution = new TimeDistribution(
                    (int)rawData.serviceDistributions[serverID].serverTime[i],
                    (decimal)rawData.serviceDistributions[serverID].serverProbability[i],
                    (decimal)(cumulativeProbability[i]*1),
                    min,
                    max
                    );
                timeDistributionsList.Add(timeDistribution);
            }
            return timeDistributionsList;
        }

        public List<Server> fillServerData()
        {
            RawData rawData = ExtraxtData.rawData;
            List<Server> serversList = new List<Server>();
            
            // dont forget equations !!!!!!!!!!!
            for (int i = 0; i < rawData.numberOfServers; i++)
            {
                List<TimeDistribution> timeDistributionsList = timeDistributions(i);
                Server server = new Server(
                    i,
                    0,
                    0,
                    0,
                    timeDistributionsList,
                    0,
                    0
                    );
                serversList.Add(server);
            }
            return serversList;
        }
    }
}
