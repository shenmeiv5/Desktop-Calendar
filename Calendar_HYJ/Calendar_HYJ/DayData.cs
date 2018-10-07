using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
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
    class DayData:INotifyPropertyChanged
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
        private int lunarMonth;
        /// <summary>
        /// 农历日
        /// </summary>
        private int lunarDay;
        /// <summary>
        /// 农历月字符串
        /// </summary>
        private string lunarStrMonth;
        /// <summary>
        /// 农历日字符串
        /// </summary>
        private string lunarStrDay;
        /// <summary>
        /// 属性改变事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public int SolarYear { get => solarYear; set => solarYear = value; }
        public int SolarMonth { get => solarMonth; set => solarMonth = value; }
        public int SolarDay
        {
            get => solarDay;
            set
            {
                solarDay = value;
                SolarDayToLunarDay();
                //激发事件
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("solarDay"));
                }
            }
        }
        public int LunarYear { get => lunarYear; set => lunarYear = value; }
        public int LunarMonth { get => lunarMonth; set => lunarMonth = value; }
        public int LunarDay { get => lunarDay; set => lunarDay = value; }
        public string LunarStrMonth
        {
            get => lunarStrMonth;
            set
            {
                lunarStrMonth = value;
                //激发事件
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("lunarStrMonth"));
                }
            }
        }
        public string LunarStrDay
        {
            get => lunarStrDay;
            set
            {
                lunarStrDay = value;
                //激发事件
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("lunarStrDay"));
                }
            }
        }
        /// <summary>
        /// 构造
        /// </summary>
        public DayData(int y, int m)
        {
            this.solarYear = y;
            this.solarMonth = m;
            //this.solarDay = 31;
            //this.lunarYear = 1900;
            //this.lunarMonth = 1;
            //this.lunarDay = 1;
            this.lunarStrMonth = "";
            this.lunarStrDay = "";
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
            LunarMonthToStr(lDate[3]);
            LunarDayToStr();
        }

        private void LunarMonthToStr(int leap)
        {
            //闰月
            if (leap == 1)
            {
                this.LunarStrMonth = "闰";
            }
            this.LunarStrMonth += LunarData.lunarMonthStrInfo[this.lunarMonth];
        }

        private void LunarDayToStr()
        {
            this.LunarStrDay = LunarData.lunarDayStrInfo[this.lunarDay];
        }
        
    }
}
