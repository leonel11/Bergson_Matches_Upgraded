   M S B A M L   `   `   `  ����   BergsonMatchesUpgraded%    BergsonMatchesUpgraded.Settings   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   $��SettingsWindow��  � Title$  Settings of the game��$	��355��$	��285�� � Icon$5 //BergsonMatchesUpgraded;component/Settings2.ico��
�������.��� .+�%  Xceed.Wpf.Toolkit.IntegerUpDown  -   $��IntegerUpDownInit���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 1X�$��30��$��
205,20,0,0q�$
��Left=�$	��Top=�$��0q�$��Center=�,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text$ 1��   TextAlignment$ Center=��  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 60X�   Minimum$ 1X�   ClipValueToMinMax . $��40��$��14(�$��Normal$�}�.  J� 	AllowDrop .  �  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]	   ParsingNumberStyle$	 Integer=�
 � ToolTip$
 Initial number of matches�� J� OpacityMask Z�   -   $��IntegerUpDownMax��$ 1X�$��30��$��
205,70,0,0q�$
��Left=�$	��Top=�$��0q�$��Center=�$ 1��$ Center=�$ 9X�$ 1X� . $��40��$��14(�$��Normal$�}�.  .  $	 Integer=�$F
 @Maximum number of matches, which can be picked up for the course�� Z� �� -   $��label1��$��Initially matches:��$��28��$
��Left=�$��	50,20,0,0q�$	��Top=��� -   $��label2��$%��Maximum at a time can be taken:��$��28��$
��Left=�$��5,70,0,0q�$	��Top=��� -   $��GroupBoxDifficulty��$��Difficulty of the game��$	��120��$
��Left=�$��
65,125,0,0q�$	��Top=�$	��135��.��� $��Stretch=� � ColumnDefinitions �� $	��64* ��� $
��Auto �.+�	� -   $��RadioButtonEasy��$
��Easy��$��15��$
��Left=�$��	40,21,0,0q�$	��Top=� 	� 	GroupName$ DifficultyGroup�� d� 	IsChecked$
 TrueY�$��2��$
 	Easy mode��{�.  d� IsThreeState .  	� -   $��RadioButtonHard��$
��Hard��$��15��$
��Left=�$��	40,56,0,0q�$	��Top=�$ DifficultyGroup��$ FalseY�$��2��$
 	Hard mode���� -	   $��ButtonOK��$��OK��$��25��$
��Left=�$��
45,280,0,0q�$	��Top=�$��75��$
 OK���� -
   $��ButtonCancel��$��Cancel��$��25��$
��Left=�$��150,280,0,0q�$	��Top=�$��75��$
 Cancel��