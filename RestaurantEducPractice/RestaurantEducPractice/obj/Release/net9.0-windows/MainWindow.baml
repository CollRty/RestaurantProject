   M S B A M L   `   `   `  ���� Q  MRestaurantEducPractice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:RestaurantEducPracticeRestaurantEducPractice  '    !RestaurantEducPractice.MainWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:RestaurantEducPractice       � Title$  Авторизация��$	��500��$	��400�� � WindowStartupLocation$ CenterScreen=����	#FF1E1E2F � 
ResizeMode$ NoResize=� � 	Resources 6   0RestaurantEducPractice.BoolToVisibilityConverter   BoolToVisibilityConverter��%   &	          .��� $��30q� � RowDefinitions �� $��* ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$%��Добро пожаловать��$��26(�
�������$��Center=�$��Bottom=�$��0,0,0,20q�$
��Bold"�� $��1��$��0,0,0,15q�$��40��.+��� -    ��Name$ LoginBox��$��14(�$��10q����	#FF2C2C3A
����������	#FF444455$��1q��� $��Email��$��14(����	#FF9CA3AF$��15,0,0,0q�$��Center=� J� IsHitTestVisible$ False��y��� *Text.IsEmpty+ �� ElementName$ LoginBox�� �� 	Converter# [  G� -   	 G�Name$	 PasswordBox��$��2��$��40��$��0,0,0,15q�$��14(�$��10q����	#FF2C2C3A
����������	#FF444455$��1q��� $��Password��$��14(����	#FF9CA3AF$��	15,12,0,0q�$	��Top=�$ False��$��2��y��� *Text.IsEmpty+$ LoginBox��# [  �� -   $��3��$��
Войти��$��40�����	#FF5A67D8
�������$��SemiBold"�$��14(�$��0q�$��0,0,0,10q�
 � Cursor$

 Hand���� -   $��4��$��Регистрация��
������ ���	#FF9CA3AF$��12(�$��0q�$

 Hand��$��Center=�