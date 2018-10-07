using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * ************************
 * 创建日期：201/10/4
 * 创建人：HYJ
 * 文件描述：DayData类（日期数据类） 实现
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
        /// 公历年
        /// </summary>
        private int solarYear;
        /// <summary>
        /// 公历月
        /// </summary>
        private int solarMonth;
        /// <summary>
        /// 公历日
        /// </summary>
        private int solarDay;
        /// <summary>
        /// 农历年
        /// </summary>
        private int lunarYear;
        /// <summary>
        /// 农历月
        /// </summary>
        private int lunarMonth = 0;
        /// <summary>
        /// 农历日
        /// </summary>
        private int lunarDay = 0;
        /// <summary>
        /// 农历月字符串
        /// </summary>
        private string lunarStrMonth;
        /// <summary>
        /// 农历日字符串
        /// </summary>
        private string lunarStrDay;
        /// <summary>
        /// 构造
        /// </summary>
        public DayData()
        {
            //SolarDayToLunarDay();
        }
        /// <summary>
        /// 公历转农历
        /// </summary>
        private void SolarDayToLunarDay()
        {
            int[] lDate = LunarData.SolarDayToLunarDay(this.solarYear, this.solarMonth, this.solarDay);
            this.lunarYear = lDate[0];
            this.lunarMonth = lDate[1];
            this.lunarDay = lDate[2];
        }
        public int SolarYear { get => solarYear; set => solarYear = value; }
        public int SolarMonth { get => solarMonth; set => solarMonth = value; }
        public int SolarDay { get => solarDay; set => solarDay = value; }
        public int LunarYear { get => lunarYear; set => lunarYear = value; }
        public int LunarMonth { get => lunarMonth; set => lunarMonth = value; }
        public int LunarDay { get => lunarDay; set => lunarDay = value; }
        
    }
}
