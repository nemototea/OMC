   M S B A M L   `   `   `  ����Q  MOperationManualCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:OperationManualCreator.ViewModel OperationManualCreator.ViewModel  5	   	   I)clr-namespace:OperationManualCreator.ViewOperationManualCreator.View  5
   	   ,    &OperationManualCreator.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   L HLivet, Version=1.3.0.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cb.l&http://schemas.livet-mvvm.net/2011/wpf  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   7vm.clr-namespace:OperationManualCreator.ViewModel  5	   	   1v)clr-namespace:OperationManualCreator.View  5
   	   -   5          �Name$
  Main��5   	    � Title$ OperationManualCreator��5   	   $	��400��5   	   $��71��5   	    � SizeToContent$ Height=�5   	    J� SnapsToDevicePixels . $��Yu Gothic UI Semilight)�5   $    � Icon$? 9/OperationManualCreator;component/Resources/SmallIcon.ico��6H   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    � MappingMode$ RelativeToBoundingBox=�6/    �� 
StartPoint$ 0.5,0&�6S   .��5      �  � Color$ Black��6   � 5      $ 	#FF00E8FF��6   	 � Offset$	 1Q�6-   5      ��5      
� 5   
   .��5      � $ Black��6   $	 0Q�6)   � 5      $ White��6   $	 1Q�6)   5      
 � DataContext
 5      :   4OperationManualCreator.ViewModel.MainWindowViewModel  5   
   .  (System.Windows.Interactivity.Interaction   Triggers 5!      9  3Livet.Behaviors.Messaging.InteractionMessageTrigger  5"   
      
MessageKey$% ShowManualCreationWindowCommand��6&      	Messenger 6S   �� *	Messenger+.  (System.Windows.Interactivity.TriggerBase   Actions. 5%      B  <Livet.Behaviors.Messaging.TransitionInteractionMessageAction     
WindowType6   0OperationManualCreator.View.ManualCreationWindow"  63      Mode$ Modal=�6`   �  �Livet.Behaviors.Messaging.InteractionMessageAction`1[[System.Windows.FrameworkElement, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]])   "InvokeActionOnlyWhenWindowIsActive .  5&   3   5'      .��5*      �  � ColumnDefinitions 5+   
   �� 5,      $��10 �6   �� 5-      $��* �6   �� 5.      $��10 �6   �� 5/      $��* �6   �� 50      $��10 �6   �� 51      $��* �6   �� 52      $��10 �6    � RowDefinitions 54   
   �� 55      $��10 �6   �� 56      $��* �6   �� 57      $��10 �6   .+�5;   
   �� $��手順の作成��6   $��1��6~   $��1��6�   $��1��6�   ��6!   ��  �� Path$ StartOperationCommand���6P   ��  �� ElementName$
 Main��6�   �� 5<   
   $!��手順のエクスポート��6   $��3��6Q   $��1��6a   $��1��6n   ��6%   �� $ StartExportCommand�6n   �� 5=   
   $��終了��6   $��5��6C   $��1��6S   $��1��6`   ��6   �� $ ExitCommand�6`   5>      5?      