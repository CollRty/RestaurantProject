   M S B A M L   `   `   `  ����   RestaurantEducPractice3    -RestaurantEducPractice.Admin_ReservationsView   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ���	#FF1E1E2F.��� $��20q�  � RowDefinitions  �� $
��Auto ��� $��* ��� $
��Auto �.+��� $/��)Просмотр бронирований��$��22(�
�������$��0,0,0,10q�&   System.Windows.Controls.DataGrid  -     Name$ ReservationsGrid��$��1��   AutoGenerateColumns$ False��   HeadersVisibility$ Column=�   CanUserAddRows$ False�����	#FF2C2C3A
�������   RowBackground �	#FF2C2C3A   AlternatingRowBackground �	#FF252535���#444   GridLinesVisibility$ 
Horizontal=�   SelectionMode$ Single=�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 ФИО��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
FullName+  $
 Стол�� �� *TableNumber+  $
 Дата�� �� *ReservationDate+  $
 
Время�� �� *ReservationTime+  $
 Гостей�� �� *GuestsCount+  $
 Статус�� �� *Status+�� $��2�� �� Orientation$ 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� -   $ ��Забронировать��$	��140��$��35��$��0,0,10,0q��� -   $��Завершить��$	��140��$��35��$��0,0,10,0q��� -   $��Удалить��$	��140��$��35��$��0,0,10,0q��� -   $��Обновить��$	��140��$��35��