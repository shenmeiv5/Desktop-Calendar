using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * *********************
 * 创建时间：2018/10/8
 * 创建人：HYJ
 * 文件描述：SolarData类（公历数据类）存储静态公历相关数据和数据转换
 * *********************
 */
namespace Calendar_HYJ
{
    /// <summary>
    /// 静态公历数据类
    /// </summary>
    static class SolarData
    {
        /// <summary>
        /// 星期字符串 例如：一
        /// </summary>
        static  public string[] weekOfDayStr = { "", "一", "二", "三", "四", "五", "六", "日" };
        /// <summary>
        /// 星期长字符串 例如：星期一
        /// </summary>
        static public string[] weekOfDayLongStr = { "", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };
    }
}
