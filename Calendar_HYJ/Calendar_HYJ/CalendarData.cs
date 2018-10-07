using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
/*
 * ***********************
 * 创建日期：2018/10/4
 * 创建人：HYJ
 * 文件描述：Calendar类（日历数据类）实现
 * ***********************
 */
namespace Calendar_HYJ
{
    /// <summary>
    /// 日历数据类
    /// </summary>
    class CalendarData:INotifyPropertyChanged
    {
        /// <summary>
        /// 当前年数据
        /// </summary>
        private int selYear;
        /// <summary>
        /// 当前月数据
        /// </summary>
        private int selMonth;
        /// <summary>
        /// 当前日期数据
        /// </summary>
        private List<DayData> selDays;
        /// <summary>
        /// 属性改变事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public int SelYear
        {
            get => selYear;
            set
            {
                selYear = value;
                //激发事件
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("selYear"));
                    InitialSelDays();
                }
            }
        }
        public int SelMonth
        {
            get => selMonth;
            set
            {
                selMonth = value;
                //激发事件
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("selMonth"));
                    InitialSelDays();
                }
            }
        }
        internal List<DayData> SelDays { get => selDays; set => selDays = value; }
        /// <summary>
        /// 构造
        /// </summary>
        public CalendarData()
        {
            selDays = new List<DayData>();
            for (int i = 0; i < 35; i++)
            {
                DayData d = new DayData();
                selDays.Add(d);
            }
            InitialSelDays();
        }
        /// <summary>
        /// 初始化当前日期数据
        /// </summary>
        private void InitialSelDays()
        {
            //y年m月的第一日
            DateTime dt = new DateTime(this.selYear, this.selMonth, 1);
            //y年m月1日 星期(Sunday 0
            int dw = (int)dt.DayOfWeek;
            if (dw == 0)
            {
                dw = 7;
            }
            //上个月天数
            int lastDays;
            if (this.selMonth == 1)
            {
                lastDays = DateTime.DaysInMonth(this.selYear, 12);
            }
            else
            {
                lastDays = DateTime.DaysInMonth(this.selYear, this.selMonth-1);
            }
            //当前月天数
            int nowDays = DateTime.DaysInMonth(this.selYear, this.selMonth);
            //上个月日期
            for (int i = 0; i < dw; i++)
            {
                this.SelDays[i].SolarDay = lastDays - i + dw +1;
            }
            //当前月日期
            for (int i = dw; i < nowDays; i++)
            {
                this.SelDays[i].SolarDay = i - dw + 1;
            }
            //下个月日期
            for (int i = dw + nowDays; i < 35; i++)
            {
                this.SelDays[i].SolarDay = i - dw - nowDays + 1;
            }
        }//InitialSelDays 函数结束
    }
}
