   M S B A M L   `   `   `  ����F  BDiplomPrint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DiplomPrintDiplomPrint  5   	        DiplomPrint.SettingsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:DiplomPrint     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  SettingsWindow��5	   	   $	��450��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�5
   	      WindowSettingStyle#��[  5   	   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��Center=�6"   $��Center=�6?    �� Orientation$ 
Horizontal=�6Z   .+�5      �� -   5         ��Name$# txtChairpersonStateCommission��5      $	��600��6=   
�������)  #MaterialDesignThemes.Wpf.HintAssist   Hint$5 /Председатель госкомиссии��5   "    % !MaterialDesignFloatingHintTextBox#��[ 5   "   5      �� 5   
   $��1��6   $��Center=�6"   $��Center=�6?   $ 
Horizontal=�6Z   .+�5      �� -   5        $ 	txtLeader��5      $	��600��6)   
�������$ Руководитель��5   "   #��[ 5   "   5      �� 5   
   $��2��6   $��Center=�6"   $��Center=�6?   $ 
Horizontal=�6Z   .+�5      �� -   5        $ txtSecretary��5      $	��600��6,   
�������$ Секретарь��5    "   #��[ 5!   "   5"      �� 5#   
   $��3��6   $��Center=�6"   $��Center=�6?   $ 
Horizontal=�6Z   .+�5$      �� -   5         ��Name$ txtSecession��5$      $	��600��6-   
�������$��Bottom=�5%   5   $ Отделение��5&   5    �� 
IsEditable . .@�5(      �� .��6   31Информационных технологий5*      �� 5+      .��6   ECПромышленных технологий и экономики5-      �� 5.      .��6   " Радиоэлектроники50      51      52      �� 53   
   -   5         ��Name$ 
SaveButton��54      $��4��55      $��Right=�56      ���#ff5722���#ff5722  MaterialDesignRaisedButton#��[ 5:      $	��200��5;      $��30, 0q�6   .��6(   Сохранить63   5<      5=      