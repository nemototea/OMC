using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows;

using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

using OperationManualCreator.Common;

namespace OperationManualCreator.Model
{
    public class ExportInWordFormat
    {
        public Boolean Execute(String i_saveFilePath)
        {
            Boolean isManualExported = false;

            // 手順書情報XMLがあれば処理を行い、なければエラーメッセージ出力する。
            if (File.Exists(Define.OPERATION_MANUAL_INFO_PATH))
            {
                try
                {
                    // Word アプリケーションオブジェクトを作成
                    Word.Application wordApplication = new Word.Application();
                    // Word の GUI を起動しないようにする
                    wordApplication.Visible = false;
                    // 新規文書を作成
                    Word.Document document = wordApplication.Documents.Add();

                    // Wordに書き出すXMLの内容を読み込む
                    XDocument xml = XDocument.Load(Define.OPERATION_MANUAL_INFO_PATH);
                    XElement table = xml.Element("ManualInfoRoot");
                    var rows = table.Elements("page");

                    // ページ毎に書きだす
                    foreach (XElement row in rows)
                    {
                        XElement largeTitle = row.Element("title").Element("large");
                        XElement midiumTitle = row.Element("title").Element("midium");
                        XElement smallTitle = row.Element("title").Element("small");
                        XElement procedure = row.Element("procedure").Element("value");
                        XElement notes = row.Element("notes").Element("value");
                        XElement screenCapture = row.Element("screenCapture");

                        // 大タイトルを追加
                        AddTitle(wordApplication, ref document, largeTitle.Value,
                            WdColorIndex.wdTurquoise, 20, WdUnderline.wdUnderlineThick, true);

                        // 画像を追加
                        AddPicture(wordApplication, ref document, screenCapture.Value);

                        // 中・小タイトルを追加
                        AddTitle(wordApplication, ref document, midiumTitle.Value,
                            WdColorIndex.wdNoHighlight, 16, WdUnderline.wdUnderlineDouble, true);
                        AddTitle(wordApplication, ref document, smallTitle.Value,
                            WdColorIndex.wdNoHighlight, 14, WdUnderline.wdUnderlineNone, false);

                        // 手順の内容を追加
                        AddText(wordApplication, ref document, Word.WdColorIndex.wdBlack, procedure.Value);

                        // 注意事項を追加
                        AddNotes(wordApplication, ref document, Word.WdColorIndex.wdGreen, procedure.Value);

                        // 改ページ
                        Int32 lastPosition = GetLastPosition(ref document);
                        document.Range(lastPosition, lastPosition).InsertBreak(WdBreakType.wdPageBreak);
                    }

                    // 名前を付けて保存
                    object filename = i_saveFilePath;
                    document.SaveAs2(ref filename);

                    // 文書を閉じる
                    document.Close();
                    document = null;
                    wordApplication.Quit();
                    wordApplication = null;

                    isManualExported = true;
                    MessageBox.Show("エクスポートされました！");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("エクスポートする手順ファイルが存在しません。",
                    "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return isManualExported;
        }

        /// <summary>
        /// 文書の末尾にタイトルを追加する.
        /// </summary>
        private static void AddTitle(Word.Application wordApp, ref Word.Document document, String text, WdColorIndex color,
            Int32 fontSize, WdUnderline underline, Boolean isBold)
        {
            if (!String.IsNullOrEmpty(text))
            {
                Int32 before = GetLastPosition(ref document);
                Word.Range rng = document.Range(document.Content.End - 1, document.Content.End - 1);

                // テキストを入力
                rng.Text += text;
                Int32 after = GetLastPosition(ref document);

                // テキストのサイズを設定する
                document.Range(before, after).Font.Size = fontSize;

                // テキストに下線を設定する
                if (underline != WdUnderline.wdUnderlineNone)
                {
                    document.Range(before, after).Font.Underline = WdUnderline.wdUnderlineSingle;
                }

                // テキストの太字を設定する
                if (isBold)
                {
                    document.Range(before, after).Font.Bold = -1;

                }

                if (color != WdColorIndex.wdNoHighlight)
                {
                    // テキストを指定した色でマーカーを設定する
                    document.Range(before, after).HighlightColorIndex = color;

                    // 後続の文章にマーカーが適用されないように、末尾をwdNoHighlightに戻す。
                    document.Range(document.Content.End - 1, document.Content.End - 1).HighlightColorIndex
                        = WdColorIndex.wdNoHighlight;
                }

                // 改行を追加
                AddParagraph(wordApp, ref document);
            }

        }

        /// <summary>
        /// 文書の末尾に画像を追加する.
        /// </summary>
        private static void AddPicture(Word.Application wordApp, ref Word.Document document, String capturePath)
        {
            if (!String.IsNullOrEmpty(capturePath))
            {
                Word.Range rng = document.Range(document.Content.End - 1, document.Content.End - 1);
                object missing = Missing.Value;
                wordApp.Selection.InlineShapes.AddPicture(capturePath, missing, missing, rng);

                // 改行を追加
                AddParagraph(wordApp, ref document);
            }
        }

        /// <summary>
        /// 文書の末尾にテキストを追加する.
        /// </summary>
        private static void AddText(Word.Application wordApp, ref Word.Document document, Word.WdColorIndex color, String text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                Int32 before = GetLastPosition(ref document);
                Word.Range rng = document.Range(document.Content.End - 1, document.Content.End - 1);
                rng.Text += text;
                Int32 after = GetLastPosition(ref document);

                // フォント色設定
                document.Range(before, after).Font.ColorIndex = color;

                // 改行を追加
                AddParagraph(wordApp, ref document);
                AddParagraph(wordApp, ref document);
            }
        }


        /// <summary>
        /// 文書の末尾に注意事項を追加する.
        /// </summary>
        private static void AddNotes(Word.Application wordApp, ref Word.Document document, Word.WdColorIndex color, String text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                // 末尾にテキスト挿入
                Int32 before = GetLastPosition(ref document);
                Word.Range rng = document.Range(document.Content.End - 1, document.Content.End - 1);
                rng.Text += text;
                Int32 after = GetLastPosition(ref document);

                // フォント色設定
                document.Range(before, after).Font.ColorIndex = color;

                // 改行を追加
                AddParagraph(wordApp, ref document);

                // 外枠設定
                document.Range(before, document.Content.End - 1).Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            }
        }

        /// <summary>
        /// 文書の末尾に改行を追加する
        /// </summary>
        /// <returns></returns>
        private static void AddParagraph(Word.Application wordApp, ref Word.Document document)
        {
            Word.Range rng = document.Range(document.Content.End - 1, document.Content.End - 1);
            document.Content.Paragraphs.Add(rng);
        }

        /// <summary>
        /// 文書の末尾位置を取得する.
        /// </summary>
        /// <returns></returns>
        private static Int32 GetLastPosition(ref Word.Document document)
        {
            return document.Content.End - 1;
        }
    }
}
