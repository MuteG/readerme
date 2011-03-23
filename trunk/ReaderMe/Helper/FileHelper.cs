using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GP.Tools.ReaderMe.Helper
{
    class FileHelper
    {
        public enum LogType
        {
            LTDetail = 0,
            LTProcStart = 1,
            LTProcStop = 2,
            LTError = 3,
            LTDB = 4
        }

        private static ProgressBar pb = null;  //進度条
        public static bool bAbort = false;     //动作停止
        private FileHelper() { }

        #region 全文件夹拷贝
        /// <summary>
        /// 全文件夹拷贝（不包括根目录）
        /// </summary>
        /// <param name="source">源文件夹</param>
        /// <param name="torget">目标文件夹</param>
        public static void DirCopy(string source, string torget)
        {
            try
            {
                string dirName, fileName;
                string torFullPath = Path.GetFullPath(torget);
                string[] fileList = Directory.GetFiles(source, "*.*", SearchOption.TopDirectoryOnly);
                string[] dirList = Directory.GetDirectories(source);
                for (int i = 0; i < fileList.Length; i++)
                {
                    if (bAbort) { break; }
                    fileName = Path.Combine(torFullPath, Path.GetFileName(fileList[i]));
                    File.Copy(fileList[i], fileName, true);
                    if (pb != null)
                    {
                        pb.Value++;
                        Application.DoEvents();
                    }
                }
                for (int i = 0; i < dirList.Length; i++)
                {
                    if (bAbort) { break; }
                    dirName = Path.Combine(torFullPath, Path.GetFileName(dirList[i]));
                    if (!Directory.Exists(dirName))
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    DirCopy(dirList[i], dirName);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 全文件夹拷贝
        /// </summary>
        /// <param name="source">源文件夹</param>
        /// <param name="torget">目标文件夹</param>
        /// <param name="copyBaseDir">是否包含根目录</param>
        public static void DirCopy(string source, string torget, bool copyBaseDir)
        {
            try
            {
                if (copyBaseDir)
                {
                    string newTorget = Path.Combine(torget, Path.GetFileName(source));
                    if (!Directory.Exists(newTorget))
                    {
                        Directory.CreateDirectory(newTorget);
                    }
                    DirCopy(source, newTorget);
                }
                else
                {
                    DirCopy(source, torget);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 全文件夹拷贝(進度条)
        /// </summary>
        /// <param name="source">源文件夹</param>
        /// <param name="torget">目标文件夹</param>
        /// <param name="copyBaseDir">是否拷贝根目录</param>
        /// <param name="ProGress">进度条条</param>
        public static void DirCopy(string sSource, string sTorget, bool bCopyBaseDir, ProgressBar ProGress)
        {
            try
            {
                pb = null;
                if (ProGress != null)
                {
                    pb = ProGress;
                    pb.Maximum = Directory.GetFiles(sSource, "*.*", SearchOption.AllDirectories).Length;
                    pb.Value = 0;
                }
                DirCopy(sSource, sTorget, bCopyBaseDir);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        public static void MoveDirectoryFiles(string sourceDirectory, string targetDirectory, string ext)
        {
            if (Directory.Exists(sourceDirectory))
            {
                if (Directory.Exists(targetDirectory))
                {
                    string _ext = string.Empty;
                    if (null == ext)
                    {
                        _ext = null;
                    }
                    else if (ext.Substring(0, 2).Equals("*."))
                    {
                        _ext = ext;
                    }
                    else if (ext.Substring(0, 1).Equals("."))
                    {
                        _ext = "*" + ext;
                    }
                    else
                    {
                        _ext = "*." + ext;
                    }
                    string[] files;
                    if (null == _ext)
                    {
                        files = Directory.GetFiles(sourceDirectory);
                    }
                    else
                    {
                        files = Directory.GetFiles(sourceDirectory, _ext);
                    }
                    for (int i = 0; i < files.Length; i++)
                    {
                        MoveFileCompel(files[i], Path.Combine(targetDirectory, Path.GetFileName(files[i])));
                    }
                }
                else
                {
                    throw new Exception("目标文件夹不存在");
                }
            }
            else
            {
                throw new Exception("源文件夹不存在");
            }
        }

        /// <summary>
        /// 将指定信息写到文件的末尾
        /// </summary>
        /// <param name="fileName">文件名（完整路径）</param>
        /// <param name="msg">需要写入的信息</param>
        public static void WriteToFile(string fileName, string msg)
        {
            StreamWriter swWriter = new StreamWriter(fileName, true, System.Text.Encoding.Default);
            swWriter.WriteLine(msg);
            swWriter.Close();
        }

        /// <summary>
        /// 从文本文件中读取数据，并包装成DataTable
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileName">文件名</param>
        /// <param name="split">字段间的分隔符</param>
        public static DataTable ReadFileToDataTable(string fileName, string split)
        {
            DataTable result = new DataTable();
            string[] txtLines = File.ReadAllLines(fileName, System.Text.Encoding.Default);
            string[] lineValues;
            for (int i = 0; i < txtLines.Length; i++)
            {
                lineValues = txtLines[i].Split(split.ToCharArray());
                if (0 == result.Columns.Count)
                {
                    for (int k = 0; k < lineValues.Length; k++)
                    {
                        result.Columns.Add("");
                    }
                }
                result.LoadDataRow(lineValues, false);
            }
            return result;
        }

        /// <summary>
        /// 从文件夹下的所有文本文件中读取数据，并包装成DataTable
        /// </summary>
        /// <param name="dir">文件夹路径</param>
        /// <param name="split">字段间的分隔符</param>
        /// <returns></returns>
        public static DataTable ReadDirToDataTable(string dir, string split)
        {
            DataTable result = new DataTable();
            string[] txtLines, lineValues;
            string[] files = Directory.GetFiles(dir);
            for (int i = 0; i < files.Length; i++)
            {
                txtLines = File.ReadAllLines(files[i], System.Text.Encoding.Default);
                for (int j = 0; j < txtLines.Length; j++)
                {
                    lineValues = txtLines[j].Split(split.ToCharArray());
                    if (0 == result.Columns.Count)
                    {
                        for (int k = 0; k < lineValues.Length; k++)
                        {
                            result.Columns.Add("");
                        }
                    }
                    result.LoadDataRow(lineValues, false);
                }
            }
            return result;
        }

        private static MD5 md5 = new MD5CryptoServiceProvider();

        private static string MD5ByteToStr(byte[] b)
        {
            string result = "";
            for (int i = 0; i < b.Length; i++)
            {
                //这里的“X2”，如果只用“X”则会出现缺位的情况
                //因为每个byte会被转换成双位的十六进制表示，如果第一位是0，则会被舍去。
                result += b[i].ToString("X2");
            }
            return result;
        }

        public static string CalcFileMD5(string fileName)
        {
            Stream stream = File.OpenRead(fileName);
            return CalcStreamMD5(stream);
        }

        public static string CalcStreamMD5(Stream stream)
        {
            byte[] md5Hash = md5.ComputeHash(stream);
            return MD5ByteToStr(md5Hash);
        }

        public static string CalcStringMD5(string str)
        {
            byte[] source = System.Text.Encoding.Default.GetBytes(str);
            byte[] md5Hash = md5.ComputeHash(source);
            return MD5ByteToStr(md5Hash);
        }

        /// <summary>
        /// 建立文件夹（如果路径不存在，建立文件夹）
        /// </summary>
        /// <param name="path">路径</param>
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// 安全拷贝文件（如果目标文件已经存在，不会进行拷贝）
        /// </summary>
        /// <param name="sourceFile">源文件</param>
        /// <param name="targetFile">目标文件</param>
        /// <returns>拷贝是否成功</returns>
        public static void CopyFileSafely(string sourceFile, string targetFile)
        {
            if (File.Exists(sourceFile))
            {
                if (!File.Exists(targetFile))
                {
                    CreateDirectory(Path.GetDirectoryName(targetFile));
                    File.Copy(sourceFile, targetFile);
                }
            }
            else
            {
                throw new Exception("Copy file error, source file not exists");
            }
        }

        /// <summary>
        /// 强制拷贝文件（务必将源文件拷贝到目标处）
        /// </summary>
        /// <param name="sourceFile">源文件</param>
        /// <param name="targetFile">目标文件</param>
        /// <returns>拷贝是否成功</returns>
        public static void CopyFileCompel(string sourceFile, string targetFile)
        {
            if (File.Exists(sourceFile))
            {
                CreateDirectory(Path.GetDirectoryName(targetFile));
                File.Copy(sourceFile, targetFile, true);
            }
            else
            {
                throw new Exception("Copy file error, source file not exists");
            }
        }

        /// <summary>
        /// 安全移动文件（源文件存在时才执行移动操作，目标文件夹如果不存在则建立文件夹，如果目标文件已经存在，不会进行移动）
        /// </summary>
        /// <param name="sourceFile">源文件</param>
        /// <param name="targetFile">目标文件</param>
        /// <returns>文件移动是否成功</returns>
        public static void MoveFileSafely(string sourceFile, string targetFile)
        {
            if (File.Exists(sourceFile))
            {
                if (!File.Exists(targetFile))
                {
                    CreateDirectory(Path.GetDirectoryName(targetFile));
                    File.Move(sourceFile, targetFile);
                }
            }
            else
            {
                throw new Exception("Move file error, source file not exists.");
            }
        }

        /// <summary>
        /// 强制移动文件（务必将文件移动到目标位置）
        /// </summary>
        /// <param name="sourceFile">源文件</param>
        /// <param name="targetFile">目标文件</param>
        /// <returns>文件移动是否成功</returns>
        public static void MoveFileCompel(string sourceFile, string targetFile)
        {
            if (File.Exists(sourceFile))
            {
                CreateDirectory(Path.GetDirectoryName(targetFile));
                File.Copy(sourceFile, targetFile, true);
                DeleteFileSafely(sourceFile);
            }
            else
            {
                throw new Exception("Move file error, source file not exists.");
            }
        }

        /// <summary>
        /// 安全删除文件
        /// </summary>
        /// <param name="sourceFile">源文件</param>
        /// <returns>删除是否成功</returns>
        public static void DeleteFileSafely(string sourceFile)
        {
            if (File.Exists(sourceFile))
            {
                new FileInfo(sourceFile).IsReadOnly = false;
                File.Delete(sourceFile);
            }
        }

        /// <summary>
        /// 安全删除文件夹（只有当文件夹内没有文件时删除）
        /// </summary>
        /// <param name="path">文件夹完整路径</param>
        public static void DeleteFolderSafely(string path)
        {
            if (Directory.Exists(path))
            {
                if (0 == Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length)
                {
                    Directory.Delete(path, true);
                }
            }
        }

        /// <summary>
        /// 强制删除文件夹
        /// </summary>
        /// <param name="path">文件夹完整路径</param>
        public static void DeleteFolderCompel(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        /// <summary>
        /// 文件重命名
        /// </summary>
        /// <param name="oldName">旧文件名（完整路径）</param>
        /// <param name="newName">新文件名</param>
        public static void RenameFileSafely(string oldName, string newName)
        {
            try
            {
                newName = Path.Combine(Path.GetDirectoryName(oldName), Path.GetFileNameWithoutExtension(newName) + Path.GetExtension(oldName));
                MoveFileCompel(oldName, newName);
            }
            catch
            {
                DeleteFileSafely(newName);
            }
        }
    }
}
