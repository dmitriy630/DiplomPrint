   M S B A M L   `   `   `  ����F  BDiplomPrint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DiplomPrintDiplomPrint  5   	       DiplomPrint.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:DiplomPrint     5   	   l hMicrosoft.Practices.Prism.Composition, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e350prism$http://www.codeplex.com/CompositeWPF  5   	   -   5          �Name$  
mainWindow��5
   	    � Title$ 
MainWindow��5	   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#202020   VS2012WindowStyle#��[  5   	   .��5      �  � ShowGridLines .   � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��32 �6   .+�5   
   � -   5         �Name$ MenuGrid��5      $��0��6!   $	��Top=�6,   .+�5      �� ���#2f31366   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $��Файл��6   
�������$��10,0,5,0q�6:   �� 5      $��Правка��6   
�������$	��5,0q�6<   �� 5      $��Параметры��6   
�������$	��5,0q�6?   �� 5      $��Шаблон��6   
�������$	��5,0q�6<   �� 5      $��Справка��6   
�������$	��5,0q�6=   5      5      � 5   
    .  $��0��6%    � ColumnDefinitions 5      �� 5      $��32 �6#   �� 5       $��* �6#   �� 5!      $��32 �6#   .+�5#      �  .  $��1��6)    5$      �� 5%      $��* �6$   �� 5&      $��50 �6$   .+�5(      � $��0��6   .+�5)      �� 5  /Microsoft.Practices.Prism.Regions.RegionManager   
RegionName$ RegionShell��6%   5*      �� 5+      $��1��5,      $��Bottom=�5-      $
��Left=�5.      $��28(�5/      $��0q�50      $��Light"�51      
�������$��DiplomPrint��53      54      55      56      57      