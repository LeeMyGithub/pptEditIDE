   M S B A M L   `   `   `  ����M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546fclr-namespace:FluentFluent  5   <   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   GalleryDropDownButtonStyle �� 
TargetType    Fluent.DropDownButton �� Property �� Value �� 
TargetType ��Name   Fluent.TwoLineLabel  Name   HasTwoLines	   HasGlyph
   Text �� RelativeSource �Name    IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � RowDefinitions � ColumnDefinitions 
� RadiusX 
� Center 
� GradientOrigin 
� RadiusY � Color � Offset �� EndPoint �� 
StartPoint � MappingMode � ActualWidth ! ContextMenuBarBackgroundBrush  ContextMenuBarBorderBrush �� CornerRadius �� Stretch    MaxDropDownHeight   Fluent.MenuPanel  Name  K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation!   DirectionalNavigation" �� Triggers# P� Property$ P� Value% �� 
TargetName   Fluent.Gallery  GalleryControlTemplate& � 	Resources  ScrollViewerStyle' �� BasedOn  ScrollBarWhite  GalleryBorderBrush( ��Name   Fluent.GalleryPanel)   MinItemsInRow*   MinItemsInRow+   MaxItemsInRow,   MaxItemsInRow-   SelectedFilterGroups.   Filter/   GroupBy0   GroupBy1   
ItemHeight2   
ItemHeight3   	ItemWidth4   	ItemWidth5   Orientation6   Orientation7   ItemContainerGenerator  GalleryStyle8 �� Triggers9 �� Orientation: � Orientation�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      Fluentclr-namespace:Fluent  6<   8d2http://schemas.microsoft.com/expression/blend/2008  6`   Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6�     5      �� 5   
   $\ Vpack://application:,,,/Fluent;component\Themes\Office2010\Controls\ScrollBarWhite.xaml?�6   �� 5      $` Zpack://application:,,,/Fluent;component\Themes\Office2010\Controls\RibbonScrollViewer.xaml?�6   %�  &	        &	 f    7  7  &	 �    7  �� 5	      "   6/   .�5
      ��  � �� 5      �� 5      "   6   .R�5   
   � .+�5   
   �� $ PART_ButtonBorder��6   
������ ._�5        $ twoLineLabel��6     .  	 . 
�������$
��Left=�6�   $	��Top=�6�   $��6,0,0,0q�6�   
 66   �� *Header+ �� *TemplatedParent+6�   5      � 5      $ 
PART_Popup��5      $��Bottom=�5      #��z 5       . |�.  $
��Fade=�5      $��0,0,-4,0q�6#   $	��Top=�65   $��2��6M   .��5      � $��DropDown��5       . $��0q�5   *   $	��Top=�65    5      �� 5      $��* �6    �� 5      $��10 �6     5      �� 5       $��* �6#   �� 5!      $��10 �6#   .+�5#      �� $
��Left=�6   $	��Top=�65   $��4��6M   $��4��6W   $��1��6b   $��1��6o   $��0��6   $��	-1,-1,0,0q�6�   ��5$      
� 5%      $ 0.984Q�6(   $ 0.017,0.002&�68   $ 0.017,0.002&�6M   $ 1Q�6j   .��5&      � $ 	#3F000000��6#   $ 0Q�65   � 5'      $ 	#00000000��6#   $ 1Q�65   5(      5*      �� 5+      $��0��6   $
��Left=�6.   $��-1,3,0,0q�6I   $	��Top=�6[   $��4��6s   $��4��6}   $��1��6�   $��0��6�   ��5,      
� 5-      $ 
0.032,1.01&�6(   $ 
0.032,1.01&�6<   $ 0.984Q�6X   $ 1Q�6h   .��5.      � $ 	#3F000000��6#   $ 0Q�65   � 5/      $ 	#00000000��6#   $ 1Q�65   50      52      �� 53      $��0��6   $
��Left=�6.   $��3,-1,0,0q�6I   $	��Top=�6[   $��4��6s   $��4��6}   $��0��6�   $��1��6�   ��54      
� 55      $ 0.996,0.027&�6(   $ 0.996,0.027&�6=   $ 0.984Q�6Z   $ 1Q�6j   .��56      � $ 	#3F000000��6#   $ 0Q�65   � 57      $ 	#00000000��6#   $ 1Q�65   58      5:      �� 5;      $��0��6   $��Stretch=�6.   $��7,-1,1,0q�6L   $	��Top=�6^   $
��Auto��6v   $��4��6�   $��0��6�   $��1��6�   ��5<      �� 5=      $ 0.5,1&�6(   $ 0.5,0&�69   $ RelativeToBoundingBox=�6L   .��5>      � $ 	#3F000000��6#   $ 0Q�65   � 5?      $ 	#00000000��6#   $ 1Q�65   5@      5B      �� 5C      $��0��6   $
��Left=�6.   $��-1,7,0,1q�6I   $��Stretch=�6[   $��4��6w   $
��Auto��6�   $��1��6�   $��0��6�   ��5D      �� 5E      $ 1,0.5&�6(   $ 0,0.5&�69   $ RelativeToBoundingBox=�6L   .��5F      � $ 	#3F000000��6#   $ 0Q�65   � 5G      $ 	#00000000��6#   $ 1Q�65   5H      5J      �� 5K      $ PART_DropDownBorder��6   #��z 64    . #���  6x   #���  6�   $��1q�6�   $ 1��6  $��1��6  $��Stretch=�6J  $	��Top=�6h  ._�5L      � $
��Auto��6   $
��Auto��6$   $��Stretch=�62   $	��Top=�6P   .+�5M      �� $	��Top=�6   $
��Auto��63   $
��Auto��6@   #���  6N   $��1q�6�   $ 1��6�   � 5N      $��1q�6   $��Stretch=�6$   $	��Top=�6B   .+�5O      �� $
 Fill=�60   ���	#FFE2E4E7$
��Left=�6R   $��24,0,0,0q�6m   $��1��6   $
��Auto��6�   $��2��6�   $y�Visible=�6�   $��Stretch=�6�   ��6    Z� 6�   �� 5P      $��1q�6#   #��z 6.    . $
��Auto=�6y   $��Hidden=�6�   .��5Q        $ PART_MenuPanel��6)     . $! Cycle=�6T   5R      5S      5T      5U      5V      5W      5X      " 5Y   
   P� 5Z      # �@J�IsMouseOver$ . . �5[      �� $% twoLineLabel��6+    � �� �	#FFFFD2326E   5\      5^   	   5`      5a      �� 5c      "  6   & 5d   
   �� 5e      �� 5f      '��       " ��62   8'   6U   �� 5g      '��       " ��6/   8'  6O   5h      .R�5j   
   �� $ 
layoutRoot��6x   #��z��6   #���  6E   ._�5k      � $
��Auto��6    5l      �� 5m      $
��Auto �6   �� 5n      $��* �6   .+�5s      �� $( scrollViewer��6   $��1��61   $��1��6B   $��1q�6O   |�.  .��5t        
�������#* z) 5u      #, z+ 6?   #. z- 6o   #0 z/ 5v   z     . #2 z1 6�   #4 z3 6�   #6 z5 6  7 6   �� *ItemContainerGenerator+ �� *TemplatedParent+6  5x      5y      5z      " 5{   
   5�   	   �� 5�      "  6!   .�5�      ��  � ��$
 Auto=�6C   �� 5�       � ��$ Hidden=�6E   �� 5�       � ��8   6!   �� 5�       � ��$ 0q�6   �� 5�       � ��$ 0,0,0,1q�6(   8 5�      P� 5�      # �@ 
IsLastItem$ . . �5�   
   ��  � ��$ 0q�6,   5�   	   P� 5�      # �@ Orientation$$ Vertical=�6'   . �5�   
   ��  � �� 5�      �� 5�      .R�5�      �� $9 Vertical=�6   5�      5�      5�   	   P� 5�      # �@ Orientation$$ 
Horizontal=�6'   . �5�   
   ��  � �� 5�      �� 5�      .R�5�      � $: 
Horizontal=�6   5�      5�      5�   	   5�      5�      