   M S B A M L   `   `   `  ���� W  SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   NoTrigersHeaderButton �� Color  TrigerHeaderButton  TrigerHeaderButton--exit  
HeaderText  HeaderText--title  HeaderPanel  MainLeftNavPanel  MainBackgroung  MainButtonBorderBrush  	 RadioButtonBackground-static  
 RadioButtonBackground-active  RaidoButtonForeground  StandardBrush  
ThumbColor  BackgroundScroll  BorderDataGrid  BorderColummnDataGrid  DataGridColorColumnHeader  WindowBorderHeaderStyle �� 
TargetType �� Property �� Value  WindowLableHeaderStyle  HeaderButton �� 
TargetType �� Triggers P� Property	 P� Value
 ^� 
Conditions �� Binding �� RelativeSource �� Value  LeftNavPanel  MainNavPanel_RadioButton �� Padding
 � Tag �� CornerRadius � Cursor J� Opacity ��Name �� Binding �� AncestorType �� Value  courseIcon-white  homeIcon-white  settingIcon-white J� Effect3    -System.Windows.Media.Effects.DropShadowEffect    
BlurRadius    ShadowDepth    Color  ViewAllButton-home&   System.Windows.Controls.DataGrid=  7System.Windows.Controls.Primitives.DataGridColumnHeader)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell  ScrollButtons  ScrollThumbs �� RadiusX �� RadiusY �Name � RowDefinitions ��Name  F�Name! ]�Name" ]� Thumb# n�Name  ContentLabel$ �� Orientation�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml        �� $! /Resource/Icon/IconSVG.xaml?�%Q  &	        &	      &	 *     &	 9     &	 I     &	 \     &	 o     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     &	 �     &	     &	     &	 *    &	 =    &	 P    7  &	 o    7  &	 �    7   7  7  7  &	 V    7  &	 u    7 	 7  7  7  &	 `    7  7  '  d    7  7  7  7  7  &	 �
    &	     '�� �    7  7  7  7  7  &	 >    �� $ Transparent���� $ #262626���� $	 Red���� $
 #FFF���� $ #5A5A5A���� $ #1F1F1F���� $ #414141���� $ #E0E0E0���� $
 #333���� $ #1F1F1F���� $ #3F3F3F���� $ White���� $ #1F1F1F���� $ #5A5A5A���� $ #3F3F3F���� $ 	#FFA5A5A5���� $ #DDDDDD���� $ #414141���� " ��.���  � ��8   �� " ��.���  � ��8   ��  � ��$ 15(���  � ��$ SemiBold"��� " ��.���  � ��$	 1,0q���  �@�Cursor$
 Hand����  � ��8   ��  � �� �� " ��.R��� #��z��._��� #��z��#��z��$��0,-5,0,0q�8�� $��Medium"�$��Center=�$��Center=� P�  �@J�IsMouseOver$
	 True��. ���  � ��8  ^� 
 ��  �� *IsMouseOver+ �� *Self+ True��  �� *Name+ �� *Self+ Exit.0���  � ��8  �� " ��.���  � ��8   �� " 	� P�  �@J�IsMouseOver$
	 True��. ���  �@J�Opacity$
 0.85Q�.���  � �� �� " 	�.R��� $ 10q�8��  # z $��5q�$ 15��$
 Hand��# z ._��� $ 	IconImage��$��25������ " �� ��  �� *Tag+ �� 
 Border Analitic.a���  � ��8  ��  �� *Tag+ �� 
 Border Home.a���  � ��8  ��  �� *Tag+ �� 
 Border Setting.a���  � ��8      $ 10Q�$ 0Q�$ Black���� " �� P�  �@J�IsMouseOver$
	 True��. ���  �@J�Opacity$	 0.8Q�.���  �@�Cursor$
 Hand����  � ��8   ��  � ��8  ��  � �� �� " ��.R��� $ 0,0,5,5��#��z��._��� #��z��$��Center=�#��z��$��SemiBold"��� "  .���  � ��8   ��   �@ HorizontalGridLinesBrush8  ��  �@ VerticalGridLinesBrush8  ��  �@ 
IsReadOnly$
 True����  �@ CanUserAddRows$ False����  �@ CanUserDeleteRows$ False����  �@ CanUserSortColumns$ False����  �@ CanUserResizeRows$ False����  �@ CanUserResizeColumns$ False����  �@ ColumnHeaderStyle �� "  .���  � ��8  ��  � ��8  ��  � ��$ 
ExtraLight"���  � ��$ 4q���  �@ RowStyle �� "   P�  �@J�IsMouseOver$
	 True��. ���  � ��
 �������  �@ 	CellStyle �� "   P�  �@ 
IsSelected$
	 True��. ���  � �� �	#ff66ccff��  � ��
 ���� ��  � ��
 �   �P�  �@J�	IsFocused$
	 True��. ���  � �� �	#ff66ccff��  � ��
 �   ���  � ��$ 1q���  � ��
 �   �.���  � ��$ 4,3,4,3q���  � ��
 ���� ��  � ��$ 1q���  � �� �� "  .R��� # z��#��z��#��z��#��z��._��� ��  �@�FocusVisualStyle �� " ��.���  � ��
 ���� �� " ��.���  � �� �� " ��.R��� $��Border��
������ ._��� �� " n�.���  � �� �� " n�.R�� $
��Grid��.+��� $��
Rectangle1��$��10��$
��Auto��$��Stretch=�$��Stretch=�#��z��$ 4��$ 4��$
 Hand���� " ��.���  � ��8   ��  � ��$ 12����  � �� �� " ��.R��� $ 5��#��z��#��� ��._�� $ GridRoot�� �� $��18���� $��0.00001* ��� $��18��.+��� $ DecreaseRepeat��$��ScrollBar.LineUpCommand��8�� #���  .��F� $  DecreaseArrow��$��Center=�$��Center=�+�����g5     �    ��j ���j ��j ��g5     8�� $
 Hand��]� $! 
PART_Track��$��1��$|�false��$
��true��" n� $# Thumb��8�� #���  �� $ IncreaseRepeat��$��2��$��ScrollBar.LineDownCommand��#���  #���  .��F� $  IncreaseArrow��$��Center=�$��Center=�+�����g5 ��j ���j     �        ��g5 ��j 8�� $
 Hand���� " ��.���  � �� �� " ��.R��� $$ 
Horizontal=�.+��� #��z #��z��#��z��$��SemiBold"��� #��z��#��z��#��z��$��5,0,0,0q�