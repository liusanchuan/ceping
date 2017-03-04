using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SharpGLWinformsApplication1
{
    public class SaveFileThread
    {
        private const string title = "Timestamp	s1_1	s2_2	s3_3_1	s3_3_2	s3_3_3	s4_4	s5_5	s6_6	s7_7	s8_8_1	s8_8_3  s8_8_3  s9_9	s10_10	s11_11	s12_12	s13_13_1	s13_13_2	s13_13_3	s14_14	s15_15	s16_16	s17_17	s18_18_1	s18_18_2	s18_18_3	s19_19	s20_20	T1_1	T2_2	T3_3	T4_4	T5_5	T6_6	T7_7	T8_8	T9_9	T10_10	T11_11	T12_12	T13_13	T14_14	T15_15	T16_16	T17_17	T18_18	T19_19	T20_20	FBG_A1	FBG_A2";
        List<RealTimeMonitoringModel> ModelList;
        string path = "";
        public SaveFileThread(List<RealTimeMonitoringModel> _ModelList, string _path)
        {
            ModelList = _ModelList;
            path = _path;
        }

        public void SaveFile()
        {
            if (ModelList == null || ModelList.Count == 0)
                return;
            if (path == "")
            {
                path = System.AppDomain.CurrentDomain.BaseDirectory + "ABC/" + DateTime.Now.ToString("yyyy-MM");
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filename = string.Format("{0}/{1}_info.txt", path, DateTime.Now.ToString("yyyyMMdd"));
            bool titleflag = false;
            if(!File.Exists(filename))
                titleflag = true;
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                if(titleflag)
                    sw.WriteLine(title);
                foreach (var model in ModelList)
                {
                    if (Convert.ToDouble(model.Stress1) >= 17.5 || Convert.ToDouble(model.Temperature1) >= 25.3 ||
                        Convert.ToDouble(model.Stress2) >= 17.5 || Convert.ToDouble(model.Temperature2) >= -4||
                        Convert.ToDouble(model.Stress3) >= 17.5 || Convert.ToDouble(model.Temperature3) >= -4||
                        Convert.ToDouble(model.Stress4) >= 17.5 || Convert.ToDouble(model.Temperature4) >= -4||
                        Convert.ToDouble(model.Stress5) >= 17.5 || Convert.ToDouble(model.Temperature5) >= -4||
                        Convert.ToDouble(model.Stress6) >= 17.5 || Convert.ToDouble(model.Temperature6) >= -4||
                        Convert.ToDouble(model.Stress7) >= 17.5 || Convert.ToDouble(model.Temperature7) >= -4||
                        Convert.ToDouble(model.Stress8) >= 17.5 || Convert.ToDouble(model.Temperature8) >= -4||
                        Convert.ToDouble(model.Stress9) >= 17.5 || Convert.ToDouble(model.Temperature9) >= -4||
                        Convert.ToDouble(model.Stress10) >= 17.5 || Convert.ToDouble(model.Temperature10) >= -4||
                        Convert.ToDouble(model.Stress11) >= 17.5 || Convert.ToDouble(model.Temperature11) >= -4||
                        Convert.ToDouble(model.Stress12) >= 17.5 || Convert.ToDouble(model.Temperature12) >= -4||
                        Convert.ToDouble(model.Stress13) >= 17.5 || Convert.ToDouble(model.Temperature13) >= -4||
                        Convert.ToDouble(model.Stress14) >= 17.5 || Convert.ToDouble(model.Temperature14) >= -4||
                        Convert.ToDouble(model.Stress15) >= 17.5 || Convert.ToDouble(model.Temperature15) >= -4||
                        Convert.ToDouble(model.Stress16) >= 17.5 || Convert.ToDouble(model.Temperature16) >= -4||
                        Convert.ToDouble(model.Stress17) >= 17.5 || Convert.ToDouble(model.Temperature17) >= -4||
                        Convert.ToDouble(model.Stress18) >= 17.5 || Convert.ToDouble(model.Temperature18) >= -4||
                        Convert.ToDouble(model.Stress19) >= 17.5 || Convert.ToDouble(model.Temperature19) >= -4||
                        Convert.ToDouble(model.Stress20) >= 17.5 || Convert.ToDouble(model.Temperature20) >= -4||
                        Convert.ToDouble(model.Stress21) >= 17.5 || 
                        Convert.ToDouble(model.Stress22) >= 17.5 || 
                        Convert.ToDouble(model.Stress23) >= 17.5 ||
                        Convert.ToDouble(model.Stress24) >= 17.5 ||
                        Convert.ToDouble(model.Stress25) >= 17.5 ||
                        Convert.ToDouble(model.Stress26) >= 17.5 ||
                        Convert.ToDouble(model.Stress27) >= 17.5 ||
                        Convert.ToDouble(model.Stress28) >= 17.5)
                    {
                        string str = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}\t{16}\t{17}\t{18}\t{19}\t{20}\t{21}\t{22}\t{23}\t{24}\t{25}\t{26}\t{27}\t{28}\t{29}\t{30}\t{31}\t{32}\t{33}\t{34}\t{35}\t{36}\t{37}\t{38}\t{39}\t{40}\t{41}\t{42}\t{43}\t{44}\t{45}\t{46}\t{47}\t{48}\t{49}", model.RecordTime.ToString("yyyy-MM-dd HH:mm:ss.fffff"),
                            model.Stress1, model.Stress2, model.Stress3, model.Stress4, model.Stress5, model.Stress6, model.Stress7, model.Stress8, model.Stress9, model.Stress11, model.Stress12, model.Stress13, model.Stress14, model.Stress15, model.Stress16, model.Stress17, model.Stress18, model.Stress19, model.Stress21, model.Stress22, model.Stress23, model.Stress24, model.Stress25, model.Stress26, model.Stress27, model.Stress28, model.Temperature1, model.Temperature2, model.Temperature2, model.Temperature3, model.Temperature4, model.Temperature5, model.Temperature6, model.Temperature7, model.Temperature8, model.Temperature9, model.Temperature10, model.Temperature11, model.Temperature12, model.Temperature13, model.Temperature14, model.Temperature15, model.Temperature16, model.Temperature17, model.Temperature18, model.Temperature19, model.Temperature20, model.Wave1, model.Wave2);
                        sw.WriteLine(str);
                    }
                }
            }
        }
    }
}
