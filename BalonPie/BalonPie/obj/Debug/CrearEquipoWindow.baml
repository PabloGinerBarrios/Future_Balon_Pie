   M S B A M L   `   `   `  ����C  ?BalonPie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BalonPieBalonPie  5   	        BalonPie.CrearEquipoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:BalonPie     5   	     � Title$  Equipo��5   	   $	��290��6   $	��420��6%    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterOwner=�5
   	    � Icon 5      ��5   
   ./img/logo7.jpeg��6(   .��5      � ��5   
   �� 5       �� ImageSource$ img/estadio1.jpeg��6    j� Stretch$ UniformToFill=�5       �� Opacity$ 1Q�5       � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $	��.8* �6   �� 5      $��* �6   .+�5    
   �� $��0��6   $��2��5!      $
��Left=�5"      $	��Top=�5#      $��	10 20 0 0q�5$      .+�5%      "   BalonPie.IndicadorFormulario  -   5        	  Name$	 equipoId��5%   (   
   Pista$
 ID��6:     5&      -   5        $	 equipoNombre��5&   (   $
 Nombre��6>     5'      -   5        $	 equipoFundacion��5'   (   $
 Año de Fundación��6A     5(      -   5        $	 equipoEstadio��5(   (   $
 Estadio��6?   5)      �� 5+   
   $��0��6   $��1��5,      $	��Top=�5-      $��0 20 0 0q�5.      $	��180��5/      $	��180��50      $��UniformToFill=�51      $��img/escudo.png��52      ��53      �� 54       �� 
TargetType" ��6   .�55      ��  �� Property � y� �� Value$ Hidden=�63    �� Triggers 56      �� 57       �� Binding 6&   �� *Source+ �� ElementName$ imagenNuevoEquipo�� �� Value 6`   Z� .a�58      ��  � y�$ Visible=�6;   59      5;      5=      �� 5?   
   -   5         ��Name$ imagenNuevoEquipo��5?      $��0��5@      $��1��5A      $	��Top=�5B      $��0 20 0 0q�5C      $	��180��5D      $	��180��5E      $��Uniform=�5F      �� 5H   
   $��1��6   $��0��5I       �� Orientation$ 
Horizontal=�5J      $��Center=�5K      $��Center=�5L      .+�5M         BalonPie.PersonalButton  -   5          Name$ 
btnGuardar��5M   #      BalonPie.PersonalButton   MouseLeftButtonDown$ GuardarEquipo��5S      $��1��5M   7   $��0��5N         
TextButton$ GUARDAR��5O      $��0 0 10 0q�5P         Ancho$ 60Q�5Q         Alto$ 16Q�5R      5S        5T      $ Cancelar��5Y      $��1��5T   #   $��0��5U      $ CANCELAR��5V      $ 60Q�5W      $ 16Q�5X      5Y      5Z        5\   
   -   5        $ btnElegirImagen��5\      $ SeleccionarImagen��5c      $��1��5\   8   $��1��5]      $��Center=�5^      $��Center=�5_      $ ELEGIR IMAGEN��5`      $	 100Q�5a      $ 16Q�5b      5c      5d      5e      