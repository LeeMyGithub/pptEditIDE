   M S B A M L   `   `   `  ����M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546fclr-namespace:FluentFluent  5   L   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089    Fluent.StatusBar  �� 
TargetType �� Property �� Value �� 
TargetType �� RelativeSource �� AncestorType   Fluent.MetroWindow   Fluent.StatusBarPanel  Name K� IsItemsHost �� Triggers	 P� Property
 P� Value �� 
TargetName   RibbonStatusBarItemStyle   Fluent.StatusBarItem �� Triggers   Fluent.StatusBarMenuItem 1 -RibbonStatusBarContextMenuItemControlTemplate  DefaultFontFamily  DefaultFontSize  DefaultFontBrush �� Mode � ColumnDefinitions ��Name # ButtonHoverOuterBackgroundBrush  ButtonHoverOuterBorderBrush �� CornerRadius # ButtonHoverInnerBackgroundBrush  ButtonHoverInnerBorderBrush ��Name ��Name #	 MenuItemCheckBoxBackgroundBrush 
 MenuItemCheckBoxBorderBrush �� RadiusX �� RadiusY ��Name J� SnapsToDevicePixels m� Icon F�Name �� Stretch �� EndPoint �� 
StartPoint � Color � Offset ]� 
Conditions �� Value  �� Property! �� BasedOn�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      !Controlsclr-namespace:Fluent  6L   %  '         &	  K    '  p    &	 �    '  �    7   �� 5      "    6.   .�5      ��  �@J�SnapsToDevicePixels . 6,   �� 5       � ��$ 23��6   �� 5       � ��$ 0,0,0,-1q�6   �� 5       � �� 5      �� 5	   
   "   6   .R�5
      �� $
��Auto��6   $	��0,1q�6#   ��69   �� *RibbonThemeColor+ �� *FindAncestor+"  ._�5        $ itemsPresenter��6;    . $
��Auto��6S   $��0q�6a   5       5      P� 5      	 �@  IsWindowMaximized
 .  . �5      �� $ itemsPresenter��6/    � ��$ 0,0,16,0q�6K   5      5      5      5      �� 5      "   5   
   .�5   
   ��  � ��$ 3,0,3,0q�5      �� 5   
    � �� 5      �� 5      "  6"   .R�5      �� #��z��6'   5      5!       5"   
   P� 5#      	 � {�
 .  . �5%      ��  � �� �	#FF8888885&      5'      5)      �� 5,      "   6   .�5-   
   ��  � ��# �  6%   �� 5.   
    � ��# �  6'   �� 5/   
    � ��# �  6%   �� 50   
    � ��# �  6'   �� 51   
    �@m�IsCheckable . 6(   �� 52   
    �@m�	IsChecked 6&   �� *StatusBarItem.IsChecked+ �� *Self+$ TwoWay=�53      �� 56      "  6L   .R�57   
   � $
��Auto��6   $��22��6   ���	#00000000 58      �� 59      $��25 �6#   �� 5:      $��* �6#   �� 5;      $
��Auto �6#   .+�5=      �� $ border��6   $��Stretch=�6%   $��0q�6C   $
��Auto��6N   $y�	Collapsed=�6[   #���  6r   #���  6�   $��1q�6�   $ 2��6  $��0��6  $��3��6"  ._�5>      �� #���  6   #���  6X   $��1q�6�   $ 1��6�   5?      �� 5@      $ textBlock_Copy��6   $
��Auto��6�   $
��Auto��6�   $��9,3,30,3q�6�   $��Center=�6�   $��1��6�   $
��None=�6�   $y�Hidden=�6�   $
��Left=�6  ��60   �� *StatusBarItem.Title+ �� *TemplatedParent+6  �� 5A      $ 	textBlock��6   $
��Auto��6�   $
��Auto��6�   $��9,3,3,3q�6�   $��Center=�6�   $��1��6�   $��CharacterEllipsis=�6�   ��6+   �� *StatusBarItem.Title+ �� *TemplatedParent+6�   �� 5B      $ 	rectangle��6   #��� 	 6+   #��� 
 6d   $��1��6�   $��Center=�6�   $��Center=�6�   $��20��6�   $��20��6�   $ 1��6�   $ 1��6
  $y�	Collapsed=�6  �� 5C      $ image��6   $��Center=�6#   $��Center=�6@   $<��6/Fluent;Component/Themes/Office2010/Images/Checked.png��6[   $
��None=�6�   $y�	Collapsed=�6�    . 6�   �� 5D      $ 	iconImage��6   $��Center=�6'   $��3,2,2,2q�6D   $��Center=�6U   $
��Auto��6p   #��z 6}    . 6�   �� 5E      $
��Auto��6n   $
��Auto��6{   $��9,3,3,3q�6�   $��Center=�6�   $��3��6�   $��CharacterEllipsis=�6�   ��6   �� *StatusBarItem.Value+ �� *TemplatedParent+6�   F� 5F      $
 path��6   $
 Fill=�6!   $��Right=�6B   $��1,0,4,0q�6^   $��4��6o   "����        �@B @B �    �� 	$��6��6�   $��3��6�   ��60   Z� ��5G      �� 5H      $ 0.945,0.872&�6*   $ 0.055,0.128&�6A   .��5I      � $ Black��6'   $ 1Q�65   � 5J      $ 	#FF828282��6'   5K      5M      5N       5O   
   P� 5P      	 �@m�	IsChecked
 . . �5Q      �� $ 	rectangle��6/    � y�$ Visible=�6F   5R      ]� 5S       5T      �� 5U       60   Z�   �@m�Icon�� 5V        �@m�	IsChecked . 65   ./�5X      �� $ image��6/    � y�$ Visible=�6B   5Y      P� 5Z      	 �@��HasItems
 .  . �5[      �� $
 path��6/    � y�$ 	Collapsed=�6A   5\      ]� 5]       5^   
   �� 5_        �@m�IsHighlighted . 6/   �� 5`        � {� . 6+   ./�5b      �� $ border��6/    � y�$ Visible=�6C   5c   	   5t      �� 5v      8!   "   6@   5w      