using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;
/*
 * ******************
 * 创建日期：2018/10/8
 * 创建人：HYJ
 * 文件描述：Config数据存储帮助类
 * ******************
 */
namespace Calendar_HYJ
{
    /// <summary>
    /// 一个帮助类：将数据存储在Config文件中
    /// </summary>
    public class WindowApplicationSettings: ApplicationSettingsBase
    {
        [UserScopedSettingAttribute()]
        [DefaultSettingValue("100, 100")]
        public Point WinLocation
        {
            get => (Point)this["WinLocation"];
            set => this["WinLocation"] = value;
        }

    }
}
