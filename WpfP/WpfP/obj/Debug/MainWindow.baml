   M S B A M L   `   `   `  ����?  ;WpfP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfPWpfP  5   	   p lDotNetProjects.DataVisualization.Toolkit, Version=6.1.94.0, Culture=neutral, PublicKeyToken=79778c5f2eed289b�rclr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=DotNetProjects.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5   	       WpfP.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:WpfP     5   	   �DVCrclr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=DotNetProjects.DataVisualization.Toolkit     5   	   Ddxc4http://schemas.devexpress.com/winfx/2008/xaml/charts     5   	   -   5          �Name$  Window1��5
   	    � Title$ КГМУ��6    � WindowStartupLocation$ CenterScreen=�6'    � 
ResizeMode$ 	CanResize=�6L   $	��450��6c   $	��800��6p    � Icon$ /Images/Icon1.jpg��6�   .��5      �  � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $
��0.5* �6   $��50��6+   �� 5      $
��0.5* �6   $��50��6+    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   >  8System.Windows.Controls.DataVisualization.Charting.Chart  -   5          Name$ DVCHistogram��5      $��
0,0,-110,0q�6*   $��0��6>   $��0��6K   $��3��6[      Series. 5      E  ?System.Windows.Controls.DataVisualization.Charting.ColumnSeries  H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries	   DependentValuePath$	 Value��6   
   IndependentValuePath$	
 Key��6:    � DataContext 6U   ��    ItemsSource 6m   �� 5      � 5   
   -   5         �Name$ 
PBProgress��5      $��1��6*   $��0��67   $��3��6G   $��10,10q�6[   �� 5   
   -   5         ��Name$ 
BtnNewUser��5      $��15(�6%   $)��#Новый пользователь��63   $��0��6P   $��2��6`   $��
25,5,25,10q�6m   6�   �� 5   
   -   5        $ BtnStart��5      $��15(�6#   $��Начать��61   $��1��6B   $��2��6R   $��
25,5,25,10q�6_   6s   �� 5   
   -   5        $ BtnSave��5      $��15(�6"   $��Сохранить��60   $��2��6D   $��2��6T   $��
25,5,25,10q�6a   6u   5$      5%      