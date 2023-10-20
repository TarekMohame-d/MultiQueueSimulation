using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace MultiQueueModels
{

    public class ExtraxtData
    {
        public static string filePath;
        public static int lineIndex = 0;
        public static Dictionary<string, List<double>> data = new Dictionary<string, List<double>>();
        public static void extractFileData()
        {
            data.Clear();
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
                                    dictionaryHelper(data, "NumberOfServers", numbers);
                                }
                                break;
                            case "StoppingNumber":
                                {
                                    dictionaryHelper(data, "StoppingNumber", numbers);
                                }
                                break;
                            case "StoppingCriteria":
                                {
                                    dictionaryHelper(data, "StoppingCriteria", numbers);
                                }
                                break;
                            case "SelectionMethod":
                                {
                                    dictionaryHelper(data, "SelectionMethod", numbers);
                                }
                                break;
                            case "InterarrivalDistribution":
                                {
                                    dictionaryHelper(data, "InterarrivalDistribution", numbers);
                                }
                                break;
                            default:
                                {
                                    dictionaryHelper(data, currentKey, numbers, lineIndex);
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

        static void dictionaryHelper(Dictionary<string, List<double>> data, string key, List<double> numbers, int lineIndex = -1)
        {
            if (key == "InterarrivalDistribution")
            {
                List<double> interarrivalTime = new List<double>();
                List<double> interarrivalProbability = new List<double>();
                string column1Name = "Interarrival_Time";
                string column2Name = "Interarrival_Probability";
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
                if (data.ContainsKey(column1Name) || data.ContainsKey(column2Name))
                {
                    data[column1Name].AddRange(interarrivalTime);
                    data[column2Name].AddRange(interarrivalProbability);
                }
                else
                {
                    data[column1Name] = interarrivalTime;
                    data[column2Name] = interarrivalProbability;
                }
            }
            else if (lineIndex >= 6)
            {
                string columnName = key.Substring(key.IndexOf('_') + 1);
                List<double> serverTime = new List<double>();
                List<double> ServerProbability = new List<double>();
                string column1Name = columnName + "_Time";
                string column2Name = columnName + "_Probability";
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        serverTime.Add(numbers[i]);
                    }
                    else
                    {
                        ServerProbability.Add(numbers[i]);
                    }
                }
                if (data.ContainsKey(column1Name) || data.ContainsKey(column2Name))
                {
                    data[column1Name].AddRange(serverTime);
                    data[column2Name].AddRange(ServerProbability);
                }
                else
                {
                    data[column1Name] = serverTime;
                    data[column2Name] = ServerProbability;
                }
            }
            else
            {
                if (data.ContainsKey(key))
                {
                    data[key].AddRange(numbers);
                }
                else
                {
                    data[key] = numbers;
                }
            }
        }
    }
}
