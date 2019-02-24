using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OperationManualCreator.Common;

namespace OperationManualCreator.ViewModel
{
    class ManualCreationWindowViewModel : ViewModelBase
    {
        #region メンバ変数
        private String largeTitle;
        private String midiumTitle;
        private String smallTitle;
        private String operationText;
        private String notes;

        private DelegateCommand startOperationCommand;
        private DelegateCommand exitCommand;

        #endregion

        #region コンストラクタ
        public ManualCreationWindowViewModel()
        {
        }
        #endregion

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

    }
}
