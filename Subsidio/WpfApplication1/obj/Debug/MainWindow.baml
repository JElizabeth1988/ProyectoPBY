   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5	   	   J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1 5   	       WpfApplication1.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5	   	   )localclr-namespace:WpfApplication1  5   	     � Title$(  "Ministerio de Vivienda y Urbanismo��5   	   $	��664��65   $��1314.001��6B   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � 
ResizeMode$ NoResize=�6m    � Icon$ imagenes/WUMmJUlJ.jpg��6�    � WindowStartupLocation$ CenterScreen=�6�      TitleCharacterCasing$ Normal=�6�    � WindowState$ 	Maximized=�6�   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      � 	 � Color$	 	#FF0E61D1��6   
 � Offset$
 0Q�6-   � 5      $	 	#FF7CB9E7��6   $

 0.56Q�6-   5      .��5      � ���	#FF4ED0F4$��0,0,-5.333,-133q�6"    � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��43* �6    � ColumnDefinitions 5   
   �� 5      $	��10* �6   �� 5      $��0* �6   �� 5      $
��178* �6   �� 5      $��1125* �6   �� 5      $��0* �6   �� 5      $��0* �6   �� 5       $��0* �6   �� 5!      $��0* �6   .+�5#   
   �� -   5         ��Name$ image1��5#      $��imagenes/1127.jpg��6     J� RenderTransformOrigin$ 0.497,0.572&�6;   $��Right=�6_   $
��1377��6{   $��	-64,0,0,0q�6�   $
��Fill=�6�   $��4��6�   $��2��6�   !   MahApps.Metro.Controls.Tile  5%   
   -   5        $��294,22,507,558.333q�5%   +   $
��Auto��6G   $
��Auto��6U   $��3��6x   $��1��6�   ��6b   Z� .��5&      � $	��100��6   $	��206��6     5'      �� 5(      $
��163* �6'   �� 5)      $	��43* �6'   ��5+      �� 5,      .+�5.      �� $
��Left=�6   $��90��67   $��
10,-10,0,0q�6C   ���	#FF006CB8$	��Top=�6j   $	��186��6�   $��2��6�   $��3��6�   �� 5/      -   5         ��Name$ lblPost��5/      $��
POSTULANTE��6)   $
��Left=�6>   $��	42,18,0,0q�6Y   $	��Top=�6l   $
��Bold"�6�   $��18.667(�6�   $��2��6�   50      51      �� 52   
   -   5        $ image��52      $
��Left=�6   $	��132��6:   $��
906,27,0,0q�6G   $	��Top=�6[   $	��158��6s   $��imagenes/Minvu.png��6   $��3��6�   $��2��6�   56      57      