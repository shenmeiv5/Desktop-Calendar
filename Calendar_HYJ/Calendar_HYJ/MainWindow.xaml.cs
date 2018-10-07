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
        CalendarData cd = new CalendarData(DateTime.Today.Year, DateTime.Today.Month);
        public MainWindow()
        {
            InitializeComponent();
            this.btYearMonthTool.DataContext = cd.SelYear.ToString() + "年" + cd.SelMonth.ToString() + "月"; 
            InitialMainRegion();
            //InitialTest();
        }
        private void InitialMainRegion()
        {
            this.wpMainRegion.DataContext = cd;
            Style btDayTemplate = (Style)this.FindResource("Day_ButtonTemplate");
            Style tbDayTemplate = (Style)this.FindResource("Day_TextBlockTemplate");
            for (int i = 0; i < 7; i++)
            {
                Button bt = new Button();
                bt.Style = tbDayTemplate;
                bt.DataContext = (i+1).ToString();

                wpMainRegion.Children.Add(bt);
            }
            for (int i = 0; i < 35; i++)
            {
                Button bt = new Button();
                bt.Style = btDayTemplate;
                bt.DataContext = cd.SelDays[i];

                wpMainRegion.Children.Add(bt);
            }
        }


        /*
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
            
            Style btDayTemplate = (Style)this.FindResource("Day_ButtonTemplate");
            Style tbDayTemplate = (Style)this.FindResource("Day_TextBlockTemplate");
            for (int i = 0; i < 7; i++)
            {
                Button bt = new Button();
                bt.Style = tbDayTemplate;
                bt.DataContext = i.ToString();
                
                //wpMainRegion.Children.Add(bt);
            }
            for (int i = 0; i < 35; i++)
            {
                
                Button bt = new Button();
                
                bt.Style = btDayTemplate;
                bt.DataContext = cd.SelDays[i];
                //wpMainRegion.Children.Add(bt);
            }
            for (int i = 0; i < 12; i++)
            {
                Button bt = new Button();
                bt.Style = (Style)this.FindResource("MonthYear_ButtonTemplate");
                bt.DataContext = i.ToString();
                wpMainRegion.Children.Add(bt);
            }
        }
        */
    }
}
