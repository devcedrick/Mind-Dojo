   M S B A M L   `   `   `  ����H  DPomodoroTimer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PomodoroTimerPomodoroTimer  5   	       PomodoroTimer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PomodoroTimer     5   	     � Icon$/  )pack://application:,,,/Resources/Logo.ico��5   	    � Title$ 	Mind Dojo��5	   	   $��703.125��6   $
��1250��6,   .��5      � -   5         �Name$ mainGrid��5       � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   .+�5   
   � -   5        $ 
leftColumn��5      $��0��6#   ���#16db65 � ShowGridLines .   � RowDefinitions 5      �� 5      $��1* �6    �� 5      $��2* �6    .+�5      �� $��Resources/Logo.png��6   $	��229��60   $	��262��6=   $��Center=�6I   $��Center=�6f   $��0,0,0,0q�6�   �� 5      $��1��6   .+�5      �� $��Session Length��6   $��Poppins)�62   $��24(�6G   $��SemiBold"�6U   $��	35,10,5,5q�6k   $��34��6~   �� 5      $��55.42��6   $	��375��6(   .+�5      �� $��55.42��6    $	��375��6/   $	��Top=�6;   ���#1b4332 �� RadiusX$ 20��6b    �� RadiusY$ 20��6o   � 5       � Orientation$ 
Horizontal=�6    .+�5      �� -   5        	 ��Name$	 ws15_button��5   !   $��55.42��66   $��93.75��6E   
 �� CornerRadius$
 	20,0,0,20��6S   $��Center=�6l   ._�5      �� $��15��6(   $��39(�62   $��Poppins)�6@   
������� �� TextAlignment$ Center=�6h   $��Center=�6   5       �� 5!      ���#FFFFFF6$   �� 5"      -   5        $	 ws25_button��5"   !   $��55.42��66   $��93.75��6E   ���#05120E$
 0,0,0,0��6h   $��Center=�6   ._�5#      �� $��25��6)   $��39(�63   $��Poppins)�6A   
�������$ Center=�6i   $��Center=�6�   5$      �� 5%      ���#FFFFFF6$   �� 5&      -   5        $	 ws45_button��5&   !   $��55.42��66   $��93.75��6E   $
 0,0,0,0��6S   $��Center=�6j   ._�5'      �� $��45��6(   $��39(�62   $��Poppins)�6@   
�������$ Center=�6h   $��Center=�6   5(      �� 5)      
�������6$   �� 5*      -   5        $	 ws60_button��5*   !   $��55.42��66   $��93.75��6E   $
 	0,20,20,0��6S   $��Center=�6l   ._�5+      �� $��60��6(   $��39(�62   $��Poppins)�6@   
�������$ Center=�6h   $��Center=�6   5,      5-      5.      �� 50      $��Short Break��6   $��Poppins)�6/   $��24(�6D   $��SemiBold"�6R   $��	35,15,5,5q�6h   $��34��6{   �� 51      $��55.42��6   $	��375��6(   .+�52      �� $��55.42��6    $	��375��6/   $	��Top=�6;   ���#1b4332$ 20��6b   $ 20��6o   � 53      $ 
Horizontal=�6    .+�54      �� -   5        $	 
sb3_button��54   !   $��55.42��65   $��93.75��6D   $
 	20,0,0,20��6R   $��Center=�6k   ._�55      �� $��3��6(   $��39(�61   $��Poppins)�6?   
�������$ Center=�6g   $��Center=�6~   56      �� 57      ���#FFFFFF6$   �� 58      -   5        $	 
sb5_button��58   !   $��55.42��65   $��93.75��6D   ���#05120E$
 0,0,0,0��6g   $��Center=�6~   ._�59      �� $��5��6)   $��39(�62   $��Poppins)�6@   
�������$ Center=�6h   $��Center=�6   5:      �� 5;      ���#FFFFFF6$   �� 5<      -	   5        $	 sb15_button��5<   !   $��55.42��66   $��93.75��6E   $
 0,0,0,0��6S   $��Center=�6j   ._�5=      �� $��15��6(   $��39(�62   $��Poppins)�6@   
�������$ Center=�6h   $��Center=�6   5>      �� 5?      
�������6$   �� 5@      -
   5        $	 sb25_button��5@   !   $��55.42��66   $��93.75��6E   $
 	0,20,20,0��6S   $��Center=�6l   ._�5A      �� $��25��6(   $��39(�62   $��Poppins)�6@   
�������$ Center=�6h   $��Center=�6   5B      5C      5D      �� 5F      $��
Long Break��6   $��Poppins)�6.   $��24(�6C   $��SemiBold"�6Q   $��	35,15,5,5q�6g   $��34��6z   �� 5G      $��55.42��6   $	��375��6(   .+�5H      �� $��55.42��6    $	��375��6/   $	��Top=�6;   ���#1b4332$ 20��6b   $ 20��6o   � 5I      $ 
Horizontal=�6    .+�5J      �� -   5        $	 lb15_button��5J   !   $��55.42��66   $��93.75��6E   $
 	20,0,0,20��6S   $��Center=�6l   ._�5K      �� $��15��6(   $��39(�62   $��Poppins)�6@   
�������$ Center=�6h   $��Center=�6   5L      �� 5M      ���#FFFFFF6$   �� 5N      -   5        $	 lb25_button��5N   !   $��55.42��66   $��93.75��6E   ���#05120E$
 0,0,0,0��6h   $��Center=�6   ._�5O      �� $��25��6)   $��39(�63   $��Poppins)�6A   
�������$ Center=�6i   $��Center=�6�   5P      �� 5Q      ���#FFFFFF6$   �� 5R      -   5        $	 lb45_button��5R   !   $��55.42��66   $��93.75��6E   $
 0,0,0,0��6S   $��Center=�6j   ._�5S      �� $��45��6(   $��39(�62   $��Poppins)�6@   
�������$ Center=�6h   $��Center=�6   5T      �� 5U      
�������6$   �� 5V      -   5        $	 lb60_button��5V   !   $��55.42��66   $��93.75��6E   $
 	0,20,20,0��6S   $��Center=�6l   ._�5W      �� $��60��6(   $��39(�62   $��Poppins)�6@   
�������$ Center=�6h   $��Center=�6   5X      5Y      5Z      �� 5\      -   5        ���#05120E$��45��5\   .   $	��220��6:   $
��0,30q�6F   $
 20��6i   ._�5]      �� $��Start Session��6    $��25(�65   $��Poppins)�6C   $ Center=�6X   $��Center=�6o   ���#FFFFFF6�   5^      5`      5a      � 5d   
   -   5        $ rightColumn��5d      $��1��6%   ���#05120E 5e      �� 5f      $��1* �6    �� 5g      $��2* �6    �� 5h      $��1* �6    .+�5k      � $��0��6   ���	#60FFFFFF$��Bottom=�67   $	��700��6R   $��2��6^   $��0,20,0,0q�6i   �� 5l      $��0��6   $��40��6&   $
��Auto��62   $��Right=�6?   $	��Top=�6[    �� Orientation$ 
Horizontal=�6s   $��8q�6�   .+�5m      �� -   5         ��Name$ minimize_button��5m      $3��-pack://application:,,,/Resources/Minimize.png��61   $��35��6h   $��35��6s    J� Opacity$
 0.75Q�6   6�   �� 5n      -   5        $ close_button��5n      $0��*pack://application:,,,/Resources/Close.png��6.   $��40��6b   $��40��6m   $	��5,0q�6y   $
 0.75Q�6�   6�   5o      �� 5p      -   5         ��Name$ session_text��5p      $��0��6.   $��Session 1 out of 4��6;   $��Poppins)�6U   $��35(�6j   $��
ExtraLight"�6x   ���#FFFFFF$��Bottom=�6�   $ Center=�6�   $
��0,20q�6�   �� 5r      -   5        $ TimerTextBlock��5r      $��1��60   $��25:00��6=   $	��270(�6J   $��Poppins)�6Y   $��
ExtraBlack"�6n   ���#FFFFFF$��Center=�6�   $��Center=�6�   � 5s      $��2��6   ���	#60FFFFFF$	��Top=�67   $	��700��6O   $��2��6[   $��0,0,0,20q�6f   �� 5t      -   5         ��Name$ timer_buttons��5t      $��2��60   $	��Top=�6=   $��Center=�6U   $��60��6r   $
��Auto��6~   $ 
Horizontal=�6�   $
��0,20q�6�   $y�Hidden=�6�   .+�5u      �� -   5        ���#16db65$��60��5u   .   $��60��69   $
��15,0q�6E   $
 50��6S   ._�5v      �� -   5        $ pauseplay_button��5v      $��Resources/Pause.png��66   $��45��6S   5w      �� 5x      -   5        $	 stop_button��5x      ���#16db65$��60��6C   $��60��6N   $
��15,0q�6Z   $
 50��6h   ._�5y      �� $��Resources/Stop.png��6   $��45��68   5z      �� 5{      -   5        $	 resert_button��5{      ���#16db65$��60��6E   $��60��6P   $
��15,0q�6\   $
 50��6j   ._�5|      �� -   5        $ disable_reset��5|      $��Resources/Reset.png��63   $��50��6P   5}      5~      5      5�      5�      