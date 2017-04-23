using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpGLWinformsApplication1
{
    class Dataclass1Singlon
    {
        //数据库连接单例模式
        private Dataclass1Singlon() { }
        private static DataClasses1DataContext dc=null;
        public static DataClasses1DataContext getSinglon()
        {
            if (dc == null)
            {
                dc = new DataClasses1DataContext();
            }
            return dc;
        }
    }
}
