   M S B A M L   `   `   `  ����Z  VWPFToolkit.Extended, Version=1.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4R<clr-namespace:Xceed.Wpf.Toolkit;assembly=WPFToolkit.ExtendedXceed.Wpf.Toolkit  5   !    jg.Editor.Library9   3jg.Editor.Library.Property.ControlPropertyTopicDrag   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Nxceed<clr-namespace:Xceed.Wpf.Toolkit;assembly=WPFToolkit.Extended     5   !   ��5      �� *Height+  �� ElementName$
  grid��.��5
      � -   5        $
��grid��5
       � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $
��auto �6   �� 5      $��25 �6   �� 5      $��25 �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   .+�5   
   �� $��0��6   $��0��6!   $��项目数量��61   $��Center=�6=   $��Center=�6Z   �� 5   
   -   5        $��txtItemCount1��5      $��0��6E   $��1��6R   $��Center=�6b   �� 5   
   $��0��6   $��2��6!   $��	干扰项��61   $��Center=�6<   $��Center=�6Y   �� 5   
   -   5        $��txtItemCount2��5      $��0��6E   $��3��6R   $��Center=�6b   �� 5   
   $��1��6   $��0��6!   $��分值��61   $��Center=�6;   $��Center=�6X   $y�	Collapsed=�6s   �� 5    
   -   5        $��txtScore��5       $��1��6E   $��1��6R   $��Center=�6b   $y�	Collapsed=�6}   �� 5!   
   $��2��6   $��0��6!   $��(非)前景色：��61   $��Center=�6@   $��Center=�6]   �� 5"   
   $��2��6   $��2��6!   $��(非)背景色：��61   $��Center=�6@   $��Center=�6]   �� 5#   
   $��3��6   $��0��6!   $��前景色：��61   $��Center=�6=   $��Center=�6Z   �� 5$   
   $��3��6   $��2��6!   $��背景色：��61   $��Center=�6=   $��Center=�6Z   #   Xceed.Wpf.Toolkit.ColorPicker  5%   
   -   5          Name$ colorOtherFor��5%      $��2��63   $��1��6@   $��Center=�6Q     5&   
   -   5        $ colorOtherBack��5&      $��2��64   $��3��6A   $��Center=�6R     5(   
   -   5        $ colorAnwerFor��5(      $��3��63   $��1��6@   $��Center=�6Q     5)   
   -   5        $ colorAnwerBack��5)      $��3��64   $��3��6A   $��Center=�6R   � 5+   
   -	   5        $��gridItem��5+      $��4��6   $��0��6,   $��4��6<    5,      �� 5-      $	��40* �6#   �� 5.      $	��70* �6#   50      51      52      