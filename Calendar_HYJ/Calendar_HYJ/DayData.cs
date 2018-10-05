using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * ************************
 * 创建日期：201/10/4
 * 创建人：HYJ
 * 文件描述：DayData类（日期数据类
 * ************************
 */
namespace Calendar_HYJ
{
    /// <summary>
    /// 日期数据类
    /// </summary>
    class DayData
    {
        /// <summary>
        /// 公历日
        /// </summary>
        private int solarDay;
        /// <summary>
        /// 农历月
        /// </summary>
        private int lunarMonth = 0;
        /// <summary>
        /// 农历日
        /// </summary>
        private int lunarDay = 0;
        
        public int SolarDay { get => solarDay; set => solarDay = value; }
        public int LunarMonth { get => lunarMonth; set => lunarMonth = value; }
        public int LunarDay { get => lunarDay; set => lunarDay = value; }
    }
}
