   M S B A M L   `   `   `  ����  	jg.Editor    jg.Editor.windowLogin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStyle$
  None=�6@    � AllowsTransparency .  � Title$ windowLogin��5   	   
������ $	��350��68   $	��510��6E    � WindowStartupLocation$ CenterScreen=�6Q    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value ��Name �� RadiusY �� RadiusX J� Effect-  'System.Windows.Media.Effects.BlurEffect   Radius   RenderingBias �� EndPoint �� 
StartPoint �� RelativeTransform �� CenterY �� CenterX �� CenterY �� CenterX �� Angle  �� CenterY! �� CenterX" � Color# � Offset$ J� SnapsToDevicePixels% J� Opacity& �� Triggers' P� Property( P� Value   	OnLoaded18  2System.Windows.Media.Animation.EasingPointKeyFrame) $� KeyTime* $� Value+   EasingFunction.  (System.Windows.Media.Animation.CubicEase7	  1System.Windows.Media.Animation.EasingFunctionBase, 	  
EasingMode��%�  '��       &	  �    �� 5   
   " ��6   .�5      ��  � �� 5	      �� 5
      " ��6&   .R�5      � 	 5        5   "   CommonStates��.
 5   &     
Normal��62     5   &   	MouseOver��. 5   *   �� .��5   .   �� $H B(Shape.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Color)�6K   $ 	rectangle��6�   .g�5   2     $ 0��6F   $ 	#FF36D0E4��6R   5   /   �� 5   .   $H B(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6K   $ 	rectangle��6�   .g�5   2     $ 0��6F   $ 	#FF0898C8��6R   5   /   �� 5   .   $H B(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6K   $ 	rectangle��6�   .g�5   2     $ 0��6F   $ 	#FF0898C8��6R   5   /   5   +   5   '     5   &   Pressed��. 5   *   �� .��5   .   �� $H B(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6K   $ 	rectangle��6�   .g�5   2     $ 0��6F   $ 	#FF064B76��6R   5    /   �� 5!   .   $H B(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6K   $ 	rectangle��6�   .g�5"   2     $ 0��6F   $ 	#FF064B76��6R   5#   /   �� 5$   .   $H B(Shape.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Color)�6K   $ 	rectangle��6�   .g�5%   2     $ 0��6F   $ 	#FF0A91CA��6R   5&   /   U� 5'   /   $ (UIElement.Opacity)�6M   $ 
rectangle1��6}   .\�5(   2     $ 0��6G   $ 0.195Q�6S   5)   /   5*   +   5+   '     5,   &   Disabled��. 5-   *   �� .��5.   .   �� $H B(Shape.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Color)�6K   $ 	rectangle��6�   .g�5/   2     $ 0��6F   $ 	#FFD6D6D6��6R   50   /   �� 51   .   $H B(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6K   $ 	rectangle��6�   .g�52   2     $ 0��6F   $ 	#FF747474��6R   53   /   �� 54   .   $H B(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6K   $ 	rectangle��6�   .g�55   2     $ 0��6F   $ 	#FF747474��6R   56   /   �� 57   .   $J D(Shape.Stroke).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6K   $ 	rectangle��6�   .g�58   2     $ 0��6F   $ 	#FFDEDEDE��6R   59   /   �� 5:   .   $J D(Shape.Stroke).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6K   $ 	rectangle��6�   .g�5;   2     $ 0��6F   $ 	#FF919191��6R   5<   /   5=   +   5>   '   5?   #   .+�5B      �� $ 	rectangle��6(   $ 5��6;   $ 5��6G    5C   "     5D   &   $ 1Q�61   $ Quality=�6<   ��5F   "   �� 5G   &   $ 0.5,1&�6:   $ 0.5,0&�6K    5H   *   V� 5I   .   .~�5J   2   �� $	 0.5Q�6A   $	 0.5Q�6O   �� 5K   2   $	 0.5Q�6@   $	 0.5Q�6N   �� 5L   2   $ 90Q�6B   $	  0.5Q�6M   $	! 0.5Q�6[   T� 5M   2   5N   /   .��5P   *   � $" 	#FF096FAF��67   $# 0Q�6I   � 5Q   *   $" 	#FF096FAF��67   $# 1Q�6I   � 5R   *   $" 	#FF26B6ED��67   $# 0.534Q�6I   5S   '   ��5U   "   �� 5V   &   $ 0.5,1&�6:   $ 0.5,0&�6K    5W   *   V� 5X   .   .~�5Y   2   �� $	 0.5Q�6A   $	 0.5Q�6O   �� 5Z   2   $	 0.5Q�6@   $	 0.5Q�6N   �� 5[   2   $	 -23Q�6B   $	  0.5Q�6N   $	! 0.5Q�6\   T� 5\   2   5]   /   .��5_   *   � $" 	#FF24ACE2��67   $# 0Q�6I   � 5`   *   $" 	#FF095787��67   $# 0.997Q�6I   5a   '   5c      �� 5d      #��z��6/   ��. #$ z$ 6�   #��z��6�   �� 5e      $ 
rectangle1��6(   $��0.023,0.011,-0.024,17.489q�6<   $ 5.425��6_   $ 5.425��6o   $	��237��6   
�������$% 0.205Q�6�   ��6�   Z� 6�   5f      & 5g      P� 5h      ' �@J�	IsFocused( . 6;   P� 5i      ' �@��IsDefaulted( . 6=   P� 5j      ' �@J�IsMouseOver( . 6=   P� 5k      ' � ��( . 6;   P� 5l      ' � {�( .  6;   5n      5p      5q      �� 5r   
   .��5s      *� $' !(UIElement.RenderTransformOrigin)�6+   $
 grid��6i   .'�5t        $) 0��6&   $* 0.5,0.5&�62   5v      U� 5x      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $
 grid��6�   .\�5y        $ 0��6'   $ -1Q�63   + 5z        5{      $, EaseOut=�6$   5}        5~      $ 0:0:1��6'   $ 1Q�67   + 5        5�      $, EaseOut=�6$   5�      5�      5�      5�      - � Triggers- 5�      :� 5�   
   . :� RoutedEvent$. FrameworkElement.Loaded��6   .[�5�      �� #��[  6   5�      .��5�      � -   5        / �Name$
/ grid��5�   $   $	��322��6   $	��495��6   z�5�   
   V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�       5�   
   3
  -System.Windows.Media.Effects.DropShadowEffect
  5�      0 
  
BlurRadius$0 9Q�6   1 
  Color$1 	#FF000000��6.   2 
  	Direction$	2 -60Q�6@   3 
  Opacity$3 1Q�6P   4 
  ShadowDepth$4 0Q�6\   5 � RowDefinitions5 5�   
   �� 5�      $��70 �6   �� 5�      .+�5�   
   �� $��2��6   $ 10��6%   $ 10��62   ���	#FF60666D���	#FFECECEC$��0q�6c   �� 5�   
   -   5        $��Image/Login_Title.png��5�   :   $
��Fill=�6Y   �� 5�   
   -   5        $��btnClose��5�      $��Right=�6!   $��
0,10,10,20q�6=   
������ $��40��6l   $��40��6w   .��5�      F� �����W� �x ӰW� �x 8�z ��K 8�z ��K �8�z ��K xr= ���Q��?xr= ���Q��?Sxr= ���Q��?�v - �v - ��v - 0A\ ��i 0A\ ��i �0A\ ��i � �c� � �c� �� �c� H�< _� H�< _� �H�< _� �wx �� �wx �� ��wx �� �M� �l� �M� �l� ��M� �l� 0S� �� 0S� �� �0S� �� �  lk �  lk ��  lk �� - �� - ��� - �W� �x �W� �x ���	#FFFFFFFF6 �� Stretch$
6 Fill=�5�       5�      �� 5�   
   $��1��6   $��20(�6!   $��51,60,0,166q�6/   $
��Left=�6D   $��Center=�6_   $��用户名：��6z   �� 5�   
   $��1��6   $��20(�6!   $��51,112,0,114q�6/   $
��Left=�6E   $��Center=�6`   $��密　码：��6{   �� 5�   
   -   5        $��txtName��5�   �   $��1��6   $��20(�6   $	��260��6-   $��150,-100,0,0q�69   $
��Left=�6O   $��Center=�6j   6�   G� 5�   
   -   5        $��txtPassword��5�   �   $��1��6   $��20(�6#   $	��260��61   $��	150,0,0,0q�6=   $
��Left=�6P   $��Center=�6k   6�   �� 5�   
   -   5        $��btnLogin��5�   $   
�������$��Right=�64   $��Bottom=�6P   $��1��5�      $��40��6   $��20(�6*   $	��100��68   $��
0,0,155,37q�6D   $��登录��6X   7 �� 	IsDefault7 . 6|   �� 5�   
   -   5        $��btnExit��5�   $   
�������$��Right=�63   $��Bottom=�6O   $��1��5�      $��40��6   $��20(�6*   $	��100��68   $��	0,0,28,37q�6D   $��退出��6X   8 �� IsCancel8 . 6{   �� 5�   
   -   5        9 ��Name$9 LoginTittle��5�   =   ���	#FFFFFFFF$��9.065(�6+   $��Microsoft YaHei)�5�      $
��Left=�5�      $	��Top=�5�      $�� ��5�      $��0��5�      $��	17,13,0,0q�6!   z�5�      u� 5�      : u� Matrix$: 2.661,0,0,2.661,0,0x�6"   5�      5�      5�      