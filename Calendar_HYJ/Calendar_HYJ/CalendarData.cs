using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * ***********************
 * 创建日期：2018/10/4
 * 创建人：HYJ
 * 文件描述：Calendar类（日历数据类
 * ***********************
 */
namespace Calendar_HYJ
{
    /// <summary>
    /// 日历数据类
    /// </summary>
    class CalendarData
    {
        /// <summary>
        /// 选择年
        /// </summary>
        private int selYear;
        /// <summary>
        /// 选择月
        /// </summary>
        private int selMonth;
        /// <summary>
        /// 选择年、月对应的日期数据
        /// </summary>
        private List<DayData> selDays;
        public int SelYear { get => selYear; set => selYear = value; }
        public int SelMonth { get => selMonth; set => selMonth = value; }
        internal List<DayData> SelDays { get => selDays; set => selDays = value; }
        /// <summary>
        /// 构造/暂时
        /// </summary>
        public CalendarData()
        {
            selDays = new List<DayData>();
        }
    }
}
