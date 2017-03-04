using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace SharpGLWinformsApplication1
{
    class HistoryList
    {
        private string[] array = null;

        
        public void InitAutoCompleteCustomSource(TextBox textBox)
        {
            array = ReadTxt();
            if (array != null && array.Length > 0)
            {
                AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();

                for (int i = 0; i < array.Length; i++)
                {

                    ACSC.Add(array[i]);

                }
                textBox.AutoCompleteCustomSource = ACSC;
            }
        }

        string[] ReadTxt()
        {
            try
            {
                if (!File.Exists("../Debug/HistoryFile/Remind.txt"))
                {
                    FileStream fs =
                        File.Create("../Debug/HistoryFile/Remind.txt");
                    fs.Close();
                    fs = null;
                }

                return File.ReadAllLines("../Debug/HistoryFile/Remind.txt", Encoding.Default);
            }
            catch
            {
                return null;
            }
        }
        public string[] ReadLastHistory(string str)
        {
            if (!File.Exists(str))
            {
                StreamWriter writer = new StreamWriter(str, true, Encoding.Default); ;
                string s = "待同步";
                for (int i = 0; i < 15; i++)
                {
                    writer.WriteLine(s);
                }
                writer.Close();
                writer = null;

            }
            return File.ReadAllLines(str, Encoding.Default);
        }
        public void Remind(string str)
        {
            StreamWriter writer = null;
            try
            {
                if (array != null && !array.Contains(str))
                {
                    writer = new StreamWriter("../Debug/HistoryFile/Remind.txt", true, Encoding.Default);
                    writer.WriteLine(str);
                }
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer = null;
                }

            }
        }
        public void ChangeLastHistory(string str1,string str2)
        {
            StreamWriter writer1 = null;
            try
            {
                writer1 = new StreamWriter(str1, true, Encoding.Default);
                writer1.WriteLine(str2);
            }
            finally
            {
                if (writer1 != null)
                {
                    writer1.Close();
                    writer1 = null;
                }

            }
        }
    }
}