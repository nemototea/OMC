using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

using OperationManualCreator.View;
using OperationManualCreator.Common;
using OperationManualCreator.Model;


namespace OperationManualCreator
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : System.Windows.Application
    {
        /// <summary>
        /// ウィンドウ表示時の画面からのマージン
        /// </summary>
        private const Int32 MAINWINDOW_DISPLAY_MARGIN = 5;

        private void Application_Startup(Object sender, StartupEventArgs e)
        {
            #region 起動時に設定ファイル・フォルダーを初期化する
            Directory.CreateDirectory(Define.SETTING_COMMON_FOLDER_PATH);
            Directory.CreateDirectory(Define.CAPTURES_FOLDER_PATH);

            // UserData初期化
            ApplicationFileInitializer.InitializeUserData();
            #endregion

            #region メインウィンドウ表示用
            // メインウィンドウのインスタンス
            Window mainWindow = new MainWindow();

            // 起動時の表示領域を設定 - 画面右下(タスクバーの上)に表示されるよう調整する
            var desktop = Screen.PrimaryScreen.WorkingArea;
            mainWindow.Top = desktop.Bottom - (mainWindow.Height + MAINWINDOW_DISPLAY_MARGIN);
            mainWindow.Left = desktop.Right - (mainWindow.Width + MAINWINDOW_DISPLAY_MARGIN);

            // 表示する
            mainWindow.Show();
            #endregion
        }
    }
}
