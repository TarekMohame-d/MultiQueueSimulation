using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace MultiQueueModels
{
    public class eventstruct
    {
       public int type; //0 for arrival,1 for departure 
       public int customernumber; // from 0 
       public Server servernumber; //from 0 
       public int time;
       public eventstruct(int type, int customernumber, int time,Server servernumber)
        {
            this.type = type;
            this.customernumber = customernumber;
            this.time = time;
            this.servernumber= servernumber;
        }
        public eventstruct(int type, int customernumber, int time)
        {
            this.type = type;
            this.customernumber = customernumber;
            this.time = time;
            this.servernumber = new Server();
            this.servernumber.ID = 999999999;
            this.servernumber.TotalWorkingTime = 999999999;
        }

    }
    public class MyClassAgeComparer : IComparer<eventstruct>
    {
        public int Compare(eventstruct x, eventstruct y)
        {
            return x.time.CompareTo(y.time);
        }
    }
    public class RawData
    {
        public int numberOfServers;
        public int stoppingNumber;
        public string stoppingCriteria;
        public string selectionMethod;
        public List<double> interarrivalTime = new List<double>();
        public List<double> interarrivalProbability = new List<double>();
        public List<ServiceDistribution> serviceDistributions = new List<ServiceDistribution>();
    }
    public class ServiceDistribution
    {
        public List<double> serverTime = new List<double>();
        public List<double> serverProbability = new List<double>();
    }
    public class ExtraxtData
    {
        public static string filePath;
        public static int lineIndex = 0;
        public static RawData rawData = new RawData();
        public static ServiceDistribution temp = new ServiceDistribution();
        public static void extractFileData()
        {
            rawData = new RawData();
            temp = new ServiceDistribution();
            lineIndex = 0;
            string currentKey = "";

            foreach (string line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Use a regular expression to match numbers in the line
                MatchCollection matches = Regex.Matches(line, @"\b\d+(\.\d+)?\b");

                if (matches.Count > 0)
                {
                    List<double> numbers = new List<double>();
                    foreach (Match match in matches)
                    {
                        if (double.TryParse(match.Value, out double number))
                        {
                            numbers.Add(number);
                        }
                    }

                    if (currentKey != "")
                    {
                        switch (currentKey)
                        {
                            case "NumberOfServers":
                                {
                                    rawData.numberOfServers = (int)numbers[0];
                                    for (int i = 0; i < rawData.numberOfServers; i++)
                                    {
                                        ServiceDistribution serviceDistribution = new ServiceDistribution();
                                        rawData.serviceDistributions.Add(serviceDistribution);
                                    }
                                }
                                break;
                            case "StoppingNumber":
                                {
                                    rawData.stoppingNumber = (int)numbers[0];
                                }
                                break;
                            case "StoppingCriteria":
                                {
                                    if (numbers[0] == 1)
                                    {
                                        rawData.stoppingCriteria = "1";
                                    }
                                    else
                                    {
                                        rawData.stoppingCriteria = "2";
                                    }
                                }
                                break;
                            case "SelectionMethod":
                                {
                                    if (numbers[0] == 1)
                                    {
                                        rawData.selectionMethod = Enums.SelectionMethod.HighestPriority.ToString();
                                    }
                                    else if (numbers[0] == 2)
                                    {
                                        rawData.selectionMethod = Enums.SelectionMethod.Random.ToString();
                                    }
                                    else
                                    {
                                        rawData.selectionMethod = Enums.SelectionMethod.LeastUtilization.ToString();
                                    }
                                }
                                break;
                            case "InterarrivalDistribution":
                                {
                                    extractDataHelper(numbers, key: "InterarrivalDistribution");
                                }
                                break;
                            default:
                                {
                                    extractDataHelper(numbers, lineIndex: lineIndex);
                                    rawData.serviceDistributions[lineIndex - 6].serverTime.AddRange(temp.serverTime);
                                    rawData.serviceDistributions[lineIndex - 6].serverProbability.AddRange(temp.serverProbability);
                                }
                                break;
                        }
                    }
                }
                else
                {
                    currentKey = line.Trim();
                    lineIndex++;
                }
            }
        }

        static void extractDataHelper(List<double> numbers, string key = "", int lineIndex = -1)
        {
            if (key == "InterarrivalDistribution")
            {
                List<double> interarrivalTime = new List<double>();
                List<double> interarrivalProbability = new List<double>();
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        interarrivalTime.Add(numbers[i]);
                    }
                    else
                    {
                        interarrivalProbability.Add(numbers[i]);
                    }
                }
                rawData.interarrivalTime.AddRange(interarrivalTime);
                rawData.interarrivalProbability.AddRange(interarrivalProbability);
            }
            else if (lineIndex >= 6) // server data
            {
                List<double> serverTime = new List<double>();
                List<double> serverProbability = new List<double>();
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        serverTime.Add(numbers[i]);
                    }
                    else
                    {
                        serverProbability.Add(numbers[i]);
                    }
                }
                temp.serverTime = serverTime;
                temp.serverProbability = serverProbability;
            }
        }
    }
}
