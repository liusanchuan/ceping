using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Threading;
namespace SharpGLWinformsApplication1
{
    public class FileOperate
    {

        /// <summary>
        /// 文件夹扫描文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static List<string> ScanFile(string path = "")
        {
            if (path == "")
            {
                path = System.AppDomain.CurrentDomain.BaseDirectory + "FilePath";
            }
            var filelist = new DirectoryInfo(path).GetFiles();
            if (filelist == null)
                return null;
            List<string> filename = new List<string>();
            foreach (var fn in filelist)
            {
                filename.Add(fn.FullName);
            }
            return filename;
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static List<RealTimeMonitoringModel> ReadFile(string filename)
        {
            List<RealTimeMonitoringModel> filemedel = new List<RealTimeMonitoringModel>();
            StreamReader reader = new StreamReader(filename, Encoding.Default);
            string line = reader.ReadLine();
            int flag = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("Timestamp"))
                    flag++;
                if (flag == 2)
                    break;
            }
            while ((line = reader.ReadLine()) != null && flag > 0)
            {
                filemedel.Add(RealTimeMonitoringModel.Parse(line, filemedel.Count));
            }
            reader.Close();
            SaveFileThread sft = new SaveFileThread(filemedel, "");//开现存
            Thread tsp = new Thread(sft.SaveFile);
            tsp.Start();
            return filemedel;
        }

        /// <summary>
        /// 文件数据组取出显示数据
        /// </summary>
        /// <param name="data">文件数据</param>
        /// <param name="start">起始点</param>
        /// <param name="seconds">时间间隔 秒</param>
        /// <param name="MaxRecord">最大点数</param>
        /// <returns></returns>
        public static List<RealTimeMonitoringModel> GetRealTimeMonitoringModel(List<RealTimeMonitoringModel> data, RealTimeMonitoringModel start, int milliseconds, int MaxRecord = 60)
        {
            List<RealTimeMonitoringModel> Model = new List<RealTimeMonitoringModel>();
            DateTime dt = start.RecordTime.AddMilliseconds(milliseconds);
            for (int i = 0; i < MaxRecord; i++)
            {
                var q = data.Find(x => x.RecordTime == dt);//q储存的是查找出来的一个对象
                if (q != null)
                {
                    Model.Add(q);
                }
                milliseconds += milliseconds;
                dt = start.RecordTime.AddSeconds(milliseconds);
            }
            return Model;
        }

        //public static void SaveFile(RealTimeMonitoringModel model, string path = "")
        //{
        //    if (path == "")
        //    {
        //        path = System.AppDomain.CurrentDomain.BaseDirectory + "ABC/"+ DateTime.Now.ToString("yyyy-MM");
        //    }
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //    string filename = string.Format("{0}/{1}_info.txt", path, DateTime.Now.ToString("yyyyMMdd"));
        //    using (StreamWriter sw = new StreamWriter(filename, true))
        //    {
        //        string str = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", model.RecordTime,
        //            model.Stress1, model.Stress2, model.Temperature1, model.Temperature2, model.Wave1, model.Wave2);
        //        sw.WriteLine(str);
        //    }
        //}
        /// <summary>
        /// 移动文件，后删除源文件
        /// </summary>
        /// <param name="filename">文件名路径</param>
        /// <param name="path">目标路径</param>
        /// <returns></returns>
        public static bool MoveDelFile(string filename, string path = "")
        {
            try
            {
                if (path == "")
                {
                    path = string.Format("{0}HistoryFile\\{1}\\{2}",
                        System.AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM"),
                        DateTime.Now.ToString("yyyy-MM-dd"));
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string name = filename.Substring(filename.LastIndexOf('\\') + 1);//取出文件名
                string destname = string.Format("{0}\\{1}", path, name);//放到目标路径
                if (File.Exists(destname))//判断文件是否存在
                    File.Delete(destname);//存在就删
                File.Move(filename, destname);//移动到history
                File.Delete(filename);//删除path中文件
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 表结构初始化
        /// </summary>
        /// <returns></returns>
        //private static DataTable FileTableInit()
        //{
        //    DataTable dtreader = new DataTable();
        //    dtreader.Columns.Add("time", typeof(string));
        //    dtreader.Columns.Add("yl1", typeof(string));
        //    dtreader.Columns.Add("yl2", typeof(string));
        //    dtreader.Columns.Add("wd1", typeof(string));
        //    dtreader.Columns.Add("wd2", typeof(string));
        //    dtreader.Columns.Add("bc1", typeof(string));
        //    dtreader.Columns.Add("bc2", typeof(string));
        //    return dtreader;
        //}

        public static DataTable ReadDangerousAlarmFile(DateTime date)
        {
            if (date == null)
                date = DateTime.Now;
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "ABC/" + date.ToString("yyyy-MM");
            string filename = string.Format("{0}/{1}_info.txt", path, date.ToString("yyyyMMdd"));//占位，path放到0.年月日放到1
            if (!File.Exists(filename))//判断有无文件
                return null;//返回空
            StreamReader reader = new StreamReader(filename, Encoding.Default);//把文件读到数据流里面
            string line = reader.ReadLine();//读行
            DataTable dt = DangerousAlarmInit(line);
            while ((line = reader.ReadLine()) != null)//循环度数据
            {
                string[] splt = line.Split('\t');
                DataRow dr = dt.NewRow();//把新建一行给这个类
                for (int i = 0; i < splt.Length; i++)
                {
                    dr[i] = splt[i];
                }
                dt.Rows.Add(dr);
            }
            reader.Close();//把所有读进列表
            return dt;
        }

        private static DataTable DangerousAlarmInit(string line)//用标题对表进行初始化
        {
            DataTable dtreader = new DataTable();
            string[] splt = line.Split('\t');//把一行分为很多列
            foreach (var s in splt)//循环
            {
                dtreader.Columns.Add(s, typeof(string));//一列列加入表结构中
            }
            return dtreader;//得到一个表结构 里面无数据
        }
    }
}
