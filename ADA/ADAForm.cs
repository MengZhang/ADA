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
            openFileDialogIn.ShowDialog();
            if (inputTB.Text.ToLower().EndsWith(".xlsx"))
            {
                xlsWarnLB.Text = "";
            }
            else
            {
                xlsWarnLB.Text = "If you do not install Microsoft Excel 2007,\n please save the input file as *.xlsx file.";

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

            SetStatus("Start generating CSV...");
            ActiveBtn(false);
            string inPath = inputTB.Text;
            string outPath = outputTB.Text + System.IO.Path.DirectorySeparatorChar;

            if (inPath.ToLower().EndsWith(".xlsx"))
            {
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
            else
            {
                string excelName = "CSV_Generator 0.2.1.xlsm";
                string macroName = "generate";
                bool isShowExcel = false;
                object[] args = new object[] { inPath, outPath };
                ToCsvByMacro runner = new ToCsvByMacro(ExcelMacroHelper.RunExcelMacro);
                runner.BeginInvoke(
                    excelName, macroName, args, isShowExcel,
                    new AsyncCallback(
                        delegate(IAsyncResult result)
                        {
                            //object ret = runner.EndInvoke(result);
                            //if (ret == null)
                            //{
                            //    ToZip(new string[0]);
                            //}
                            //else
                            //{
                            //    ToZip((string[])ret);
                            //}
                            ToZip(runner.EndInvoke(result));
                        }
                    ),
                    null);
            }
        }

        private void ToZip(Dictionary<string, object> ret)
        {
            if (ret.ContainsKey("error"))
            {
                SetStatus("Fail to load model to generate CSV");
                MessageBox.Show(((Exception)ret["error"]).Message);
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
    }
}
