   M S B A M L   `   `   `  ����Q  MRestaurantEducPractice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:RestaurantEducPracticeRestaurantEducPractice  5   	   /    )RestaurantEducPractice.RegistrationWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:RestaurantEducPractice     5   	     � Title$  Регистрация��5   	   $	��600��5	   	   $	��450��6   ���	#FF1E1E2F � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � $��30q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Регистрация��6   $��26(�5      
�������$
��Bold"�5      $��Center=�5      $��0,0,0,20q�5      �� 5   
   $��1��6   $	��Top=�6"   .+�5      �� $��ФИО��6   
�������$��0,0,0,5q�66   �� 5      -   5         ��Name$ FullNameBox��5      $��40��6+   $��14(�67   $��0,0,0,10q�6E   ���	#FF2C2C3A
����������	#FF444455$��1q�5   X   $��10q�6l   �� 5!      $��Email��6   
�������$��0,0,0,5q�68   �� 5"      -   5        $ EmailBox��5"      $��40��6(   $��14(�64   $��0,0,0,10q�6B   ���	#FF2C2C3A
����������	#FF444455$��1q�5#   X   $��10q�6l   �� 5%      $��Телефон��6   
�������$��0,0,0,5q�6:   �� 5&      -   5        $ PhoneBox��5&      $��40��6(   $��14(�64   $��0,0,0,10q�6B   ���	#FF2C2C3A
����������	#FF444455$��1q�5'   X   $��10q�6l   �� 5)      $��Пароль��6   
�������$��0,0,0,5q�69   G� 5*      -   5         G�Name$ PasswordBox��5*      $��40��6/   $��14(�6;   $��0,0,0,10q�6I   ���	#FF2C2C3A
����������	#FF444455$��1q�5+   \   $��10q�6p   �� 5-      $)��#Подтвердите пароль��6   
�������$��0,0,0,5q�6E   G� 5.      -   5        $ ConfirmPasswordBox��5.      $��40��66   $��14(�6B   $��0,0,0,10q�6P   ���	#FF2C2C3A
����������	#FF444455$��1q�5/   \   $��10q�6p   �� 51      -   5        $&�� Зарегистрировать��51      $��40��60   $��14(�6<   ���	#FF5A67D8
�������$��0q�52   ?   $��0,0,0,10q�53      54      �� 55      -   5        $��Отмена��55      $��30��6&   $��12(�62   
������ ���	#FF9CA3AF$��0q�57      6)   58      59      5:      