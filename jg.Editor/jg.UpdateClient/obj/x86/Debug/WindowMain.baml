   M S B A M L   `   `   `  ����  jg.UpdateClient     jg.UpdateClient.WindowMain   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
WindowMain��5   	   $	��540��6   $	��525��6,   
������  � WindowStyle$
 None=�6Q    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6�   .��5      � ���	#FFF2F2F2$	��530��6#   $	��505��61    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 9Q�6      Color$ 	#FF000000��6.      	Direction$	 -60Q�6@      Opacity$ 1Q�6P   	   ShadowDepth$	 0Q�6\   
 � RowDefinitions
 5	   
   �� 5
      $
��auto �6   �� 5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   � $��0��6   ���	#FFFF4D00$��76��63   $	��Top=�6?    � ColumnDefinitions 5      �� 5      $
��auto �6$   �� 5      �� 5      .+�5      �� -   5        ���	#FF2D3340$��0��5   )   $��3��6:   $��72��6N   $	��Top=�6[   6�   F� 5      -   5         F�Name$ logopath��5      $
��Left=�6%   $��Center=�6�   ������ ��� �� ��� � ��� ���� ��j�t�T@@�,^j�t�T@@�,^�j�t�T@@�,^j�t�T@@;�O���@@j�t�T@@;�O���@@j�t�T@@;�O���@@� �H�� �H��� �H�� �0�.� �0�.�� �0�.�@���@����@����o��o���o� ��� � ��� ��� Pc� Ӏ� Pc� h
-�oh
-�o�h
-�oh
-��h
-���h
-����� ��6��� ��6Ӑ�� ��6��� ;�O���@@��� ;�O���@@S��� ;�O���@@ȁ�  �ȁ�  ��ȁ�  �ȁ� @��ȁ� @���ȁ� @���R� ����R� �����R� ����R� P4z�R� P4z��R� P4zh
-0��h
-0���h
-0��h
-@��h
-@���h
-@���� �q5�� �q5Ӏ� �q5�� Pc� �� Pc� ����� Ӹ���� �΂�V �΂�V Ә΂�V 8�W�T� 8�W�T� �8�W�T� � 2 ��M � 2 ��M �� 2 ��M 8S� 8x" 8S� 8x" �8S� 8x" ��_��b ��_��b Ӡ�_��b (�8�R (�8�R �(�8�R ��`��C ��`��C ӈ�`��C ����� ����� ���	#FFFF4D00$��46��6�   �� Left$ 37��6�  
 �� Top$ 23��6�  $��44��6�  $��25,0,0,0q�6  �� 5      -   5         ��Name$ logotxt��5      $��Center=�6)   $��5,0,0,0q�6�   $��1��6�   ���	#FFFFFFFF$��25(�6�   $��Microsoft YaHei)�6�    �� IsHyphenationEnabled . $ 90.789��6   �� TextAlignment$
 Left=�6  $
��Wrap=�60  $��更新��6D  $ 26.241��6N  5      �� 5      -   5         � Cursor$
 Hand��5      
������    buttonClose#��[  6?   $��2��6e   $��Right=�6v   $��0,0,7,0q�6�   .��5      F� -   5        $ Error_2��5      �����W� �x ӰW� �x 8�z ��K 8�z ��K �8�z ��K xr= ���Q��?xr= ���Q��?Sxr= ���Q��?�v - �v - ��v - H=\ ��i H=\ ��i �H=\ ��i � �c� � �c� �� �c� `|< _� `|< _� �`|< _� �wx �� �wx �� ��wx �� �I� �l� �I� �l� ��I� �l� 0S� �ܧ 0S� �ܧ �0S� �ܧ �  lk �  lk ��  lk �� (- �� (- ��� (- �W� �x �W� �x ���	#FFFFFFFF$��15��6  $��16��6  5       5!      �� 5#   
   $
��Left=�6   $��Center=�60   $��1��6M   $��60,5,0,0q�6Z   ���	#FF000000$��Microsoft YaHei)�6�    . $ 75��6�   $
 Left=�6�   $
��Wrap=�6�   $	 111��6�   �� 6	  $
��Bold"�6  $��16(�6  $1�+多媒体课件编辑器有新的版本！
��6-  �� 6J  $��14(�6N  $Q�K多媒体课件编辑器2.0是可用版本，您想要现在就下载吗？��6\  6�  �� 5'   
   $��	60,0,60,0q�6   $��2��6)   .+�5(      �� $��0,0,0,5q�6   ���	#FF000000$
��Bold"�6B   $��14(�6T   $��Microsoft YaHei)�6b    . $
 Left=�6�   $
��Wrap=�6�   $��新版本特性：��6�   �� 5)      -   5         ��Name$ 
txtContent��5)   7   $	��235��6   $��1q�6#   ���	#ffc4c4c4$��5q�6d    �� TextWrapping$
 Wrap=�6p   6�   5*      �� 51   
   $��6��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�52   
   �� -   5        $��更新��52        ButtonStyleNew#��[ 6   $	��120��6J   $��30��6V   $��18(�6b   $��0,0,5,30q�6p   
�������6�   �� 53   
   -   5        $��以后再说��53      #��[ 6!   $	��120��6K   $��30��6W   $��18(�6c   $��5,0,0,30q�6q   
�������6�   54      55      56      