using System;
using System.Windows;

using OperationManualCreator.Common;
using OperationManualCreator.Model;
using System.IO;
using System.Linq;

namespace OperationManualCreator.ViewModel
{
    class ManualCreationWindowViewModel : Livet.ViewModel
    {
        #region メンバ変数
        private String largeTitle;
        private String midiumTitle;
        private String smallTitle;
        private String operationText;
        private String notes;

        private Window _manualCreationWindow;

        // 手順のページ数初期値1
        // 次の手順が実行されるたびにインクリメントする。
        private Int32 pageNumber = 1;

        private DelegateCommand monitorCaptureCommand;
        private DelegateCommand nextOperationCommand;
        private DelegateCommand<object> exitOperationCreateCommand;
        #endregion

        #region コンストラクタ
        public ManualCreationWindowViewModel()
        {
        }
        #endregion

        #region 操作
        #region 画面キャプチャ
        /// <summary>
        /// 画面キャプチャのコマンド
        /// </summary>
        public DelegateCommand MonitorCaptureCommand
        {
            get
            {
                if (this.monitorCaptureCommand == null)
                {
                    this.monitorCaptureCommand = new DelegateCommand(MonitorCaptureExecute, CanMonitorCaptureExecute);
                }

                return this.monitorCaptureCommand;
            }
        }

        /// <summary>
        /// 画面キャプチャのコマンドの実行を行います。
        /// </summary>
        private void MonitorCaptureExecute()
        {
            try
            {
                _manualCreationWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

                // 画面を最小化する
                _manualCreationWindow.WindowState = WindowState.Minimized;

                // 画面キャプチャ
                // ページ番号毎のキャプチャをとる。
                CreateScreenShot screenShot = new CreateScreenShot();
                screenShot.CreateAndSaveScreenShot(PageNumber);
            }
            finally
            {
                // 画面の表示を元に戻す
                _manualCreationWindow.WindowState = WindowState.Normal;
            }

        }

        /// <summary>
        /// 画面キャプチャが実行可能かどうかの判定を行います。
        /// </summary>
        /// <returns></returns>
        private bool CanMonitorCaptureExecute()
        {
            // 無条件で実行可能
            // ボタン押す度に上書き保存される
            return true;
        }
        #endregion

        #region 次の手順
        /// <summary>
        /// 次の手順のコマンド
        /// </summary>
        public DelegateCommand NextOperationCommand
        {
            get
            {
                if (this.nextOperationCommand == null)
                {
                    this.nextOperationCommand = new DelegateCommand(NextOperationExecute, CanNextOperationExecute);
                }

                return this.nextOperationCommand;
            }
        }

        /// <summary>
        /// 次の手順のコマンドの実行を行います。
        /// </summary>
        private void NextOperationExecute()
        {
            // 現在のページの内容をXMLに保存する
            String saveFileName = Define.CAPTURES_FILE_PREFIX + PageNumber.ToString() + ".png";
            String saveFilePath = Path.Combine(Define.CAPTURES_FOLDER_PATH, saveFileName);

            var xmlSerializer = new XMLSerializer();
            xmlSerializer.SaveCurrentPageForXML(PageNumber, LargeTitle, MidiumTitle, SmallTitle, OperationText,
                Notes, saveFilePath);

            // 画面上の表示をクリア・更新する
            LargeTitle = String.Empty;
            MidiumTitle = String.Empty;
            SmallTitle = String.Empty;
            OperationText = String.Empty;
            Notes = String.Empty;

            // ページ番号を更新
            PageNumber++;
        }

        /// <summary>
        /// 次の手順が実行可能かどうかの判定を行います。
        /// </summary>
        /// <returns></returns>
        private bool CanNextOperationExecute()
        {
            bool isExistsOperationManualInformation = false;

            // 最低限キャプチャと手順が入力されていなければ次の手順を入力できない
            String saveFileName = Define.CAPTURES_FILE_PREFIX + PageNumber.ToString() + ".png";
            String saveFilePath = Path.Combine(Define.CAPTURES_FOLDER_PATH, saveFileName);
            
            if (File.Exists(saveFilePath) &&
                !String.IsNullOrEmpty(OperationText))
            {
                isExistsOperationManualInformation = true;
            }

            return isExistsOperationManualInformation;
        }
        #endregion


        #region 手順作成の終了
        /// <summary>
        /// 手順作成終了のコマンド
        /// </summary>
        public DelegateCommand<object> ExitOperationCreateCommand
        {
            get
            {
                if (this.exitOperationCreateCommand == null)
                {
                    this.exitOperationCreateCommand = new DelegateCommand<object>(ExitOperationCreateExecute, CanExitOperationCreateExecute);
                }

                return this.exitOperationCreateCommand;
            }
        }

        /// <summary>
        /// 手順作成終了のコマンドの実行を行います。
        /// ※コマンドの引数として受け取ったウィンドウに対してClose実行するパターン
        /// </summary>
        private void ExitOperationCreateExecute(object window)
        {
            // 現在のページの内容をXMLに保存する
            String saveFileName = Define.CAPTURES_FILE_PREFIX + PageNumber.ToString() + ".png";
            String saveFilePath = Path.Combine(Define.CAPTURES_FOLDER_PATH, saveFileName);

            var xmlSerializer = new XMLSerializer();
            xmlSerializer.SaveCurrentPageForXML(PageNumber, LargeTitle, MidiumTitle, SmallTitle, OperationText,
                Notes, saveFilePath);
            
            if (window != null)
            {
                // ウィンドウを閉じる
                Window manualCreationWindow = (Window)window;
                manualCreationWindow.Close();
            }
        }

        /// <summary>
        /// 手順作成の終了が実行可能かどうかの判定を行います。
        /// </summary>
        /// <returns></returns>
        private bool CanExitOperationCreateExecute(object window)
        {
            // 無条件で実行可能
            return true;
        }
        #endregion
        #endregion

        #region プロパティ
        /// <summary>
        /// 大タイトル
        /// </summary>
        public String LargeTitle
        {
            get
            {
                return this.largeTitle;
            }

            set
            {
                this.largeTitle = value;
                this.RaisePropertyChanged("LargeTitle");
            }
        }

        /// <summary>
        /// 中タイトル
        /// </summary>
        public String MidiumTitle
        {
            get
            {
                return this.midiumTitle;
            }

            set
            {
                this.midiumTitle = value;
                this.RaisePropertyChanged("MidiumTitle");
            }
        }

        /// <summary>
        /// 小タイトル
        /// </summary>
        public String SmallTitle
        {
            get
            {
                return this.smallTitle;
            }

            set
            {
                this.smallTitle = value;
                this.RaisePropertyChanged("SmallTitle");
            }
        }

        /// <summary>
        /// 手順
        /// </summary>
        public String OperationText
        {
            get
            {
                return this.operationText;
            }

            set
            {
                this.operationText = value;
                this.RaisePropertyChanged("OperationText");
            }
        }

        /// <summary>
        /// 注意事項
        /// </summary>
        public String Notes
        {
            get
            {
                return this.notes;
            }

            set
            {
                this.notes = value;
                this.RaisePropertyChanged("Notes");
            }
        }

        /// <summary>
        /// ページ数
        /// </summary>
        public Int32 PageNumber
        {
            get
            {
                return this.pageNumber;
            }

            set
            {
                this.pageNumber = value;
                this.RaisePropertyChanged("PageNumber");
            }
        }
        #endregion

    }
}
