using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManualCreator.Common
{
    public class Define
    {
        #region アプリケーション
        /// <summary>
        /// アプリケーション名
        /// </summary>
        public static String ALLPICATION_NAME = "OperationManualCreator";
        #endregion

        #region 汎用パス
        /// <summary>
        /// ユーザーデータ用フォルダパス
        /// ※%LOCALALLPDATA%下
        /// </summary>
        public static String USERDATA_FOLDER_PATH = System.Windows.Forms.Application.LocalUserAppDataPath;
        
        /// <summary>
        /// 設定ファイル(Common)フォルダパス
        /// </summary>
        public static String SETTING_COMMON_FOLDER_PATH = Path.Combine(USERDATA_FOLDER_PATH, "Common");

        /// <summary>
        /// 画面キャプチャ格納用フォルダパス
        /// </summary>
        public static String CAPTURES_FOLDER_PATH = Path.Combine(USERDATA_FOLDER_PATH, "ScreenCaptures");
        #endregion

        #region 設定ファイル・データ
        /// <summary>
        /// 手順書情報のファイル名
        /// </summary>
        public static String OPERATION_MANUAL_INFO_FILE_NAME = "OperationManualInfo.xml";

        /// <summary>
        /// 画面キャプチャファイル名(接頭辞)
        /// ※末尾にページ番号を付与する想定
        /// </summary>
        public static String CAPTURES_FILE_PREFIX = "OperatingProcedure";

        /// <summary>
        /// 手順書情報XMLのパス
        /// </summary>
        public static String OPERATION_MANUAL_INFO_PATH = 
            Path.Combine(SETTING_COMMON_FOLDER_PATH, OPERATION_MANUAL_INFO_FILE_NAME);
        #endregion


    }
}
