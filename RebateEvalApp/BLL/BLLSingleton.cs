using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Written by Max Chen for CS6326.001, assignment 3, starting September 28, 2019.
    NetID: mmc170330
*/
namespace RebateEvalApp.BLL
{
    class BLLSingleton
    {
        // Instance Variable
        private static BLLSingleton instance;


        private BLLSingleton()
        {

        }

        public static BLLSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BLLSingleton();
                }
                return instance;
            }
        }

        public String GetRebateRecordFilePath()
        {
            return DAL.DALSingleton.Instance.RebateRecordFilePath;
        }

        public String GetRebateRecordFileDirectory()
        {
            return DAL.DALSingleton.Instance.RebateRecordFilePath;
        }

        public ICollection<String> GetAnalysisList()
        {
            //List of analysis
            List<String> rebateAnalysis = new List<string>();
            
            //First get file information
            List<String> rebateInfo = DAL.DALSingleton.Instance.ReadRebateRecords_FromFile().ToList();

            //List to hold rebateInfos
            List<Domain.AnalysisInfo> analysisInfos = new List<Domain.AnalysisInfo>();

            foreach (String item in rebateInfo)
            {
                //Parse text to Analyis Info
                String[] text = item.Split('\t');
                Domain.AnalysisInfo analysisInfoTemp = new Domain.AnalysisInfo();
                analysisInfoTemp.StartTime = Convert.ToDateTime(text[13]);
                analysisInfoTemp.EndTime = Convert.ToDateTime(text[14]);
                analysisInfoTemp.Backspaces = Int32.Parse(text[15]);
                analysisInfos.Add(analysisInfoTemp);
            }



            //Number of records: 10
            String numRec = "Number of records: " + analysisInfos.Count.ToString();


            //Perform entry time analyis
            List<String> entryTimeAnalysisList = GetEntryTimeAnalysis(analysisInfos).ToList();

            //Minimum entry time: 1:12
            String minEntryTime = "Minimum entry time: " + entryTimeAnalysisList.ElementAt(0);

            //Maximum entry time: 2:06
            String maxEntryTime = "Maximum entry time: " + entryTimeAnalysisList.ElementAt(1);

            //Average entry time: 1:37
            String aveEntryTime = "Average entry time: " + entryTimeAnalysisList.ElementAt(2);


            //Perform inter-record time analysis
            List<String> interRecordTimeAnalysisList = GetInterRecordTimeAnalysis(analysisInfos).ToList();

            //Minimum inter-record time: 0:03
            String minInterRecTime = "Minimum inter-record time: " + interRecordTimeAnalysisList.ElementAt(0);

            //Maximum inter-record time: 0:9
            String maxInterRecTime = "Maximum inter-record time: " + interRecordTimeAnalysisList.ElementAt(1);

            //Average inter-record time: 0:05
            String aveInterRecTime = "Average inter-record time: " + interRecordTimeAnalysisList.ElementAt(2);


            //Total time: 16:12
            TimeSpan totalTimeSpan = analysisInfos.Last().EndTime - analysisInfos.First().StartTime;
            String totalTime = "Total time: " + totalTimeSpan.ToString();


            //Backspace count: 14
            int totalBackSpace = 0;
            foreach (Domain.AnalysisInfo item in analysisInfos)
            {
                totalBackSpace += item.Backspaces;
            }
            String backspaceCount = "Backspace count: " + totalBackSpace.ToString();

            //Add all correct string analysis to rebateAnalysis list
            rebateAnalysis.Add(numRec);
            rebateAnalysis.Add(minEntryTime);
            rebateAnalysis.Add(maxEntryTime);
            rebateAnalysis.Add(aveEntryTime);
            rebateAnalysis.Add(minInterRecTime);
            rebateAnalysis.Add(maxInterRecTime);
            rebateAnalysis.Add(aveInterRecTime);
            rebateAnalysis.Add(totalTime);
            rebateAnalysis.Add(backspaceCount);
            
            return rebateAnalysis;
        }

        private ICollection<String> GetEntryTimeAnalysis(List<Domain.AnalysisInfo> analysisInfos)
        {
            List<String> entryTimeAnalysisList = new List<string>();


            List<TimeSpan> entryTimeSpanList = new List<TimeSpan>();
            foreach (Domain.AnalysisInfo item in analysisInfos)
            {
                TimeSpan timeSpanTemp = (item.EndTime - item.StartTime);
                entryTimeSpanList.Add(timeSpanTemp);
            }

            return GetCalcTimeSpanList(entryTimeSpanList);
        }
        
        private ICollection<String> GetInterRecordTimeAnalysis(List<Domain.AnalysisInfo> analysisInfos)
        {
            List<String> interRecordTimeAnalysisList = new List<string>();

            List<TimeSpan> interRecordTimeSpanList = new List<TimeSpan>();

            int count = 0;
            DateTime lastRecordsEndTime = analysisInfos.First().EndTime;
            foreach (Domain.AnalysisInfo item in analysisInfos)
            {
                if(count == 0)
                {
                    
                }
                else
                {
                    TimeSpan timeSpanTemp = (item.StartTime - lastRecordsEndTime);
                    interRecordTimeSpanList.Add(timeSpanTemp);
                    lastRecordsEndTime = item.EndTime;
                }
                count++;
            }

            return GetCalcTimeSpanList(interRecordTimeSpanList);
        }

        private List<String> GetCalcTimeSpanList(List<TimeSpan> timeSpanList)
        {
            List<String> timeSpanListInfo = new List<string>();

            //Calculate entry time info
            TimeSpan minTimeSpan = timeSpanList.First();
            TimeSpan maxTimeSpan = timeSpanList.First();
            TimeSpan totalTimeSpan = TimeSpan.Zero;
            int count = 0;
            foreach (TimeSpan item in timeSpanList)
            {
                if (TimeSpan.Compare(minTimeSpan, item) == 1)
                {
                    //"t1 is greater than t2"
                    minTimeSpan = item;
                }

                if (TimeSpan.Compare(item, maxTimeSpan) == 1)
                {
                    //"t1 is greater than t2"
                    maxTimeSpan = item;
                }

                totalTimeSpan += item;
                count++;
            }

            TimeSpan aveTimeSpan = new TimeSpan(totalTimeSpan.Ticks / count);

            aveTimeSpan = TimeSpan.FromSeconds((long)Math.Round(aveTimeSpan.TotalSeconds));

            timeSpanListInfo.Add(minTimeSpan.ToString());
            timeSpanListInfo.Add(maxTimeSpan.ToString());
            timeSpanListInfo.Add(aveTimeSpan.ToString());

            return timeSpanListInfo;
        }

    }
}
