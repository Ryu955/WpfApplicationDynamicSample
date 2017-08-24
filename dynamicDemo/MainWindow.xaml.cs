using System;
using System.Windows;
using System.Windows.Threading;

namespace DynamicDemo {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        private DispatcherTimer dispatcherTimer;
        private int countUp = 0;

        public MainWindow() {
            InitializeComponent();
            FixedTimeProcess();
        }

        /// <summary>
        /// 一定時間でDispatcherTimerTickを実行する関数
        /// </summary>
        private void FixedTimeProcess() {
            //初期化
            dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            //左から　日数、時間、分、秒、ミリ秒で設定
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            dispatcherTimer.Tick += new EventHandler(DispatcherTimerTick);
            dispatcherTimer.Start();
        }

        /// <summary>
        /// FixedTimeProcessで実行される関数
        /// </summary>
        private void DispatcherTimerTick(object sender, EventArgs e) {
            countUp++;
            this.Resources["count"] = countUp;
        }

    }



}
