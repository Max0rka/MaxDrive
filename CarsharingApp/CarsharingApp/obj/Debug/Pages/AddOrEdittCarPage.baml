   M S B A M L   `   `   `  ����H  DCarsharingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CarsharingApp.PagesCarsharingApp.Pages  5      +    %CarsharingApp.Pages.AddOrEdittCarPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CarsharingApp.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  67     N� Title$L  FДобавление/Редактирование автомобиля��5	       N� 
Background
 ����� � 	Resources 5      ��%    5      .��5      �� .��5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5       $
��auto �6    �� 5!      $
��auto �6    .+�5#      �� .+�5$      �� $��Изображение��6   $��10q�6/   $
��Left=�6;   �� 5%      -   5         ��Name$ BtnLoad��5%      $��Center=�6+    � ToolTip$ 
Назад��6{   $��5q�6�   ��6H   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Download=�6�   5&      �� 5'      $��Название авто��6   $��1��6-   $��10q�6:   $
��Left=�6F   �� 5(      $7��1Дополнительная информация��6   $��2��69   $��10q�6F   $
��Left=�6R   �� 5)      $#��Тип трансмиссии��6   $��3��6/   $��10q�6<   $
��Left=�6H   �� 5*      $��Тип привода��6   $��4��6+   $��10q�68   $
��Left=�6D   �� 5+      $��Класс авто��6   $��5��6*   $��10q�67   $
��Left=�6C   �� 5,      $��Статус��6   $��6��6&   $��10q�63   $
��Left=�6?   �� 5-      $��Цена аренды��6   $��7��6+   $��10q�68   $
��Left=�6D   �� 5.      $#��Размер скидки (%)��6   $��8��61   $��10q�6>   $
��Left=�6J   �� 5/      $.��(Средний расход (л/100км)��6   $��9��68   $��10q�6E   $
��Left=�6Q   �� 51      -   5         ��Name$ ImageCar��51      $	��200��6&   $	��200��65   $��Uniform=�6E   $
��Left=�6W   $��5q�6r   $��1��6}   ��52      �� 53      	 �� Path$	 CarPhoto�6   
 �� TargetNullValue
 54      ��55      /Assets/picture.png��6?   57      59      �� 5:      $
��Left=�6/   $	��300��6J   $��1��6V   $��1��6f   ��6   �� *	CarName+6f   �� 5;      $
��Left=�69   $	��300��6T    �� TextWrapping$
 Wrap=�6`   $	��100��6t   $��1��6�   $��2��6�   ��6   �� *CarAdditionalInfo+6�   �� 5<      -   5         ��Name$ ComboGearboxTypes��5<      $	��300��62   $
��Left=�6>   $��1��6Y   $��3��6i    �� DisplayMemberPath$ GearboxTypeName��6v    �� SelectedItem 6�   �� *GearboxType+�� 5=      -   5        $ ComboDriveUnits��5=      $	��300��60   $
��Left=�6<   $��1��6W   $��4��6g   $ DriveUnitName��6t    6�   �� *	DriveUnit+�� 5>      -   5        $ ComboCarClasses��5>      $	��300��60   $
��Left=�6<   $��1��6W   $��5��6g   $ CarClassName��6t    6�   �� *
CarClass+�� 5?      -   5        $ ComboStatuses��5?      $	��300��6.   $
��Left=�6:   $��1��6U   $��6��6e   $ 
StatusName��6r    6�   �� *Status+�� 5@      $
��Left=�6^   $	��150��6y   $��1��6�   $��7��6�   ��6   �� *RentalPrice+ �� StringFormat$ c�� �� ConverterCulture$ ru-RU��6�   �� 5A      $
��Left=�60   $	��150��6K   $��1��6W   $��8��6g   ��6   �� *
Discount+6g   �� 5B      $
��Left=�66   $	��150��6Q   $��1��6]   $��9��6m   ��6   �� *AvgConsumption+6m   �� 5C      -   5        $ BtnSave��5C   /   $��10��6   $��10q�6#   $��Сохранить��6@   $��Center=�6T   $��2��6q   6�   5D      5E      5F      