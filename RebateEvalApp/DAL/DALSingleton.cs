using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Written by Max Chen for CS6326.001, assignment 3, starting September 28, 2019.
    NetID: mmc170330
*/
namespace RebateEvalApp.DAL
{
    class DALSingleton
    {
        // Instance Variable
        private static DALSingleton instance;

        // Stores the path of the input file
        public String RebateRecordFilePath { get; set; }
        
        // Stores the path of the input file directory
        public String RebateRecordFileDirectory { get; set; }

        private DALSingleton()
        {

        }

        public static DALSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DALSingleton();
                }
                return instance;
            }
        }

        public ICollection<String> ReadRebateRecords_FromFile()
        {
            //First clear all whitespace
            var lines = File.ReadAllLines(RebateRecordFilePath).Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(RebateRecordFilePath, lines);

            //List variable that holds text from file
            List<String> recordsText = null;

            //Reads text from file
            try
            {
                recordsText = File.ReadAllLines(RebateRecordFilePath).ToList();
            }
            catch
            {
                File.Create(RebateRecordFilePath).Dispose();
            }

            return recordsText;
        }

        public void WriteRebateAnalysis_ToFile(List<String> rebateAnalysis)
        {
            //Sets the path and file name
            String dataFilePath = RebateRecordFileDirectory + "\\CS6326Asg3_Analysis.txt";

            //String builder to hold new text to write over existing file
            StringBuilder rebateAnalysisTxt = new StringBuilder();

            foreach (String item in rebateAnalysis)
            {
                rebateAnalysisTxt.Append(item + "\n");
            }
            
            System.IO.File.WriteAllText(dataFilePath, rebateAnalysisTxt.ToString());
        }

    }
}
