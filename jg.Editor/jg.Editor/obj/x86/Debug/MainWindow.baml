   M S B A M L   `   `   `  ����M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
   	   L Hjg.Editor.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:jg.Editor.Library.Property;assembly=jg.Editor.Libraryjg.Editor.Library.Property 5   	   Z VWPFToolkit.Extended, Version=1.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4R<clr-namespace:Xceed.Wpf.Toolkit;assembly=WPFToolkit.ExtendedXceed.Wpf.Toolkit 5   	   P:clr-namespace:jg.Editor.Library;assembly=jg.Editor.Libraryjg.Editor.Library 5   	   \@clr-namespace:jg.Editor.Library.Topic;assembly=jg.Editor.Libraryjg.Editor.Library.Topic 5   	   `Bclr-namespace:jg.Editor.Library.Control;assembly=jg.Editor.Libraryjg.Editor.Library.Control 5   	    	jg.Editor   jg.Editor.MainWindow   5   	   /Fluent$clr-namespace:Fluent;assembly=Fluent  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 	    5   	   9System&clr-namespace:System;assembly=mscorlib 	    5
   	   Smy1Cclr-namespace:jg.Editor.Library.Property;assembly=jg.Editor.Library 	    5   	   Nxceed<clr-namespace:Xceed.Wpf.Toolkit;assembly=WPFToolkit.Extended 	    5   	   Jmy2:clr-namespace:jg.Editor.Library;assembly=jg.Editor.Library 	    5   	   Pmy3@clr-namespace:jg.Editor.Library.Topic;assembly=jg.Editor.Library 	    5   	   QmyBclr-namespace:jg.Editor.Library.Control;assembly=jg.Editor.Library 	    5   	   -   5           FF00003A  � Title#  [  5   	   $	��768��5   	   $
��1024��5   	    � WindowState$ 	Maximized=�5	   	    � Icon$) #/jg.Editor;component/Image/Icon.ico��5   !   $	��658��5   	   $	��377��5   	   $��Microsoft YaHei)�6      Fluent.MetroWindow   RibbonThemeColor �	#FF2D3340���#ECECEC � 	Resources 5       �� MergedDictionaries �� Source  WindowColor  ContentAreaColorLight  ContentAreaColorDark  DisabledControlLightColor  DisabledControlDarkColor  DisabledForegroundColor  SelectedBackgroundColor  SelectedUnfocusedColor 	 ControlLightColor 
 ControlMediumColor  ControlDarkColor  ControlMouseOverColor  ControlPressedColor  
GlyphColor  GlyphMouseOver  BorderLightColor  BorderMediumColor  BorderDarkColor  PressedBorderLightColor  PressedBorderDarkColor  DisabledBorderLightColor  DisabledBorderDarkColor  DefaultBorderBrushDarkColor  HeaderTopColor " DatagridCurrentCellBorderColor  SliderTrackDarkColor  NavButtonFrameColor  MenuPopupBrush �� EndPoint �� 
StartPoint	 � Color
 � Offset $  ProgressBarIndicatorAnimatedFill �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Color ��Name  ScrollViewerStyle3  ExpandCollapseToggleStyle'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   Hidden R� Value   Visible F�Name �� Stretch   TreeViewItemFocusVisual �� StrokeDashArray J� Opacity �� UpdateSourceTrigger  (� Stretch! � ColumnDefinitions" � RowDefinitions# d�Name$ �� 	ClickMode% d� 	IsChecked& �� RelativeSource' ��Name( J� SnapsToDevicePixels) ��Name* �� Triggers+ P� Property, P� Value- �� 
TargetName,  &jg.Editor.Library.DataConverterVisible ! dc. �� DataType(  "jg.Editor.Library.TreeViewItemInfo/ �� ItemsSource0 �� Path1 J� 	AllowDrop2 � ContextMenu3 ��Name4 m�Name5 m� Icon
6 � Tag7 � DataContext " RadioButtonStyleNew8 	� 	GroupName # 
Routed_New9 �� Text $ Routed_Load % Routed_Save & 
Routed_Cut ' Routed_Copy ( Routed_Paste ) Routed_Undo * Routed_Redo�� 5   
    5      �� 5      $ Resources/White.xaml?�6%   %*  &	       &	 !     &	 B     &	 c     &	 �     &	 �     &	 �     &	 �     &		     &	
 )    &	 J    &	 k    &	 �    &	 �    &	 �    &	     &	 2    &	 S    &	 t    &	 �    &	 �    &	 �    &	 �    &	     &	 6    &	 S    &	 t    &	 �    &	 \    'R� �    7  &	 �    &	       'Q� �    7  &	! �    (��     5�   '   *, +)&	# �    &	$ *    &	% W    &	& �    &	' �    &	( �    &	)     &	* 8    ��5      	#FFE8EDF9��63   ��5      	#FFC5CBF9��6=   ��5       	#FF7381F9��6<   ��5!      	#FFE8EDF9��6A   ��5"      	#FFC5CBF9��6@   ��5#      	#FF888888��6?   ��5$      	#FFC5CBF9��6?   ��5%      	#FFDDDDDD��6>   ��5&      	#FFFFFFFF��69   ��5'      	#FF7381F9��6:   ��5(      	#FF211AA9��68   ��5)      	#FF3843C4��6=   ��5*      	#FF211AA9��6;   ��5+      	#FF444444��62   ��5,      /+sc#1, 0.004391443, 0.002428215, 0.242281124��6X   ��5-      	#FFCCCCCC��68   ��5.      	#FF888888��69   ��5/      	#FF444444��67   ��50      	#FF888888��6?   ��51      	#FF444444��6>   ��52      	#FFAAAAAA��6@   ��53      	#FF888888��6?   ��54      	Black��6?   ��55      	#FFC5CBF9��66   ��56      	Black��6B   ��57      	#FFC5CBF9��6<   ��58      	#FF3843C4��6;   �� 59      $ 0.5,1&�5:      $ 0.5,0&�5;      .��5<      � #	 � 	 6   $
 0Q�5=      � 5>      #	 � 
 6   $	
 0.5Q�5?      � 5@      #	 � 	 6   $
 1Q�5A      5B      �� 5D      $	 0,0&�5E      $	 1,0&�5F      ��5H      � � 5I      $	 	#000000FF��6'   $
 0Q�5J      � 5K      $	 	#FF373B43��6'   $	
 0.4Q�5L      � 5M      $	 	#FF373B43��6'   $	
 0.6Q�5N      � 5O      $	 	#000000FF��6'   $
 1Q�5P      5Q      5S      �� 5U      " R�5V      .�5W      ��  �@�OverridesDefaultStyle . 5X      �� 5Y       �@J�SnapsToDevicePixels . 5Z      �� 5[       � ��$
 Auto=�5\      �� 5]       � ��$
 Auto=�5^      �� 5_       � �� 5`      �� 5a      " R�6*   .R�5b      �� $��Border��6%   $ 1��5c      $��1q�5d      ��5e   "   �� 5f   &   # �  66   ��5h   "   �� 5i   &   # � 	 66   ._�5k   "   �� $ sviewer��6s   |�.  8��  ���#f0f0f0��.  $��4q�5m      .��5n   &   �� 5o   #   5p      5q      5s      5t      �� 5v      " d�5w      .�5x      ��  � |� .  5y      �� 5z       � �� 5{      �� 5|      " d�6*   .R�5}      � $��10��6#   $��10��5~      
������  5�   "     5�   &   CheckStates��. 5�   *     Checked��. 5�   .   �� .��5�   2   T� $ (UIElement.Visibility)�6P   $ 	Collapsed��5�   2   ..�5�   6   i� $ 0��6M   # Z 5�   -   5�   3   T� 5�   2   $ (UIElement.Visibility)�6P   $ Expanded��5�   2   ..�5�   6   i� $ 0��6M   # Z 5�   -   5�   3   5�   /   5�   +     5�   *   	Unchecked��66     5�   *   Indeterminate��66   5�   '   .+�5�   "   F� $ 	Collapsed��6'   $
��Left=�5�      $��Center=�5�      $��1,1,1,1q�5�      $
 Fill=�6$   "���� 	=     � z  	= � 	=  z 	��5�   &   �� 5�   *   $ Black��6:   5�   #   F� 5�   "   $ Expanded��6'   $
��Left=�5�      $��Center=�5�      $��1,1,1,1q�5�      $
 Fill=�6"   "����     	= � z  	= � 	=  z 	$y�Hidden=�5�      ��5�   &   �� 5�   *   $ Black��6:   5�   #   5�      5�      5�      5�      �� 5�      .�5�      ��  � �� 5�      �� 5�      .R�5�      �� ._�5�   "   �� $��0,0,0,0q�6,   $��5��5�      
���   �$	 1 2R�5�      $ 0Q�5�      5�      5�      5�      5�      �� 5�      " Q�6   .�5�      ��  �@Q�
IsExpanded . 6/   �� 5�       �@Q�
IsSelected 6/   �� *
IsSelected+$ PropertyChanged=��� 5�       � ��
 �   �6/   �� 5�       � �� 5�      �� 5�      " Q�6*   .R�5�      (� $
  Fill=�6&   .��5�   "   � ! 5�   &   �� 5�   *   $��25 �6<   �� 5�   *   " 5�   &   �� 5�   *   �� 5�   *   .+�5�   &   d� $# Expander��64   $$ Press=�6F   8��  % 6X   �� *
IsExpanded+& �� *TemplatedParent+6�   � 5�   &   $��1��6+   .+�5�   *   �� $' PART_Header��6<   $��Stretch=�6R   $��Header��6n   #��z��6�   #( z( 6�   5�   '   �� 5�   &   $) 	ItemsHost��66   $��2��6I   $��1��6]   $��1��6m   5�   #   5�      * 5�      P� 5�   "   + �@Q�
IsExpanded, .  . �5�   &   �� $- 	ItemsHost��6C    � y�$ 	Collapsed=�6Z   5�   #   P� 5�   "   + �@��HasItems, .  . �5�   &   �� $- Expander��6C    � y�$ Hidden=�6Y   5�   #   5�      5�      5�        5�      6'   �� 5�      ".  6'   / 6P   �� $0 Children�.R�5�      � -   5        $��Stretch=�5�      $��Stretch=�5�      1 . 2 5�      �� 5�      $3 GridMenu��6&   -   5        .@�5�      m� $4 GridMain��6'   -   5        $��添加主目录��5�   9   $-5 '/jg.Editor;component/Image/RightNew.png��6I   $��30��6x   6 6�   �� $0 ClassInfoBind�6�   m� 5�      $4 GridAdd��6'   -   5        $��添加子目录��5�   8   $��30��6G   6 6U   �� $0 ClassInfoBind�6z   �� 5�      $	 0.4Q�6(   68   m� 5�      $4 
GridDelete��6'   -   5        $��删除目录��5�   ;   $��30��6J   $-5 '/jg.Editor;component/Image/Rightdel.png��6W   6 6�   �� $0 ClassInfoBind�6�   �� 5�      $	 0.4Q�6(   68   m� 5�      $4 
GridUpdate��6'   -   5        $��修改目录��5�   ;   $��30��6I   $.5 (/jg.Editor;component/Image/Rightedit.png��6V   6 6�   �� $0 ClassInfoBind�6�   �� 5�      $	 0.4Q�6(   68   m� 5�      $4 GridUpLeavel��6'   -   5        $��上移目录��5�   =   $��30��6K   $,5 &/jg.Editor;component/Image/Rightup.png��6X   6 6�   �� $0 ClassInfoBind�6�   �� 5      $	 0.4Q�6(   68   m� 5     $4 GridDownLeavel��6'   -	   5        $��下移目录��5  ?   $��30��6M   $.5 (/jg.Editor;component/Image/RightDown.png��6Z   6 6�   �� $0 ClassInfoBind�6�   �� 5     $	 0.4Q�6(   68   m� 5     $4 Gridcopy��6'   -
   5        $��复制目录��5  9   $��30��6G   $.5 (/jg.Editor;component/Image/Rightcopy.png��6T   6 6�   �� $0 ClassInfoBind�6�   �� 5     $	 0.4Q�6(   68   5     " 5     �� 5     $��21��6)   $��21 �68   �� 5	     $��56.25��6(   $��191.25��6;   $��119.25 �6N   �� 5
     $��21��6)   $��21 �68   ! 5     �� 5     �� 5     $	��100��6-   $	��320��6=   $	��170 �6L   �� 5     $��21��6-   $��22 �6<   .+�5     �� $��0��6    $��1��6.   ��6>   �� $0 Title�7 5     �� $0 ClassInfoBind�y�5     �� $0 IsTbVisabled��� 5     -   5        $��0��5     $��1��6,   6 6=   �� $0 ParentId���6\   �� $0 Title�y�5     �� $0 IsTxtVisabled�5     	� 5     #��� " 6"   $8 a��5  &   $��Stretch=�5!  &   $��Stretch=�5"  &   $��1��5#  %   $��1��65   % 5  &   �� *
IsSelected+$ PropertyChanged=���5   &   �� *PageContent+5$  )   �� 5&     $��2��6   ���#f0f0f0$ 1Q�6>   $��1��6K   5(     5*     5,     �� 5.     $9 routedUICommandNew��61   �� 5/     $9 routedUICommandLoad��62   �� 50     $9 routedUICommandSave��62   �� 51     $9 routedUICommandCut��61   �� 52     $9 routedUICommandCopy��62   �� 53     $9 routedUICommandPaste��63   �� 54     $9 routedUICommandUndo��62   �� 55     $9 routedUICommandRedo��62   56     : J� InputBindings: 59     �� 5:  
   ; �� Gesture$; Ctrl+N��6   
< �� Key$< N��6&   = �� Command#= [# 6.   �� 5;  
   $; Ctrl+L��6   $< L��6&   #= [$ 6.   �� 5<  
   $; Ctrl+S��6   $< S��6&   #= [% 6.   �� 5=  
   $; Ctrl+X��6   $< X��6&   #= [& 6.   �� 5>  
   $; Ctrl+C��6   $< C��6&   #= [' 6.   �� 5?  
   $; Ctrl+V��6   $< V��6&   #= [( 6.   �� 5@  
   $; Ctrl+Z��6   $< Z��6&   #= [) 6.   �� 5A  
   $; Ctrl+Y��6   $< Y��6&   #= [* 6.   > J� CommandBindings> 5D     )  #System.Windows.Input.CommandBinding  5E  
   -   5        ?   Command#? [# 5E     6g     5F  
   -   5        #? [$ 5F     6g     5G  
   -   5        #? [% 5G     6g     5H  
   -   5        #? [& 5H     6g     5I  
   -   5        #? [' 5I     6g     5J  
   -   5        #? [( 5J     6h     5K  
   -   5        #? [) 5K     6g     5L  
   -   5        #? [* 5L     6g   .��5P     � ! 5R  
   �� 5S     $��1 �6   �� 5T     -   5        @ �Name$
@ col1��5T     $	��320��6,   $	��230��6;   $	��300 �6J   �� 5U     $��2 �6   �� 5V     $��* �6   �� 5W     $��0 �6   �� 5X     -   5        $
@ col5��5X     $	��300 �6+   �� 5Y     $��1 �6   " 5\  
   �� 5]     $
��auto �6   �� 5^     -   5        $@ rowStage��5^     $��* �6-   �� 5_     $��0 �6   �� 5`     -   5        $
@ row4��5`     $
��auto �6(   �� 5a     $
��auto �6   6,   .+�5i     � $��0��6   $��0��6#   $��5��60   ���	#FF2D33406Z   � 5j     $��6��6   $��0��6    $��5��6-   ���	#FF2D33406W   	   Fluent.Ribbon	  5l     -   5        A 	 Name$A ribbon��5n     B 	  AutomaticStateManagementB . $��5��5l  ?   $��1��6W   $��0��6i    + RibbonControlTemplate#��[+ 6x   C 	  MenuC 5r  
   
   Fluent.Backstage
  5t     D 
  Content.D 5v         Fluent.BackstageTabControl  .@�5w        Fluent.Button  -   5        E  Name$E 	btnCreate��5w  2   F   Header$F 新建��6&   
�������   Fluent.KeyTipG   Keys$G A��5y  (   6@     5z     -   5        $E btnLoad��5z  2   $F 打开��6&   
�������$G A��5|  (   6@     5}     -   5        $F 保存��5}  $   
�������$G S��5  +   6B     5�     -   5        $F 	另存为��5�  &   
�������$G A��5�  (   6@      Fluent.BackstageTabItem  5�     H   Header$H 信息��66   ��5�     � 5�     
�������" 5�     �� 5�     $��15 �6    �� 5�     $��50 �6    �� 5�     $��37 �6    �� 5�     $��30 �6    �� 5�     $	��201 �6    �� 5�     $��26 �6    �� 5�     $��39 �6    �� 5�     $��* �6    ! 5�     �� 5�     $	��107 �6#   �� 5�     $��0 �6#   �� 5�     $	��301 �6#   �� 5�     $��62 �6#   �� 5�     $��1 �6#   �� 5�     $��55 �6#   �� 5�     $��* �6#   �� 5�     $��83 �6#   .+�5�     �� $��2��6   $��2��6%   ._�5�     �� $��课件信息��6   $��Microsoft YaHei)�6(   $��32(�6E   5�     �� 5�     $��2��6   $��4��6*   ._�5�     �� I �� Orientation$I 
Horizontal=�6   .+�5�  
   �� -   5        $��80��5�     $��80��6   $
��Left=�6(   $	��Top=�6C   $��加密��6[   $��Microsoft YaHei)�6�   
�������$��18(�6�   6�   �� 5�  
   $��80��6   $
��Left=�6"   $	��Top=�6=   $��10q�6U   .+�5�     �� $
��Left=�6   $	��Top=�65   
���   �$��Microsoft YaHei)�6a   $
��Bold"�6~   $��14(�6�   加密6�   �� 5�     $
��Left=�6   $	��Top=�65   $��0,3,0,0q�6N   $��Microsoft YaHei)�6_   $��15(�6|   )'对您的课件做进一步的保护。6�   5�     5�     5�     �� 5�  
   $��4��6   $��7��6$   $
 Fill=�65   $��1��6E   $	 0.8Q�6R   ��5�     
� 5�     .��5�     � $	 	#FF2D3340��6#   $
 0Q�65   � 5�     $	 White��6#   $
 1Q�61   5�     5�     � 5�  
   $��6��6   $��4��6   $��4��6,   " 5�     �� 5�     $
��auto �6    �� 5�     $
��auto �6    �� 5�     $
��auto �6    �� 5�     $
��auto �6    �� 5�     $
��auto �6    �� 5�     $
��auto �6    �� 5�     $
��auto �6    �� 5�     $
��auto �6    �� 5�     $��* �6    ! 5�     �� 5�     $	��100 �6#   �� 5�     $��* �6#    5�     ��%�   '��       �� 5�     " ��6   .�5�     ��  � ��$ 14(�61   �� 5�      � ��$
 Wrap=�65   �� 5�      �@��Padding$ 0,0,0,35q�60   5�     5�     .+�5�     �� $��名       称：��6   $��0��6*   $��Microsoft YaHei)�67   �� 5�     $��修改时间：��6   $��1��6%   $��Microsoft YaHei)�62   �� 5�     $��创建时间：��6   $��2��6%   $��Microsoft YaHei)�62   �� 5�     $��画布大小：��6   $��3��6%   $��Microsoft YaHei)�62   �� 5�     $��背景颜色：��6   $��4��6%   $��Microsoft YaHei)�62   �� 5�     $��修  改 者：��6   $��5��6'   $��Microsoft YaHei)�64   �� 5�     $��创  建 者：��6   $��6��6'   $��Microsoft YaHei)�64   �� 5�     -   5        J ��Name$J FileName��5�     $��0��6+   $��1��68   $	��Top=�6H   $
��Left=�6`   
�������$��	未命名��6�   $��12(�6�   $��Microsoft YaHei)�6�   �� 5�     -   5        $J 
UpdateTime��5�     $�� ��6,   $��1��64   $��1��6A   $	��Top=�6Q   $
��Left=�6k   
�������$��12(�6�   $��Microsoft YaHei)�6�   �� 5�     -    5        $J 
CreateTime��5�     $�� ��6,   $��2��64   $��1��6A   $	��Top=�6Q   $
��Left=�6k   
�������$��12(�6�   $��Microsoft YaHei)�6�   �� 5�     $��3��6   $��1��6&   $I 
Horizontal=�66   $
��Left=�6O   .+�5�     �� $	��2.7q�6   $	��Top=�6&   $��40��6?   
�������$��12(�6]   .��6k   	宽度:6p   �� 5�     -!   5        K ��Name$K txtWidth��5�  &   $
��1280��6   $	��Top=�68   $��Microsoft YaHei)�6Q   $��1q�6n   $6 defaultwidth��6�   $��Center=�5�  V   $��12(�5�     
���   �
���   �6Q   �� 5�     $	��2.7q�6   $	��Top=�6&   
�������$��12(�6S   .��6a   	高度:6f   �� 5�     -"   5        $K 	txtHeight��5�  %   $	��720��6   $	��Top=�68   $��40��6P   $��Microsoft YaHei)�6\   $��1q�6y   $6 defaultheight��6�   $��Center=�5�  V   $��12(�6x   
���   �
���   �6�   5�     #  Xceed.Wpf.Toolkit.ColorPicker  5�     -#   5        L  Name$L colorPicker��5�      $��4��65   $��1��6B   $
��Left=�6S   $	��135��6o   $	��Top=�6{   �� 5�     -$   5        $J 
UpdateUser��5�  !   $�� ��6   $��5��65   $��1��6B   $	��Top=�6R   
�������$��12(�6}   $��Microsoft YaHei)�6�   �� 5�     -%   5        $J 
CreateUser��5�  !   $�� ��6   $��6��65   $��1��6B   $	��Top=�6R   
�������$��12(�6}   $��Microsoft YaHei)�6�   5�     5�     5�        Fluent.SeparatorTabItem  56       59     -&   5        $F 退出��59     
�������$G X��5:  (   5;  +   5<     5=     M 	  Tabs.M 5H        Fluent.RibbonTabItem  -'   5        N  Name$N tabItem1��5H  C    , FF00005DO   Header#O [, 6    P   
IsSelectedP .   - RibbonTabItemControlTemplate#��[- 6g   $G H��5I  %   Q � ToolTip$Q Regular Tool Tip��5J  %   R   ReduceOrder$QR KFont, Font, Font, Font,B,A,A,A,(A),(A),(A),Clipboard,Font,B,B,(A),C,(A),(A)��5K  %   S   Groups.S 5M  
      Fluent.RibbonGroupBox  -(   5        T  Name$T OperationGroupBox��5P     $G 	Operation��5O     U   Header$U  ��5Q     V   LauncherKeys$V ZBOperation��5R     .@�5T       -)   5        $��
btnPageAdd��5W     $��10,8,4,0q�5T     W   Icon$1W +/jg.Editor;component/Image/Top_Page_Add.png��5U     X   	LargeIcon$1X +/jg.Editor;component/Image/Top_Page_Add.png��5V     $��Center=�5X      . FF00004E#F [. 5Z     2 5]     �� 5^     .@�5_     m� -*   5        $
6 Main��5_  #    / FF000062#��[/ 6E   m� 5`     -+   5        $	6 Sub��5`  #    0 FF000063#��[0 6D   5n     Q 5q        Fluent.ScreenTip  5r     Y   Title$	Y Add��6'   Z   Text$Z Add a page.��5s  /   $	��190��5t  /   5v       5x     -,   5        $��
btnPageDel��5x     $��10,8,4,0q�60   $��Center=�5y  '    1 FF00004F#F [1 5{  )   $1W +/jg.Editor;component/Image/Top_Page_Del.png��5|  )   $1X +/jg.Editor;component/Image/Top_Page_Del.png��5}  )   Q 5       5�     $	Y Del��6'   $Z Del a page.��5�  /   $	��190��5�  /   5�       5�     --   5        $��btnUndo��5�     $��	10,8,10,0q�6.   $4W ./jg.Editor;component/Image/Top_Redo_Normal.png��5�  +   $4X ./jg.Editor;component/Image/Top_Redo_Normal.png��5�      2 FF000000#F [2 5�  )   $��Center=�5�     Q 5�       5�     $
Y Undo��6'   $Z Undo  Operation��5�  /   $	��190��5�  /   5�       5�     -.   5        $��btnRedo��5�     $��	10,8,10,0q�6-   $4W ./jg.Editor;component/Image/Top_Undo_Normal.PNG��5�     $4X ./jg.Editor;component/Image/Top_Undo_Normal.PNG��5�  )    3 FF000001#F [3 5�  )   $��Center=�5�     Q 5�       5�     $
Y Redo��6'   $Z Redo  Operation��5�  /   $	��190��5�  /   5�        Fluent.SplitButton  5�     -/   5        $��toggleButton1��5�  #   $��	10,8,10,0q�69    4 FF00006B   Fluent.DropDownButton[   Header#[ [4 5�  1   \   Icon$8\ 2/jg.Editor;component/Image/Top_aligning_Normal.png��5�  )   ]   	LargeIcon$8] 2/jg.Editor;component/Image/Top_aligning_Normal.png��5�  )   $��Center=�5�  '   Q 5�       5�     $Y Align��6'   $Z Align Page.��5�  /   $	��190��5�  /   .@�5�        Fluent.MenuItem  -0   5        $��	左对齐��5�  "   $
6 Left��6/   $/5 )/jg.Editor;component/Image/Align_Left.png��6Z   6�     5�     -1   5        $��顶端对齐��5�  "   $	6 Top��61   $.5 (/jg.Editor;component/Image/Align_Top.png��6Y   6�     5�     -2   5        $��	右对齐��5�  "   $6 Right��60   $05 */jg.Editor;component/Image/Align_Right.png��6Z   6�     5�     -3   5        $��底部对齐��5�  "   $6 Bottom��62   $15 +/jg.Editor;component/Image/Align_Bottom.png��6\   6�   5�     5�       5�  
   -4   5        $T q��5�     $
G View��5�     $U  ��5�     $V ZBView��5�     .@�5�       -5   5        $��btnCut��5�     $��	10,8,10,0q�5�     $3W -/jg.Editor;component/Image/Top_Cut_Normal.png��5�     $3X -/jg.Editor;component/Image/Top_Cut_Normal.png��5�      5 FF000050#F [5 5�     $��Center=�5�     Q 5�       5�     $	Y Cut��6'   $Z Cut a little Controls.��5�  /   $	��190��5�  /   5�       5�     -6   5        $��btnCopy��5�  (   $��	10,8,10,0q�5�     $4W ./jg.Editor;component/Image/Top_Copy_Normal.png��5�  (   $4X ./jg.Editor;component/Image/Top_Copy_Normal.png��5�  (   $��Center=�5�  (    6 FF000051#F [6 5�  +   Q 5�       5�     $
Y Copy��6'   $Z Copy a little Controls.��5�  /   $	��190��5�  /   5�       5�     -7   5        $��btnPaste��5�     $��	10,8,10,0q�5�     $5W //jg.Editor;component/Image/Top_Paste_Normal.png��5�     $5X //jg.Editor;component/Image/Top_Paste_Normal.png��5�      7 FF000052#F [7 5�     $��Center=�5�     Q 5�       5�     $Y Paste��6'   $Z Paste a little Controls.��5�  /   $	��190��5�  /   5�     5�       5�  
   -8   5        $T ViewGroupBox��5�      !8 RibbonGroupBoxControlTemplate#��[8 5�  !   $
G View��5�     $U  ��5�     $V ZBView��5�     .@�5�       -9   5        $��Preview��5�     $��	10,8,10,0q�5�     $4W ./jg.Editor;component/Image/Top_Add_Preview.png��5�     $4X ./jg.Editor;component/Image/Top_Add_Preview.png��5�      9 FF000005#F [9 5�     $��Center=�5�     Q 5�       5�     $Y Preview��6'   $Z Preview  File��5�  /   $	��190��5�  /   5�       5     -:   5        $��
btnPublish��5     $7W 1/jg.Editor;component/Image/Top_Release_Normal.png��5     $7X 1/jg.Editor;component/Image/Top_Release_Normal.png��5      : FF000053#F [: 5     $��Center=�5     $y�	Collapsed=�6A   Q 5       5	     $Y Preview��6'   $Z Preview  File��5
  /   $	��190��5  /   5     5     5       5     -;   5        $��tabItem2��5  @    ; FF00005E#O [; 6   .S 5  
     -<   5        $T ResourcesRibbonGroupBox��5  !   $U  ��6B   $��Hidden=�6M   ^   IsLauncherVisible^ .  .@�5       $G Image��6   $��	10,8,10,0q�69    < FF000054#F [< 5  )   $6 Image��5  .   $7W 1/jg.Editor;component/Image/Top_Picture_Normal.png��5  )   $7X 1/jg.Editor;component/Image/Top_Picture_Normal.png��5  )   _   SizeDefinition$_ Large��5  )   Q 5       5     $Y Image��6'   $Z insert a Image.��5  /   $	��190��5   /   5$       5&     $G Movie��6   $��	10,8,10,0q�6=    = FF000055#F [= 5'  )   $6 Movie��5)  .   $5W //jg.Editor;component/Image/Top_Video_Normal.png��5*  )   $5X //jg.Editor;component/Image/Top_Video_Normal.png��5+  )   $_ Large��5,  )   Q 5-       5.     $Y Image��6'   $Z insert a Image.��5/  /   $	��190��50  /   54       5F     $G Sound��6   $��	10,8,10,0q�6>    > FF000057#F [> 5G  )   $6 Sound��5I  .   $5W //jg.Editor;component/Image/Top_Audio_Normal.png��5J  )   $5X //jg.Editor;component/Image/Top_Audio_Normal.png��5K  )   $_ Large��5L  )   Q 5M       5N     $Y Sound��6'   $Z insert a Sound.��5O  /   $	��190��5P  /   5T       5u     $G 
TPageGroup��6   $��	10,8,10,0q�6B    ? FF000083#F [? 5v  )   $6 
TPageGroup��5x  .   $8W 2/jg.Editor;component/Image/Top_ImgGroup_Normal.png��5y  )   $8X 2/jg.Editor;component/Image/Top_ImgGroup_Normal.png��5z  )   $_ Large��5{  )   ��5|     �� 5}     Q 5       5�     $Y 
TPageGroup��6'   $Z insert a TPageGroup.��5�  /   $	��190��5�  /   5�     5�       5�  
   $U  ��6    $��Hidden=�6+   ^ .  .@�5�       -=   5        $
G Text��5�     $��	10,8,10,0q�6<    @ FF000059#F [@ 5�  )   $
6 Text��5�  .   $4W ./jg.Editor;component/Image/Top_Text_Normal.png��5�  )   $4X ./jg.Editor;component/Image/Top_Text_Normal.png��5�  )   $_ Large��5�  )   Q 5�       5�     $
Y Text��6'   $Z insert a Text.��5�  /   $	��190��5�  /   5�       5�     ->   5        $G 	TopicDrag��5�     $��	10,8,10,0q�6B    A FF00005A#F [A 5�  )   $6 	TopicDrag��5�  .   $;W 5/jg.Editor;component/Image/Top_DragandDrop_Normal.png��5�  )   $;X 5/jg.Editor;component/Image/Top_DragandDrop_Normal.png��5�  )   $_ Large��5�  )   Q 5�       5�     $Y 	TopicDrag��6'   $Z insert a TopicDrag.��5�  /   $	��190��5�  /   5�       5�     -?   5        $G Topic��5�     $��	10,8,10,0q�6>    B FF00005B#F [B 5�  )   $6 Topic��5�  .   $>W 8/jg.Editor;component/Image/Top_Multiplechoice_Normal.png��5�  )   $>X 8/jg.Editor;component/Image/Top_Multiplechoice_Normal.png��5�  )   $_ Large��5�  )   Q 5�       5�     $Y Topic��6'   $Z insert a Topic.��5�  /   $	��190��5�  /   5�       5�     -@   5        $G HTML5��5�     $��	10,8,10,0q�6>    C FF000081#F [C 5�  )   $6 HTML5��5�  .   $5W //jg.Editor;component/Image/Top_html5_Normal.png��5�  )   $5X //jg.Editor;component/Image/Top_html5_Normal.png��5�  )   $_ Large��5�  )   Q 5�       5�     $Y HTML5��6'   $Z insert a HTML5.��5�  /   $	��190��5�  /   5�     5�     55       5�     -A   5        $N tabItem6��5�  >    D FF00007E#O [D 6   .S 5�  
     $U  ��6    ^ .  .@�5�       -B   5        $��btnHelp��5�     $��	10,8,10,0q�62   $4W ./jg.Editor;component/Image/Top_help_Normal.png��5�  .   $4X ./jg.Editor;component/Image/Top_help_Normal.png��5�  .   #F [D 5�  0   $��Center=�5�  .   Q 5�       5�     $Y help.��6'   $Z feedback��5�  /   $	��190��5�  /   5�       5�     -C   5        $��btnfeedback��5�     $��	10,8,10,0q�64   $;W 5/jg.Editor;component/Image/Top_retroaction_Normal.png��5�  +   $;X 5/jg.Editor;component/Image/Top_retroaction_Normal.png��5�  )    E FF00007F#F [E 5�  *   $��Center=�5�  *   Q 5�       5�     $Y feedback��6'   $Z 	feedback.��5�  /   $	��190��5�  /   5�     5     5       5     $O MUST BE HIDDEN��6   $y�	Collapsed=�5  #   `   Group` 5  #   �� a �� ElementName$a invisibleTabGroup��b �� Mode$b OneWay=�.S 5  
     $U MUST BE HIDDEN��6    ^ .  $y�	Collapsed=�5  (   5     5     5     R� 5      -D   5        c R�Name$c treeViewControl1��5*     $��Stretch=�5      $��Stretch=�62   $��0q�5"     $��1��5#  C   $��1��6S   1 . 5*     �� 5-     -E   5        $��scrollViewer��5-     #��[ 5.     $��Stretch=�6D   $��Stretch=�6b   $��Center=�5/     $��3��50     $��1��6'   ���#8d8d8d$
��Auto=�51     $
��Auto=�52     .��56  
   � -F   5        $
��grid��56     ���#8d8d8d$��Center=�62   $��Center=�6O   d � LayoutTransformd 59     V� 5:     .~�5;     �� -G   5        scaleTransform��5;  %   5<     5?     5A     �� 5B     $��2��6   $��1��6#   $��3��61   ���	#FFF0F0F0$��0q�5C  /   e �� ResizeDirection$e Columns=�5D     $��Center=�61   $��Stretch=�5E     $��5��63   � 5F     $��5��6   $��1��6   ���#A4A4A4.+�5G  
   �� $��2��6   $��0q�6&   $	��298��6:   $��0,2,0,0q�6F   ���#f0f0f0 F TabItemStyle2#��[F 6r   .@�5H     �� $��属性��6   .��5I     �� $
��Auto=�6    $��Hidden=�6C   ���#f0f0f0.��5K     /  )jg.Editor.Library.Property.PropertyManage  -H   5        $��propertyManage1��5K  +   $	��298��6C   $��Center=�6Q   5L     5M     �� 5u     $��图层��6   .��5v     � .+�5~     '  !jg.Editor.Library.ControlTimeLine  -I   5        f  Name$f controlTimeLine��5~  *   $	��298��6D   $��Center=�6Q   5�     5�     5�     5�     �� 5�     $��5��6   $��1��6   $��5��6*   ���#8d8d8d$��	0,1.5,0,0q�6T   ._�5�  
      Fluent.StatusBar  $��Stretch=�6   $��Bottom=�5�     $��5��5�     $��0��6(   $��7��68   .@�5�     �� $
��Left=�6      Fluent.StatusBarItem  5�     g   Title$
g Zoom��6#   $��Center=�61   ���	#FFFF4D00$��Right=�5�  #   h   Valueh 5�  #   �� *Value+$a 
zoomSlider��i �� StringFormat$i {0:0}%��  5�     $g Zoom Slider��6#   $��Right=�5�  #   .��5�     �� -J   5        j ��Name$j 
zoomSlider��5�     $��Center=�6/   k � Minimum$k 1Q�5�     l � Maximum$	l 400Q�5�     m �� IsDirectionReversedm .   G ZoomSliderStyle#��� G 5�     n � Value$	n 100Q�5�     6%   5�     5�     5�     � 5�     -K   5        o �Name$o 
ShowNewWin��5�     $��0��6!   $��1��61   $y�	Collapsed=�6?   $��5��5�     $��5��6,   .+�5�  
   � $	 0.2Q�6   ���	#FF312F2F69   0  *jg.Editor.Library.Control.ProgressEditBusy  5�  
   -L   5        p  Name$p ProgressEditBusyName��5�  Y   q   	BusyColor
q �   �r   	FirstLine$r 正在加载��66   s   TwoLine$s 请您耐心等待��6G   $	��300��6w   $	��300��6�   5�     5�     5�     