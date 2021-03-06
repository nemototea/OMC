﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using OperationManualCreator.ViewModel;

namespace OperationManualCreator.View
{
    /// <summary>
    /// ManualCreationWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ManualCreationWindow : Window
    {
        public ManualCreationWindow()
        {
            InitializeComponent();

            this.DataContext = new ManualCreationWindowViewModel();
        }
    }
}
