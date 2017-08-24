using System;
using System.Windows;
using System.Windows.Threading;

namespace DynamicDemo {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        private DispatcherTimer dispatcherTimer;

        private int windowWidth = 525;

        private double catleft = 0;
        private double catright = 200;

        public MainWindow() {
            InitializeComponent();
            FixedTimeProcess();
        }

        /// <summary>
        /// 一定時間でDispatcherTimerTickを実行する関数
        /// </summary>
        private void FixedTimeProcess() {
            // 初期化
            dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            // 左から　日数、時間、分、秒、ミリ秒で設定
            // 1ミリ秒ごとに30回実行
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dispatcherTimer.Tick += new EventHandler(DispatcherTimerTick);
            dispatcherTimer.Start();
        }

        /// <summary>
        /// FixedTimeProcessで実行される関数
        /// </summary>
        private void DispatcherTimerTick(object sender, EventArgs e) {

            catleft = (catleft < windowWidth / 2) ? catleft + 1 : -40;
            catright = (catleft < windowWidth / 2) ? catright - 1 : 240;

            MovePic(catleft, 84, catright, 84, "catMargin");
        }

        /// <summary>
        /// テキストの大きさを変える関数
        /// </summary>
        private void MovePic(double left, double top, double right, double bottom, string target) {
            Thickness margin = new Thickness(left, top, right, bottom);
            this.Resources[target] = margin;
        }
    }
}
