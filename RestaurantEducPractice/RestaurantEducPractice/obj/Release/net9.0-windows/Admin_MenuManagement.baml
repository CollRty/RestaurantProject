   M S B A M L   `   `   `  ����   RestaurantEducPractice1    +RestaurantEducPractice.Admin_MenuManagement   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ���	#FF1E1E2F.��� $��20q�  � RowDefinitions  �� $
��Auto ��� $��* ��� $
��Auto �.+��� $6��0Управление меню ресторана��$��22(�
�������$��0,0,0,10q�&   System.Windows.Controls.DataGrid  -     Name$ 
DishesGrid��$��1��   AutoGenerateColumns$ False��   HeadersVisibility$ Column=�   CanUserAddRows$ False�����	#FF2C2C3A
�������   RowBackground �	#FF2C2C3A   AlternatingRowBackground �	#FF252535���#444   GridLinesVisibility$ 
Horizontal=�   SelectionMode$ Single=�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Название��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $
 Цена��$	 100  �� *Price+  $
 Категория��$	 150  �� *CategoryName+  $
 Остаток��$	 100  �� *PortionsAvailable+�� $��2�� �� Orientation$ 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� -   $��Добавить��$	��120��$��35��$��0,0,10,0q��� -   $ ��Редактировать��$	��120��$��35��$��0,0,10,0q��� -   $��Удалить��$	��120��$��35��$��0,0,10,0q��� -   $��Обновить��$	��120��$��35��