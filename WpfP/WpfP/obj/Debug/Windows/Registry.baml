   M S B A M L   `   `   `  ����?  ;WpfP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfPWpfP  5   	       WpfP.Registry   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:WpfP     5   	     � Title$  Регистрация��5   	    � WindowStartupLocation$ CenterScreen=�6    � Icon$ /Images/Icon1.jpg��6B    � 
ResizeMode$ NoResize=�6[   $	��320��6q   $	��400��6~   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��3* �6   �� 5      $
��0.1* �6   .+�5   
   �� $��15(�6   $��Center=�6   $��1��6;   $��0��6K   $��Имя��6X   �� 5   
   $��15(�6   $��Center=�6   $��1��6;   $��1��6K   $��Фамилия��6X   �� 5   
   $��15(�6   $��Center=�6   $��1��6;   $��2��6K   $��Группа��6X   �� 5   
   $��15(�6   $��Center=�6   $��1��6;   $��3��6K   $��Возраст��6X   �� 5   
   -   5         ��Name$ TBName��5      $��15(�6"    �� TextAlignment$ Center=�60   $��Stretch=�6G   $��Stretch=�6c   $��1��6�   $��0��6�   $��10,25,10,7.5q�6�    �� TextWrapping$
 Wrap=�6�   �� 5   
   -   5        $ 	TBSurname��5      $��15(�6%   $ Center=�63   $��Stretch=�6J   $��Stretch=�6f   $��1��6�   $��1��6�   $��10,25,10,7.5q�6�   $
 Wrap=�6�   �� 5   
   -   5        $ TBSecondName��5      $��15(�6(   $ Center=�66   $��Stretch=�6M   $��Stretch=�6i   $��1��6�   $��2��6�   $��10,25,10,7.5q�6�   $
 Wrap=�6�   �� 5   
   -   5        $ 
TBBirthday��5      $��15(�6&   $ Center=�64   $��Stretch=�6K   $��Stretch=�6g   $��1��6�   $��3��6�   $��10,25,10,7.5q�6�   $
 Wrap=�6�   �� 5   
   -   5        	 ��Name$	 
BtnConfirm��5      $��15(�6%   $��Подтвердить��63   $��Stretch=�6I   $��Stretch=�6e   $��1��6�   $��4��6�   $��75,10,75,10q�6�   6�   5      5       