   M S B A M L   `   `   `  ����M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546fclr-namespace:FluentFluent  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ToolTipStyle  �� 
TargetType �� Property  DefaultFontBrush �� Value  DefaultFontFamily  DefaultFontSize �� 
TargetType � ColumnDefinitions � RowDefinitions    Fluent.ScreenTip  ScreenTipControlTemplate ��Name ��Name    Title	 �Name
    Image    Text ��Name �� ElementName �� Path �� RelativeSource �� AncestorType �� AncestorLevel   Fluent.Ribbon   Localization �� Source �� Mode    DisableReason    HelpLabelVisibility ��Name    	HelpTopic �� Triggers P� 
SourceName P� Property P� Value �� 
TargetName ]� 
Conditions �� 
SourceName  �� Value! �� Property  ScreenTipStyle�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      Fluentclr-namespace:Fluent  5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      %  &	        &	 �    &	 I    7  �� 5      "  _�6   .�5      ��  � ��# �  6!   �� 5	       � ��# �  6$   �� 5
       � ��# �  6"   �� 5       � �� 5      �� 5   
   " _�6   .R�5      �  5      �� 5      $��* �6!   �� 5      $��5 �6!    5      �� 5      $��* �6   �� 5      $��5 �6   .+�5      �� $��1��6   $��1q�6&   
�������
�������._�5      �� $��4,4,4,4q�6   5      5      5      5      5      �� 5       "   6   .R�5!      �  5"      �� 5#      $��* �6!   �� 5$      $��5 �6!    5&      �� 5'      $��* �6   �� 5(      $��5 �6   .+�5*      �� $��1��6   $��1q�6&   
�������
�������._�5+      � .+�5,      �� $ screenTipPanel��6   .+�5-      �� $ title��6   $
��Wrap=�6-   $��7,8,7,10q�6A   $
��Bold"�6S   #��z 6e   � 5.      $	 imageAndTextSection��6    5/      �� 50      $
��Auto �6!   �� 51      $��* �6!   .+�53      �� $��7,5,3,7q�6   $
��Left=�6   $	��Top=�69   #��z
 6Q   $��48��6{   �� 54      #��z 6   $
��Wrap=�6@   $��8,0,8,6q�6T   ���	#FF414141$��1��6|   55      �� 56      $ 	separator��6   $��2��6    $
��Auto��6+   $��Stretch=�68   $��5q�6�   
�������$��0,0,0,1q�6�   y�6V   �� $ disableReasonSection��$ 
Visibility�{�6�   �� $ (IsEnabled)� �� *FindAncestor+$ ControlL�$ 2��� 57      $	 disableReasonSection��6   .+�58      �� $��16��6   $��16��6'   $
��Left=�63   $	��Top=�6N   $��5,0,0,0q�6f   $W��Qpack://application:,,,/Fluent;component\Themes\Office2010\Images\WarningSmall.png��6w   � 59       5:      �� 5;   	   $
��Auto �6   �� 5<   	   $
��Auto �6   �� 5=   	   $
��Auto �6   .+�5?      �� $ disableReasonHeader��6$   disableReasonHeader��$
��Wrap=�6�   $��28,0,5,2q�6�   ���	#FF414141$��Stretch=�6  $��0��6&  $
��Bold"�63  ��6]   �� # Z $" ScreenTipDisableReasonHeader�$ OneWay=�63  �� 5@      $ disableReasonText��6   #��z 6-   $
��Wrap=�6]   $��28,0,5,6q�6q   ���	#FF414141$��Stretch=�6�   $��1��6�   �� 5A      $ helpText��6   $
��Wrap=�6%   $��28,0,5,6q�69   ���	#FF414141$��1��6b   $��2��6s   $��Stretch=�6�   ��6�   �� *Text+$ 	textBlock��$ Default=�5B      5C      �� 5D      $ 
separator2��6   $��2��6/   $
��Auto��6:   $��Stretch=�6G   #y�z 6e   $��5q�6�   
�������$��0,0,0,1q�6�   � 5E      $	 helpSection��6   #y�z 6.   .+�5F      �� $��16��6   $��16��6'   $
��Left=�63   $	��Top=�6N   $��5,0,0,0q�6f   $T��Npack://application:,,,/Fluent;component\Themes\Office2010\Images\HelpSmall.png��6w   �� 5G      $ 	textBlock��61   HelpText��$
��Wrap=�6�   $��28,0,6,6q�6�   ���	#FF414141$
��Bold"�6�   $��Stretch=�6�   ��6D   �� # Z $ ScreenTipF1LabelHeader�$ OneWay=�6�   �� 5H      $ 	helpTopic��6   #��z 6)   $y�	Collapsed=�6X   5I      5J      5K      5L      5M       5N      P� 5O      $ 	separator��6"    � {� .  . �5P      �� $ disableReasonSection��6-    � y�$ Visible=�6O   5Q      P� 5R      $ 	separator��6+    � {� . . �5S      �� $ disableReasonSection��6-    � y�$ 	Collapsed=�6O   5T      ]� 5U       5V      �� 5W      $ 	helpTopic��6/     6F   Z� ! � ���� 5X      $ disableReasonText��65   ! � ��$   ��6,   65   ./�5Z      �� $ 	separator��6-    � y�$ 	Collapsed=�6D   5[      P� 5\      $ disableReasonText��6&    � ��$  ��6E   . �5]      �� $ disableReasonSection��6-    � y�$ 	Collapsed=�6O   5^      P� 5_      $ 	helpTopic��6)    6@   Z�  � ��. �5`      �� $ helpText��6-    � y�$ 	Collapsed=�6C   �� 5a      $ helpSection��6-    � y�$ 	Collapsed=�6F   �� 5b      $ 
separator2��6$    � y�$ 	Collapsed=�6<   5c      P� 5d      $ disableReasonSection��6,    � y�$ Visible=�6N   . �5e      �� $ helpText��6.    � y�$ 	Collapsed=�6D   5f      5h      �� 5j      "    6#   .�5k      ��  � ��# �  6$   �� 5l       � ��# �  6$   �� 5m       � ��# �  6"   �� 5n       � ��8   6"   5o      5p      