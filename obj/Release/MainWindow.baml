   M S B A M L   `   `   `  ���� F  BDiplomPrint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DiplomPrintDiplomPrint      DiplomPrint.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:DiplomPrint     l hMicrosoft.Practices.Prism.Composition, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e350prism$http://www.codeplex.com/CompositeWPF  -     �Name$  
mainWindow�� � Title$ 
MainWindow�� � WindowStartupLocation$ CenterScreen=����#202020   VS2012WindowStyle#��[  .���  � ShowGridLines .   � RowDefinitions �� $��* ��� $��32 �.+�� -    �Name$ MenuGrid��$��0��$	��Top=�.+��� ���#2f3136��  �� Orientation$ 
Horizontal=�.+��� $��Файл��
�������$��10,0,5,0q��� $��Правка��
�������$	��5,0q��� $��Параметры��
�������$	��5,0q��� $��Шаблон��
�������$	��5,0q��� $��Справка��
�������$	��5,0q��  .  $��0�� � ColumnDefinitions �� $��32 ��� $��* ��� $��32 �.+��  .  $��1�� �� $��* ��� $��50 �.+�� $��0��.+��� 5  /Microsoft.Practices.Prism.Regions.RegionManager   
RegionName$ RegionShell���� $��1��$��Bottom=�$
��Left=�$��28(�$��0q�$��Light"�
�������$��DiplomPrint��