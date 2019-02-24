using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

using OperationManualCreator.Common;


namespace OperationManualCreator.Model
{
    /// <summary>
    /// XMLルートノード
    /// </summary>
    [XmlRoot(ElementName = "root")]
    public class Root
    {
        // 子要素の定義
        [XmlElement(ElementName = "pageList")]
        public PageList PageList { get; set; }
    }

    /// <summary>
    /// ページリスト
    /// </summary>
    public class PageList
    {
        // 子要素の定義
        [XmlElement(ElementName = "page")]
        public Page Pages { get; set; }
    }


    /// <summary>
    /// ページ数
    /// </summary>
    public class Page
    {
        // 属性の定義
        [XmlAttribute(AttributeName = "no")]
        public int No { get; set; }

        // スクショ子要素の定義
        [XmlElement(ElementName = "screenCapture")]
        public ScreenCapture ScreenCapture { get; set; }

        // タイトル子要素の定義
        [XmlElement(ElementName = "title")]
        public Title Title { get; set; }

        // 手順子要素の定義
        [XmlElement(ElementName = "procedure")]
        public Procedure Procedure { get; set; }

        // 注意事項子要素の定義
        [XmlElement(ElementName = "notes")]
        public Notes Notes { get; set; }
    }

    /// <summary>
    /// タイトル(大中小)
    /// </summary>
    public class ScreenCapture
    {
        // 子要素の定義
        [XmlElement(ElementName = "path")]
        public String Path { get; set; }
    }

    /// <summary>
    /// タイトル(大中小)
    /// </summary>
    public class Title
    {
        // 子要素の定義
        [XmlElement(ElementName = "large")]
        public String Large { get; set; }

        // 子要素の定義
        [XmlElement(ElementName = "midium")]
        public String Midium { get; set; }

        // 子要素の定義
        [XmlElement(ElementName = "small")]
        public String Small { get; set; }
    }
    
    /// <summary>
    /// 手順
    /// </summary>
    public class Procedure
    {
        // 子要素の定義
        [XmlElement(ElementName = "value")]
        public String Value { get; set; }
    }

    /// <summary>
    /// 注意事項
    /// </summary>
    public class Notes
    {
        // 子要素の定義
        [XmlElement(ElementName = "value")]
        public String Value { get; set; }
    }

    /// <summary>
    /// XMLファイルの読み書きを行うクラス
    /// </summary>
    class XMLSerializer
    {
        private String xmlPath = Define.OPERATION_MANUAL_INFO_PATH;

        /// <summary>
        /// 手順をXMLに書き込む
        /// </summary>
        public void SaveCurrentPageForXML(
            Int32 i_pageNumber,
            String i_largeTitle,
            String i_mudiumTitle,
            String i_smallTitle,
            String i_operationText,
            String i_notes,
            String i_imagePath
            )
        {
            if (!File.Exists(xmlPath))
            {
                //File.Create(xmlPath).Close();

                var xdoc = new XDocument(new XDeclaration("1.0", "utf-8", null), new XElement("ManualInfoRoot"));
                xdoc.Save(xmlPath);
            }
            var xmlFile = XElement.Load(xmlPath);

            // 追加するperson
            var person = new XElement("page", new XAttribute("no", i_pageNumber),
                 new XElement("title",
                    new XElement("large", i_largeTitle),
                    new XElement("midium", i_mudiumTitle),
                    new XElement("small", i_smallTitle)
                    ),
                 new XElement("procedure",
                    new XElement("value", i_operationText)
                    ),
                 new XElement("notes", 
                    new XElement("value", i_notes)
                    ),
                 new XElement("screenCapture", i_imagePath)
            );

            // 追加するpersonをxmlFileに追加
            xmlFile.Add(person);

            // xmlを保存
            xmlFile.Save(xmlPath);
        }
    }
}
