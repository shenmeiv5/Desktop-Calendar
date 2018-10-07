using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * *********************
 * 创建日期：2018/10/6
 * 创建人：HYJ
 * 文件描述：LunarData类（农历数据类）存储静态农历相关数据和数据转换
 * *********************
 */
namespace Calendar_HYJ
{
    /// <summary>
    /// 静态农历数据类
    /// </summary>
    static class LunarData
    {
        ///数据结构 二级制: 
        ///第1-4位:   闰月月份 1-12，没有为0
        ///第5-16位: 月份天数，16位为1月，1为30天，0位29天
        ///第17位：  闰月天数，1位30天,0位28天
        static public long[] lunarInfo = {   //农历数据来源于香港天文台（地址：https://data.weather.gov.hk/gts/time/conversion1_text_c.htm）
            0x04bd8, 0x04ae0, 0x0a570, 0x054d5, 0x0d260, 0x0d950, 0x16554, 0x056a0, 0x09ad0, 0x055d2,//1900-1909
            0x04ae0, 0x0a5b6, 0x0a4d0, 0x0d250, 0x1d255, 0x0b540, 0x0d6a0, 0x0ada2, 0x095b0, 0x14977,//1910-1919
            0x04970, 0x0a4b0, 0x0b4b5, 0x06a50, 0x06d40, 0x1ab54, 0x02b60, 0x09570, 0x052f2, 0x04970,//1920-1929
            0x06566, 0x0d4a0, 0x0ea50, 0x06e95, 0x05ad0, 0x02b60, 0x186e3, 0x092e0, 0x1c8d7, 0x0c950,//1930-1939
            0x0d4a0, 0x1d8a6, 0x0b550, 0x056a0, 0x1a5b4, 0x025d0, 0x092d0, 0x0d2b2, 0x0a950, 0x0b557,//1940-1949
            0x06ca0, 0x0b550, 0x15355, 0x04da0, 0x0a5b0, 0x14573, 0x052b0, 0x0a9a8, 0x0e950, 0x06aa0,//1950-1959
            0x0aea6, 0x0ab50, 0x04b60, 0x0aae4, 0x0a570, 0x05260, 0x0f263, 0x0d950, 0x05b57, 0x056a0,//1960-1969
            0x096d0, 0x04dd5, 0x04ad0, 0x0a4d0, 0x0d4d4, 0x0d250, 0x0d558, 0x0b540, 0x0b6a0, 0x195a6,//1970-1979
            0x095b0, 0x049b0, 0x0a974, 0x0a4b0, 0x0b27a, 0x06a50, 0x06d40, 0x0af46, 0x0ab60, 0x09570,//1980-1989
            0x04af5, 0x04970, 0x064b0, 0x074a3, 0x0ea50, 0x06b58, 0x055c0, 0x0ab60, 0x096d5, 0x092e0,//1990-1999
            0x0c960, 0x0d954, 0x0d4a0, 0x0da50, 0x07552, 0x056a0, 0x0abb7, 0x025d0, 0x092d0, 0x0cab5,//2000-2009
            0x0a950, 0x0b4a0, 0x0baa4, 0x0ad50, 0x055d9, 0x04ba0, 0x0a5b0, 0x15176, 0x052b0, 0x0a930,//2010-2019
            0x07954, 0x06aa0, 0x0ad50, 0x05b52, 0x04b60, 0x0a6e6, 0x0a4e0, 0x0d260, 0x0ea65, 0x0d530,//2020-2029
            0x05aa0, 0x076a3, 0x096d0, 0x04afb, 0x04ad0, 0x0a4d0, 0x1d0b6, 0x0d250, 0x0d520, 0x0dd45,//2030-2039
            0x0b5a0, 0x056d0, 0x055b2, 0x049b0, 0x0a577, 0x0a4b0, 0x0aa50, 0x1b255, 0x06d20, 0x0ada0,//2040-2049
            0x14b63, 0x09370, 0x049f8, 0x04970, 0x064b0, 0x168a6, 0x0ea50, 0x06b20, 0x1a6c4, 0x0aae0,//2050-2059
            0x0a2e0, 0x0d2e3, 0x0c960, 0x0d557, 0x0d4a0, 0x0da50, 0x05d55, 0x056a0, 0x0a6d0, 0x055d4,//2060-2069
            0x052d0, 0x0a9b8, 0x0a950, 0x0b4a0, 0x0b6a6, 0x0ad50, 0x055a0, 0x0aba4, 0x0a5b0, 0x052b0,//2070-2079
            0x0b273, 0x06930, 0x07337, 0x06aa0, 0x0ad50, 0x14b55, 0x04b60, 0x0a570, 0x054e4, 0x0d160,//2080-2089
            0x0e968, 0x0d520, 0x0daa0, 0x16aa6, 0x056d0, 0x04ae0, 0x0a9d4, 0x0a2d0, 0x0d150, 0x0f252,//2090-2099
            0x0d520//2100
        };
        /// <summary>
        /// 农历月份Str数据
        /// </summary>
        static public string[] lunarMonthStrInfo = {
            "", "正月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "腊月"
        };
        static public string[] lunarDayStrInfo = {
            "",
            "初一", "初二", "初三", "初四", "初五", "初六", "初七", "初八", "初九", "初十",//1-10
            "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九", "二十",//11-20
            "廿一", "廿二", "廿三", "廿四", "廿五", "廿六", "廿七", "廿八", "廿九", "三十",//21-30
        };
        /// <summary>
        /// 农历y年闰哪个月 1-12 没有为0
        /// </summary>
        static public int LeapMonth(int y)
        {
            return (int)(lunarInfo[y - 1900] & 0xf);
        }
        /// <summary>
        /// 农历y年m月天数 29 或 30
        /// </summary>
        static public int MonthDays(int y, int m)
        {
            if ((lunarInfo[y - 1900] & (0x10000 >> m)) != 0)
                return 30;
            else
                return 29;
        }
        /// <summary>
        /// 农历y年闰月天数
        /// </summary>
        static public int LeapMonthDays(int y)
        {
            if (LeapMonth(y) != 0)
            {
                if ((int)(lunarInfo[y - 1900] & 0x10000) != 0)
                    return 30;
                else
                    return 29;
            }
            else
                return 0;
        }
        /// <summary>
        /// 农历y年总天数
        /// </summary>
        static public int LunarYearDays(int y)
        {
            int sum = 348;
            for (int i = 0x8000; i > 0x8; i >>= 1)
            {
                if ((lunarInfo[y - 1900] & i) != 0)
                    sum++;
            }

            return sum + LeapMonthDays(y);
        }
        /// <summary>
        /// 公历转农历
        /// </summary>
        /// <param name="y">公历年</param>
        /// <param name="m">公历月</param>
        /// <param name="d">公历日</param>
        /// <returns>农历年year0，农历月month1，农历日day2</returns>
        static public int[] SolarDayToLunarDay(int y, int m, int d)
        {
            //农历1900年正月初一公历日期
            DateTime baseDate = new DateTime(1900, 1, 31);
            //目标公历日期
            DateTime targetDate = new DateTime(y, m, d);
            TimeSpan ts = targetDate - baseDate;
            int totalDays = ts.Days +1 ;
            //农历数据 年0 月1 日2 闰3（1闰，0不闰
            int[] lDate = new int[4];
            for(int i=1900; i<2101 && totalDays>0; i++)
            {
                totalDays -= LunarYearDays(i);
                lDate[0] = i;
            }
            if (totalDays <= 0)
            {
                totalDays += LunarYearDays(lDate[0]);
            }
            //该农历年对应闰月
            int leapM = LeapMonth(lDate[0]);
            lDate[3] = 0;
            for (int i=1;i<13 && totalDays>0 ; i++)
            {
                if ((leapM!=0) && (i == leapM+1))
                {
                    //闰月
                    if (lDate[3] == 0)
                    {
                        totalDays -= LeapMonthDays(lDate[0]);
                        lDate[3] = 1;
                        i--;
                    }
                    else//解除闰月
                    {
                        lDate[3] = 0;
                        totalDays -= MonthDays(lDate[0], i);
                    }
                }
                else
                {
                    totalDays -= MonthDays(lDate[0], i);
                }
                lDate[1] = i;
            }
            if (totalDays <=0)
            {
                if (lDate[3] == 0)
                    totalDays += MonthDays(lDate[0], lDate[1]);
                else
                    totalDays += LeapMonthDays(lDate[0]);
            }
            lDate[2] = totalDays;

            return lDate;
        }//SolarDayToLunarDay 函数结束


    }
}
