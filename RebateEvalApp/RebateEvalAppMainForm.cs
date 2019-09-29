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
        public RebateEvalAppMainForm()
        {
            InitializeComponent();
        }

        private void RebateEvalAppMainForm_Load(object sender, EventArgs e)
        {

            
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
            BLL.BLLSingleton.Instance.GetAnalysisList();
        }
    }
}
