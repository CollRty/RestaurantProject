   M S B A M L   `   `   `  ����   RestaurantEducPractice4    .RestaurantEducPractice.ReservationCreateWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$)  #Новое бронирование��$	��420��$	��400�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=����	#FF1E1E2F.��� $��20q�.+��� .+��� $��ФИО клиента��
�������$��0,0,0,5q��� -    ��Name$ FullNameBox��$��30��$��0,0,0,10q����	#FF2C2C3A
����������#444�� $��Номер стола��
�������$��0,0,0,5q��� -   $ TableNumberBox��$��30��$��0,0,0,10q����	#FF2C2C3A
����������#444�� $'��!Дата бронирования��
�������$��0,0,0,5q�(  "System.Windows.Controls.DatePicker  -     Name$ 
DatePicker��$��0,0,0,10q����	#FF2C2C3A
��������� $*��$Время (например: 18:30)��
�������$��0,0,0,5q��� -   $ TimeBox��$��30��$��0,0,0,10q����	#FF2C2C3A
����������#444�� $-��'Количество гостей (1-4)��
�������$��0,0,0,5q��� -   $ 	GuestsBox��$��30��$��0,0,0,20q����	#FF2C2C3A
����������#444�� -   $ ��Забронировать��$��40�����	#FF5A67D8
�������$��SemiBold"�