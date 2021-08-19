using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClientTCPLibrary.FileWork
{
    /// <summary>
    /// Class for work with file
    /// </summary>
    public class TextFile
    {
        /// <summary>
        /// Method for create string for send
        /// </summary>
        /// <param name="path1">path for file with main matrix</param>
        /// <param name="path2">path for file with vector</param>
        /// <returns>string with main matrix and vector</returns>
        public string SendMessage(string path1, string path2) 
        {
            string[] str1 = ReadMainMatrix(path1).Split('\n'); 
            string[] str2 = ReadVector(path2).Split('\n');
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < str1.Length - 1; i++)
            {
                str.Append(str1[i]);
                str.Append("\n");
            }
            for (int i = 0; i < str2.Length - 1; i++)
            {
                str.Append(str2[i]);
                str.Append("\n");
            }
            return str.ToString();
        }
        /// <summary>
        /// Method for read main matrix from file
        /// </summary>
        /// <param name="path">path for file with main matrix</param>
        /// <returns>string with main matrix</returns>
        public string ReadMainMatrix(string path)
        {
            StreamReader file = new StreamReader(path);
            string s = file.ReadToEnd();
            file.Close();
            return s;
        }
        /// <summary>
        /// Method for read vector from file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadVector(string path)
        {
            StreamReader file = new StreamReader(path);
            string s = file.ReadToEnd();
            file.Close();
            return s;
        }
    }
}