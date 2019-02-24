using System;
using System.Drawing;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

using OperationManualCreator.Common;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace OperationManualCreator.Model
{
    public class CreateScreenShot
    {
        /// <summary>
        /// 画面キャプチャを作成＆保存する
        /// </summary>
        public void CreateAndSaveScreenShot(Int32 pageNumber)
        {
            System.Threading.Thread.Sleep(500);
            String saveFileName = Define.CAPTURES_FILE_PREFIX + pageNumber.ToString() + ".png";
            String saveFilePath = Path.Combine(Define.CAPTURES_FOLDER_PATH, saveFileName);
            
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, rectangle.Size, CopyPixelOperation.SourceCopy);
            }

            bitmap.Save(saveFilePath, ImageFormat.Png);
        }
    }
}
