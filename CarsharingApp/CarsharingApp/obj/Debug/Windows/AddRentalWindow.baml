   M S B A M L   `   `   `  ����H  DCarsharingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CarsharingApp.WindowsCarsharingApp.Windows  5   	   +    %CarsharingApp.Windows.AddRentalWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:CarsharingApp.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6;   X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xceed)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$'  !Аренда автомобиля��5	   	   $	��740��6#   $	��370��60   $	��740��6<   $	��370��6L    � WindowStartupLocation$ CenterScreen=�6[    � 
ResizeMode$ NoResize=�6�   .��5
      �� .��5   
   �  � RowDefinitions 5      �� 5      $	��100 �6    �� 5      $��* �6    �� 5      $
��auto �6    .+�5      �� $	��100��6   $	��100��6#   $��Uniform=�63   $��Center=�6E   ��5      �� 5       �� Path$ CarPhoto�6    �� TargetNullValue 5      ��5      /Assets/picture.png��6?   5      5      �� 5      $��1��6   $��Center=�6&   .+�5      �� $
��Left=�6C   $��5q�6^   ��6   �� *CarClass.CarClassName+6^   �� 5      $
��Left=�65   $��5q�6P   $��20(�6[   $
��Bold"�6i   ��6   �� *	CarName+6i   �� 5       �� Orientation$ 
Horizontal=�6   $��5q�66   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CarTransmission=�6.   $��Center=�6E   �� 5       $��Center=�6M   ��6    �� *GearboxType.GearboxTypeName+6M     5!      $ CarCog=�6.   $��Center=�6<   $��5,0,0,0q�6W   �� 5"      $��Center=�6I   ��6    �� *DriveUnit.DriveUnitName+6I     5#      $ 
GasStation=�6.   $��Center=�6@   $��5,0,0,0q�6[   �� 5$      $��Center=�6Z   ��6    �� *AvgConsumption+ �� StringFormat$ {0}л/100км��6Z   5%      �� 5&      $8��2Дополнительная информация:��6   $
��Left=�6>   $��5q�6Y   $��NoWrap=�6d   �� 5'      $
��Left=�6?   $��5,0,5,5q�6Z   $��60��6k   $
��Wrap=�6w   ��6   �� *CarAdditionalInfo+6w   �� 5(      $��Период аренды��6   $
��Left=�61   $��5q�6L   $��16(�6W   $
��Bold"�6e   �� 5)      $��c��6   $
��Left=�6%   $��5q�6@   �� 5*      $ 
Horizontal=�6   .+�5+      (  "System.Windows.Controls.DatePicker  -   5        	  Name$	 DatePickerStart��5+   !   $	��150��6:    $   MaterialDesignOutlinedDatePicker#��[  6F   $��5q�6�   $��5q�6�   {�.  6�   )  #MaterialDesignThemes.Wpf.TimePicker  5,      -   5        
  Name$
 TimePickerStart��5,   0   $��90��6I    $  MaterialDesignOutlinedTimePicker#��[ 6T      	Is24Hours . $��5q�5-   A   $��5q�6L   {�.  6�   5.      �� 5/      $
��по��6   $
��Left=�6&   $��5q�6A   �� 50      $ 
Horizontal=�6   .+�51        -   5        $	 DatePickerEnd��51   !   $	��150��68   #��[  6D   $��5q�6~   $��5q�6�   {�.  6�     52      -   5        $
 TimePickerEnd��52   0   $��90��6G   #��[ 6R    . $��5q�6�   $��5q�6�   {�.  53   0   54      �� 55      $-��'Дополнительные опции��6   $
��Left=�68   $��5q�6S   $��16(�6^   $
��Bold"�6l   %  Xceed.Wpf.Toolkit.CheckComboBox  56      -   5          Name$ ComboAddServices��56   &   $	��250��6@    �� DisplayMemberPath$ AddServiceNamePice��6L   $��5q�6s   $
��Left=�57   &   +  %Xceed.Wpf.Toolkit.Primitives.Selector   SelectedMemberPath$ AddServiceSelected��6A   �� 58      $#��Общая стоимость��6   $
��Left=�63   $	��5,0q�6N   $��16(�6[   $
��Bold"�6i   � 59       5:      �� 5;      $
��auto �6(   �� 5<      $
��auto �6(   �� 5=      $
��auto �6(   �� 5>      $
��auto �6(    � ColumnDefinitions 5@      �� 5A      $��* �6+   �� 5B      $��* �6+   .+�5D      �� $��В сутки: ��6    $
��Left=�61   $	��5,0q�6L   $��14(�6Y   $
��Bold"�6g   �� 5E      -   5         ��Name$ TbDay��5E       $�� ��6/   $��1��67   $��Right=�6G   $	��5,0q�6c   $��14(�6p   $
��Bold"�6~   �� 5F      $"��За весь период: ��6    $��1��68   $
��Left=�6E   $	��5,0q�6`   $��14(�6m   $
��Bold"�6{   �� 5G      -   5        $ TbPeriod��5G       $�� ��62   $��1��6:   $��1��6G   $��Right=�6W   $	��5,0q�6s   $��14(�6�   $
��Bold"�6�   �� 5H      $��За доп. опций: ��6    $��2��67   $
��Left=�6D   $	��5,0q�6_   $��14(�6l   $
��Bold"�6z   �� 5I      -   5        $ TbAddService��5I       $�� ��66   $��2��6>   $��1��6K   $��Right=�6[   $	��5,0q�6w   $��14(�6�   $
��Bold"�6�   �� 5J      $��
Итого��6    $
��Left=�6-   $��3��6H   $��5q�6V   $��16(�6a   $
��Bold"�6o   �� 5K      -	   5        $ 	TbGeneral��5K       $�� ��63   $��3��6;   $��1��6H   $��Right=�6X   $��5q�6t   $��16(�6   $
��Bold"�6�   5L      5O      �� 5P      -
   5         ��Name$ 	BtnRental��5P      $��2��6(   $��10q�65   
�������
�������
�������$��Center=�6�   .��5Q      �� $��Арендовать��6   
�������6.   5R      5S      5T      5U      