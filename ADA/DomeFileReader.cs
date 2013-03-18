using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using System.Threading;

namespace ADA
{
    class DomeFileReader
    {
        private ExcelPackage pck;
        private string outputDir;

        public DomeFileReader(string excelName, string output)
        {
            if (!output.Equals("") && !output.EndsWith(new string(System.IO.Path.DirectorySeparatorChar, 1)))
            {
                output += System.IO.Path.DirectorySeparatorChar;
            }
            pck = new ExcelPackage(new FileInfo(excelName));
            outputDir = output;
        }

        public Dictionary<string, object> ToCsvFiles()
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();
            ret.Add("mode", "EPPLUS");
            try
            {
                IEnumerator<ExcelWorksheet> e = pck.Workbook.Worksheets.GetEnumerator();
                List<string> csvFiles = new List<string>();
                while (e.MoveNext())
                {
                    ExcelWorksheet sheet = e.Current;
                    int lastRow = sheet.Dimension.End.Row;
                    int lastCol = sheet.Dimension.End.Column;
                    string fileName = outputDir + sheet.Name + ".csv";
                    StreamWriter csv = new StreamWriter(new FileStream(fileName, FileMode.Create));
                    for (int i = 1; i <= lastRow; i++)
                    {

                        if (!getValue(sheet, i, 1).TrimStart().StartsWith("!"))
                        {
                            sheet.Select(i + ":" + i);
                            int cnt = sheet.SelectedRange.Count((cell) => { return cell.Value != null; });
                            if (cnt == 0)
                            {
                                continue;
                            }

                            StringBuilder sb = new StringBuilder();
                            //sb.Append(cnt + ",");
                            for (int j = 1; j < lastCol; j++)
                            {
                                sb.Append(toCsvText(getValue(sheet, i, j), ","));
                            }
                            sb.Append(toCsvText(getValue(sheet, i, lastCol), ""));
                            csv.WriteLine(sb);
                        }
                    }
                    csvFiles.Add(fileName);
                    csv.Flush();
                    csv.Close();
                    csv.Dispose();
                }

                ret.Add("result", csvFiles.ToArray());
                return ret;
            }
            catch (Exception ex)
            {
                ret.Add("error", ex);
                return ret;
            }
        }

        public static string toCsvText(string text, string sep)
        {
            if (text.Contains(","))
            {
                text = "\"" + text + "\"";
            }
            return text + sep;
        }

        public static string getValue(ExcelWorksheet sheet, int row, int col)
        {
            object value = sheet.Cells[row, col].Value;
            string text = sheet.Cells[row, col].Text;
            if (value == null)
            {
                return text;
            }
            else
            {
                if (text.Equals(""))
                {
                    return value.ToString();
                }
                else if (text.StartsWith(".") || text.StartsWith("-."))
                {
                    return value.ToString();
                }
                else
                {
                    return text;
                }
            }
        }
    }
}
