using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Written by Max Chen for CS6326.001, assignment 3, starting September 28, 2019.
    NetID: mmc170330
*/
namespace RebateEvalApp
{
    public partial class RebateEvalAppMainForm : Form
    {
        //List of analysis
        List<String> rebateAnalysis = new List<string>();

        public RebateEvalAppMainForm()
        {
            InitializeComponent();
        }

        private void RebateEvalAppMainForm_Load(object sender, EventArgs e)
        {
            //Change ListView Settings
            listViewRecordAnalysis.View = View.Details;
            listViewRecordAnalysis.GridLines = true;
            listViewRecordAnalysis.Columns.Add("Analysis:");
            listViewRecordAnalysis.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewRecordAnalysis.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        private void BtnFileBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog chooseFileDialog = new OpenFileDialog();
            chooseFileDialog.Filter = "All Files (*.*)|*.*";
            chooseFileDialog.FilterIndex = 1;
            //chooseFileDialog.Multiselect = false;

            if (chooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
                
                DAL.DALSingleton.Instance.RebateRecordFilePath = chooseFileDialog.FileName;
                DAL.DALSingleton.Instance.RebateRecordFileDirectory = Path.GetDirectoryName(chooseFileDialog.FileName);
            }

            //Sets the selected file name
            txtFilePath.Text = BLL.BLLSingleton.Instance.GetRebateRecordFilePath();

        }

        private void TxtFilePath_TextChanged(object sender, EventArgs e)
        {
            btnPerformAnalysis.Enabled = true;
        }

        private void BtnPerformAnalysis_Click(object sender, EventArgs e)
        {
            try
            {
                //Populates rebateAnalysis List
                rebateAnalysis = BLL.BLLSingleton.Instance.GetAnalysisList().ToList();
            }
            catch
            {
                MessageBox.Show("Incorrect Input File Format. Please select correct record information. ");
                //Refreshes the ListView
                RefreshListView();
                return;
            }

            //Writes analysis to text file
            DAL.DALSingleton.Instance.WriteRebateAnalysis_ToFile(rebateAnalysis);

            //Refreshes the ListView
            RefreshListView();
        }

        private void RefreshListView()
        {
            //Clears ListView
            listViewRecordAnalysis.Items.Clear();

            //Check if RebateInfo is null
            if (rebateAnalysis == null || !rebateAnalysis.Any())
            {
                listViewRecordAnalysis.Enabled = false;
                return;
            }
            else
            {
                listViewRecordAnalysis.Enabled = true;
            }

            //Populates Listview
            foreach (String item in rebateAnalysis)
            {
                ListViewItem itemLS = new ListViewItem();
                itemLS.Text = item;

                listViewRecordAnalysis.Items.Add(item);
            }


        }
    }
}
