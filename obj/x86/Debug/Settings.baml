   M S B A M L   `   `   `  ����  BergsonMatchesUpgraded%    BergsonMatchesUpgraded.Settings   5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5        $��SettingsWindow��5   �     � Title$  Settings of the game��6	   $	��355��6&   $	��285��63    � Icon$5 //BergsonMatchesUpgraded;component/Settings2.ico��6?   
������� � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�    � Cursor$
 Hand��6�    � WindowStyle$ SingleBorderWindow=�6�   .��5      � .+�5   
   %  Xceed.Wpf.Toolkit.IntegerUpDown  -   5        $��IntegerUpDownInit��5   '   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 1X�6   $��30��6@   $��
205,20,0,0q�6L   $
��Left=�6`   $	��Top=�6{   $��0q�6�   $��Center=�6�   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text$ 1��6�      TextAlignment$ Center=�6�   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]	   Maximum$	 60X�6�   
   Minimum$
 1X�6�      ClipValueToMinMax . $��40��6  $��14(�67  $��Normal$�6E  }�.  J� 	AllowDrop .  �  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ParsingNumberStyle$ Integer=�6~   � ToolTip$ Initial number of matches��6�   J� OpacityMask 6   Z� 6�    5   
   -   5        $��IntegerUpDownMax��5   '   $ 1X�6   $��30��6?   $��
205,70,0,0q�6K   $
��Left=�6_   $	��Top=�6z   $��0q�6�   $��Center=�6�   $ 1��6�   $ Center=�6�   $	 9X�6�   $
 1X�6�    . $��40��6  $��14(�65  $��Normal$�6C  }�.  .  $ Integer=�6|  $F @Maximum number of matches, which can be picked up for the course��6�   6  Z� 6�  �� 5	   
   -   5        $��label1��5	   g   $��Initially matches:��6   $��28��6-   $
��Left=�69   $��	50,20,0,0q�6T   $	��Top=�6u   �� 5
   
   -   5        $��label2��5
   s   $%��Maximum at a time can be taken:��6   $��28��6:   $
��Left=�6F   $��5,70,0,0q�6a   $	��Top=�6�   �� 5   
   -   5        $��GroupBoxDifficulty��5   o   $��Difficulty of the game��6   $	��120��63   $
��Left=�6@   $��
65,125,0,0q�6[   $	��Top=�6�   $	��135��6�   .��5      � $��Stretch=�6    � ColumnDefinitions 5      �� 5      $	��64* �6'   �� 5      $
��Auto �6'   .+�5      	� -   5        $��RadioButtonEasy��5   g   $
��Easy��6   $��15��6-   $
��Left=�69   $��	40,21,0,0q�6T   $	��Top=�6~    	� 	GroupName$ DifficultyGroup��6�    d� 	IsChecked$
 TrueY�6�   $��2��6�   $ 	Easy mode��6�   {�.  d� IsThreeState .  6  	� 5      -   5        $��RadioButtonHard��5   g   $
��Hard��6   $��15��6-   $
��Left=�69   $��	40,56,0,0q�6T   $	��Top=�6~   $ DifficultyGroup��6�   $ FalseY�6�   $��2��6�   $ 	Hard mode��6�   6�   5      5      �� 5   
   -	   5        $��ButtonOK��5   Y   $��OK��6   $��25��6   $
��Left=�6*   $��
45,280,0,0q�6E   $	��Top=�6i   $��75��6�   $ OK��6�   6�   �� 5   
   -
   5        $��ButtonCancel��5   ^   $��Cancel��6   $��25��6"   $
��Left=�6.   $��150,280,0,0q�6I   $	��Top=�6r   $��75��6�   $ Cancel��6�   6�   5      5      