   M S B A M L   `   `   `  ����H  DCarsharingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CarsharingApp.PagesCarsharingApp.Pages  5      !    CarsharingApp.Pages.CarPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6D   -local!clr-namespace:CarsharingApp.Pages  5      -   5          N� Title$+  %Каталог автомобилей��5	       N� 
Background
 �����.��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6    .+�5      � $��Center=�6   .+�5      �� -   5         ��Name$ 	TbCarName��5   &   $	��200��6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$. (Поиск по наименованию��69   6p   �� 5      -   5        $��ComboCarClasses��5   '   $	��200��6   $ Класс авто��6>    �� DisplayMemberPath$ CarClassName��6j   6�   �� 5      -   5        $��ComboGearboxTypes��5   '   $	��200��6   $ Тип КПП��6@   $ GearboxTypeName��6i   6�   �� 5      -   5        $��ComboUnitTypes��5   '   $	��200��6   $ Тип привода��6=   $ DriveUnitName��6j   6�   �� 5      -   5        $��	ComboSort��5   '   $	��200��6   $ Сортировка��68   .@�5      �� .��5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $%��Стоимость аренды��6$   '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$ ArrowUp=�62   $	��5,0q�6A   $��Center=�6N   5      5      �� 5      .��5      �� $ 
Horizontal=�6!   .+�5       �� $%��Стоимость аренды��6$     5!      $ 	ArrowDown=�62   $	��5,0q�6C   $��Center=�6P   5"      5#      �� 5$      .��5%      �� $ 
Horizontal=�6%   .+�5&      �� $*��$Наиименование авто ��6(     5'      $ ArrowUp=�66   $	��5,0q�6E   $��Center=�6R   5(      5)      �� 5*      .��5+      �� $ 
Horizontal=�6%   .+�5,      �� $'��!Наименование авто��6(     5-      $ 	ArrowDown=�66   $	��5,0q�6G   $��Center=�6T   5.      5/      50      51      �� 52      $��1��6   $ 
Horizontal=�6&   $��Center=�6?   .+�53      �� $-��'Время бронирования с ��6   (  "System.Windows.Controls.DatePicker  54      -   5          Name$ DatePickerStart��54      $	��150��66    $   MaterialDesignOutlinedDatePicker#��[  6B   $��5q�6|   $��5q�6�   6�   )  #MaterialDesignThemes.Wpf.TimePicker  55      -   5        	  Name$	 TimePickerStart��55   ,   $��90��6E    $  MaterialDesignOutlinedTimePicker#��[ 6P   
   	Is24Hours
 . $��5q�56   A   $��5q�6L   6X   �� 57      $
��по��6     58      -	   5        $ DatePickerEnd��58      $	��150��64   #��[  6@   $��5q�6z   $��5q�6�   6�     59      -
   5        $	 TimePickerEnd��59   ,   $��90��6C   #��[ 6N   
 . $��5q�6�   $��5q�6�   5:   0   5;      �� 5<      -   5         ��Name$ ListViewCars��5<   $   $��2��6     ListViewItem#��[ 6:   $��Disabled=�6m   ��5=      �� 5>      .R�5?      � $��Center=�6$   5@      ��5B      �� 5C      .R�5D      � $	��300��6    5E      �� 5F   "   $	��200 �60   �� 5G   "   $��* �60   .+�5I      �� $	��200��6$   $	��200��60   $��Uniform=�6=   $��Center=�6O   ��5J   "   �� 5K   &    �� Path$ CarPhoto�6.    �� TargetNullValue 5L   *   ��5M   .   /Assets/picture.png��6O   5O   '   5Q      �� 5R      $��1��6)   .+�5T   "   �� $
��Left=�6S   $��5q�6n   ��6,   �� *CarClass.CarClassName+6n   �� 5U   "   $
��Left=�6E   $��5q�6`   $��20(�6k   $
��Bold"�6y   ��6,   �� *	CarName+6y   �� 5V   "   $ 
Horizontal=�6-   $��5q�6F   .+�5W   &     $ CarTransmission=�6>   $��Center=�6U   �� 5X   &   $��Center=�6]   ��60   �� *GearboxType.GearboxTypeName+6]     5Y   &   $ CarCog=�6>   $��Center=�6L   $��5,0,0,0q�6g   �� 5Z   &   $��Center=�6Y   ��60   �� *DriveUnit.DriveUnitName+6Y     5[   &   $ 
GasStation=�6>   $��Center=�6P   $��5,0,0,0q�6k   �� 5\   &   $��Center=�6j   ��60   �� *AvgConsumption+ �� StringFormat$ {0}л/100км��6j   5]   #   �� 5^   "   $8��2Дополнительная информация:��6,   $
��Left=�6N   $��5q�6i   �� 5_   "   $
��Left=�6O   $��5,0,5,5q�6j   $��60��6{   $
��Wrap=�6�   ��6,   �� *CarAdditionalInfo+6�   �� 5`   "   $
��Bold"�6g   $��15(�6y   
���P��$��Strikethrough{�6�   ��6,   �� *RentalPrice+$ {0:f2} Р/сутки��6�   �� 5a   "   $
��Bold"�6g   $��20(�6y   
����p����6,   �� *ActualPrice+$ {0:f2} Р/сутки��6�   �� 5b   "    ��Name$ 	BtnRental��6)   -   5        
�������
�������
�������y�5b   �   �� *RentalVisible+.��5c   &   �� $��Арендовать��60   
�������6B   5d   #   5e      5f      5g      5i      5j      5k      5l      