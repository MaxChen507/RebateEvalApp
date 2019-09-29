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
            List<String> rebateAnalysis = null;
            
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
            String numRec = "Number of records: " + rebateInfo.Count.ToString();


            //Perform entry time analyis
            List<String> entryTimeAnalysisList = GetEntryTimeAnalysis(analysisInfos).ToList();

            //Minimum entry time: 1:12
            String minEntryTime = "Minimum entry time: ";

            //Maximum entry time: 2:06
            String maxEntryTime = "Maximum entry time: ";

            //Average entry time: 1:37
            String aveEntryTime = "Average entry time: ";



            //Minimum inter-record time: 0:03
            String minInterRecTime = "Minimum inter-record time: ";

            //Maximum inter-record time: 0:9
            String maxInterRecTime = "Maximum inter-record time: ";

            //Average inter-record time: 0:05
            String aveInterRecTime = "Average inter-record time: ";

            //Total time: 16:12
            String totalTime = "Total time: ";

            //Backspace count: 14
            String backspaceCount = "Backspace count: ";




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

            //Calculate entry time info
            TimeSpan minTimeSpan = entryTimeSpanList.First();
            TimeSpan maxTimeSpan = entryTimeSpanList.First();
            TimeSpan totalTimeSpan = TimeSpan.Zero;
            int count = 0;
            foreach (TimeSpan item in entryTimeSpanList)
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

            aveTimeSpan = TimeSpan.FromSeconds((int)(aveTimeSpan.TotalSeconds));

            entryTimeAnalysisList.Add(minTimeSpan.ToString());
            entryTimeAnalysisList.Add(maxTimeSpan.ToString());
            entryTimeAnalysisList.Add(aveTimeSpan.ToString());

            return entryTimeAnalysisList;
        }
        

    }
}
