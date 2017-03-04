using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpGLWinformsApplication1
{
    public class Limit
    {
        public Limit()//构造函数的名字必须和类的名字一样
        {
            LimitList = new List<LimitValue>();//new出来，相当于给他个内存

            LimitValue value1 = new LimitValue()
            {
                id = 1,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value1);//加到列表中

            LimitValue value2 = new LimitValue()
            {
                id = 2,
                StressLimit = 15,
                TemperatureLimit = -4
            };
            LimitList.Add(value2);
            
            LimitValue value3 = new LimitValue()
            {
                id = 3,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value3);//加到列表中

            LimitValue value4 = new LimitValue()
            {
                id = 4,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value4);//加到列表中
            
            LimitValue value5 = new LimitValue()
            {
                id = 5,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value5);//加到列表中
            
            LimitValue value6 = new LimitValue()
            {
                id = 6,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value6);//加到列表中

            LimitValue value7 = new LimitValue()
            {
                id = 7,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value7);//加到列表中

            LimitValue value8 = new LimitValue()
            {
                id = 8,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value8);//加到列表中

            LimitValue value9 = new LimitValue()
            {
                id =9,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value9);//加到列表中

            LimitValue value10 = new LimitValue()
            {
                id = 10,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value10);//加到列表中

            LimitValue value11 = new LimitValue()
            {
                id = 11,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value11);//加到列表中

            LimitValue value12 = new LimitValue()
            {
                id = 12,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value12);//加到列表中

            LimitValue value13 = new LimitValue()
            {
                id = 13,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value13);//加到列表中

            LimitValue value14 = new LimitValue()
            {
                id = 14,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value14);//加到列表中

            LimitValue value15 = new LimitValue()
            {
                id = 15,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value15);//加到列表中

            LimitValue value16 = new LimitValue()
            {
                id = 16,
                StressLimit = 17.5,
                TemperatureLimit = 25.3//定义测点限制值
            };
            LimitList.Add(value16);//加到列表中
        }

        public List<LimitValue> LimitList { set; get; }//定义测点限制，具体到数值
    }

    public class LimitValue
    {
        public int id { get; set; }

        public double StressLimit { set; get; }//设置、获取

        public double TemperatureLimit { set; get; }
    }
}
