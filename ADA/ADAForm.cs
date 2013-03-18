using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ADA
{
    public partial class ADAForm : Form
    {
        delegate Dictionary<string, object> ToCsv();
        delegate Dictionary<string, object> ToCsvByMacro(
            string excelFilePath,
            string macroName,
            object[] parameters,
            bool isShowExcel);
        delegate void SetTextCallback(string text);
        delegate void ActiveBtnCallback(bool active);

        public ADAForm()
        {
            InitializeComponent();
        }

        private void openFileDialogIn_FileOk(object sender, CancelEventArgs e)
        {
            inputTB.Text = openFileDialogIn.FileName;
            if (sameDirCB.Checked)
            {
                setOutputTB();
            }
        }

        private void inputBrowse_Click(object sender, EventArgs e)
        {
            if (modeCB.Checked)
            {
                openFileDialogIn.Filter = "excel files|*.xlsx";
            }
            else
            {
                openFileDialogIn.Filter = "excel files|*.xlsx; *.xls; *.xlsm; *.xlsb";
            }
            openFileDialogIn.ShowDialog();
            if (modeCB.Checked && !inputTB.Text.ToLower().EndsWith(".xlsx"))
            {
                ActiveBtn(false);
            }
            else
            {
                ActiveBtn(true);
            }
        }

        private void outputBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogOut.ShowDialog().Equals(DialogResult.OK))
            {
                outputTB.Text = folderBrowserDialogOut.SelectedPath;
            }
        }

        private void sameDirCB_CheckedChanged(object sender, EventArgs e)
        {
            outputBrowse.Enabled = !sameDirCB.Checked;
            setOutputTB();
        }

        private void setOutputTB()
        {
            FileInfo fi = new FileInfo(openFileDialogIn.FileName);
            outputTB.Text = fi.DirectoryName;
        }

        private void csvGenBtn_Click(object sender, EventArgs e)
        {
            if (inputTB.Text.Equals(""))
            {
                MessageBox.Show("Please select a data file for input source");
                return;
            }
            else if (!File.Exists(inputTB.Text))
            {
                MessageBox.Show(inputTB.Text + " does not exist");
                return;
            }
            if (outputTB.Text.Equals(""))
            {
                MessageBox.Show("Please select a directory for output file");
                return;
            }
            ActiveBtn(false);

            if (modeCB.Checked)
            {
                ToCSVByEPPlus();
            }
            else
            {
                ToCSVByMS(); 
            }
        }

        private void ToCSVByMS()
        {
            SetStatus("Start generating CSV with MS Engine...");
            string inPath = inputTB.Text;
            string outPath = outputTB.Text + System.IO.Path.DirectorySeparatorChar;
            DomeFileReader reader = new DomeFileReader(inPath, outPath);
            ToCsv runner = new ToCsv(reader.ToCsvFiles);
            runner.BeginInvoke(
                new AsyncCallback(
                    delegate(IAsyncResult result)
                    {
                        ToZip(runner.EndInvoke(result));
                    }
                ),
                null);
        }

        private void ToCSVByEPPlus()
        {
            SetStatus("Start generating CSV with EPPlus Engine...");
            string inPath = inputTB.Text;
            string outPath = outputTB.Text + System.IO.Path.DirectorySeparatorChar;
            string excelName = "CSV_Generator.xlsm";
            string macroName = "generate";
            bool isShowExcel = false;
            object[] args = new object[] { inPath, outPath };
            ToCsvByMacro runner = new ToCsvByMacro(ExcelMacroHelper.RunExcelMacro);
            runner.BeginInvoke(
                excelName, macroName, args, isShowExcel,
                new AsyncCallback(
                    delegate(IAsyncResult result)
                    {
                        ToZip(runner.EndInvoke(result));
                    }
                ),
                null);
        }

        private void ToZip(Dictionary<string, object> ret)
        {
            if (ret.ContainsKey("error"))
            {
                if ("EPPLUS".Equals(ret["mode"]))
                {
                    SetStatus("Fail to load model to generate CSV");
                    MessageBox.Show(((Exception)ret["error"]).Message);
                }
                else
                {
                    ToCSVByEPPlus();
                }
            }
            else if (ret.ContainsKey("result"))
            {
                string[] files = (string[])ret["result"];
                if (files == null)
                {
                    files = new string[0];
                }
                SetStatus("start compress to zip...");
                //try
                //{

                if (files.Length > 0)
                {
                    string outPath = outputTB.Text + System.IO.Path.DirectorySeparatorChar;
                    string zipName = new FileInfo(inputTB.Text).Name;
                    zipName = zipName.Substring(0, zipName.LastIndexOf(".")) + ".zip";
                    ZipHelper.BuildZip(files, outPath + zipName, true);
                    SetStatus("Job done");
                }
                else
                {
                    SetStatus("No file has been generated");
                }
            }
            else
            {
                SetStatus("No has been generated");
            }
            ActiveBtn(true);
        }

        private void SetStatus(string status)
        {
            if (this.statusLB.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatus);
                this.Invoke(d, new object[] { status });
            }
            else
            {
                this.statusLB.Text = status;
            }

        }

        private void ActiveBtn(bool active)
        {
            if (this.csvGenBtn.InvokeRequired)
            {
                ActiveBtnCallback d = new ActiveBtnCallback(ActiveBtn);
                this.Invoke(d, new object[] { active });
            }
            else
            {
                this.csvGenBtn.Enabled = active;
            }
        }

        private void modeCB_CheckedChanged(object sender, EventArgs e)
        {
            if (modeCB.Checked)
            {
                xlsWarnLB.Text = "Safe mode only supports *.xlsx file.";
                if (!inputTB.Text.ToLower().EndsWith(".xlsx")) {
                    ActiveBtn(false);
                }
            }
            else
            {
                xlsWarnLB.Text = "";
                ActiveBtn(true);
            }
        }
    }
}
