using System;
using System.IO;
using System.Security.Cryptography;

namespace ReaderMe.Helper
{
    class FileHelper
    {
        private FileHelper() { }

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
