   M S B A M L   `   `   `  ����   RestaurantEducPractice-    'RestaurantEducPractice.Admin_Statistics   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ���	#FF1E1E2F.��� $��20q�  � RowDefinitions  �� $
��Auto ��� $��* �.+��� $.��(Статистика по заказам��$��22(�
�������$��0,0,0,10q��� $��1��.+�&   System.Windows.Controls.DataGrid  -     Name$ DishStatsGrid��   AutoGenerateColumns$ False�����	#FF2C2C3A
�������   RowBackground �	#FF2C2C3A   AlternatingRowBackground �	#FF252535   HeadersVisibility$ Column=����#444   GridLinesVisibility$ 
Horizontal=�$��0,0,0,20q�$	��250��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Блюдо��	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *
DishName+  $) #Количество заказов��$		 150 
 �� *TotalOrdered+  $ Общая выручка��$		 150 
 �� *TotalRevenue+  -   $ CategoryStatsGrid��$ False�����	#FF2C2C3A
������� �	#FF2C2C3A �	#FF252535$ Column=����#444$ 
Horizontal=�$	��200��   $ Категория��$	 * 
 �� *
Category+  $  Кол-во заказов��$		 200 
 �� *
OrderCount+