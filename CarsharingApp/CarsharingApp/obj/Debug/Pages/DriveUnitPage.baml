   M S B A M L   `   `   `  ����H  DCarsharingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CarsharingApp.PagesCarsharingApp.Pages  5      '    !CarsharingApp.Pages.DriveUnitPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CarsharingApp.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  67   -   5          N� Title$  Типы приводов��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5      �� -   5         ��Name$ BtnAdd��5       � ToolTip$ Добавить��6R   $��5q�6e   ��6%   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$	 Add=�6p   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridDriveUnits��5       $��2��6      AutoGenerateColumns .  	   
IsReadOnly	 . 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 67      textWrap1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  6c      Binding 6A   �� *DriveUnitName+6c   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 auto 6)      CellTemplate 5      �� 5      .R�5      �� $ BtnEdit��6%   -   5        $  Редактировать��5   d   ��66     $
 Edit=�6|   5      5        5      $
 auto 6)    5      �� 5       .R�5!      �� $ BtnDell��6%   -   5        $ Удалить��5!   f   ��66     $ Delete=�6x   5"      5$      5&      5'      5(      