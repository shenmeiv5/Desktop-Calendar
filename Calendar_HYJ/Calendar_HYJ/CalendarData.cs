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
        /// 当前年字符串数据
        /// </summary>
        private string selStrYear;
        /// <summary>
        /// 当前月字符串数据
        /// </summary>
        private string selStrMonth;
        /// <summary>
        /// 当前年月字符串数据
        /// </summary>
        private string selStrYearMonth;
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
                this.SelYearToStr();
                //激发事件
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("selYear"));
                    this.SelYearToStr();
                }
            }
        }
        public int SelMonth
        {
            get => selMonth;
            set
            {
                selMonth = value;

                this.SelMonthToStr();
                this.SynchronizationSelDays();               
            }
        }
        internal List<DayData> SelDays { get => selDays; set => selDays = value; }
        public string SelStrYear
        {
            get => selStrYear;
            set
            {
                selStrYear = value;
                this.StrYearAndMonth();
            }
        }
        public string SelStrMonth
        {
            get => selStrMonth;
            set
            {
                selStrMonth = value;
                this.StrYearAndMonth();
            }
        }
        public string SelStrYearMonth
        {
            get => selStrYearMonth;
            set
            {
                selStrYearMonth = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("selStrYearMonth"));
                }
            }
        }

        /// <summary>
        /// 构造
        /// </summary>
        public CalendarData(int y=1900, int m=1, int d=31)
        {
            this.selYear = y;
            this.selMonth = m;
            SelYearToStr();
            SelMonthToStr();
            InitialSelDays(y, m);
            SynchronizationSelDays();
        }
        /// <summary>
        /// 初始化当前日期数据
        /// </summary>
        private void InitialSelDays(int y, int m)
        {
            this.selDays = new List<DayData>();
            for (int i = 0; i < 42; i++)
            {
                DayData d = new DayData(y, m);
                selDays.Add(d);
            }
        }
        /// <summary>
        /// 同步当前年月数据
        /// </summary>
        private void SynchronizationSelYearMonth(DayData d, int m)
        {
            if (m == 0)
            {
                d.SolarYear = this.selYear - 1;
                d.SolarMonth = 12;
            }
            else if (m == 13)
            {
                d.SolarYear = this.selYear + 1;
                d.SolarMonth = 1;
            }
            else
            {
                d.SolarYear = this.selYear;
                d.SolarMonth = m;
            }
        }
        /// <summary>
        /// 同步当前日期数据
        /// </summary>
        private void SynchronizationSelDays()
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
            for (int i = 0; i < dw - 1; i++)
            {
                SynchronizationSelYearMonth(this.SelDays[i], this.selMonth - 1);
                this.SelDays[i].SolarDay = lastDays + i - dw +2;
            }
            //当前月日期
            for (int i = dw - 1; i < dw + nowDays - 1; i++)
            {
                SynchronizationSelYearMonth(this.SelDays[i], this.selMonth);
                this.SelDays[i].SolarDay = i - dw + 2;
            }
            //下个月日期
            for (int i = dw + nowDays - 1; i < 42; i++)
            {
                SynchronizationSelYearMonth(this.SelDays[i], this.selMonth + 1);
                this.SelDays[i].SolarDay = i - dw - nowDays + 2;
            }
        }//InitialSelDays 函数结束
        private void SelYearToStr()
        {
            this.SelStrYear = this.selYear.ToString() + "年";
        }
        private void SelMonthToStr()
        {
            this.SelStrMonth = this.selMonth.ToString() + "月";
        }
        private void StrYearAndMonth()
        {
            this.SelStrYearMonth = this.selStrYear + this.selStrMonth;
        }
    }
}
