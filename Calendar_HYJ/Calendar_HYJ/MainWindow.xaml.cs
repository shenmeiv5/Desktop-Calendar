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
using System.Windows.Threading;

namespace Calendar_HYJ
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        CalendarData cd = new CalendarData(DateTime.Today.Year, DateTime.Today.Month);
        private DispatcherTimer showTimer;
        public MainWindow()
        {
            InitializeComponent();

            showTimer = new DispatcherTimer();
            showTimer.Tick += new EventHandler(ShowTimer);
            showTimer.Interval = new TimeSpan(0, 0, 0, 1);
            showTimer.Start();

            this.btYearMonthTool.DataContext = cd; 
            InitialMainRegion();
            //InitialTest();
        }

        public void ShowTimer(object sender, EventArgs e)
        {
            this.Timer.Text = DateTime.Now.ToString();
        }
        /// <summary>
        /// 初始化主要区域
        /// </summary>
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
            for (int i = 0; i < 42; i++)
            {
                Button bt = new Button();
                bt.Style = btDayTemplate;
                bt.DataContext = cd.SelDays[i];

                wpMainRegion.Children.Add(bt);
            }
        }
        /// <summary>
        /// 上个月
        /// </summary>
        private void btLastMonth_Click(object sender, RoutedEventArgs e)
        {
            if (cd.SelMonth == 1)
            {
                cd.SelYear -= 1;
                cd.SelMonth = 12;
            }
            else
            {
                cd.SelMonth -= 1;
            }
        }
        /// <summary>
        /// 下个月
        /// </summary>
        private void btNextMonth_Click(object sender, RoutedEventArgs e)
        {
            if (cd.SelMonth == 12)
            {
                cd.SelYear += 1;
                cd.SelMonth = 1;
            }
            else
            {
                cd.SelMonth += 1;
            }
        }
    }
}
