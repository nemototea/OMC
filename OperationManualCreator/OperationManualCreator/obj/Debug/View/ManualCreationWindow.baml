   M S B A M L   `   `   `  ����Q  MOperationManualCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:OperationManualCreator.ViewModel OperationManualCreator.ViewModel  5   	   I)clr-namespace:OperationManualCreator.ViewOperationManualCreator.View  5   	   6    0OperationManualCreator.View.ManualCreationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   =vm.clr-namespace:OperationManualCreator.ViewModel     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7v)clr-namespace:OperationManualCreator.View     5   	   -   5          �Name$  ManualCreation��5   	    � Title$ 手順の作成��5
   	   $	��480��6   $	��500��6$    � Icon$? 9/OperationManualCreator;component/Resources/SmallIcon.ico��60    � DataContext 5      D  >OperationManualCreator.ViewModel.ManualCreationWindowViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $	��100 �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $	��100 �6   �� 5      $��10 �6   �� 5      $	��100 �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $��30 �6   �� 5      $��10 �6   �� 5      $��30 �6   �� 5      $��* �6   $��30��6'   �� 5      $��* �6   $��30��6'   �� 5       $��* �6   $��30��6'   �� 5!      $��10 �6   �� 5"      $��* �6   $	��120��6'   �� 5#      $��* �6   $��90��6'   �� 5$      $��10 �6   �� 5%      $��30 �6   �� 5&      $��10 �6   .+�5*   
   �� $��画面キャプチャ��6   $��1��6�   $��1��6�   $��1��6�   ��6#   ��  �� Path$ MonitorCaptureCommand���6R   ��  �� ElementName$ ManualCreation��6�   �� 5+   
   $��次の手順��6   $��4��6N   $��11��6^   $��1��6l   ��6    �� $ NextOperationCommand�6l   �� 5,   
   $��終了��6   $��6��6�   $��11��6�   $��1��6�   ��6   �� $  ExitOperationCreateCommand���6R   �� $ ManualCreation��6�   �� 5/   
   -   5         ��Name$ captureLabel��5/      $O��Iこのウィンドウを最小化し 全画面をキャプチャします��6&   $��3��6J   $
��10,0q�6Z   $��1��6h   $��4��6u   �� 50   
   -   5        $ largeTitleLabel��50      $��大タイトル��6)   $��1��69   $��	10,0,10,3q�6I   $��4��6\   $��1��6i   �� 51   
   -   5        $ midiumTitleLabel��51      $��中タイトル��6*   $��1��6:   $��	10,0,10,3q�6J   $��5��6]   $��1��6j   �� 52   
   -   5        $ smallTitleLabel��52      $��小タイトル��6)   $��1��69   $��	10,0,10,3q�6I   $��6��6\   $��1��6i   �� 53   
   -   5        $ operationTextLabel��53      $��手順��6,   $��1��69   $��
10,0,10,90q�6I   $��8��6]   $��1��6j   �� 54   
   -   5        $ 
notesLabel��54      $��注意事項��6$   $��1��63   $��
10,0,10,60q�6C   $��9��6W   $��1��6d   �� 55   
   -   5        $ pageNumberLabel1��55      $��手順��6*   $��1��67   $��	10,0,46,0q�6G   $��11��6Z   $��1��6h   $��14.667(�6|   �� 56   
   -	   5        $ pageNumberLabel2��56      $��1��6{   $��	54,0,10,0q�6�   $��11��6�   $��1��6�   $��14.667(�6�   ��6*   �� *
PageNumber+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   �� 59   
   -
   5         ��Name$ groupBox��59      $��1��6%   $��タイトル(見出し)��65   $��	0,10,10,0q�6H   $��3��6[   $��6��6h   $��5��6|   �� 5<   
   -   5         ��Name$ largeTitleTextBox��5<      $��3��6{   $��	21,5,26,0q�6�   $��4��6�    �� TextWrapping$
 Wrap=�6�   $��4��6�   ��6-   �� *
LargeTitle+$	 TwoWay=�$
 PropertyChanged=�6�   �� 5=   
   -   5        $ mudiumTitleTextBox��5=      $��3��6}   $��	21,5,26,0q�6�   $��5��6�   $
 Wrap=�6�   $��4��6�   ��6.   �� *MidiumTitle+$	 TwoWay=�$
 PropertyChanged=�6�   �� 5>   
   -   5        $ smallTitleTextBox��5>      $��3��6{   $��	21,5,26,0q�6�   $��6��6�   $
 Wrap=�6�   $��4��6�   ��6-   �� *
SmallTitle+$	 TwoWay=�$
 PropertyChanged=�6�   �� 5?   
   -   5        $ operationTextBox��5?      $��1��6}   $��
77,5,10,10q�6�   $��8��6�   $
 Wrap=�6�   $��6��6�   ��6,   �� *OperationText+$	 TwoWay=�$
 PropertyChanged=�6�   �� 5@   
   -   5        $ notesTextBox��5@      $��1��6q   $��
77,5,10,10q�6�   $��9��6�   $
 Wrap=�6�   $��6��6�   ��6(   �� *Notes+$	 TwoWay=�$
 PropertyChanged=�6�   5B      5C      