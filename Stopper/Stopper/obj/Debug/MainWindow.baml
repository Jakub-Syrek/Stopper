   M S B A M L   `   `   `  ����B  >Stopper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:StopperStopper  5   	       Stopper.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Stopper     5   	     � Title$  
MainWindow��5   	   $	��300��6   $	��200��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� -   5         ��Name$ Zegar��5      $�� ��6!   $��5,5,5,5q�5      $��1��5      $��2��5      $��1��5       �� MaxLines$ 1��5      $��50��5      $	��150��6!    �� TextWrapping$
 Wrap=�5      $ �� HorizontalScrollBarVisibility$ Disabled=�5      " �� VerticalScrollBarVisibility$
 Auto=�5        J� OpacityMask �	#FF440C0C65   �� 5"   
   -   5        	 ��Name$	 StartStopper��5"      $��start stopper��6'   $��1��6?   $��3��6O   $��2��6]   $��5,5,5,5q�5#      ��5$      �� 5%      
 �� EndPoint$
 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5&      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5'      $ 	#FFB7DEDE��6#   $ 1Q�65   5(      5*      5+      5,      