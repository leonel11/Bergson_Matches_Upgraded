   M S B A M L   `   `   `  ����  BergsonMatchesUpgraded'    !BergsonMatchesUpgraded.MainWindow   5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   x  Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�  -   5        $��	AppWindow��5   V    � Title$(  "Bergson Matches (Upgraded version)��6	    � WindowStartupLocation$ CenterScreen=�64    � WindowState$ Normal=�6Y    � WindowStyle$ SingleBorderWindow=�6n    � Icon$1 +/BergsonMatchesUpgraded;component/Match.ico��6�   $��Microsoft Sans Serif)�6�   $��12(�6�   $��Normal$�6�   $��Normal&�6   � Cursor$
 Hand��6   � 
ResizeMode$ NoResize=�6@  $	��480��6�  $	��640��6	  
������� � DataContext 6(  �� ��5      �� 5   
    �� EndPoint$ 1,0.5&�6   	 �� 
StartPoint$	 0,0.5&�6/   .��5      � 
 � Color$
 Black��6    � Offset$ 0Q�6)   � 5	      $
 White��6   $ 1Q�6)   5
       � ContextMenu 5      �� 5   
   -   5        $��ContextMenuGame��5   ,   $��Segoe UI)�6   $
 Hand��6C   .@�5      m� -   5        $��Settings��5       m� InputGestureText$ Shift+T��6)   6D   �� 5      6   m� 5      -   5        $��Rules��5      $ Shift+R��6&   6_   5      .��5      � -   5        $��AppGrid��5   n   ���	#FFFFF5F0$
��Left=�6"   $	��Top=�6=   $	��480��6U   $	��640��6b   .+�5   
   o� -   5        $��MenuGame��5   "   $��	0,0,0,460q�6   ���	#FFE1EBFF
���   �.@�5      m� $
��File��6   .@�5      m� -   5        $��New game��5      $ Shift+N��6-   6h   m� 5      -   5        $
��Load��5      $ Shift+L��6)   6e   m� 5      -	   5        $
��Save��5      $ Shift+S��6)   6e   �� 5      6   m� 5      -
   5        $��SettingsMenuItem��5      $��Settings��63   $ Shift+T��6E   6`   �� 5      m� 5      -   5        $��ExitMenuItem��5      $
��Exit��6/   $	 Esc��6=   6q   5      m� 5      $
��Help��6   .@�5      m� -   5        $��RulesMenuItem��5      $��Rules��60   $ Shift+R��6?   6x   �� 5       6   m� 5!      -   5        $��AboutMenuItem��5!      $��About...��60   6`   5"      5#      %  Xceed.Wpf.Toolkit.IntegerUpDown  5$   
   -   5        $��IntegerUpDownInput��5$   '   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 1X�6   $��30��6A   $��300,360,0,0q�6M   $
��Left=�6b   $	��Top=�6}   $��0q�6�   $��Center=�6�   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text$ 1��6�      TextAlignment$ Center=�6�   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 9X�6�      Minimum$ 1X�6�      ClipValueToMinMax . $��40��6  $��14(�68  $��Normal$�6F  }�.  J� 	AllowDrop .  �  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ParsingNumberStyle$ Integer=�6   � ToolTip$ Amount of the matches��6�   J� OpacityMask 6!  Z� 6�  �� 5%   
   -   5        $��ButtonConfirm��5%   _   $��Confirm��6   $��30��6#   $
��Left=�6/   $��390,360,0,0q�6J   $	��Top=�6t   $��90��6�   $��14(�6�   $ Confirm��6�   6�   �� 5&   
   -   5        $��Label1��5&   a   $��Away:��6   $��30��6    $��Center=�6,   $��180,360,410,90q�6I   $��Center=�6o   $��Center=�6�   $��Center=�6�   $��14(�6�   $��50��6�   �� 5'   
   -   5        $��Label2��5'   j   $��Left matches:��6   $��30��6(   $��Center=�64   $��225,303,322,147q�6Q   $��Center=�6x   $��14(�6�   �� 5(   
   -   5        $��LabelAmountMatches��5(   ^   $��0��6   $��30��6   $��Center=�6(   $��351,303,259,147q�6E   $��Center=�6x   $��30��6�   $��Center=�6�   $��Center=�6�   $��14(�6�   �� 5)   
   -   5        $��Label3��5)   k   $��Level of difficulty:��6   $��25��6/   $
��Left=�6;   $��15,40,0,415q�6V   $��Center=�6y   �� 5*   
   -   5        $��LabelDifficulty��5*   W   $��0��6   $��25��6   $
��Left=�6(   $��
120,40,0,0q�6C   $	��Top=�6n   $��25��6�   �� 5+   
   -   5        $��Label4��5+   e   $��Computer select:��6   $��25��6+   $
��Left=�67   $��	15,70,0,0q�6R   $	��Top=�6s   �� 5,   
   -   5        $��LabelFoe��5,   W   $��0��6   $��25��6   $
��Left=�6(   $��
120,70,0,0q�6C   $	��Top=�6g   $��25��6   �� 5-   
   -   5        $��ButtonSounds��5-   L   $��42��6   $
��Left=�6   $��
565,60,0,0q�68   $	��Top=�6`   $��42��6x   $ Switch audio mode��6�    5.      �� 5/      $ 1,0.5&�6&   $	 0,0.5&�67   .��50      � $
 Black��6#   $ 0Q�61   � 51      $
 White��6#   $ 1Q�61   52      .��54      �� -   5        $��
ImageSound��54   (   $��
Sound2.ico��6   6(   55      �� 56   
   -   5        $��LabelSounds��56   [   $��Sound��6   $��25��6    $
��Left=�6,   $��
555,25,0,0q�6G   $	��Top=�6n   $��80��6�   � 57   
   -   5        $��WrapPanelMatches��57   P   $	��120��6   $
��Left=�6!   $��
75,140,0,0q�6<   $	��Top=�6h   $	��480��6�   $ Arrow��6�   6�   �� 58   
   -   5        $��StatusBarGame��58   Z   $��22��6   $��Stretch=�6    $��Stretch=�6<   $ Arrow��6o   $
��Auto��6~   $��	0,404,0,0q�6�   .@�59      �� .��5:      �� -   5        $��StatusGameTextBlock��5:      $	��640��67   5;      5<      r� 5=   
   -   5        $��mediaElementSounds��5=   S   $��32��6   $
��Left=�6#   $��570,110,0,0q�6>   $	��Top=�6m   $��32��6�    r� Source$ 	Match.wav?�6�   5>      5?      