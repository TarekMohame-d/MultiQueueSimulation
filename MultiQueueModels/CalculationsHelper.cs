using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class CalculationsHelper
    {
        void timeDistributions(int serverID)
        {
            RawData rawData = ExtraxtData.rawData;
            List<double> cumulativeProbability = new List<double>();
            cumulativeProbability[0] = rawData.serviceDistributions[serverID].serverProbability[0] + 0;
            for (int i = 1; i < rawData.serviceDistributions[serverID].serverProbability.Count; i++)
            {
                cumulativeProbability[i] = rawData.serviceDistributions[serverID].serverProbability[i-1] +
                    rawData.serviceDistributions[serverID].serverProbability[i];
            }
            for (int i = 0; i < rawData.serviceDistributions[serverID].serverTime.Count;i++)
            {
                 
                /*TimeDistribution timeDistribution = new TimeDistribution(
                    rawData.serviceDistributions[serverID].serverTime[i],
                    rawData.serviceDistributions[serverID].serverProbability[i],
                    cumulativeProbability[i],

                    );*/
            }    
        }

    }
}
