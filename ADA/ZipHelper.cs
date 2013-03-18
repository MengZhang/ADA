using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Core;

namespace ADA
{
    class ZipHelper
    {
        public static void BuildZip(string[] files, string outDir, bool delFlg)
        {
            ZipOutputStream zipStream = new ZipOutputStream(File.Create(outDir));
            zipStream.SetLevel(6);  // 0-9
            for (int i = 0; i < files.Length; i++)
            {
                if (File.Exists(files[i]))
                {
                    CreateZipFiles(files[i], zipStream, outDir, delFlg);
                }
            }

            zipStream.Finish();
            zipStream.Close();
        }

        public static void BuildZip(string inDir, string outDir, bool delFlg)
        {
            if (inDir[inDir.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                inDir += System.IO.Path.DirectorySeparatorChar;

            ZipOutputStream zipStream = new ZipOutputStream(File.Create(outDir));
            zipStream.SetLevel(6);  // 0-9
            CreateZipFiles(inDir, zipStream, inDir, delFlg);

            zipStream.Finish();
            zipStream.Close();
        }

        public static void BuildZip(string dir, bool delFlg)
        {
            BuildZip(dir, dir, delFlg);
        }

        private static void CreateZipFiles(string sourceFilePath, ZipOutputStream zipStream, string staticFile, bool delFlg)
        {
            Crc32 crc = new Crc32();
            string[] filesArray;
            if (Directory.Exists(sourceFilePath))
            {
                filesArray = Directory.GetFileSystemEntries(sourceFilePath);

            }
            else
            {
                filesArray = new string[] { sourceFilePath };
            }

            foreach (string file in filesArray)
            {
                if (Directory.Exists(file))
                {
                    CreateZipFiles(file, zipStream, staticFile, delFlg);
                }
                else
                {
                    FileStream fileStream = File.OpenRead(file);

                    byte[] buffer = new byte[fileStream.Length];
                    fileStream.Read(buffer, 0, buffer.Length);
                    string tempFile = file.Substring(staticFile.LastIndexOf("\\") + 1);
                    ZipEntry entry = new ZipEntry(tempFile);

                    entry.DateTime = DateTime.Now;
                    entry.Size = fileStream.Length;
                    fileStream.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    zipStream.PutNextEntry(entry);
                    zipStream.Write(buffer, 0, buffer.Length);
                    if (delFlg) File.Delete(file);
                }
            }
        }
    }
}
