using System;
using System.IO;
using System.Text;
using System.Windows;
using Livet.Messaging;
using Microsoft.Win32;

using OperationManualCreator.Common;
using OperationManualCreator.Model;


namespace OperationManualCreator.ViewModel
{
    /// <summary>
    /// MainViewのViewModel
    /// </summary>
    public class MainWindowViewModel :Livet.ViewModel
    {
        #region メンバ変数
        private DelegateCommand startOperationCommand;
        private DelegateCommand startExportCommand;
        private DelegateCommand exitCommand;

        private Window _mainWindow;

        private Boolean isManualExported = true;
        #endregion

        #region コンストラクタ
        public MainWindowViewModel()
        {

        }

        public MainWindowViewModel(Window mainWindow)
        {
            _mainWindow = mainWindow;
        }
        #endregion

        #region 手順の作成
        /// <summary>
        /// 手順の作成のコマンド
        /// </summary>
        public DelegateCommand StartOperationCommand
        {
            get
            {
                if (this.startOperationCommand == null)
                {
                    this.startOperationCommand = new DelegateCommand(StartOperationExecute, CanStartOperationExecute);
                }

                return this.startOperationCommand;
            }
        }

        /// <summary>
        /// 手順の作成のコマンドの実行を行います。
        /// </summary>
        private void StartOperationExecute()
        {
            // 手順の作成が開始されたらメインウィンドウは非表示にする
            _mainWindow.Hide();

            try
            {
                // 手順の作成ウィンドウの表示
                InteractionMessage message = new TransitionMessage(new ManualCreationWindowViewModel(), "ShowManualCreationWindowCommand");
                Messenger.Raise(message);
            }
            finally
            {
                isManualExported = false;
                _mainWindow.ShowDialog();
            }
        }

        /// <summary>
        /// 手順の作成が実行可能かどうかの判定を行います。
        /// </summary>
        /// <returns></returns>
        private bool CanStartOperationExecute()
        {
            // 無条件で実行可能
            return true;
        }
        #endregion

        #region 手順のエクスポート
        /// <summary>
        /// 手順のエクスポートのコマンド
        /// </summary>
        public DelegateCommand StartExportCommand
        {
            get
            {
                if (this.startExportCommand == null)
                {
                    this.startExportCommand = new DelegateCommand(StartExportExecute, CanStartExportExecute);
                }

                return this.startExportCommand;
            }
        }

        /// <summary>
        /// 手順のエクスポートのコマンドの実行を行います。
        /// </summary>
        private void StartExportExecute()
        {
            // 確認メッセージ表示
            var messageBoxResult = MessageBox.Show("手順をWord形式でエクスポートします。実行しますか？",
                "エクスポート", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (messageBoxResult == MessageBoxResult.No)
            {
                return;
            }

            // 名前を付けて保存
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Word形式(*.docx)|*.docx";
            bool? saveDialogResult = dlg.ShowDialog();

            if (saveDialogResult == true)
            {
                string filename = dlg.FileName;
                try
                {
                    var exportInWordFormat = new ExportInWordFormat();
                    isManualExported = exportInWordFormat.Execute(filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// 手順のエクスポートが実行可能かどうかの判定を行います。
        /// </summary>
        /// <returns></returns>
        private bool CanStartExportExecute()
        {
            bool isExistsOperationManualInformation = false;
            String saveFileName = Define.CAPTURES_FILE_PREFIX + "1.png";
            String saveFilePath = Path.Combine(Define.CAPTURES_FOLDER_PATH, saveFileName);

            // 手順書情報が一切ない場合はボタンをDisableにする。
            // 手順の作成を行わないとエクスポートさせない。
            if (File.Exists(Define.OPERATION_MANUAL_INFO_PATH) &&
                File.Exists(saveFilePath))
            {
                isExistsOperationManualInformation = true;
            }
            return isExistsOperationManualInformation;
        }
        #endregion

        #region 終了
        /// <summary>
        /// 終了処理のコマンド
        /// </summary>
        public DelegateCommand ExitCommand
        {
            get
            {
                if (this.exitCommand == null)
                {
                    this.exitCommand = new DelegateCommand(ExitExecute, CanExitExecute);
                }

                return this.exitCommand;
            }
        }

        /// <summary>
        /// 終了処理のコマンドの実行を行います。
        /// </summary>
        private void ExitExecute()
        {
            if (isManualExported == false)
            {
                // 確認メッセージ表示
                var result = MessageBox.Show("記録された手順がエクスポートされていません。終了しますか？",
                    "アプリケーション終了", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }

            // アプリケーションの終了コマンドの実行
            Application.Current.Shutdown();

        }

        /// <summary>
        /// 終了処理が実行可能かどうかの判定を行います。
        /// </summary>
        /// <returns></returns>
        private bool CanExitExecute()
        {
            // 無条件で実行可能
            return true;
        }
        #endregion
    }
}
