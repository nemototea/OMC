using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

using OperationManualCreator.View;

namespace OperationManualCreator
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : System.Windows.Application
    {
        /// <summary>
        /// 通知ウィンドウ表示時の画面からのマージン
        /// </summary>
        private const Int32 MAINWINDOW_DISPLAY_MARGIN = 5;

        private void Application_Startup(Object sender, StartupEventArgs e)
        {
            // メインウィンドウのインスタンス
            Window mainWindow = new MainWindow();
            
            // 起動時の表示領域を設定 - 画面右下(タスクバーの上)に表示されるよう調整するよ
            var desktop = Screen.PrimaryScreen.WorkingArea;
            mainWindow.Top = desktop.Height - (mainWindow.Height + MAINWINDOW_DISPLAY_MARGIN);
            mainWindow.Left = desktop.Left - (mainWindow.Height + MAINWINDOW_DISPLAY_MARGIN);

            // メインウィンドウには親としての自覚を持ってもらう
            mainWindow.Owner = mainWindow;

            // 表示する
            mainWindow.Show();
        }
    }
}
