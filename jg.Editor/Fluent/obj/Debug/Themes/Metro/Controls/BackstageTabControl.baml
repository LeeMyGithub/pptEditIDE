   M S B A M L   `   `   `  ����M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546fclr-namespace:FluentFluent  5      1clr-namespace:Fluent.InternalFluent.Internal  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source#    Fluent.ObjectToImageConverter   StringToImageConvert " BackstageButtonControlTemplate �� 
TargetType   Fluent.Button ��Name �� CornerRadius �� Orientation ��Name J� SnapsToDevicePixels �� RelativeSource	 �� 	Converter
 ��Name   Header �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName �� Property �� Value P� Property P� Value   Fluent.GrayscaleEffect  BackstageButtonStyle �� 
TargetType  ControlStyleEmptyFocus �� AncestorType    Fluent.BackstageTabControl �� FallbackValue  BackstageFontBrush   Fluent.SeparatorTabItem " BackstageSeparatorTabItemStyle �� StrokeStartLineCap �� Stretch �� StrokeEndLineCap  RibbonTopBorderBrush �� StrokeMiterLimit �� StrokeLineJoin �� StrokeDashArray  BackstageControlTemplate � 	Resources �� BasedOn  ScrollBarWhite   Fluent.DropDownButton  	 DropDownButtonBackstageStyle   Fluent.ComboBox 
 ComboBoxBackstageStyle   Fluent.Spinner  SpinnerBackstageStyle  Key  �� TargetProperty! �� 
TargetName<  6System.Windows.Media.Animation.EasingThicknessKeyFrame" p� KeyTime# p� Value$   EasingFunction.	  (System.Windows.Media.Animation.CubicEase7
  1System.Windows.Media.Animation.EasingFunctionBase% 
  
EasingMode9  3System.Windows.Media.Animation.EasingDoubleKeyFrame& O� KeyTime' O� Value( �Name  BackstageBackgroundBrush) � ColumnDefinitions* � 	Resources  ButtonBackstageStyle   Fluent.MetroWindow+ � UseLayoutRounding, J� RenderTransformOrigin- F�Name
. �� Top/ �� Left0 A�Name.  (System.Windows.Interactivity.Interaction1   Triggers/  )System.Windows.Interactivity.EventTrigger2   	EventName3  -System.Windows.Interactivity.EventTriggerBase3   
SourceName.  (System.Windows.Interactivity.TriggerBase4   Actions#   Fluent.Internal.InvokeCommand   Fluent.RibbonCommands5   OpenBackstage6   Command7 K� IsItemsHost8 �� Value9 �� Binding   Fluent.Backstage: N� EnterActions; ��Name  OnIsOpenTrueStoryboard< N� ExitActions= �� BeginStoryboardName> P� 
SourceName  BackstageStyle  DefaultFontBrush  DefaultFontFamily  DefaultFontSize ! BackstagePanelBackgroundBrush�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      Fluentclr-namespace:Fluent  5      *Internalclr-namespace:Fluent.Internal  5      bInteractivityPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5        5      �� 5   
   $\ Vpack://application:,,,/Fluent;component\Themes\Office2010\Controls\ScrollBarWhite.xaml?�6   �� 5   
   $_ Ypack://application:,,,/Fluent;component\Themes\Office2010\Controls\BackstageControls.xaml?�6   %[  &	        &	      7   &	 �    7  &	 �    &	 �	    7  7  7 	 7 
 7  7  7  7  &	 4    7     5
      6$   �� 5      "  5      .R�5   
   � ���	#00000000.+�5      �� $ border��6   $��0q�5      $ 1��5      $y�	Collapsed=�5      #��z��5      ��5      Z� ._�5      �� $��0q�6   $ 1��5      $��1q�5      ���	#19000000���	#BFFFFFFF._�5      �� ���	#7FFFFFFF$��1q�5      $ 1��5      ���	#33FFFFFF5      5      5      �� 5      $ 
Horizontal=�6   $��	16,0,15,0q�5       $
��Left=�5!      $��Center=�5"      .+�5#      �� $ 	iconImage��6#   $
��Left=�5$   #   $��16��5%   #   $��Center=�5&   #   $��16��5(   #    . ��5'   #   �� *Icon+ �� *TemplatedParent+8	   5)   #   �� 5*      $
 controlLabel��50      #��z 5*      $��NoWrap=�5+      $��Center=�5,      $
��Left=�5-      $��5,0,0,0q�5.      $��CharacterEllipsis=�5/      50      51      52       53   
   ]� 54       55      �� 56       �@J�IsMouseOver . 57       �� 58       � {� . 59       ./�5;      �� $ border��5<       � y�$ Visible=�5=      5>      P� 5?       � {� .  . �5A      �� $ 	iconImage��5B       �@J�Opacity$	 0.5Q�5C      �� 5D      $ controlLabel��5E       �@J�Opacity$	 0.5Q�5F      �� 5G      $ 	iconImage��5H       �@J�Effect 5I        5J      5L      5M      5O      �� 5P      "  5Q      .�5R   
   ��  �@�FocusVisualStyle# �  5S      �� 5T   
    � ��$ 26��5U      �� 5V   
    � ��$	 5,1q�5W      �� 5X   
    � ��8   5Y      �� 5Z   
    � �� 5[      �� *
Background+ �� *FindAncestor+"  $	 Red���� 5\   
    � ��# �  5]      5^      �� 5_      "  6   .�5a   
   ��  � �� 5b      �� 5c      "  6"   .R�5d      � $��0,0,10,0q�6   .+�5e      �� $
 header��6$   $	��5,5q�5f   $   $
��Wrap=�5g   $   #��z��5h   $   $��Center=�5i   $   $��14(�5j   $   $
��Bold"�5k   $   ���	#FF5E5E5E$y�Visible=�5m   $   F� 5n      ����        �@B     	$��1��5p      $��0q�5q      $
 Flat=�5r      $
 Fill=�5s      $
 Flat=�5t      #���  5u      $��1��5v      $ 10Q�5w      $ Miter=�5x      $��Bottom=�5y      $	 2 2R�5z      ��5o      Z� 5z      5{       5|      P� 5}       � �� .  . �5      �� $ header��6%    � y�$ 	Collapsed=�5�   %   5�      5�      5�      5�      �� 5�      "  5�       5�   
   �� 5�      �� 5�      '        "  5�      8   5�      �� 5�      '��       " ��5�      8  5�      �� 5�      '        "  5�      8  5�      �� 5�      '        "  5�      8  5�      �� 5�      '        "  5�      8  5�      �� 5�      '        "  6   8  5�      �� 5�      OnIsOpenTrueStoryboard .��5�      r� $  (FrameworkElement.Margin)�67   $
! grid��5�   7   .	�5�        $" 0��62   $# 	-30,0,0,0q�5�   2     5�      $" 0:0:0.2��62   $# 0q�5�   2   $ 5�      	  5�   "   $% 	EaseInOut=�6,   5�      5�      U� 5�      $  (UIElement.Opacity)�64   $
! grid��5�   4   .\�5�        $& 0��6/   $' 0Q�5�   /     5�      $& 0:0:0.2��6/   $' 1Q�5�   /   5�      U� 5�      $V  P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�64   $! 
backbutton��5�   4   .\�5�        $& 0:0:0.1��6/   $	' -23Q�5�   /     5�      $& 0:0:0.2��6/   $' 0Q�5�   /   5�      5�      5�      .R�5�   
   � $
( grid��6   $��0q�5�      #���  5�      ) 5�      �� 5�      $	��107��6#   $
��Auto �5�   #   �� 5�      $��* �6#   .+�5�      � $
��Auto��6   $��1��5�      * 5�      �� 5�      �� 5�      '        "  5�       8  5�       5�      .+�5�      �� $ PART_SelectedContentHost��6#   $��Stretch=�5�   #   $��Stretch=�5�   #   $
��Auto��5�   #   $��1��5�   #   $��SelectedContent��5�   #   5�      � 5�      $��0q�6   $��Stretch=�5�      ��5�      �� *RibbonThemeColor+ �� *FindAncestor+"  .+�5�      � $( 
backbutton��5�      $��32��5�      $��32��5�      + .  $��	15,10,0,0q�5�      $	��Top=�5�      $
��Left=�5�      $, 0.5,0.5&�5�      z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      .+�5�      F� $- 	arrowpath��6   $��16��5�      $��12��5�      $. 10��5�      $	/ 7.5��5�      $ Uniform=�5�      
�������a���� Q%��O� Q%����p\-�������@��� �8@����ا  6n� �8��� ������� �p\-��O� Q%��O5�      A� 5�      $0 backellipse��6   
�������$��32��5�      $/ 0��5�      $��32��5�      $��2��5�      F� 5�      K����        �     H� H� H��     H� H� H� H� H�� H�    	
������ $��Stretch=�5�      $��0q�5�      $
 None=�5�      $
��Auto��5�      1 5�        5�      $2 MouseLeftButtonDown��65   $3 
backbutton��5�   5   .4 5�        #6 Z5 65   5�      5      �� 5     $��0,70,0,0q�6   $
��Auto��5     7 . 5     5     5      5  
   �� 5     $
8 True��5     9 5     �� *IsOpen+ �� "  : 5	     �� 5
     $; IsOpenBeginStoryboard��6&   8�� 6E   < 5     �� 5     $= IsOpenBeginStoryboard��6'   5     P� 5     $> 
backbutton��5      �@J�IsMouseOver . . �5     �� $ 	arrowpath��5      �@J�Opacity$	 0.5Q�5     �� 5     $ backellipse��5      �@J�Opacity$	 0.5Q�5     5     5     �� 5     "  5     .�5  
   ��  � ��# �  5      �� 5!  
    � ��# �  5"     �� 5#  
    � ��# �  5$     �� 5%  
    � ��8   5&     �� 5'  
    �@�FocusVisualStyle# �  5(     �� 5)  
    � ��$ 	0,-24,0,0q�5*     �� 5+  
    � �� 5,     �� *
Background+ �� *FindAncestor+"  $	 Red���� 5-  
    �@ ItemsPanelBackground# �  5.     5/     50     