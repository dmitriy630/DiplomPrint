   M S B A M L   `   `   `  ���� F  BDiplomPrint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DiplomPrint.Styles.TabControlStyle"DiplomPrint.Styles.TabControlStyle  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   TabControlStyle  �� 
TargetType �� Property �� Value �� 
TargetType-   'System.Windows.Input.KeyboardNavigation    TabNavigation � RowDefinitions ��Name K� ZIndex K� IsItemsHost	    TabIndex
 ��Name �� CornerRadius    DirectionalNavigation ��Name  TabItemStyle  dgFocusVisualStyte � 	Resources  Key �� 
TargetName �� TargetProperty W� From	 W� To g� Duration �Name � ColumnDefinitions �� Triggers P� Property P� Value �� 
TargetName N� EnterActions  StartAction N� ExitActions  
ExitAction�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     :local0clr-namespace:DiplomPrint.Styles.TabControlStyle  %�  &	        &	 �    7  7  7  &	 s    �� "  ��.���  �@�OverridesDefaultStyle . ��  �@J�SnapsToDevicePixels . ��  � �� �� " ��.R�� $ Local=� �� $
��Auto ��� $��* �.+��� $ HeaderPanel��$��0��$ 1��$��0,0,4,-1q� . $	 1��
������ �� $
 Border��$��1��$��2q�$ 2��$ Local=�$ 	Contained=�$	 2��
������ ._��� $ PART_SelectedContentHost��$��4q�$��SelectedContent���� "  ��.���  � ��$ 12(���  � ��$
 Bold"���  � �� �	#FFB4AFAF��  �@�FocusVisualStyle8   ��  � �� �� " �� ���� StartAction .��W� $ Border1Highlited��$ (UIElement.Opacity)�$ 0X�$ 1X�$ 0:0:0.5D�W� $ Border2Highlited��$ (UIElement.Opacity)�$ 0X�$ 1X�$ 0:0:0.5D��� 
ExitAction .��W� $ Border1Highlited��$ Opacity�$ 1X�$ 0X�$ 0:0:0.3D�W� $ Border2Highlited��$ Opacity�$ 1X�$ 0X�$ 0:0:0.3D�.R�� $
 Root�� �� $��* ��� $��1 � �� $��* ��� $��6 ��� $��2 �.+��� $
 Border��$��0,0,-1,0q�
������ ._��� $ ContentSite��$��Center=�$��Center=�$��Header��$��
30,10,30,4q���. �� $��1��$��0,10,0,4q�
������ �� $��1��$��2�����	#FF5B5B5B�� $��Border1Highlited��$��1��$��2�����	#FF5B5B5B�� $��2��$��2�����	#FF303030�� $��Border2Highlited��$��2��$��2�����	#FF303030 P�  �@��
IsSelected . . ���  �@K�ZIndex$	 100���� $ Border1Highlited�� � �� �#ff3c1f�� $ Border2Highlited�� � �� �#bc2a14 �� 8��  �� 8�� P�  � {� .  . ���  � �� �	#FF5B5B5B�� .���  � �� �� .R��� $
 
FocusStyle�����	#4433b4ed