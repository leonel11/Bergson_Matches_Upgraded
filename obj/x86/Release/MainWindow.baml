   M S B A M L   `   `   `  ����   BergsonMatchesUpgraded'    !BergsonMatchesUpgraded.MainWindow   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -   $��	AppWindow��  � Title$(  "Bergson Matches (Upgraded version)�� � WindowStartupLocation$ CenterScreen=� � WindowState$ Normal=� � WindowStyle$ SingleBorderWindow=� � Icon$1 +/BergsonMatchesUpgraded;component/Match.ico��$��Microsoft Sans Serif)�$��12(�$��Normal$�$��Normal&� � Cursor$
 Hand�� � 
ResizeMode$ NoResize=�$	��480��$	��640��
������� � DataContext �� ����  �� EndPoint$ 1,0.5&�	 �� 
StartPoint$	 0,0.5&�.��� 
 � Color$
 Black�� � Offset$ 0Q�� $
 White��$ 1Q� � ContextMenu �� $��Microsoft Sans Serif)�.��� ���	#FFFFF5F0$
��Left=�$	��Top=�$	��480��$	��640��.+�o� -   $��MenuGame��$��	0,0,0,460q����	#FFE1EBFF
���   �.@�m� $
��File�� m� InputGestureText$ Ctrl+F��.@�m� -   $��New game��$ Ctrl+N��m� $
��Load��$ Ctrl+L��m� $��Load last game��$ Ctrl+G���� m� $
��Save��$ Ctrl+S��m� $��
Save As...���� m� -   $��SettingsMenuItem��$��Settings��$ Ctrl+R���� m� -   $��ExitMenuItem��$
��Exit��m� $
��Help��$ Ctrl+H��.@�m� -   $��RulesMenuItem��$��Rules��$ Ctrl+R���� m� -   $��AboutMenuItem��$��About...��%  Xceed.Wpf.Toolkit.IntegerUpDown  -   $��IntegerUpDownInput���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 1X�$��30��$��300,360,0,0q�$
��Left=�$	��Top=�$��0q�$��Center=�,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text$ 1��   TextAlignment$ Center=��  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 9X�   Minimum$ 1X�   ClipValueToMinMax . $��40��$��14(�$��Normal$�}�.  J� 	AllowDrop .  �  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ParsingNumberStyle$ Integer=� � ToolTip$ Amount of the matches�� J� OpacityMask Z� �� -	   $��ButtonConfirm��$��Confirm��$��30��$
��Left=�$��390,360,160,0q�$	��Top=�$��90��$��14(�$ Confirm���� -
   $��Label1��$��Away:��$��30��$��Center=�$��180,360,410,90q�$��Center=�$��Center=�$��Center=�$��14(�$��50���� -   $��Label2��$��Left matches:��$��30��$��Center=�$��225,303,322,147q�$��Center=�$��14(��� -   $��LabelAmountMatches��$��0��$��30��$��Center=�$��351,303,259,147q�$��Center=�$��30��$��Center=�$��Center=�$��14(��� -   $��Label3��$��Level of difficulty:��$��25��$
��Left=�$��15,40,0,415q�$��Center=��� -   $��LabelDifficulty��$��0��$��25��$
��Left=�$��
120,40,0,0q�$	��Top=�$��25���� -   $��Label4��$��Computer select:��$��25��$
��Left=�$��	15,70,0,0q�$	��Top=��� -   $��LabelFoe��$��0��$��25��$
��Left=�$��
120,70,0,0q�$	��Top=�$��25���� -   $��ButtonSounds��$��42��$
��Left=�$��
550,60,0,0q�$	��Top=�$��42��$ Switch audio mode�� �� $ 1,0.5&�$	 0,0.5&�.��� $
 Black��$ 0Q�� $
 White��$ 1Q�.���� $��
Sound2.ico���� -   $��LabelSounds��$��Sound on/off��$��25��$
��Left=�$��
530,25,0,0q�$	��Top=�$��80��