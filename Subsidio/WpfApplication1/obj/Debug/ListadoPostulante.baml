   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5	   	   J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1 5   	   '   !WpfApplication1.ListadoPostulante   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5	   	   )localclr-namespace:WpfApplication1  5   	     � Title$  Listado de Postulantes��5   	   $��512.355��6(   $��733.833��69   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � 
ResizeMode$ NoResize=�6b    � Icon$ imagenes/WUMmJUlJ.jpg��6x    � WindowStartupLocation$ CenterScreen=�6�   ���	#FF7EDCF6   TitleCharacterCasing$ Normal=�6�   .��5      � ���	#FF7EDCF6.+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��105��6:   $��
553,34,0,0q�6G   $	��Top=�6[   $	��127��6s   $��imagenes/Minvu.png��6   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgvLista��5      $
��Left=�6%   $��
25,195,0,0q�6@   $	��Top=�6T   $	��267��6l   $	��678��6y   6�   �� 5   
   -   5         ��Name$ label��5      $.��(Postulantes Beneficiados con el Subsidio��6   $
��Left=�6R   $��	75,60,0,0q�6m   $	��Top=�6�   $
��Bold"�6�   �� 5   
   -   5        	 ��Name$	 
btnListado��5      $��Ver Listado��6%   $
��Left=�6;   $��
79,137,0,0q�6V   $	��Top=�6j   $	��113��6�   $
��Bold"�6�   )   #MahApps.Metro.Controls.ButtonHelper
   PreserveTextCase
 .  J� RenderTransformOrigin$ 1.662,0.727&�6�      AccentedSquareButtonStyle#��[  6�   6%  5      5      