   M S B A M L   `   `   `  ����Q  MRestaurantEducPractice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:RestaurantEducPracticeRestaurantEducPractice  5      '    !RestaurantEducPractice.MainWindow   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      6local$clr-namespace:RestaurantEducPractice     5        � Title$  Авторизация��5	      $	��500��5
      $	��400��6    � WindowStartupLocation$ CenterScreen=�5      ���	#FF1E1E2F � 
ResizeMode$ NoResize=�5       � 	Resources 5      6   0RestaurantEducPractice.BoolToVisibilityConverter   BoolToVisibilityConverter��%   &	          5   
   6*   5      .��5      � $��30q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $%��Добро пожаловать��6!   $��26(�5      
�������$��Center=�5       $��Bottom=�5!      $��0,0,0,20q�5"      $
��Bold"�5#      � 5%   
   $��1��6   $��0,0,0,15q�6   $��40��6.   .+�5&      �� -   5         ��Name$ LoginBox��5&      $��14(�5'      $��10q�5(      ���	#FF2C2C3A
����������	#FF444455$��1q�5,      �� 5-      $��Email��6   $��14(�5.      ���	#FF9CA3AF$��15,0,0,0q�50      $��Center=�51       J� IsHitTestVisible$ False��52      y�53      �� *Text.IsEmpty+ �� ElementName$ LoginBox�� �� 	Converter# [  54      G� 56   
   -   5        	 G�Name$	 PasswordBox��56      $��2��6+   $��40��68   $��0,0,0,15q�57      $��14(�58      $��10q�59      ���	#FF2C2C3A
����������	#FF444455$��1q�5=      �� 5>   
   $��Password��6   $��14(�5?      ���	#FF9CA3AF$��	15,12,0,0q�5A      $	��Top=�5B      $ False��5C      $��2��5D   �   y�6   �� *Text.IsEmpty+$ LoginBox��# [  6�   �� 5F   
   -   5        $��3��5F      $��
Войти��6   $��40��5G      ���	#FF5A67D8
�������$��SemiBold"�5J      $��14(�5K      $��0q�5L      $��0,0,0,10q�5M      
 � Cursor$

 Hand��5N      5O      �� 5Q   
   -   5        $��4��5Q      $��Регистрация��6   
������ ���	#FF9CA3AF$��12(�5T      $��0q�5U      $

 Hand��5V      $��Center=�5W      5X      5Y      5Z      