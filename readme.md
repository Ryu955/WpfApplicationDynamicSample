# [wpf]xamlで宣言したImageを動かすサンプルソース

## サンプルデモ

- 猫が左から右へ移動し続けるアプリ

![result](https://github.com/Ryu955/WpfApplicationDynamicSample/blob/media/xaml.gif)

## 解説

### Update()の実装
- UnityのUpdate()見たいな関数を作りたかった

```C#:MainWindow.xaml.cs

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
  // 一定時間毎に処理したい内容をここに記述
}
```

### 猫の画像を動かす
- 今回は左から右に動かすだけだから，marginのtopとbottomは定数とした
- marginのleftをインクリメントして，rightをデクリメントさせることで移動する
  - この時，画像本体の横幅が一定になるようにする
- 画面の端に行ったらleftとrightを初期値に戻す
- MovePic()は最初の4つの引数でmarginを設定する
  - 最後のstring型の引数で移動させたいtargetの名前をいれる

```C#:DispatcherTimerTick()
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
```
