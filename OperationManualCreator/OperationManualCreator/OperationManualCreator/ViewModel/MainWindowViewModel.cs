using System.Collections.Generic;
using System.Linq;
using System.Windows;
using OperationManualCreator.Common;

namespace OperationManualCreator.ViewModel
{
    /// <summary>
    /// MainViewのViewModel
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        #region メンバ変数
        private DelegateCommand startOperationCommand;
        private DelegateCommand startExportCommand
        private DelegateCommand exitCommand;
        #endregion

        #region コンストラクタ
        public MainWindowViewModel()
        {
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
            // 手順の作成ウィンドウの表示
            // ☆★☆TODO:ほんとは、メインウィンドウのVMが直接別ウィンドウを表示しちゃダメ


            var creationWindow = new View.ManualCreationWindow();
            creationWindow.ShowDialog();
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
                    this.startExportCommand = new DelegateCommand(StartOperationExecute, CanStartOperationExecute);
                }

                return this.startExportCommand;
            }
        }

        /// <summary>
        /// 手順のエクスポートのコマンドの実行を行います。
        /// </summary>
        private void StartExportExecute()
        {
            // 手順のエクスポートウィンドウの表示
            // ☆★☆TODO:ほんとは、メインウィンドウのVMが直接別ウィンドウを表示しちゃダメ

            // 進捗ダイアログ～メッセージボックスを表示させる予定！！！
            var exportPreparationWindow = new View.ExportPreparationWindow();
            exportPreparationWindow.ShowDialog();
        }

        /// <summary>
        /// 手順のエクスポートが実行可能かどうかの判定を行います。
        /// </summary>
        /// <returns></returns>
        private bool CanStartExportExecute()
        {
            // TODO：手順書情報が一切ない場合はボタンをDisableにする。
            return true;
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
