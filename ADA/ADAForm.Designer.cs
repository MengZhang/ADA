namespace ADA
{
    partial class ADAForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADAForm));
            this.csvPage = new System.Windows.Forms.TabPage();
            this.modeCB = new System.Windows.Forms.CheckBox();
            this.xlsWarnLB = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusLB = new System.Windows.Forms.Label();
            this.satusLB = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.csvGenBtn = new System.Windows.Forms.Button();
            this.outputBrowse = new System.Windows.Forms.Button();
            this.inputBrowse = new System.Windows.Forms.Button();
            this.outputTB = new System.Windows.Forms.TextBox();
            this.inputTB = new System.Windows.Forms.TextBox();
            this.sameDirCB = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.helpPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialogIn = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogOut = new System.Windows.Forms.FolderBrowserDialog();
            this.csvPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.helpPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // csvPage
            // 
            this.csvPage.Controls.Add(this.modeCB);
            this.csvPage.Controls.Add(this.xlsWarnLB);
            this.csvPage.Controls.Add(this.label5);
            this.csvPage.Controls.Add(this.label4);
            this.csvPage.Controls.Add(this.statusLB);
            this.csvPage.Controls.Add(this.satusLB);
            this.csvPage.Controls.Add(this.label3);
            this.csvPage.Controls.Add(this.csvGenBtn);
            this.csvPage.Controls.Add(this.outputBrowse);
            this.csvPage.Controls.Add(this.inputBrowse);
            this.csvPage.Controls.Add(this.outputTB);
            this.csvPage.Controls.Add(this.inputTB);
            this.csvPage.Controls.Add(this.sameDirCB);
            this.csvPage.Location = new System.Drawing.Point(4, 26);
            this.csvPage.Name = "csvPage";
            this.csvPage.Padding = new System.Windows.Forms.Padding(3);
            this.csvPage.Size = new System.Drawing.Size(472, 330);
            this.csvPage.TabIndex = 0;
            this.csvPage.Text = "CSV Creator";
            this.csvPage.UseVisualStyleBackColor = true;
            // 
            // modeCB
            // 
            this.modeCB.AutoSize = true;
            this.modeCB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeCB.Location = new System.Drawing.Point(205, 196);
            this.modeCB.Name = "modeCB";
            this.modeCB.Size = new System.Drawing.Size(160, 21);
            this.modeCB.TabIndex = 12;
            this.modeCB.Text = "Run with safe mode";
            this.modeCB.UseVisualStyleBackColor = true;
            this.modeCB.CheckedChanged += new System.EventHandler(this.modeCB_CheckedChanged);
            // 
            // xlsWarnLB
            // 
            this.xlsWarnLB.AutoSize = true;
            this.xlsWarnLB.ForeColor = System.Drawing.Color.Red;
            this.xlsWarnLB.Location = new System.Drawing.Point(202, 230);
            this.xlsWarnLB.Name = "xlsWarnLB";
            this.xlsWarnLB.Size = new System.Drawing.Size(0, 17);
            this.xlsWarnLB.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Output Direcoty";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Original Data File";
            // 
            // statusLB
            // 
            this.statusLB.AutoSize = true;
            this.statusLB.Location = new System.Drawing.Point(95, 261);
            this.statusLB.Name = "statusLB";
            this.statusLB.Size = new System.Drawing.Size(12, 17);
            this.statusLB.TabIndex = 8;
            this.statusLB.Text = " ";
            // 
            // satusLB
            // 
            this.satusLB.AutoSize = true;
            this.satusLB.Location = new System.Drawing.Point(85, 261);
            this.satusLB.Name = "satusLB";
            this.satusLB.Size = new System.Drawing.Size(0, 17);
            this.satusLB.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Status: ";
            // 
            // csvGenBtn
            // 
            this.csvGenBtn.AutoSize = true;
            this.csvGenBtn.Location = new System.Drawing.Point(21, 196);
            this.csvGenBtn.Name = "csvGenBtn";
            this.csvGenBtn.Size = new System.Drawing.Size(142, 28);
            this.csvGenBtn.TabIndex = 5;
            this.csvGenBtn.Text = "Generate CSVs";
            this.csvGenBtn.UseVisualStyleBackColor = true;
            this.csvGenBtn.Click += new System.EventHandler(this.csvGenBtn_Click);
            // 
            // outputBrowse
            // 
            this.outputBrowse.AutoSize = true;
            this.outputBrowse.Enabled = false;
            this.outputBrowse.Location = new System.Drawing.Point(355, 114);
            this.outputBrowse.Name = "outputBrowse";
            this.outputBrowse.Size = new System.Drawing.Size(92, 27);
            this.outputBrowse.TabIndex = 4;
            this.outputBrowse.Text = "Browse";
            this.outputBrowse.UseVisualStyleBackColor = true;
            this.outputBrowse.Click += new System.EventHandler(this.outputBrowse_Click);
            // 
            // inputBrowse
            // 
            this.inputBrowse.AutoSize = true;
            this.inputBrowse.Location = new System.Drawing.Point(355, 45);
            this.inputBrowse.Name = "inputBrowse";
            this.inputBrowse.Size = new System.Drawing.Size(92, 27);
            this.inputBrowse.TabIndex = 3;
            this.inputBrowse.Text = "Browse";
            this.inputBrowse.UseVisualStyleBackColor = true;
            this.inputBrowse.Click += new System.EventHandler(this.inputBrowse_Click);
            // 
            // outputTB
            // 
            this.outputTB.Location = new System.Drawing.Point(21, 114);
            this.outputTB.Name = "outputTB";
            this.outputTB.ReadOnly = true;
            this.outputTB.Size = new System.Drawing.Size(316, 25);
            this.outputTB.TabIndex = 2;
            // 
            // inputTB
            // 
            this.inputTB.Location = new System.Drawing.Point(21, 46);
            this.inputTB.Name = "inputTB";
            this.inputTB.ReadOnly = true;
            this.inputTB.Size = new System.Drawing.Size(316, 25);
            this.inputTB.TabIndex = 1;
            // 
            // sameDirCB
            // 
            this.sameDirCB.AutoSize = true;
            this.sameDirCB.Checked = true;
            this.sameDirCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sameDirCB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sameDirCB.Location = new System.Drawing.Point(21, 145);
            this.sameDirCB.Name = "sameDirCB";
            this.sameDirCB.Size = new System.Drawing.Size(210, 21);
            this.sameDirCB.TabIndex = 0;
            this.sameDirCB.Text = "Save directory with input file";
            this.sameDirCB.UseVisualStyleBackColor = true;
            this.sameDirCB.CheckedChanged += new System.EventHandler(this.sameDirCB_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.csvPage);
            this.tabControl1.Controls.Add(this.helpPage);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(480, 360);
            this.tabControl1.TabIndex = 0;
            // 
            // helpPage
            // 
            this.helpPage.Controls.Add(this.label6);
            this.helpPage.Controls.Add(this.label2);
            this.helpPage.Controls.Add(this.label1);
            this.helpPage.Location = new System.Drawing.Point(4, 26);
            this.helpPage.Name = "helpPage";
            this.helpPage.Padding = new System.Windows.Forms.Padding(3);
            this.helpPage.Size = new System.Drawing.Size(472, 330);
            this.helpPage.TabIndex = 1;
            this.helpPage.Text = "Help";
            this.helpPage.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Version 0.3.6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(435, 168);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "All rights reserved by AgMIP IT team.";
            // 
            // openFileDialogIn
            // 
            this.openFileDialogIn.Filter = "excel files|*.xlsx; *.xls; *.xlsm; *.xlsb";
            this.openFileDialogIn.Title = "Open Data File";
            this.openFileDialogIn.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogIn_FileOk);
            // 
            // ADAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(506, 373);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ADAForm";
            this.Text = "AgMIP Data Assistant 0.3.6";
            this.csvPage.ResumeLayout(false);
            this.csvPage.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.helpPage.ResumeLayout(false);
            this.helpPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage csvPage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage helpPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputTB;
        private System.Windows.Forms.TextBox inputTB;
        private System.Windows.Forms.CheckBox sameDirCB;
        private System.Windows.Forms.Button inputBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialogIn;
        private System.Windows.Forms.Button outputBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogOut;
        private System.Windows.Forms.Button csvGenBtn;
        private System.Windows.Forms.Label satusLB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label statusLB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label xlsWarnLB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox modeCB;
    }
}

