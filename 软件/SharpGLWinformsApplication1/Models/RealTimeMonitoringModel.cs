using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpGLWinformsApplication1
{
    public class RealTimeMonitoringModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int RecordID { set; get; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RecordTime { set; get; }

        /// <summary>
        /// 应力1
        /// </summary>
        public string Stress1 { set; get; }

        /// <summary>
        /// 应力2
        /// </summary>
        public string Stress2 { set; get; }

        /// <summary>
        /// 应力3
        /// </summary>
        public string Stress3 { set; get; }

        /// <summary>
        /// 应力4
        /// </summary>
        public string Stress4 { set; get; }

        /// <summary>
        /// 应力5
        /// </summary>
        public string Stress5 { set; get; }

        /// <summary>
        /// 应力6
        /// </summary>
        public string Stress6 { set; get; }

        /// <summary>
        /// 应力7
        /// </summary>
        public string Stress7 { set; get; }

        /// <summary>
        /// 应力8
        /// </summary>
        public string Stress8 { set; get; }

        /// <summary>
        /// 应力9
        /// </summary>
        public string Stress9 { set; get; }

        /// <summary>
        /// 应力10
        /// </summary>
        public string Stress10 { set; get; }

              /// <summary>
        /// 应力11
        /// </summary>
        public string Stress11 { set; get; }

        /// <summary>
        /// 应力12
        /// </summary>
        public string Stress12 { set; get; }

        /// <summary>
        /// 应力13
        /// </summary>
        public string Stress13 { set; get; }

        /// <summary>
        /// 应力14
        /// </summary>
        public string Stress14 { set; get; }

        /// <summary>
        /// 应力15
        /// </summary>
        public string Stress15 { set; get; }

        /// <summary>
        /// 应力16
        /// </summary>
        public string Stress16 { set; get; }

        /// <summary>
        /// 应力17
        /// </summary>
        public string Stress17 { set; get; }

        /// <summary>
        /// 应力18
        /// </summary>
        public string Stress18 { set; get; }

        /// <summary>
        /// 应力19
        /// </summary>
        public string Stress19 { set; get; }

        /// <summary>
        /// 应力20
        /// </summary>
        public string Stress20 { set; get; }

        /// <summary>
        /// 应力21
        /// </summary>
        public string Stress21 { set; get; }

        /// <summary>
        /// 应力22
        /// </summary>
        public string Stress22 { set; get; }

        /// <summary>
        /// 应力23
        /// </summary>
        public string Stress23 { set; get; }

        /// <summary>
        /// 应力24
        /// </summary>
        public string Stress24 { set; get; }

        /// <summary>
        /// 应力25
        /// </summary>
        public string Stress25 { set; get; }

        /// <summary>
        /// 应力26
        /// </summary>
        public string Stress26 { set; get; }

        /// <summary>
        /// 应力27
        /// </summary>
        public string Stress27 { set; get; }

        /// <summary>
        /// 应力28
        /// </summary>
        public string Stress28{ set; get; }

        /// <summary>
        /// 温度1
        /// </summary>
        public string Temperature1 { set; get; }

        /// <summary>
        /// 温度2
        /// </summary>
        public string Temperature2 { set; get; }

        /// <summary>
        /// 温度3
        /// </summary>
        public string Temperature3 { set; get; }

        /// <summary>
        /// 温度4
        /// </summary>
        public string Temperature4 { set; get; }

        /// <summary>
        /// 温度5
        /// </summary>
        public string Temperature5 { set; get; }

        /// <summary>
        /// 温度6
        /// </summary>
        public string Temperature6 { set; get; }

        /// <summary>
        /// 温度7
        /// </summary>
        public string Temperature7 { set; get; }

        /// <summary>
        /// 温度8
        /// </summary>
        public string Temperature8 { set; get; }

        /// <summary>
        /// 温度9
        /// </summary>
        public string Temperature9 { set; get; }

        /// <summary>
        /// 温度10
        /// </summary>
        public string Temperature10 { set; get; }

        /// <summary>
        /// 温度11
        /// </summary>
        public string Temperature11 { set; get; }

        /// <summary>
        /// 温度12
        /// </summary>
        public string Temperature12 { set; get; }

        /// <summary>
        /// 温度13
        /// </summary>
        public string Temperature13 { set; get; }

        /// <summary>
        /// 温度14
        /// </summary>
        public string Temperature14 { set; get; }

        /// <summary>
        /// 温度15
        /// </summary>
        public string Temperature15 { set; get; }

        /// <summary>
        /// 温度16
        /// </summary>
        public string Temperature16 { set; get; }

        /// <summary>
        /// 温度17
        /// </summary>
        public string Temperature17 { set; get; }

        /// <summary>
        /// 温度18
        /// </summary>
        public string Temperature18 { set; get; }

        /// <summary>
        /// 温度19
        /// </summary>
        public string Temperature19 { set; get; }

        /// <summary>
        /// 温度20
        /// </summary>
        public string Temperature20 { set; get; }

               /// <summary>
        /// 波长1
        /// </summary>
        public string Wave1 { set; get; }

        /// <summary>
        /// 波长2
        /// </summary>
        public string Wave2 { set; get; }
       
        /// <summary>
        /// 波长3
        /// </summary>
        public string Wave3 { set; get; }

        public static RealTimeMonitoringModel Parse(string line, int _recordid)
        {
            RealTimeMonitoringModel Model = new RealTimeMonitoringModel();
            string[] splt = line.Split('\t');//table隔开,split:分离
            Model.RecordID = _recordid;
            Model.RecordTime = Convert.ToDateTime(splt[0]);
            //Model.RecordTime = DateTime.ParseExact(splt[0], "yyyy/MM/dd HH:mm:ss.sssss",null);
            Model.Stress1 = splt[1];
            Model.Stress2 = splt[2];
            Model.Stress3 = splt[3];
            Model.Stress4 = splt[4];
            Model.Stress5 = splt[5];
            Model.Stress6 = splt[6];
            Model.Stress7 = splt[7];
            Model.Stress8 = splt[8];
            Model.Stress9 = splt[9];
            Model.Stress10 = splt[10];
            Model.Stress11 = splt[11];
            Model.Stress12 = splt[12];
            Model.Stress13 = splt[13];
            Model.Stress14 = splt[14];
            Model.Stress15 = splt[15];
            Model.Stress16 = splt[16];
            Model.Stress17 = splt[17];
            Model.Stress18 = splt[18];
            Model.Stress19 = splt[19];
            Model.Stress20 = splt[20];
            Model.Stress21 = splt[21];
            Model.Stress22 = splt[22];
            Model.Stress23 = splt[23];
            Model.Stress24 = splt[24];
            Model.Stress25 = splt[25];
            Model.Stress26 = splt[26];
            Model.Stress27 = splt[27];
            Model.Stress28 = splt[28];
            
            Model.Temperature1 = splt[29];
            Model.Temperature2 = splt[30];
            Model.Temperature3 = splt[31];
            Model.Temperature4 = splt[32];
            Model.Temperature5 = splt[33];
            Model.Temperature6 = splt[34];
            Model.Temperature7 = splt[35];
            Model.Temperature8 = splt[36];
            Model.Temperature9 = splt[37];
            Model.Temperature10 = splt[38];
            Model.Temperature11 = splt[39];
            Model.Temperature12 = splt[40];
            Model.Temperature13 = splt[41];
            Model.Temperature14 = splt[42];
            Model.Temperature15 = splt[43];
            Model.Temperature16 = splt[44];
            Model.Temperature17 = splt[45];
            Model.Temperature18 = splt[46];
            Model.Temperature19 = splt[47];
            Model.Temperature20 = splt[48];
            Model.Wave1 = splt[49];
            Model.Wave2 = splt[50];
            //bool flag = false;
            //if (Convert.ToDouble(Model.StressOne) >= 17.5)
            //{
            //    flag = true;
            //}
            //if (Convert.ToDouble(Model.TemperatureOne) >= 25.3)
            //{
            //                   flag = true;
            //}

            //if (Convert.ToDouble(Model.StressTwo) >= 15.5)
            //{
            //                    flag = true;
            //}

            //if (Convert.ToDouble(Model.TemperatureTwo) >= -4)
            //{
            //                    flag = true;
            //}
            
            
            //if (flag)
            //{
            //    FileOperate.SaveFile(Model);
            //}
            return Model;
        }
    }
}
