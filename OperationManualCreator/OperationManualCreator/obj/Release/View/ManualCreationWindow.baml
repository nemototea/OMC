   M S B A M L   `   `   `  ���� Q  MOperationManualCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:OperationManualCreator.ViewModel OperationManualCreator.ViewModel  I)clr-namespace:OperationManualCreator.ViewOperationManualCreator.View  6    0OperationManualCreator.View.ManualCreationWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     =vm.clr-namespace:OperationManualCreator.ViewModel     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7v)clr-namespace:OperationManualCreator.View     -     �Name$  ManualCreation�� � Title$ 手順の作成��$	��480��$	��500�� � Icon$? 9/OperationManualCreator;component/Resources/SmallIcon.ico�� � DataContext D  >OperationManualCreator.ViewModel.ManualCreationWindowViewModel  .���  � ColumnDefinitions �� $��10 ��� $	��100 ��� $��10 ��� $��* ��� $	��100 ��� $��10 ��� $	��100 ��� $��10 � � RowDefinitions �� $��10 ��� $��30 ��� $��10 ��� $��30 ��� $��* �$��30���� $��* �$��30���� $��* �$��30���� $��10 ��� $��* �$	��120���� $��* �$��90���� $��10 ��� $��30 ��� $��10 �.+��� $��画面キャプチャ��$��1��$��1��$��1������  �� Path$ MonitorCaptureCommand�����  �� ElementName$ ManualCreation���� $��次の手順��$��4��$��11��$��1������ $ NextOperationCommand��� $��終了��$��6��$��11��$��1������ $  ExitOperationCreateCommand����� $ ManualCreation���� -    ��Name$ captureLabel��$O��Iこのウィンドウを最小化し 全画面をキャプチャします��$��3��$
��10,0q�$��1��$��4���� -   $ largeTitleLabel��$��大タイトル��$��1��$��	10,0,10,3q�$��4��$��1���� -   $ midiumTitleLabel��$��中タイトル��$��1��$��	10,0,10,3q�$��5��$��1���� -   $ smallTitleLabel��$��小タイトル��$��1��$��	10,0,10,3q�$��6��$��1���� -   $ operationTextLabel��$��手順��$��1��$��
10,0,10,90q�$��8��$��1���� -   $ 
notesLabel��$��注意事項��$��1��$��
10,0,10,60q�$��9��$��1���� -   $ pageNumberLabel1��$��手順��$��1��$��	10,0,46,0q�$��11��$��1��$��14.667(��� -	   $ pageNumberLabel2��$��1��$��	54,0,10,0q�$��11��$��1��$��14.667(����� *
PageNumber+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� -
    ��Name$ groupBox��$��1��$��タイトル(見出し)��$��	0,10,10,0q�$��3��$��6��$��5���� -    ��Name$ largeTitleTextBox��$��3��$��	21,5,26,0q�$��4�� �� TextWrapping$
 Wrap=�$��4������ *
LargeTitle+$	 TwoWay=�$
 PropertyChanged=��� -   $ mudiumTitleTextBox��$��3��$��	21,5,26,0q�$��5��$
 Wrap=�$��4������ *MidiumTitle+$	 TwoWay=�$
 PropertyChanged=��� -   $ smallTitleTextBox��$��3��$��	21,5,26,0q�$��6��$
 Wrap=�$��4������ *
SmallTitle+$	 TwoWay=�$
 PropertyChanged=��� -   $ operationTextBox��$��1��$��
77,5,10,10q�$��8��$
 Wrap=�$��6������ *OperationText+$	 TwoWay=�$
 PropertyChanged=��� -   $ notesTextBox��$��1��$��
77,5,10,10q�$��9��$
 Wrap=�$��6������ *Notes+$	 TwoWay=�$
 PropertyChanged=�