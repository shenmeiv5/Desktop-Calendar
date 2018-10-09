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
        private CalendarData cd = new CalendarData(DateTime.Today.Year, DateTime.Today.Month);
        private bool toolFlag = false;
        private DispatcherTimer showTimer;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            StartShowTimer();
            this.btYearMonthTool.DataContext = cd; 
            InitialMainRegion();
        }
        /// <summary>
        /// 启动定时器
        /// </summary>
        private void StartShowTimer()
        {
            showTimer = new DispatcherTimer();
            showTimer.Tick += new EventHandler(ShowTimer);
            showTimer.Interval = new TimeSpan(0, 0, 1);//间隔一秒
            showTimer.Start();
        }
        public void ShowTimer(object sender, EventArgs e)
        {
            cd.NowDay.SolarYear = DateTime.Now.Year;
            cd.NowDay.SolarMonth = DateTime.Now.Month;
            cd.NowDay.SolarDay = DateTime.Now.Day;
            string str = cd.NowDay.SolarYear.ToString() + "年" + cd.NowDay.SolarMonth.ToString() + "月"
                + cd.NowDay.SolarDay.ToString() + "日  " + cd.NowDay.LunarStrMonth + cd.NowDay.LunarStrDay;
            this.btDay.DataContext = str;
            this.tbLunarDay.Text = "今日 " + cd.NowDay.LunarStrMonth + cd.NowDay.LunarStrDay;
        }
        /// <summary>
        /// 窗口加载
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Color.FromRgb(70, 70, 70));
            string str = cd.NowDay.SolarYear.ToString() + "年" + cd.NowDay.SolarMonth.ToString() + "月"
                + cd.NowDay.SolarDay.ToString() + "日  " + cd.NowDay.LunarStrMonth + cd.NowDay.LunarStrDay;
            this.btDay.DataContext = str;
            this.tbLunarDay.Text = "今日 " + cd.NowDay.LunarStrMonth + cd.NowDay.LunarStrDay;
        }
        /// <summary>
        /// 初始化主要区域
        /// </summary>
        private void InitialMainRegion()
        {
            this.wpMainRegion.DataContext = cd;
            SetDayMainRegion();
        }
        /// <summary>
        /// 设置主要区域为日期模块
        /// </summary>
        private void SetDayMainRegion()
        {
            Style btDayTemplate = (Style)this.FindResource("Day_ButtonTemplate");
            Style tbDayTemplate = (Style)this.FindResource("Day_TextBlockTemplate");
            for (int i = 0; i < 7; i++)
            {
                Button bt = new Button();
                bt.Style = tbDayTemplate;
                bt.DataContext = SolarData.weekOfDayStr[i+1];

                wpMainRegion.Children.Add(bt);
            }
            for (int i = 0; i < 42; i++)
            {
                Button bt = new Button();
                bt.Style = btDayTemplate;
                if (cd.SelDays[i].SolarMonth != cd.SelMonth)
                {
                    Color color = (Color)ColorConverter.ConvertFromString("DarkGray");
                    bt.Foreground = new SolidColorBrush(color);
                }
                if (cd.SelDays[i].SolarMonth == DateTime.Now.Month && cd.SelDays[i].SolarDay == DateTime.Now.Day)
                {
                    Color color = (Color)ColorConverter.ConvertFromString("CornflowerBlue");
                    bt.Background = new SolidColorBrush(color);
                }
                bt.DataContext = cd.SelDays[i];

                wpMainRegion.Children.Add(bt);
            }
        }
        private void SetMonthMainregion()
        {
            Style btMonthTemplate = (Style)this.FindResource("MonthYear_ButtonTemplate");
            for (int i=1;i<13;i++)
            {
                Button bt = new Button();
                bt.Style = btMonthTemplate;
                bt.Click += new RoutedEventHandler(btMonth_Click);//添加Click事件
                bt.DataContext = i.ToString() + "月";
                wpMainRegion.Children.Add(bt);
            }
        }
        private bool IsToday(DayData d)
        {
            return false;
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
            wpMainRegion.Children.Clear();
            SetDayMainRegion();
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
            wpMainRegion.Children.Clear();
            SetDayMainRegion();
        }
        /// <summary>
        /// 更改选择年月_(只实现了更改月
        /// </summary>
        private void btYearMonthTool_Click(object sender, RoutedEventArgs e)
        {
            this.toolFlag = !this.toolFlag;
            if (this.toolFlag == true)
            {
                wpMainRegion.Children.Clear();
                //cd.SelStrMonth = "";
                SetMonthMainregion();
            }
            else
            {
                wpMainRegion.Children.Clear();
                //cd.SelMonthToStr();
                SetDayMainRegion();
            }
        }
        /// <summary>
        /// 选择月
        /// </summary>
        private void btMonth_Click(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;//捕获当前Button对象
            this.cd.SelMonth = int.Parse(bt.DataContext.ToString().TrimEnd(new char[] { '月'}) );
            wpMainRegion.Children.Clear();
            SetDayMainRegion();
        }
        /// <summary>
        /// 窗体不为活动状态时
        /// </summary>
        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
