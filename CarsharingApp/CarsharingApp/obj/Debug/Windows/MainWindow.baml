   M S B A M L   `   `   `  ����H  DCarsharingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CarsharingAppCarsharingApp  5   	       CarsharingApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CarsharingApp     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  63   -   5        $	��800��5   E   $	��800��6R     � WindowStartupLocation$  CenterScreen=�6^    � WindowState$ 	Maximized=�5	   	   $	��800��6!   $
��1300��61    � Title 5   	   ��  �� ElementName$ 	MainFrame�� �� Path$ Content.Title�.��5
      �  � RowDefinitions 5   
   �� 5      $��90 �6   �� 5      .+�5   
   � 
���   �6   �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� $��/Assets/car.png��6   $��5q�6-   $
��Left=�68   �� 5      -   5         ��Name$ StackPanelAdmin��5   2   $ 
Horizontal=�6   $y�	Collapsed=�6K   .+�5      �� -   5         ��Name$ BtnCar��5      	 � ToolTip$	 Автомобили��6W   $��5q�6l   ��6*   0  *MaterialDesignThemes.Wpf.PackIconExtension  
   Kind$	
 Car=�6w   �� 5      -   5        $ 	BtnClient��5      $	 Клиенты��6[   $��5q�6m   ��6-     $

 User=�6x   �� 5      -   5        $ 	BtnRental��5      $	 Аренды��6^   $��5q�6o   ��6-     $
 ListBox=�6z   �� 5      -   5        $ BtnAddItionalService��5      $3	 -Дополнинительные услуги��6j   $��5q�6�   ��68     $
 CardPlus=�6�   5      �� 5      -   5        $ StackPanelUser��5      $ 
Horizontal=�61   $��5q�6J   $
��Left=�6U   $y�	Collapsed=�6p   .+�5      �� -   5        $ BtnMyProfile��5      $	 Мой профиль��6^   $��5q�6t   ��60     $

 User=�6   �� 5      -	   5        $ BtnMyRental��5      $	 Мои аренды��6_   $��5q�6t   ��6.     $
 ListBox=�6   5      5      �� 5   
   $A��;Каршеринговая компания 'MaxДрайв'��6   $��Center=�6=   $
��Bold"�6Z   $��Center=�6l   $��20(�6�   
����p��6�   �� 5   
   $ 
Horizontal=�6   $��Right=�6.   $��0,0,10,0q�6J   .+�5      �� -
   5        $ BtnLogin��5      $	 Авторизация��6^   $��5q�6t   ��6(     $
 LoginVariant=�6   �� 5       -   5        $ BtnBack��5       $	 
Назад��6[   $��5q�6k   ��6'     $
 	ArrowBack=�6v   �� 5!      -   5        $ BtnExit��5!      $	 
Выход��6X   $��5q�6h   ��6'     $
 ExitRun=�6s   5"       � 5#   
   -   5          �Name$ 	MainFrame��5#      $��1��6     � NavigationUIVisibility$ Hidden=�60   6P   5$      5%      