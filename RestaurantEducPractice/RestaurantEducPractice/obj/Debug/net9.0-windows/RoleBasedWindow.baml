   M S B A M L   `   `   `  ����  RestaurantEducPractice,    &RestaurantEducPractice.RoleBasedWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$+  %Панель пользователя��5   	   $	��600��5   	   $
��1000��6    � WindowStartupLocation$ CenterScreen=�5   	   ���	#FF1E1E2F � 
ResizeMode$ NoResize=�5   	   .��5	      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   .+�5   
   ]� $��2��6   ���	#FF2C2C3A$��False��6?   $	��Top=�6U   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��10,0,0,0q�62   $��Center=�6D   .+�5      �� -   5         ��Name$ UserNameText��5      
�������$��16(�6E   $
��Bold"�6S   �� 5      $	�� | ��6   
�������$��16(�6:   $	��5,0q�6H   �� 5      -   5        $ UserRoleText��5      
�������$��16(�6E   5      �� 5      -   5        $��
Выйти��5      $��
0,10,10,10q�6%   $��Right=�5       $��Center=�61   
������ 
�������
�������$��1q�5!   U   $��5q�5"      5#      �� 5&   
   -   5         ��Name$ SidebarPanel��5&      $��1��6+   $��0��68   ���	#FF2C2C3A6H   �� 5)   
   $��1��6   $��1��6   $��10q�6.   ���	#FF1E1E2F���	#FF444455$��1q�6i   ._�5*      �� -   5        $ MainContentText��5*      
�������$��24(�6D   $��Center=�6R   $��Center=�6o   5+      5,      5-      