   M S B A M L   `   `   `  ����D  @CBRParser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CBRParser	CBRParser  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5   	   =#clr-namespace:CBRParser.BizObjModelCBRParser.BizObjModel  5   	       CBRParser.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CBRParser     5   	   Jcollections2clr-namespace:System.Collections;assembly=mscorlib     5   	   ;bizObjModel#clr-namespace:CBRParser.BizObjModel     5   	     � Title$  
MainWindow��5
   	   $	��768��6   $
��1024��6)   .��5      �� .+�5   
   �� -   5         ��Name$( "GetDataByLnqFromRemoteServerButton��5      $��30��6=   $M��GПолучить и сохранить данные из задания��6I   $��	0,0,704,0q�6�   �� 5   
   -   5        $ GetDataFromDbButton��5      $��30��6.   $Y��SЗагрузить данные из БД и отобразить в таблице��6:   $��	0,0,704,0q�6�   � 5   
   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ CurrenciesGrid��5         AutoGenerateColumns .    HorizontalGridLinesBrush
 �����   RowBackground
 �����   AlternatingRowBackground
 �����   
IsReadOnly . $	��670��5   a   $
��auto��6n   5      5      5      5      