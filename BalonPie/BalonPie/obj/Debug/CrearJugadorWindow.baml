   M S B A M L   `   `   `  ����C  ?BalonPie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BalonPieBalonPie  5   	   !    BalonPie.CrearJugadorWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:BalonPie     5   	     � Title$  Jugador��5   	   $	��390��6   $	��450��6&    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterOwner=�5
   	    � Icon 5      ��5   
   ./img/logo7.jpeg��6(   .��5      � ��5   
   �� 5       �� ImageSource$ img/estadio1.jpeg��6    j� Stretch$ UniformToFill=�5       �� Opacity$ 1Q�5       � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $	��.8* �6   �� 5      $��* �6   .+�5    
   �� $��0��6   $��2��5!      $
��Left=�5"      $	��Top=�5#      $��	10 20 0 0q�5$      .+�5%      "   BalonPie.IndicadorFormulario  -   5        	  Name$	 playerId��5%   (   
   Pista$
 ID��6:     5&      -   5        $	 playerNombre��5&   (   $
 Nombre��6>     5'      -   5        $	 playerApellidos��5'   (   $
 	Apellidos��6A     5(      -   5        $	 playerApodo��5(   (   $
 Apodo��6=     5)      -   5        $	 
playerEdad��5)   (   $

 Edad��6<     5*      -   5        $	 playerDorsal��5*   (   $
 Dorsal��6>     5+      -   5        $	 playerNacionalidad��5+   (   $
 Nacionalidad��6D   �� 5,      -   5         ��Name$ equipoOpciones��5,       �� DisplayMemberPath$ nombre��5-      5.      �� 50   
   $��0��6   $��1��51      $	��Top=�52      $��0 20 0 0q�53      $	��180��54      $	��180��55      $��UniformToFill=�56      $��img/player.png��57      ��58      �� 59       �� 
TargetType" ��6   .�5:      ��  �� Property � y� �� Value$ Hidden=�63    �� Triggers 5;      �� 5<       �� Binding 6&   �� *Source+ �� ElementName$ imagenNuevoJugador�� �� Value 6a   Z� .a�5=      ��  � y�$ Visible=�6;   5>      5@      5B      �� 5D   
   -	   5         ��Name$ imagenNuevoJugador��5D      $��0��5E      $��1��5F      $	��Top=�5G      $��0 20 0 0q�5H      $	��180��5I      $	��180��5J      $��Uniform=�5K      �� 5M   
   $��1��6   $��0��5N       �� Orientation$ 
Horizontal=�5O      $��Center=�5P      $��Center=�5Q      .+�5R         BalonPie.PersonalButton  -
   5          Name$ 
btnGuardar��5R   #      BalonPie.PersonalButton   MouseLeftButtonDown$ GuardarJugador��5X   #   $��1��5R   7   $��0��5S   #      
TextButton$ GUARDAR��5T   #   $��0 0 10 0q�5U   #      Ancho$ 55Q�5V   #      Alto$ 15Q�5W   #   5X   #     5Y      $ Cancelar��5^   #   $��1��5Y   #   $��0��5Z   #   $ CANCELAR��5[   #   $ 55Q�5\   #   $ 15Q�5]   #   5^   #   5_        5a   
   -   5        $ btnElegirImagen��5a      $ SeleccionarImagen��5h      $��1��5a   8   $��1��5b      $��Center=�5c      $��Center=�5d      $ ELEGIR IMAGEN��5e      $	 100Q�5f      $ 15Q�5g      5h      5i      5j      