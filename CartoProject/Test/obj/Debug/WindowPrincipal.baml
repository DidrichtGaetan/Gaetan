   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5   	   ? ;Test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TestTest 5         Test.WindowPrincipal   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5   	   $localclr-namespace:Test     5        � Title$  WindowPrincipal��5
   	   $	��600��6!   $
��1000��6.   .��5      � .+�5   
   ]� .+�5      o� $	��Top=�6   .@�5      m� -   5         m�Name$
 Menu��5      $��_File��6)   .@�5      m� -   5        $
��_New��5      .@�5      m� -   5        $
�� POI��5   #   6F   m� 5      -   5        $��Polyline��5   #   6N   m� 5      -   5        $��	 Polygone��5   #   6O   5      m� 5      -   5        $��_Open��5      6.   m� 5      -   5        $ sauvegarder��5      $��_Save��64   6C   m� 5      -   5        $	 POI��5      $
��_POI��6,   .@�5      m� -	   5        $ 	importPoi��5   #   $��_Import��66   6G   m� 5      $��_Export��6#   5      m� 5      $��_Trajet��6   .@�5      m� $��_Import��6#   m� 5      $��_Export��6#   5      m� 5      -
   5        $��_Suppression��5      5       �� 5!      m� 5"      -   5        $��_Exit��5"      6.   5#      m� 5$      -   5        $ 	toolsMenu��5$      $��_Tools��6.   .@�5%      m� $��_Option��6   m� 5&      -   5        $ AboutBox��5&      $��
_About Box��61   6E   5'      5(      � 5)       � ColumnDefinitions 5*      �� 5+      $	��160 �6'   �� 5,       � RowDefinitions 5.      �� 5/      �� 50      $	��276 �6$   .+�52      '   !Microsoft.Maps.MapControl.WPF.Map  -   5          Name$ MyMap��52      +   %Microsoft.Maps.MapControl.WPF.MapCore   CredentialsProviderT   NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F @AuAXVhi47l6fwz0esoePydsl2fmmFRIe3kdY3JSitDrtq4THT5F_YqwsfHO06vqU 6)      Mode;   5Microsoft.Maps.MapControl.WPF.Design.MapModeConverter$ AerialWithLabels 6�      Center<   6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ 50.608231,5.487558 6�   $��0,0,-0.4,-0.2q�6�      	ZoomLevel$ 16Q�6�   $��1��6�   $��2��6�   6  �� 54      -   5        	 ��Name$	 ListBox1��54      $
��Left=�6E   $	��277��6`   $	��Top=�6m   $	��160��6�   $��0��6�   $��0��6�   55      �� 58      -   5        $	 ListBox2��58      $
��Left=�6,   $	��271��6G   $��0,5.2,0,-0.2q�6T   $��0��6j   $��1��6z   $	��Top=�6�   $	��155��6�   .@�59      �� -   5        
 ��Name$
 CouleurContour��59   #   $��40��6;   
���   �$��0q�6[   {�.  5:      �� 5;      -   5        $
 CouleurRemplissage��5;   #   $��40��6?   
���   �$��0q�6_   {�.  5=      �� 5>      -   5        $
 Opacite��5>   #   $��40��64   
���   �$��0q�6T   {�.  5@      �� 5A      -   5        $
 	Epaisseur��5A   %   $��40��68   
���   �$��0q�6X   {�.  5C      �� 5E      -   5        $
 Description��5E   "   $��40��67   
���   �$��0q�6W   {�.  5G      5H      5J      5K      5N      5P      