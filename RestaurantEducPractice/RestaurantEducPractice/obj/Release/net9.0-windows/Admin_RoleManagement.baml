   M S B A M L   `   `   `  ���� Q  MRestaurantEducPractice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:RestaurantEducPracticeRestaurantEducPractice  1    +RestaurantEducPractice.Admin_RoleManagement   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6local$clr-namespace:RestaurantEducPractice     ���	#FF1E1E2F.��� $��20q�  � RowDefinitions  �� $
��Auto ��� $��* ��� $
��Auto �.+��� $B��<Управление ролями пользователей��$��22(�
�������$��0,0,0,10q�&   System.Windows.Controls.DataGrid  -     Name$ ClientsGrid��$��1��   AutoGenerateColumns$ False��   HeadersVisibility$ Column=�   CanUserAddRows$ False�����	#FF2C2C3A
�������   RowBackground �	#FF2C2C3A   AlternatingRowBackground �	#FF252535���#444   GridLinesVisibility$ 
Horizontal=�   SelectionMode$ Single=�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 ФИО��   
IsReadOnly$
 True��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
FullName+  $
 Email��$
 True�� �� *Email+  $
 Телефон��$
 True�� �� *Phone+4  .System.Windows.Controls.DataGridTemplateColumn  $
 Роль��   CellTemplate �� .R��� -    �� SelectedItem �� *Role+ �� Mode$ TwoWay=�����  �� Path$	 Tag� �� RelativeSource ��  �� AncestorType UserControl�� -   $��2��$+��%Сохранить изменения��$��40��$��14(�$��0,10,0,0q�$��Right=�$	��200�����	#FF5A67D8
�������