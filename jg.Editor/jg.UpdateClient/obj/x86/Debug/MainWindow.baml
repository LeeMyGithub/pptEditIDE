   M S B A M L   `   `   `  ����  jg.UpdateClient     jg.UpdateClient.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � AllowsTransparency  . 
������  � Title$ 
MainWindow��5   S   $	��220��6g   $	��520��6t    � WindowState$ Normal=�6�    � WindowStyle$
 None=�6�    � WindowStartupLocation$ CenterScreen=�6�   .��5      � ���	#FFF2F2F2$	��210��6"   $	��500��6/    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 9Q�6      Color$ 	#FF000000��6.      	Direction$	 -60Q�6@   	   Opacity$	 1Q�6P   
   ShadowDepth$
 0Q�6\    � RowDefinitions 5	   
   �� 5
      $
��auto �6   �� 5      �� 5      .+�5   
   � $��0��6   ���	#FFFF4D00$��76��63   $	��Top=�6?    � ColumnDefinitions 5      �� 5      $
��auto �6$   �� 5      �� 5      .+�5      �� -   5        ���	#FF2D3340$��0��5   )   $��3��6:   $��72��6N   $	��Top=�6[   6�   F� 5      -   5         F�Name$ logopath��5      $
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
-@���� �q5�� �q5Ӏ� �q5�� Pc� �� Pc� ����� Ӹ���� �΂�V �΂�V Ә΂�V 8�W�T� 8�W�T� �8�W�T� � 2 ��M � 2 ��M �� 2 ��M 8S� 8x" 8S� 8x" �8S� 8x" ��_��b ��_��b Ӡ�_��b (�8�R (�8�R �(�8�R ��`��C ��`��C ӈ�`��C ����� ����� ���	#FFFF4D00$��46��6�   �� Left$ 37��6�  
 �� Top$ 23��6�  $��44��6�  $��25,0,0,0q�6  �� 5      -   5         ��Name$ logotxt��5      $��Center=�6)   $��5,0,0,0q�6�   $��1��6�   ���	#FFFFFFFF$��25(�6�   $��Microsoft YaHei)�6�    �� IsHyphenationEnabled . $ 90.789��6   �� TextAlignment$
 Left=�6  $
��Wrap=�60  $��多媒体课件编辑器��6D  $ 26.241��6T  5      �� 5      -   5         � Cursor$
 Hand��5      
������    buttonClose#��[  6?   $��2��6e   $��Right=�6v   $��0,0,7,0q�6�   .��5      F� -   5        $ Error_2��5      �����W� �x ӰW� �x 8�z ��K 8�z ��K �8�z ��K xr= ���Q��?xr= ���Q��?Sxr= ���Q��?�v - �v - ��v - H=\ ��i H=\ ��i �H=\ ��i � �c� � �c� �� �c� `|< _� `|< _� �`|< _� �wx �� �wx �� ��wx �� �I� �l� �I� �l� ��I� �l� 0S� �ܧ 0S� �ܧ �0S� �ܧ �  lk �  lk ��  lk �� (- �� (- ��� (- �W� �x �W� �x ���	#FFFFFFFF$��15��6  $��16��6  5      5      �� 5   
   $��1��6   $��Center=�6$   $��
40,10,40,0q�6A   .+�5!   
   � -   5        $��progressBar��5!      $	��Top=�6,   ���	#FFFF4D00$��20��6]   �� 5"      -   5        $��
txtMessage��5"      $y�	Collapsed=�6*   $	��123��6D   $��5q�6O   $
��Wrap=�6Z   �� 5#      -	   5        $��	textBlock��5#   %   $��3��6   $$��正在更新文件······��66   $��5q�6J   5$      �� 5&   
   $��2��6   $��停止��6     ButtonStyleNew#��[ 6+   $	��120��6U   $��30��6a   $��18(�6m   
�������6�   5'      5(      