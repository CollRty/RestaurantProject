   M S B A M L   `   `   `  ����   RestaurantEducPractice2    ,RestaurantEducPractice.Admin_TableManagement   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ���	#FF1E1E2F.��� $��20q�  � RowDefinitions  �� $
��Auto ��� $��* ��� $
��Auto �.+��� $)��#Управление столами��$��22(�
�������$��0,0,0,10q�&   System.Windows.Controls.DataGrid  -     Name$ 
TablesGrid��$��1��   AutoGenerateColumns$ False��   HeadersVisibility$ Column=�   CanUserAddRows$ False�����	#FF2C2C3A
�������   RowBackground �	#FF2C2C3A   AlternatingRowBackground �	#FF252535���#444   GridLinesVisibility$ 
Horizontal=�   SelectionMode$ Single=�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $
 Номер стола��$	 150  �� *TableNumber+  $
 Мест��$	 100  �� *Seats+  $
 Статус��$	 150  �� *Status+�� $��2�� �� Orientation$ 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� -   $��Добавить��$	��120��$��0,0,10,0q��� -   $ ��Редактировать��$	��120��$��0,0,10,0q��� -   $��Удалить��$	��120��$��0,0,10,0q��� -   $��Обновить��$	��120��