namespace RebateEvalApp
{
    partial class RebateEvalAppMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewRecordAnalysis = new System.Windows.Forms.ListView();
            this.btnFileBrowse = new System.Windows.Forms.Button();
            this.btnPerformAnalysis = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewRecordAnalysis
            // 
            this.listViewRecordAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewRecordAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewRecordAnalysis.HideSelection = false;
            this.listViewRecordAnalysis.Location = new System.Drawing.Point(12, 12);
            this.listViewRecordAnalysis.Name = "listViewRecordAnalysis";
            this.listViewRecordAnalysis.Size = new System.Drawing.Size(332, 280);
            this.listViewRecordAnalysis.TabIndex = 0;
            this.listViewRecordAnalysis.UseCompatibleStateImageBehavior = false;
            // 
            // btnFileBrowse
            // 
            this.btnFileBrowse.Location = new System.Drawing.Point(12, 352);
            this.btnFileBrowse.Name = "btnFileBrowse";
            this.btnFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnFileBrowse.TabIndex = 3;
            this.btnFileBrowse.Text = "Browse";
            this.btnFileBrowse.UseVisualStyleBackColor = true;
            this.btnFileBrowse.Click += new System.EventHandler(this.BtnFileBrowse_Click);
            // 
            // btnPerformAnalysis
            // 
            this.btnPerformAnalysis.Enabled = false;
            this.btnPerformAnalysis.Location = new System.Drawing.Point(128, 402);
            this.btnPerformAnalysis.Name = "btnPerformAnalysis";
            this.btnPerformAnalysis.Size = new System.Drawing.Size(101, 48);
            this.btnPerformAnalysis.TabIndex = 4;
            this.btnPerformAnalysis.Text = "Perform Analysis";
            this.btnPerformAnalysis.UseVisualStyleBackColor = true;
            this.btnPerformAnalysis.Click += new System.EventHandler(this.BtnPerformAnalysis_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(12, 326);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(332, 20);
            this.txtFilePath.TabIndex = 2;
            this.txtFilePath.TextChanged += new System.EventHandler(this.TxtFilePath_TextChanged);
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(12, 310);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(51, 13);
            this.labelFilePath.TabIndex = 1;
            this.labelFilePath.Text = "File Path:";
            // 
            // RebateEvalAppMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 462);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnPerformAnalysis);
            this.Controls.Add(this.btnFileBrowse);
            this.Controls.Add(this.listViewRecordAnalysis);
            this.Name = "RebateEvalAppMainForm";
            this.Text = "Rebate Eval Main Form";
            this.Load += new System.EventHandler(this.RebateEvalAppMainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewRecordAnalysis;
        private System.Windows.Forms.Button btnFileBrowse;
        private System.Windows.Forms.Button btnPerformAnalysis;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label labelFilePath;
    }
}

