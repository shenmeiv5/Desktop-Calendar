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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.ComponentModel;

namespace Calendar_HYJ
{
    /// <summary>
    /// FrontWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FrontWindow : Window
    {
        /// <summary>
        /// 窗口位置记录
        /// </summary>
        private Point lastWinLocation;
        /// <summary>
        /// 计时器
        /// </summary>
        private DispatcherTimer showTimer;
        /// <summary>
        /// 窗口位置
        /// </summary>
        public WindowApplicationSettings settings = new WindowApplicationSettings(); 
        public FrontWindow()
        {
            InitializeComponent();
            this.tbShowDay.Text = DateTime.Now.Day.ToString();
            this.Closing += new CancelEventHandler(Winodw_Closing);
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            
        }
        /// <summary>
        /// 启动定时器
        /// </summary>
        private void StartShowTimer()
        {
            showTimer = new DispatcherTimer();
            showTimer.Tick += new EventHandler(ShowTimer);
            showTimer.Interval = new TimeSpan(0, 0, 1, 0);//一分钟
            showTimer.Start();
        }

        public void ShowTimer(object sender, EventArgs e)
        {
            this.tbShowDay.Text = DateTime.Now.Day.ToString();
        }

        private void Winodw_Closing(object sender, CancelEventArgs e)
        {
            settings.WinLocation = new Point(this.Left, this.Top);
            settings.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            settings.Reload();
            this.Left = settings.WinLocation.X;
            this.Top = settings.WinLocation.Y;
            this.lastWinLocation = settings.WinLocation;
        }
        /// <summary>
        /// 左键拖动窗体
        /// </summary>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            this.lastWinLocation.X = this.Left;
            this.lastWinLocation.Y = this.Top;
        }
        /// <summary>
        /// 左键单击 显示主窗体
        /// </summary>
        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.lastWinLocation == new Point(this.Left, this.Top))
            {
                MainWindow mw = new MainWindow();
                this.Visibility = Visibility.Hidden;
                mw.Left = this.Left - 250;
                mw.Top = this.Top;
                mw.ShowDialog();
                this.Visibility = Visibility.Visible;
            }
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            this.tbCancel.Visibility = Visibility.Visible;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            this.tbCancel.Visibility = Visibility.Hidden;
        }

        private void Window_Closed(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
