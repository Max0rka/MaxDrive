   M S B A M L   `   `   `  ����H  DCarsharingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CarsharingApp.PagesCarsharingApp.Pages  5      $    CarsharingApp.Pages.RentalPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CarsharingApp.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  67   -   5          N� Title$  Аренда��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��Center=�6   .+�5      �� -   5         ��Name$ TbFIOClient��5   "   $	��300��6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ФИО клиента��67   6d   �� 5      -   5        $��	ComboCars��5   #   $	��200��6   $ Авто��64    �� DisplayMemberPath$ CarName��6Z   6v   �� 5      -   5        $��ComboStatuses��5   #   $	��200��6   $ Статус��68   $ 
StatusName��6`   6   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridRentals��5       $��2��6      AutoGenerateColumns .     
IsReadOnly . 	   Columns	 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 110 6)      Header$  Изо-ие клиента��65      CellTemplate 5      �� 5      .R�5      �� $	��100��6$   $	��100��63   $��Uniform=�6C   $��Center=�6U   $��5q�6r   ��5   "   �� 5   &    �� Path$ Client.ClientPhoto�6.    �� TargetNullValue 5    *   ��5!   .   /Assets/picture.png��6O   5#   '   5%      5&      5(      0  *System.Windows.Controls.DataGridTextColumn  5)      $ ФИО��6%   $
 * 62      textWrap1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  6f      Binding 6<   �� *Client.ClientFullName+6f     5*      $	
 110 6)   $ Изо-ие авто��65    5+      �� 5,      .R�5-      �� $	��100��6$   $	��100��63   $��Uniform=�6C   $��Center=�6U   $��5q�6r   ��5.   "   �� 5/   &   $ Car.CarPhoto�6.    50   *   ��51   .   /Assets/picture.png��6O   53   '   55      56      58        59      $ Название��6%   $
 * 67   # [  6a    6A   �� *Car.CarName+6a     5:      $% Список доп. услуг��6%   $
 2* 6@   # [  6r    6K   �� *RentalServicesName+6r     5;      $( "Дата начала аренды��6%   $
 * 6A   # [  6�    6K   �� *RentalStart+ �� StringFormat$ {0:dd.MM.yyyy HH.mm}��6�     5<      $&  Дата конца аренды��6%   $
 * 6@   # [  6�    6J   �� *	RentalEnd+$ {0:dd.MM.yyyy HH.mm}��6�     5=      $) #Итоговая стоимость��6%   $
 * 6A   # [  6�    6K   �� *RentalPrice+$ c�� �� ConverterCulture$ ru-RU��6�     5>      $ Статус��6%   $
 * 65   # [  6e    6?   �� *Status.StatusName+6e     5H      $

 auto 6)    5I      �� 5J      .R�5K      ��  ��Name$ BtnDell��6%   -   5         � ToolTip$ Удалить��5K   f   ��66   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Delete=�6x   5L      5N      5P      5Q      5R      