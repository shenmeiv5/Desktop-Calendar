using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendar_HYJ
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        CalendarData cd = new CalendarData();
        public MainWindow()
        {
            InitializeComponent();

            InitialTest();
        }

        private void InitialTest()
        {
            List<DayData> days = new List<DayData>();
            for (int i = 0; i < 42; i++)
            {
                DayData d = new DayData();
                d.SolarDay = i+1;
                d.LunarDay = i;
                days.Add(d);
            }
            cd.SelDays.AddRange(days);

            wpMainRegion.DataContext = cd.SelDays;

            TextBlock tb = new TextBlock();
            

            Style dayStyle = (Style)this.FindResource("Day_WrapTemplate");
            wpMainRegion.Style = dayStyle;
            Style btDayTemplate = (Style)this.FindResource("Day_ButtonTemplate");
            for (int i = 0; i < 42; i++)
            {
                
                Button bt = new Button();
                
                bt.Style = btDayTemplate;
                bt.DataContext = cd.SelDays[i];
                wpMainRegion.Children.Add(bt);
            }

        }
    }
}
