using System;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.IO;

namespace ADA
{
    /// <summary>
    /// Helper for Running Macro from Excel
    /// </summary>
    public class ExcelMacroHelper
    {
        private static Excel.Workbooks oBooks;
        private static Excel.Workbook oBook;
        private static Excel.Application oExcel;

        /// <summary>
        /// Run marco from Excel
        /// </summary>
        /// <param name="excelFilePath">Excel file path</param>
        /// <param name="macroName">macro name</param>
        /// <param name="parameters">macro arguments list</param>
        /// <param name="isShowExcel">Flg for if show opened excel file</param>
        public static Dictionary<string, object> RunExcelMacro(
            string excelFilePath,
            string macroName,
            object[] parameters,
            bool isShowExcel
            )
        {
            Dictionary<string, object> rtnValue = new Dictionary<string, object>();
            rtnValue.Add("mode", "MS");
            try
            {
                #region Validation

                // Check if file exits
                excelFilePath = new FileInfo(excelFilePath).FullName;
                if (!File.Exists(excelFilePath))
                {
                    rtnValue.Add("error", new System.Exception(excelFilePath + " does not exit"));
                    return rtnValue;
                }

                // Check if macro name is valid
                if (string.IsNullOrEmpty(macroName))
                {
                    rtnValue.Add("error", new System.Exception("Please provide valid macro name"));
                    return rtnValue;
                }

                #endregion

                #region Macro Call

                // Prepare the arguments for opening excel
                object oMissing = System.Reflection.Missing.Value;

                // Prepare the arguments for calling macro
                object[] paraObjects;

                if (parameters == null)
                {
                    paraObjects = new object[] { macroName };
                }
                else
                {
                    // The length of macro parameters
                    int paraLength = parameters.Length;

                    paraObjects = new object[paraLength + 1];

                    paraObjects[0] = macroName;
                    for (int i = 0; i < paraLength; i++)
                    {
                        paraObjects[i + 1] = parameters[i];
                    }
                }

                // Create Excel object
                oExcel = new Excel.Application();

                // make opened file visible or not
                oExcel.Visible = isShowExcel;

                // Create Workbooks object
                oBooks = oExcel.Workbooks;

                // Create Workbook object
                oBook = null;

                // Open Excel file
                oBook = oBooks.Open(
                    excelFilePath,
                    oMissing,
                    oMissing,
                    oMissing,
                    oMissing,
                    oMissing,
                    oMissing,
                    oMissing,
                    oMissing,
                    oMissing,
                    oMissing,
                    oMissing,
                    oMissing,
                    oMissing,
                    oMissing
                    );

                // Run macor in the Excel file
                rtnValue.Add("result", RunMacro(oExcel, paraObjects));

                // Save change
                // oBook.Save();

                // Exit Workbook
                oBook.Close(false, oMissing, oMissing);

                #endregion

            }
            catch (Exception ex)
            {
                rtnValue.Add("error", ex);
                return rtnValue;
            }
            finally
            {
                #region Release Objects

                // Release Workbook object
                if (oBook != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
                    oBook = null;
                }

                // Release Workbooks object
                if (oBooks != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oBooks);
                    oBooks = null;
                }

                if (oExcel != null)
                {
                    // Close Excel
                    oExcel.Quit();

                    // Release Excel object
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
                    oExcel = null;
                }

                // Garbage collection
                GC.Collect();

                #endregion
            }

            return rtnValue;
        }

        /// <summary>
        /// Run Macro
        /// </summary>
        /// <param name="oApp">Excel Object</param>
        /// <param name="oRunArgs">Arguments（First is macro name，others are arguments for macro）</param>
        /// <returns>Macro return value</returns>
        private static object RunMacro(object oApp, object[] oRunArgs)
        {
            try
            {
                object objRtn;

                // Run macro by using reflection
                objRtn = oApp.GetType().InvokeMember(
                    "Run",
                    System.Reflection.BindingFlags.Default |
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    oApp,
                    oRunArgs
                    );
                return objRtn;

            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.ToString().Length > 0)
                {
                    throw ex.InnerException;
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}