   M S B A M L   `   `   `  ����L  Hjg.Editor.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:jg.Editor.Library.Controljg.Editor.Library.Control  5      0    *jg.Editor.Library.Control.ControlTopicDrag   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6my'clr-namespace:jg.Editor.Library.Control     5      -   5        }�.   � 	Resources  5	         thumbAnswer �� 
TargetType,   &jg.Editor.Library.Control.ControlThumb �� Property �� Value �� 
TargetType � DataContext � Cursor   TextVisibility   Text  thumbQuestion	 �� Left

 �� Top  MoveThumbTemplate)   #jg.Editor.Library.Control.MoveThumb  textControl  Name��%�  &	        &	 �    &	 �    &	 �    7  �� 5   
   "  6$   .�5      ��  � �� 5      �� 5      "  6&   .R�5      � $	��120��6    $��30��6,    68   �� *0.RelativeSource{RelativeSource TemplatedParent}+.+�5      �� $ SizeAll��6*   
������ $��0��6P   ���	#FFB4B4B4$	��120��6u   $��30��6�   5      �� 5      $��Center=�6/   $��Center=�6L   #y�z 6h   ���#ECECEC#��z 6�   5      5      5      5      �� 5   
   "  6&   .�5      ��  � �� 5      �� 5      "  6&   .R�5       A� $ SizeAll��6"   $��10��63   $��10��6?   
����  �$		 269��6V   $	
 104��6h   5!      5#      5$      �� 5&   
   "  64   .R�5'      �� 
������ 6   5(      �� 5*   
   " ��6$   .�5+      ��  � �� �#FD70536+   �� 5,       � �� 5.      �� 5/      " ��6&   .R�50      � $	��120��6    $��30��6,    68   �� *0.RelativeSource{RelativeSource TemplatedParent}+.+�51      �� #��z��6*   53      �� 54      $��Center=�6/   $��Center=�6L   
���  ��6i     55      $ PART_MoveThumb��6+   $ SizeAll��56   &   8��  57   &   58      59      5;      5<      5>      .��5?      �  � RowDefinitions 5@   
   �� 5A      �� 5B      $
��auto �6   .+�5D   
   �� -   5        $��canvas��5D      $��0��6   5F      �� 5G   
   -   5        $��	btnSubmit��5G        btnSubmitStyle#��[ 6#   $��1��5H      $��Right=�5I      $��0,0,10,0q�5J      $��30��5K      $��50��5L      
�������  FF000066#��[ 5M      5N      5O      5R      