   M S B A M L   `   `   `  ���� J  FWPFAppConverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPFAppConverterWPFAppConverter  O,clr-namespace:WPFAppConverter.MVVM.ViewModelWPFAppConverter.MVVM.ViewModel       WPFAppConverter.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WPFAppConverter     B	viewModel,clr-namespace:WPFAppConverter.MVVM.ViewModel     -      currentViewModel  � DataContext#  [    
TitleForms � Title# [ $	��450��$	��840�� � WindowStyle$
 None=� � AllowsTransparency$
 True��  MainBackgroung#���  $	��750��$	��450��.���  � RowDefinitions �� $��25 ��� $��* �.+��� -     WindowBorderHeaderStyle#���  ._�� .+��� #��[ $��Center=�  WindowLableHeaderStyle#���  $��0, -12q���  �� Orientation$ 
Horizontal=�$��Right=�$��Center=�.+��� -   $
��Auto��$��25��  HeaderButton#���  $��_���� -    ��Name$ MaxBtn��$
��Auto��$��25��#���  $	��☐���� -   $
��Exit��$
��Auto��$��40��#���  $	��⨉��$��16(�� $��1�� � ColumnDefinitions �� $��60 ��� $��* �.+���   LeftNavPanel#���  ._��  �� $��* ��� $��50 �.+��� .+�	�   MainNavPanel_RadioButton#���  
 � Tag$
 Home��	 � ToolTip$
	 Home������ *HomeCommand+�� $
��10,5q�	� #���  $ Analitic��$	 Assets������ *AnaliticCommand+	� #���  $ Convert��$	 Convert������ *ConvertCommand+�� $
��10,5q�	� #���  $ 	Exchanges��$	 	Exchanges������ *ExchangeCommand+�� $
��10,5q�	� #���  $ Setting��$��1��$	 Setting������ *SettingCommand+ � $��1��
  � NavigationUIVisibility$
 Hidden=����� *CurrentView+� $��1�� J� Opacity$	 0.1Q�.+��� -    ��Name$ WindowResizeBottomLeft��$��4��$��4��$
��Left=�$��Bottom=� � Cursor$ SizeNESW����Z� �� -   $ WindowResizeBottomRight��$��4��$��4��$��Right=�$��Bottom=�$ SizeNWSE����Z� �� -   $ WindowResizeLeft��$��2�����#000$
��Left=�$��Stretch=�$ SizeWE����Z� �� -	   $ WindowResizeRight��$��2�����#000$��Right=�$��Stretch=�$ SizeWE����Z� �� -
   $ WindowResizeBottom��$��2�����#000$��Stretch=�$��Bottom=�$ SizeNS����Z� 