   M S B A M L   `   `   `  ����J  FWPFAppConverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPFAppConverterWPFAppConverter  5   	   O,clr-namespace:WPFAppConverter.MVVM.ViewModelWPFAppConverter.MVVM.ViewModel  5   	        WPFAppConverter.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPFAppConverter     5   	   B	viewModel,clr-namespace:WPFAppConverter.MVVM.ViewModel     5   	   -   5           currentViewModel  � DataContext#  [  5        
TitleForms � Title# [ 5	   	   $	��450��6-   $	��840��6:    � WindowStyle$
 None=�5
   	    � AllowsTransparency$
 True��6     MainBackgroung#���  66   $	��750��5   6   $	��450��6E   .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��* �6   .+�5   
   �� -   5          WindowBorderHeaderStyle#���  5      ._�5      � .+�5      �� #��[ 6   $��Center=�6>     WindowLableHeaderStyle#���  5      $��0, -12q�6I   �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�66   $��Center=�6R   .+�5      �� -   5        $
��Auto��5      $��25��6+     HeaderButton#���  66   $��_��6]   5      �� 5      -   5         ��Name$ MaxBtn��5   2   $
��Auto��5      $��25��6+   #���  66   $	��☐��6]   5   2   �� 5      -   5        $
��Exit��5   w   $
��Auto��6   $��40��6+   #���  66   $	��⨉��6]   $��16(�6i   5      5      5       5!      � 5$   
   $��1��6    � ColumnDefinitions 5%      �� 5&      $��60 �6#   �� 5'      $��* �6#   .+�5+      ��   LeftNavPanel#���  6   ._�5,      �  5-      �� 5.      $��* �6(   �� 5/      $��50 �6(   .+�52      �� .+�53      	�   MainNavPanel_RadioButton#���  6&   
 � Tag$
 Home��6Y   	 � ToolTip$
	 Home��54   F   ��6&   �� *HomeCommand+6F   �� 55      $
��10,5q�6$   	� 56      #���  6&   $ Analitic��6Y   $	 Assets��57   J   ��6&   �� *AnaliticCommand+6J   	� 58      #���  6&   $ Convert��6Y   $	 Convert��59   I   ��6&   �� *ConvertCommand+6I   �� 5:      $
��10,5q�6$   	� 5;      #���  6&   $ 	Exchanges��6Y   $	 	Exchanges��5<   J   ��6&   �� *ExchangeCommand+6J   �� 5=      $
��10,5q�6$   5>      	� 5?      #���  6"   $ Setting��6U   $��1��5@   E   $	 Setting��6R   ��6"   �� *SettingCommand+6R   5A      5B       � 5E      $��1��6   
  � NavigationUIVisibility$
 Hidden=�6D   ��6$   �� *CurrentView+6D   5F      � 5I   
   $��1��6    J� Opacity$	 0.1Q�6   .+�5J      �� -   5         ��Name$ WindowResizeBottomLeft��5J   -   $��4��6   $��4��6#   $
��Left=�5K   &   $��Bottom=�6A    � Cursor$ SizeNESW��6\   ��6   Z� 6\   �� 5L      -   5        $ WindowResizeBottomRight��5L   -   $��4��6   $��4��6#   $��Right=�5M   &   $��Bottom=�6B   $ SizeNWSE��6]   ��6   Z� 6]   �� 5O      -   5        $ WindowResizeLeft��5O   "   $��2��6   ���#000$
��Left=�5P   &   $��Stretch=�6A   $ SizeWE��6]   ��6   Z� 6]   �� 5Q      -	   5        $ WindowResizeRight��5Q   "   $��2��6   ���#000$��Right=�5R   &   $��Stretch=�6B   $ SizeWE��6^   ��6   Z� 6^   �� 5S      -
   5        $ WindowResizeBottom��5S   #   $��2��6   ���#000$��Stretch=�5T   &   $��Bottom=�6D   $ SizeNS��6_   ��6   Z� 6_   5U      5V      5W      