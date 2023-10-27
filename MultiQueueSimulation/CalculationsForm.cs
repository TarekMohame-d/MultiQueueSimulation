using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MultiQueueModels;
using MultiQueueTesting;

namespace MultiQueueSimulation
{
    public partial class CalculationsForm : Form
    {
        public static SimulationSystem oursystem = new SimulationSystem();
        
        public CalculationsForm()
        {
            InitializeComponent();

        }


        private void CalculationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public void NoOfcustomersandpriority()
        {
            List<SimulationCase> Customers = new List<SimulationCase>();
            CalculationsHelper c = new CalculationsHelper();
            List<TimeDistribution> listforinterarrival = c.timeDistributionsforinterarrivals();
            List<List<TimeDistribution>> listforservers = new List<List<TimeDistribution>>();
            for (int i = 0; i < ExtraxtData.rawData.numberOfServers; i++)
            {

                listforservers.Add(c.timeDistributionsforservers(i));
            }
            int totaltime = 0;

            var customComparer = new MyClassAgeComparer();
            List<eventstruct> eventlist = new List<eventstruct>();
            int simulationclock;
            List<Server> servers = new List<Server>();
            for (int i = 0; i < ExtraxtData.rawData.numberOfServers; i++)
            {
                servers.Add(new Server(i, listforservers[i]));
            }
            int numberofcustomerswhowaitinqueue = 0;
            int time = 0;
            for (int i = 0; i < ExtraxtData.rawData.stoppingNumber; i++)
            {
                if (i == 0)
                {
                    Customers.Add(new SimulationCase(i, 0, 0, 1));
                    continue;
                }
                Tuple<int, int> t = c.GetTime(listforinterarrival);
                int interarrivaltime = t.Item2;
                
                int timeofarrive = interarrivaltime + time;
                time = timeofarrive;
                Customers.Add(new SimulationCase(i, interarrivaltime, timeofarrive, t.Item1));

            }

            int maxnumberinqueue = 0;
            Queue<int> myQueue = new Queue<int>();
            eventlist.Add(new eventstruct(0, 0, Customers[0].ArrivalTime));
            while (eventlist.Count != 0)
            {
                eventstruct ev = eventlist.First();
                eventlist.Remove(ev);
                bool find = false;
                if (ev.type == 0) // arrival
                {
                    if (ev.customernumber != ExtraxtData.rawData.stoppingNumber - 1)
                    {
                        eventlist.Add(new eventstruct(0, ev.customernumber + 1, Customers[ev.customernumber + 1].ArrivalTime));
                        eventlist = eventlist.OrderBy(x => x.time).ThenBy(x => x.servernumber.ID).ToList();
                    }
                    for (int i = 0; i < servers.Count(); i++)
                    {
                        if (servers[i].state == 0)
                        {
                            find = true;
                            servers[i].state = 1;
                            Customers[ev.customernumber].StartTime = ev.time;
                            Customers[ev.customernumber].TimeInQueue = 0;
                            Tuple<int, int> t = c.GetTime(servers[i].TimeDistribution);
                            int servicetime = t.Item2;
                            Customers[ev.customernumber].EndTime = ev.time + servicetime;
                            Customers[ev.customernumber].ServiceTime = servicetime;
                            Customers[ev.customernumber].RandomService = t.Item1;
                            Customers[ev.customernumber].AssignedServer = servers[i];
                            servers[i].TotalWorkingTime += servicetime;
                            servers[i].numofcustomers++;
                            eventlist.Add(new eventstruct(1, ev.customernumber, ev.time + servicetime, servers[i]));
                            eventlist = eventlist.OrderBy(x => x.time).ThenBy(x => x.servernumber.ID).ToList(); 
                            break;
                        }
                    }
                    if (!find)
                    {
                        myQueue.Enqueue(ev.customernumber);
                        numberofcustomerswhowaitinqueue++;
                        maxnumberinqueue = Math.Max(maxnumberinqueue, myQueue.Count());
                    }
                }
                else
                {
                    if (myQueue.Count != 0)
                    {
                        int numberofcustomer = myQueue.Dequeue();
                        Customers[numberofcustomer].StartTime = ev.time;
                        Customers[numberofcustomer].TimeInQueue = ev.time - Customers[numberofcustomer].ArrivalTime;
                        Tuple<int, int> t = c.GetTime(servers[ev.servernumber.ID].TimeDistribution);
                        int servicetime = t.Item2;
                        Customers[numberofcustomer].EndTime = ev.time + servicetime;
                        Customers[numberofcustomer].RandomService = t.Item1;
                        Customers[numberofcustomer].ServiceTime = servicetime;
                        Customers[numberofcustomer].AssignedServer = servers[ev.servernumber.ID];
                        servers[ev.servernumber.ID].TotalWorkingTime += servicetime;
                        servers[ev.servernumber.ID].numofcustomers++;
                        eventlist.Add(new eventstruct(1, numberofcustomer, ev.time + servicetime, servers[ev.servernumber.ID]));
                        eventlist = eventlist.OrderBy(x => x.time).ThenBy(x => x.servernumber.ID).ToList();
                    }
                    else
                    {
                        servers[ev.servernumber.ID].state = 0;
                    }

                }
                if (eventlist.Count == 0)
                {
                    totaltime = ev.time;
                }
            }
            decimal totaldelaytime = 0;
            for (int i = 0; i < Customers.Count(); i++)
            {
                totaldelaytime += Customers[i].TimeInQueue;
            }
            decimal averagewaitinginqueue = totaldelaytime / ExtraxtData.rawData.stoppingNumber;
            decimal probabilityofwaiting = (decimal)numberofcustomerswhowaitinqueue / ExtraxtData.rawData.stoppingNumber;
            PerformanceMeasures p = new PerformanceMeasures();
            p.WaitingProbability = probabilityofwaiting;
            p.AverageWaitingTime = averagewaitinginqueue;
            p.MaxQueueLength = maxnumberinqueue;
            
            oursystem.InterarrivalDistribution = listforinterarrival;
            oursystem.StoppingNumber = ExtraxtData.rawData.stoppingNumber;
            if (int.Parse(ExtraxtData.rawData.stoppingCriteria) == 1)
            {
                oursystem.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
            }
            else
            {
                oursystem.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
            }

            oursystem.NumberOfServers = ExtraxtData.rawData.numberOfServers;
            for (int i = 0; i < servers.Count; i++)
            {
                servers[i].ID += 1;
                servers[i].Utilization = (decimal)servers[i].TotalWorkingTime / totaltime;
                servers[i].IdleProbability = 1 - servers[i].Utilization;
                if (servers[i].numofcustomers != 0)
                {
                    servers[i].AverageServiceTime = (decimal)servers[i].TotalWorkingTime / servers[i].numofcustomers;
                }
                else
                    servers[i].AverageServiceTime = 0;

            }
            
            oursystem.Servers = servers;
            oursystem.SimulationTable = Customers;
            oursystem.PerformanceMeasures = p;
            string testingresult = TestingManager.Test(oursystem, Constants.FileNames.TestCase2);
            //MessageBox.Show(testingresult);
            //MessageBox.Show(numberofcustomerswhowaitinqueue.ToString());
        }
        public void NoOfCustomersandleastutilization()
        {
            CalculationsHelper c = new CalculationsHelper();
            List<TimeDistribution> listforinterarrival = c.timeDistributionsforinterarrivals();
            List<List<TimeDistribution>> listforservers = new List<List<TimeDistribution>>();
            

            for (int i = 0; i < ExtraxtData.rawData.numberOfServers; i++)
            {

                listforservers.Add(c.timeDistributionsforservers(i));
            }
            int totaltime = 0;

            var customComparer = new MyClassAgeComparer();
            List<eventstruct> eventlist = new List<eventstruct>();
            List<SimulationCase> Customers = new List<SimulationCase>();
            int simulationclock;
            List<Server> servers = new List<Server>();
            for (int i = 0; i < ExtraxtData.rawData.numberOfServers; i++)
            {
                servers.Add(new Server(i, listforservers[i]));
            }
            int numberofcustomerswhowaitinqueue = 0;
            int time = 0;
            for (int i = 0; i < ExtraxtData.rawData.stoppingNumber; i++)
            {
                if (i == 0)
                {
                    Customers.Add(new SimulationCase(i, 0, 0, 1));
                    continue;
                }
                Tuple<int, int> t = c.GetTime(listforinterarrival);
                int interarrivaltime = t.Item2;
                int timeofarrive = interarrivaltime + time;
                time = timeofarrive;
                Customers.Add(new SimulationCase(i, interarrivaltime, timeofarrive, t.Item1));

            }

            int maxnumberinqueue = 0;
            Queue<int> myQueue = new Queue<int>();
            eventlist.Add(new eventstruct(0, 0, Customers[0].ArrivalTime));
            while (eventlist.Count != 0)
            {
                eventstruct ev = eventlist.First();
                eventlist.Remove(ev);
                bool find = false;
                if (ev.type == 0) // arrival
                {
                    if (ev.customernumber != ExtraxtData.rawData.stoppingNumber - 1)
                    {
                        eventlist.Add(new eventstruct(0, ev.customernumber + 1, Customers[ev.customernumber + 1].ArrivalTime));
                        eventlist = eventlist.OrderBy(x => x.time).ThenBy(x => x.servernumber.TotalWorkingTime).ToList();
                    }
                    servers = servers.OrderBy(x => x.TotalWorkingTime).ToList();
                    for (int i = 0; i < servers.Count(); i++)
                    {
                        if (servers[i].state == 0)
                        {
                            find = true;
                            servers[i].state = 1;
                            Customers[ev.customernumber].StartTime = ev.time;
                            Customers[ev.customernumber].TimeInQueue = 0;
                            Tuple<int, int> t = c.GetTime(servers[i].TimeDistribution);
                            int servicetime = t.Item2;
                            Customers[ev.customernumber].EndTime = ev.time + servicetime;
                            Customers[ev.customernumber].ServiceTime = servicetime;
                            Customers[ev.customernumber].RandomService = t.Item1;
                            Customers[ev.customernumber].AssignedServer = servers[i];
                            servers[i].TotalWorkingTime += servicetime;
                            servers[i].numofcustomers++;
                            eventlist.Add(new eventstruct(1, ev.customernumber, ev.time + servicetime, servers[i]));
                            eventlist = eventlist.OrderBy(x => x.time).ThenBy(x => x.servernumber.TotalWorkingTime).ToList();
                            break;
                        }
                    }
                    if (!find)
                    {
                        myQueue.Enqueue(ev.customernumber);
                        numberofcustomerswhowaitinqueue++;
                        maxnumberinqueue = Math.Max(maxnumberinqueue, myQueue.Count());
                    }
                }
                else
                {
                    if (myQueue.Count != 0)
                    {
                        int numberofcustomer = myQueue.Dequeue();
                        Customers[numberofcustomer].StartTime = ev.time;
                        Customers[numberofcustomer].TimeInQueue = ev.time - Customers[numberofcustomer].ArrivalTime;
                        Tuple<int, int> t = c.GetTime(servers[ev.servernumber.ID].TimeDistribution);
                        int servicetime = t.Item2;
                        Customers[numberofcustomer].EndTime = ev.time + servicetime;
                        Customers[numberofcustomer].RandomService = t.Item1;
                        Customers[numberofcustomer].ServiceTime = servicetime;
                        Customers[numberofcustomer].AssignedServer = servers[ev.servernumber.ID];
                        servers[ev.servernumber.ID].TotalWorkingTime += servicetime;
                        servers[ev.servernumber.ID].numofcustomers++;
                        eventlist.Add(new eventstruct(1, numberofcustomer, ev.time + servicetime, servers[ev.servernumber.ID]));
                        eventlist = eventlist.OrderBy(x => x.time).ThenBy(x => x.servernumber.TotalWorkingTime).ToList();
                    }
                    else
                    {
                        servers[ev.servernumber.ID].state = 0;
                    }

                }
                if (eventlist.Count == 0)
                {
                    totaltime = ev.time;
                }
            }
            decimal totaldelaytime = 0;
            for (int i = 0; i < Customers.Count(); i++)
            {
                totaldelaytime += Customers[i].TimeInQueue;
            }
            decimal averagewaitinginqueue = totaldelaytime / ExtraxtData.rawData.stoppingNumber;
            decimal probabilityofwaiting = (decimal)numberofcustomerswhowaitinqueue / ExtraxtData.rawData.stoppingNumber;
            PerformanceMeasures p = new PerformanceMeasures();
            p.WaitingProbability = probabilityofwaiting;
            p.AverageWaitingTime = averagewaitinginqueue;
            p.MaxQueueLength = maxnumberinqueue;
            
            oursystem.InterarrivalDistribution = listforinterarrival;
            oursystem.StoppingNumber = ExtraxtData.rawData.stoppingNumber;
            if (int.Parse(ExtraxtData.rawData.stoppingCriteria) == 1)
            {
                oursystem.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
            }
            else
            {
                oursystem.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
            }

            oursystem.NumberOfServers = ExtraxtData.rawData.numberOfServers;
            for (int i = 0; i < servers.Count; i++)
            {
                servers[i].ID += 1;
                servers[i].Utilization = (decimal)servers[i].TotalWorkingTime / totaltime;
                servers[i].IdleProbability = 1 - servers[i].Utilization;
                if (servers[i].numofcustomers != 0)
                {
                    servers[i].AverageServiceTime = (decimal)servers[i].TotalWorkingTime / servers[i].numofcustomers;
                }
                else
                    servers[i].AverageServiceTime = 0;

            }
            oursystem.Servers = servers;
            oursystem.SimulationTable = Customers;
            oursystem.PerformanceMeasures = p;
            string testingresult = TestingManager.Test(oursystem, Constants.FileNames.TestCase3);
            //MessageBox.Show(testingresult);
            //MessageBox.Show(numberofcustomerswhowaitinqueue.ToString());
        }

        public void makeColumnsOfTable()
        {
            dataGridView1.Columns.Add("customerNumber", "Customer Number");
            dataGridView1.Columns[0].Width = 122;

            dataGridView1.Columns.Add("randomArrival", "Random Digits for Arrival");
            dataGridView1.Columns[1].Width = 122;

            dataGridView1.Columns.Add("timeBetweenArrival", "Time Between Arrivals");
            dataGridView1.Columns[2].Width = 122;

            dataGridView1.Columns.Add("clockTimeOfArrival", "Clock Time of Arrival");
            dataGridView1.Columns[3].Width = 122;

            dataGridView1.Columns.Add("randomOfService", "Random Digits of Service");
            dataGridView1.Columns[4].Width = 122;

            for (int i = 0; i < oursystem.NumberOfServers; i++)
            {
                dataGridView1.Columns.Add($"timeServiceBeginofServer{i+1}", $"Time Service Begin of Server {i + 1}");
                dataGridView1.Columns[5 + i].Width = 122;

                dataGridView1.Columns.Add($"serviceTimeofServer{i+1}", $"Service Time of Server {i + 1}");
                dataGridView1.Columns[5 + i].Width = 122;

                dataGridView1.Columns.Add($"timeServiceEndofServer{i+1}", $"Time Service Ends of Server {i + 1}");
                dataGridView1.Columns[5 + i].Width = 122;
            }

            dataGridView1.Columns.Add("timeInQueue", "Time in Queue");
            dataGridView1.Columns[4].Width = 122;
        }

        private void FillRowsOfTable()
        {
            for (int i = 0; i < oursystem.StoppingNumber; i++)
            {
                dataGridView1.Rows.Add();
            }

            for (int i = 0; i < oursystem.StoppingNumber; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = oursystem.SimulationTable[i].CustomerNumber + 1;
                dataGridView1.Rows[i].Cells[1].Value = oursystem.SimulationTable[i].RandomInterArrival;
                dataGridView1.Rows[i].Cells[2].Value = oursystem.SimulationTable[i].InterArrival;
                dataGridView1.Rows[i].Cells[3].Value = oursystem.SimulationTable[i].ArrivalTime;
                dataGridView1.Rows[i].Cells[4].Value = oursystem.SimulationTable[i].RandomService;

                dataGridView1.Columns[0].Frozen = true;
                dataGridView1.Columns[1].Frozen = true;
                dataGridView1.Columns[2].Frozen = true;
                dataGridView1.Columns[3].Frozen = true;
                dataGridView1.Columns[4].Frozen = true;

                int indexOfLastColumn = 5 + (oursystem.NumberOfServers * 3);  // To know the index lf Time in Queue column As the table is dynamic

                string columnOftimeServiceBeginofServer = $"timeServiceBeginofServer{oursystem.SimulationTable[i].AssignedServer.ID}";
                if (dataGridView1.Columns.Contains(columnOftimeServiceBeginofServer))  // Accessing The column of the assigned server by name
                {
                    int columnIndex = dataGridView1.Columns[columnOftimeServiceBeginofServer].Index;
                    dataGridView1.Rows[i].Cells[columnIndex].Value = oursystem.SimulationTable[i].StartTime;
                }

                string columnOftimeServiceofServer = $"serviceTimeofServer{oursystem.SimulationTable[i].AssignedServer.ID}";
                if (dataGridView1.Columns.Contains(columnOftimeServiceofServer))
                {
                    int columnIndex = dataGridView1.Columns[columnOftimeServiceofServer].Index;
                    dataGridView1.Rows[i].Cells[columnIndex].Value = oursystem.SimulationTable[i].ServiceTime;
                }

                
                string columnOftimeServiceEndofServer = $"timeServiceEndofServer{oursystem.SimulationTable[i].AssignedServer.ID}";
                if (dataGridView1.Columns.Contains(columnOftimeServiceEndofServer))
                {
                    int columnIndex = dataGridView1.Columns[columnOftimeServiceEndofServer].Index;
                    dataGridView1.Rows[i].Cells[columnIndex].Value = oursystem.SimulationTable[i].EndTime;
                }

                dataGridView1.Rows[i].Cells[indexOfLastColumn].Value = oursystem.SimulationTable[i].TimeInQueue;

            }
        }
        

        private void CalculationsForm_Load(object sender, EventArgs e)
        {

            if (int.Parse(ExtraxtData.rawData.stoppingCriteria) == 1 && (ExtraxtData.rawData.selectionMethod.Equals("HighestPriority") || ExtraxtData.rawData.selectionMethod.Equals("Random")))
            {
                NoOfcustomersandpriority();
            }
            else if (int.Parse(ExtraxtData.rawData.stoppingCriteria) == 1 && ExtraxtData.rawData.selectionMethod.Equals("LeastUtilization"))
            {
                NoOfCustomersandleastutilization();
            }

            makeColumnsOfTable();

            FillRowsOfTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PerformanceMeasuresForm().Show();

        }
    }
}
