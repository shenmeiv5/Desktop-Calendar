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
        /// 计时器
        /// </summary>
        private DispatcherTimer showTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        /// <summary>
        /// 窗口位置记录
        /// </summary>
        private Point lastWinLocation;
        /// <summary>
        /// config存储数据帮助类对象
        /// </summary>
        public WindowApplicationSettings settings = new WindowApplicationSettings(); 
        public FrontWindow()
        {
            InitializeComponent();
            InitialNotifyIcon();
            StartShowTimer();
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
        /// <summary>
        /// 初始化NotifyIcon（托盘运行相关
        /// </summary>
        private void InitialNotifyIcon()
        {
            this.notifyIcon = new System.Windows.Forms.NotifyIcon();

            this.notifyIcon.Text = "Calendar";
            this.notifyIcon.Icon = new System.Drawing.Icon("G:/Git-Calendar/Calendar_HYJ/Calendar_HYJ/lcons/calendarTray.ico");
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipText = "Calendar is working";
            this.notifyIcon.ShowBalloonTip(2000);

            //设置菜单
            System.Windows.Forms.MenuItem showMenu = new System.Windows.Forms.MenuItem("Show");
            showMenu.Click += new EventHandler(ShowMenu_Click);
            System.Windows.Forms.MenuItem exitMenu = new System.Windows.Forms.MenuItem("Exit");
            exitMenu.Click += new EventHandler(ExitMenu_Click);

            //关联托盘控件
            System.Windows.Forms.MenuItem[] menus = new System.Windows.Forms.MenuItem[] { showMenu, exitMenu };
            this.notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(menus);
        }

        /// <summary>
        /// 展示菜单项
        /// </summary>
        private void ShowMenu_Click(object sender, EventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mw.Left = this.Left - 250;
            mw.Top = this.Top;
            mw.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 关闭菜单项
        /// </summary>
        private void ExitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
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
