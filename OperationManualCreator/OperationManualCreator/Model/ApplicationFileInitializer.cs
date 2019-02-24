using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OperationManualCreator.Common;

namespace OperationManualCreator.Model
{
    class ApplicationFileInitializer
    {
        static DirectoryInfo m_captureFolder = new DirectoryInfo(Define.CAPTURES_FOLDER_PATH);
        static DirectoryInfo m_settingCommonFolder = new DirectoryInfo(Define.SETTING_COMMON_FOLDER_PATH);

        public static void InitializeUserData()
        {
            // キャプチャされた画像ファイルを消す
            foreach (FileInfo captureFile in m_captureFolder.GetFiles())
            {
                captureFile.Delete();
            }

            // 記載内容を保持するXMLファイルを初期化する
            foreach (FileInfo settingFile in m_settingCommonFolder.GetFiles())
            {
                settingFile.Delete();
            }
        }
    }
}
