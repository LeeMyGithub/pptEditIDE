   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5      L Hjg.Editor.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:jg.Editor.Library.Control.ComboTree#jg.Editor.Library.Control.ComboTree 5      6   0jg.Editor.Library.Property.ControlPropertyAction   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      oMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     5      G	ComboTree1clr-namespace:jg.Editor.Library.Control.ComboTree     5        � 	Resources  5       �� 
TargetType �� Property �� Value   ComboBoxFocusVisual �� StrokeDashArray J� SnapsToDevicePixels  DownArrowGeometry  ButtonNormalBackground �� EndPoint �� 
StartPoint � Color	 � Offset  ButtonNormalBorder
 �� Color  ValidationToolTipTemplate �Name J� RenderTransformOrigin J� Opacity T� X'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Name   Transitions%  System.Windows.VisualTransition   GeneratedDuration	   To   
Storyboard �� 
TargetName �� TargetProperty	 W� To g� Duration W� EasingFunction-  'System.Windows.Media.Animation.BackEase   	Amplitude7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode   States   System.Windows.VisualState   
Storyboard �� CornerRadius � UseLayoutRounding  ComboBoxToggleButton  �� 
TargetType+   %Microsoft.Windows.Themes.ButtonChrome!  Name"   
Background#   BorderBrush$ J� IsMouseOver%   RenderMouseOver&   RenderPressed'   RoundCorners( F�Name) �� Triggers* P� Property+ P� Value, �� 
TargetName  ComboBoxEditableTemplate:  4jg.Editor.Library.Control.ComboTree.ComboBoxTreeView- � ColumnDefinitions. �Name/ � AllowsTransparency0 �� RelativeSource5	   /Microsoft.Windows.Themes.SystemDropShadowChrome1 	 Name2 �� MaxDropDownHeight3 	  Color4 �� ElementName5 ��Name:
  4jg.Editor.Library.Control.ComboTree.ExtendedTreeView6 
 Name7   ItemsSource,   &Microsoft.Windows.Themes.ListBoxChrome8  Name9   
Background:   BorderBrush;   BorderThickness< ��Name  ComboBoxEditableTextBox= �� SelectionBoxItem> �� 
IsReadOnly? d� 	IsChecked@ �� Mode  MouseOverBorderBrushA P� 
SourceNameB ��Name  	 ComboBoxReadonlyToggleButton 
 comboboxTreeStyleC J� IsHitTestVisible#D �� SelectionBoxItemStringFormatE �� ContentStringFormatF �� SelectionBoxItemTemplateG �� TriggersH �� PathI �� Self  comboboxTreeItemStyleJ �� DataType3  -jg.Editor.Library.Control.ComboTree.TreeModelK �� ItemsSource��%�  '��       &	  H     &	 �     &	 *    &	     &	 A    &	 �    7  &	 �
    &	 �    &		 |    7  &	
 �    7   7  7  7  &	 �    �� 5   
   " ��6   .�5      ��  � ��$ 25 �6'   5      �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� 
���   �$	 1 2R�63   $��1��6I   $��4,4,21,4q�6]    . 6o   5      5      5      �5   
   M 0 0 L 3.5 4 L 7 0 Z�6D   �� 5!   
   $	 0,1&�6=   $	 0,0&�6L   .��5"      � $ #F3F3F3��6   $	 0Q�6+   � 5#      $ #EBEBEB��6   $		 0.5Q�6+   � 5$      $ #DDDDDD��6   $		 0.5Q�6+   � 5%      $ #CDCDCD��6   $	 1Q�6+   5&      �� 5(   
   $
 	#FF577A2A��65   �� 5+   
   .R�5,      � $
 Root��6   $	��5,0q�6!   $	 0,0&�6.   $ 0Q�6J   z�5-      T� 5.      	xform��$	 -25Q�68    50        51      $ 
OpenStates��6'    52        53      $ 0D�6/     54      $
 Open��6/   $ 0:0:0.2D�69   . 55   "   �� .��56   &   W� $ xform��66   $ X�6T   $ 0X�6r   $ 0:0:0.2D�6y    57   *     58   .   $ .3Q�67   $ EaseOut=�6F   5:   '   W� 5;   &   $
 Root��66   $ Opacity�6S   $ 1X�6w   $ 0:0:0.2D�6~   5<   #   5=      . 5?        
Closed��. 5@      �� .��5A   "   W� $
 Root��62   $ Opacity�6O   $ 0X�6s   $ 0D�6z   5B      5C        5D      Open��. 5E      �� .��5F   "   W� $ xform��62   $ X�6P   $ 0X�6n   $ 0D�6u   W� 5G   "   $
 Root��62   $ Opacity�6O   $ 1X�6s   $ 0D�6z   5H      5I      5J      .+�5M      �� $��	4,4,-4,-4q�6   ���	#052A2E31$ 5��6C   �� 5N      $��	3,3,-3,-3q�6   ���	#152A2E31$ 4��6C   �� 5O      $��	2,2,-2,-2q�6   ���	#252A2E31$ 3��6C   �� 5P      $��	1,1,-1,-1q�6   ���	#352A2E31$ 2��6C   �� 5R      ���	#FFDC000C$ 2��60   �� 5S      $ 2��6   ._�5T      ��  .  
�������$��8,4,8,4q�5V   &   $	��250��67   $
��Wrap=�6F   ��6Z   �� *%#(Validation.Errors)[0].ErrorContent+5W      5X      5Y      �� 5[   
   " d�6-   .�5\      ��  �@�OverridesDefaultStyle . 66   �� 5]       � �� .  6*   �� 5^       � |� .  6*   �� 5_       �@��	ClickMode$ Press=�6*   �� 5`       � �� 5a      �� 5b      "  d�6&   .R�5c        $! Chrome��6@   #��� r�6P    . #" z��5d   W   ## z��5e   <   #% z$ 6h   #& z��5f   <   ' .  ._�5g      F� $( Arrow��6#   
���   �$��Center=�6?   $��0,1,0,0q�6\   $��Center=�6m   8��  6�   5h      ) 5i      P� 5j      * �@d�	IsChecked$
+ trueY�6;   . �5k   "   �� $, Chrome��6B    �@ RenderPressed . 6V   5l      P� 5m      * � {�+ .  . �5n   "   �� $, Arrow��69    � �� �#AFAFAF6L   5o      5q      5s      5t      �� 5v   
   "   6;   .R�5w      � $ 	Placement��6    . - 5x      �� 5y      $��* �6'   �� 5z      $
��Auto �6'   .+�5|      � $. 
PART_Popup��6   / . $��Bottom=�6�   #��� .�5}      $��2��6m   ��5|   F   �� *IsDropDownOpen+0 �� *TemplatedParent+.��5~      	  $
1 Shdw��6F   #��z2 6T   $3 Transparent��6�   ��6�   �� *ActualWidth+$4 	Placement��._�5      �� $5 DropDownBorder��6!   #��� ��69   #��� ��5�      $��0q�6i   ._�5�      
  $6 treeView��69   #��z7 6K   #��z��6w   5�      5�      5�        5�      $8 Border��69   $��2��6I   #9 z��6]   #: z��5�   5   #; z��6a   �� 5�      $< PART_EditableTextBox��6   #��z��68   #���  6[   #��z��5�      #��z��6`   #��z= 5�   j   > 6   �� *
IsReadOnly+0 �� *TemplatedParent+6j   d� 5�      #���  6   $��1��6N   ? 5�      �� *IsDropDownOpen+$@ TwoWay=�0 �� *TemplatedParent+5�      ) 5�      P� 5�      * �@J�IsKeyboardFocusWithin+ . . �5�      ��  � ��
 �   �63   5�      P� 5�      * �@��IsDropDownOpen+ . . �5�      �� $, Border��66    �@ RenderFocused . 6J   5�      P� 5�      * �@J�IsMouseOver+ . . �5�      �� $, Border��64   # �  6H    �@ BorderBrush5�      P� 5�      * �@��HasItems+ .  . �5�      �� $, DropDownBorder��6/    � ��$ 95��6K   5�      P� 5�      * � {�+ .  . �5�      �� # � ��63    � ��5�      P� 5�      * �@��
IsGrouping+ . . �5�      ��  � �� .  6F   5�      P� 5�      $A 
PART_Popup��63   * �@�HasDropShadow+ . . �5�      �� $
, Shdw��6/    � ��$ 0,0,5,5q�6A   �� 5�      $
, Shdw��6.    �@	 Color$ 	#71000000��6@   5�      5�      �� 5�   
   " ��60   .�5�      ��  �@�OverridesDefaultStyle . 66   �� 5�       �@J�	AllowDrop . 6*   �� 5�       � ��$ 0��6)   �� 5�       � ��$ 0��6*   �� 5�       �@�FocusVisualStyle 61   Z� �� 5�       � �� 5�      �� 5�      "  ��6&   .R�5�      �� $B PART_ContentHost��6'   
������ |�.  $��Hidden=�6l   $��Hidden=�6�   5�      5�      5�      �� 5�   
   " d�65   .�5�      ��  �@�OverridesDefaultStyle . 66   �� 5�       � �� .  6*   �� 5�       � |� .  6*   �� 5�       �@��	ClickMode$ Press=�6*   �� 5�       � �� 5�      �� 5�      "  d�6&   .R�5�        $! Chrome��6@    . #" z��6k   ## z��5�   <   #% z$ 6h   #& z��5�   <   ._�5�      � $��Right=�6#   #��� r�6?   .+�5�   "   F� $( Arrow��6'   
���   �$��Center=�6C   $��3,1,0,0q�6`   $��Center=�6q   8��  6�   5�      5�      ) 5�      P� 5�      * �@d�	IsChecked$
+ trueY�6;   . �5�   "   �� $, Chrome��6B    �@ RenderPressed . 6V   5�      P� 5�      * � {�+ .  . �5�   "   �� $, Arrow��69    � �� �#AFAFAF6L   5�      5�      5�      5�      �� 5�   
   "  6*   .�5�      ��  �@�FocusVisualStyle8   61   �� 5�       � ��# � ��6+   �� 5�       � ��8  6+   �� 5�       � ��8  6,   �� 5�       � ��$ 1q�60   �� 5�       � ��$
 Auto=�6K   �� 5�       � ��$
 Auto=�6I   �� 5�       � ��$	 4,3q�6(   �� 5�       � �� 5�      �� 5�      "   6&   .R�5�      � $ MainGrid��6    . - 5�      �� 5�   "   $��* �63   �� 5�   "   #��� r�63   $��0 �6�   .+�5�      � $. 
PART_Popup��6$   $��1q�68   / . $��Bottom=�5�       #��� .�5�       $��2��6y   ��5�       �� *IsDropDownOpen+0 �� *TemplatedParent+.��5�   "   	  $
1 Shdw��6R   #��z2 6`   $3 Transparent��6�   ��6�   �� *ActualWidth+$4 MainGrid��._�5�   &   �� $5 DropDownBorder��6-   #��� ��6E   #��� ��6�   $��1q�6�   ._�5�   *   
  $6 treeView��6E   #��z7 6W   #��z��6�   5�   '   5�   #   5�      d� 5�      #��� 	 6+   #��z��6b   #��z��6�   $��2��5�   '   ? 6;   �� *IsDropDownOpen+$@ TwoWay=�0 �� *TemplatedParent+�� 5�      #��z��6/   #��z��6r   #��z��5�   +   C .  # z 5�   +   #��z= 6g   #E zD 5�   +   #��zF 6p   #��z��5�   +   5�      5�      5�      G 5�      P� 5�      * �@��
IsEditable+ . . �5�      ��  � ��
 �  ��64   �� 5       � ��
 �   �63   �� 5      � �� �#CDCDCD63   �� 5      � �� .  62   �� 5      � ��$ 3q�60   �� 5      � ��8  61   5     P� 5     * �@=�HasError+ . . �5     ��  � ��
 �  ��63   �� 5      �@�ToolTip 5	     �� 5
     $2H ,(Validation.Errors).CurrentItem.ErrorContent�6'   #0 ZI 6\   5     5     5     �� 5  
   "J  6A   K 6i   �� $H Children�.R�5     � .+�5     �� ��6   �� *DisplayValuePath+5     5     5     .��5     � L � RowDefinitionsL 5  
   �� 5     �� 5     �� 5     �� 5     �� 5      - 5#  
   �� 5$     $	��100 �6   �� 5%     $��* �6   .+�5'  
   �� $
��Left=�6   $��	23,0,23,0q�6/   $��0��6D   $��Center=�6T   $��0��6o     FF000010#��[ 6|   �� 5(  
   -   5        M ��Name$M cmbEvent��5(  ;     CboCommomStyle#��[ 6   $��1��6M   N �� SelectedIndex$N 0��6]   $��0��6o   .@�5)     ��   FF000013#��[ 6   �� 5*       FF000014#��[ 6   5+     �� 5-  
   $
��Left=�6   $��	23,0,23,0q�6/   $��Center=�6D   $��1��6_     FF000011#��[ 6l   �� 5.  
   -   5        $M 	cmbAction��5.  ;   #��[ 6   $N 0��6N   $��1��6a   $��1��6q   .@�5/     ��   FF000016#��[ 6   �� 50       FF000017#��[ 6   �� 51       FF000018#��[ 6   �� 52       FF000077#��[ 6   53     �� 55  
   $
��Left=�6   $��	23,0,23,0q�6/   $��Center=�6B   $��2��6]     FF000012#��[ 6j   �� 57  
   -   5        $M cmbAssetList��58     #��[ 57     $N 0��5:     $��1��6&   $��2��5;     �� 5=  
   -   5        $M cmbTree��5=     #��[ 6(   $N 0��5?  %   $y�Hidden=�5@  %   $��5��5A  %   �� 5C  
   $
��Left=�6   $��	23,0,23,0q�6/   $��Center=�6D   $��3��6_     FF000091#��[ 6l   �� 5D  
   -   5        $< txtTime��5D  (   O �� TextAlignment$O Right=�6   $��1��69   $��3��6I   6V   5G     5H     