   M S B A M L   `   `   `  ����E  ATP-Pokemon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TP_Pokemon
TP_Pokemon  5   	       TP_Pokemon.Combat   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:TP_Pokemon     5   	     � Title$  Combat��5   	   $	��733��6   $
��1168��6%    � 
ResizeMode$ NoResize=�62   ��5	      �� 5
   
    �� ImageSource$ Images/stadium-bg.jpg��6   .��5      � .+�5   
   � -   5         �Name$ panel_pokemon��5      $
��Left=�6&   $	��261��6A   $��446,422,0,0q�6N   $	��Top=�6c   $	��644��6{   $y�Visible=�6�   ��5      �� 5      $! Images/background-menu2.jpg��6   .+�5      �� 
���   �$��8q�6)   $
��Left=�6=   $	��262��6X   $	��Top=�6e   $	��644��6}   $��0,-1,0,0q�6�   �� 5      -   5         ��Name$ image_pokemon_panel��5      $
��Left=�61   $	��238��6L   $	��Top=�6Y   $	��218��6q   $��Images/inconnu.png��6}   $��	34,13,0,0q�6�   �� 5      -   5         ��Name$ button_habilete_1��5      $��
Habilete 1��60   $
��Left=�6E   $��329,147,0,0q�6`   $	��Top=�6u   $	��200��6�   $��36��6�   ���	#FF4933D6���	#FFFDFCFC6�   �� 5      -   5        $ button_habilete_2��5      $��
Habilete 2��60   $
��Left=�6E   $��329,205,0,0q�6`   $	��Top=�6u   $	��200��6�   $��36��6�   ���	#FF4933D6���	#FFFDFCFC6�   �� 5      -   5         ��Name$ 	label_nom��5      $��Nom Inconnu��6'   $
��Left=�6=   $��
290,13,0,0q�6X   $	��Top=�6l   $��18(�6�   ���	#FFE8D9D96�   �� 5      -   5        $ label_level��5      $��Level 0��6)   $
��Left=�6;   $��
427,13,0,0q�6V   $	��Top=�6j   $��18(�6�   ���	#FFE8D9D96�   �� 5      -   5        $ label_id��5      $	��#id��6&   $
��Left=�64   $��
329,43,0,0q�6O   $	��Top=�6c   $��16(�6{   ���	#FFE8D9D96�   �� 5      -   5        $ label_element��5      $	��Feu��6+   $
��Left=�69   $��
450,43,0,0q�6T   $	��Top=�6h   $��16(�6�   ���	#FFE8D9D96�   �� 5      -	   5        $ label_xp��5      $��XP : 0/10000��6&   $
��Left=�6=   $��288,105,0,0q�6X   $	��Top=�6m   $��20(�6�   ���	#FFE8D9D96�   �� 5      -
   5        $ label_mana_Copy��5      $��Regen : +10��6-   $
��Left=�6C   $��450,105,0,0q�6^   $	��Top=�6s   $��20(�6�   ���	#FFE8D9D96�   �� 5      -   5        $ label_attaque��5      $��Attaque : x 0��6+   $
��Left=�6C   $��
290,74,0,0q�6^   $	��Top=�6r   $��20(�6�   ���	#FFE8D9D96�   �� 5      -   5        $ label_défense��5      $��Défense : x 0��6+   $
��Left=�6C   $��
450,74,0,0q�6^   $	��Top=�6r   $��20(�6�   ���	#FFE8D9D96�   5      � 5   
   -   5        $ panel_control��5      $
��Left=�6&   $	��261��6A   $��
96,422,0,0q�6N   $	��Top=�6b   $	��331��6z   ��5       �� 5!      $! Images/background-menu2.jpg��6   .+�5#      �� 
���   �$��8q�6)   $
��Left=�6=   $	��261��6X   $	��Top=�6e   $	��331��6}   �� 5$      -   5        $ button_choix1��5$      $
��Left=�6,   $��	10,10,0,0q�6G   $	��Top=�6Z   $��73��6r   $��67��6}   ��6�   Z� .��5%      �� -   5        $ image_choix1��5%      $��57��6.   $��63��6:   $��Images/inconnu.png��6E   5&      �� 5'      -   5        $ button_choix2��5'      $
��Left=�6,   $��
122,10,0,0q�6G   $	��Top=�6[   $��72��6s   $��67��6~   ��6�   Z� .��5(      �� -   5        $ image_choix2��5(      $��57��6.   $��63��6:   $��Images/inconnu.png��6E   5)      �� 5*      -   5        $ button_choix3��5*      $
��Left=�6,   $��
229,10,0,0q�6G   $	��Top=�6[   $��73��6s   $��67��6~   ��6�   Z� .��5+      �� -   5        $ image_choix3��5+      $��57��6.   $��63��6:   $��Images/inconnu.png��6E   5,      �� 5-      -   5        $ button_choix4��5-      $
��Left=�6,   $��	52,96,0,0q�6G   $	��Top=�6Z   $��73��6r   $��66��6}   ��6�   Z� .��5.      �� -   5        $ image_choix4��5.      $��57��6.   $��63��6:   $��Images/inconnu.png��6E   5/      �� 50      -   5        $ button_choix5��50      $
��Left=�6,   $��
172,96,0,0q�6G   $	��Top=�6[   $��73��6s   $��67��6~   ��6�   Z� .��51      �� -   5        $ image_choix5��51      $��57��6.   $��63��6:   $��Images/inconnu.png��6E   52      �� 53      -   5        $ button_inventaire��53      $
��Left=�60   $��
52,184,0,0q�6K   $	��Top=�6_   $��73��6w   $��67��6�   ��6�   Z� .��54      �� -   5        $ image��54      $��57��6'   $��63��63   $��Images/backpack1.png��6>   55      �� 56      -   5        $ button_quitter��56      $
��Left=�6-   $��172,184,0,0q�6H   $	��Top=�6]   $��73��6u   $��67��6�   ��6�   Z� .��57      �� -   5        $ 
image_Copy��57      $��57��6,   $��63��68   $��Images/icone_exit.png��6C   58      59      �� 5;   
   -   5        $ image_main_cadre��5;      $
��Left=�6*   $	��417��6E   $��	256,0,0,0q�6R   $	��Top=�6e   $	��656��6}   $��Images/main_cadre.png��6�   �� 5<   
   -   5         ��Name$ textBox_Console��5<      $
��Left=�6+   $	��234��6F   $��
371,80,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $T��N                            Bienvenu   
Ici s'affichera le contenu des combats��6{   $	��Top=�6�   $	��422��6�   ���	#FF214AB6���	#FFF7F5F5$��18(�6'  	 �� IsReadOnlyCaretVisible	 . 65  �� 5=   
   -   5        $  image_pokemon_player_frame��5=      $
��Left=�64   $	��417��6O   $��	-96,0,0,0q�6\   $	��Top=�6o   $	��651��6�   $��Images/miniframe.png��6�   �� 5>   
   -   5        $! image_pokemon_adverse_frame��5>      $
��Left=�65   $	��417��6P   $��748,0,-236,0q�6]   $	��Top=�6s   $	��650��6�   $��Images/miniframe.png��6�   �� 5?   
   -    5        $ image_pokemon_adverse��5?      $
��Left=�6/   $	��234��6J   $��
891,80,0,0q�6W   $	��Top=�6k   $	��243��6�   $��Images/inconnu.png��6�   �� 5@   
   -!   5        $ image_pokemon_player��5@      $
��Left=�6.   $	��234��6I   $��	34,80,0,0q�6V   $	��Top=�6i   $	��244��6�   $��Images/inconnu.png��6�   
 J� RenderTransformOrigin$
 -3.204,0.487&�6�   � 5A   
   -"   5         �Name$ barre_vie_player��5A      $
��Left=�60   $��28��6K   $��
10,340,0,0q�6W   $	��Top=�6k   $	��284��6�   ���	#FFFF1717 � Value$	 100Q�6�   � 5B   
   -#   5        $ barre_mana_player��5B      $
��Left=�61   $��28��6L   $��
10,373,0,0q�6X   $	��Top=�6l   $	��284��6�   ���	#FF0127D3$	 100Q�6�   � 5C   
   -$   5        $ barre_vie_adverse��5C      $
��Left=�61   $��28��6L   $��868,340,0,0q�6X   $	��Top=�6m   $	��284��6�   ���	#FFD30101$	 100Q�6�   $
 0.5,0.5&�6�   z�5D      V� 5E      .~�5F      �� �� 5G      �� 5H       �� Angle$ -179.792Q�6&   T� 5I      5J      5L      � 5M   
   -%   5        $ barre_mana_adverse��5M      $
��Left=�62   $��28��6M   $��868,375,0,0q�6Y   $	��Top=�6n   $	��284��6�   ���	#FF0127D3$	 100Q�6�   $
 0.5,0.5&�6�   z�5N      V� 5O      .~�5P      �� �� 5Q      �� 5R      $ -179.863Q�6&   T� 5S      5T      5V      � 5W   
   -&   5        $ fenetre_difficulty��5W      $
��Left=�6+   $	��590��6F   $��	13,42,0,0q�6S   $	��Top=�6f   $
��1100��6~   $y�Hidden=�6�   ��5X      �� 5Y      $ background.jpg��6   .+�5[      �� 
���   �$��8q�6)   $
��Left=�6=   $	��590��6X   $	��Top=�6e   $
��1100��6}   �� 5\      -'   5        $ button_facile��5\      $��Facile��6,   $
��Left=�6=   $��356,124,0,0q�6X   $	��Top=�6m   $	��340��6�   $��46��6�   $��20(�6�   ���	#FFF1EEEE��5]      �� 5^       �� EndPoint$	 0,1&�6*    �� 
StartPoint$	 0,0&�69   .��5_      �  � Color$ 	#FFF3F3F3��6'    � Offset$ 0Q�69   � 5`      $ 	#FFEBEBEB��6'   � 5a      $ 	#FFDDDDDD��6'   $ 0.006Q�69   � 5b      $ 	#FF1C7CDC��6'   $ 0.099Q�69   5c      5e      �� 5f      -(   5        $ button_moyen��5f      $��Moyen��6+   $
��Left=�6;   $��356,196,0,0q�6V   $	��Top=�6k   $	��340��6�   $��46��6�   $��20(�6�   ���	#FFF1EEEE��5g      �� 5h      $	 0,1&�6*   $	 0,0&�69   .��5i      � $ 	#FFF3F3F3��6'   $ 0Q�69   � 5j      $ 	#FFEBEBEB��6'   � 5k      $ 	#FFDDDDDD��6'   $ 0.006Q�69   � 5l      $ 	#FF1C7CDC��6'   $ 0.099Q�69   5m      5o      �� 5p      -)   5        $ button_Difficile��5p      $��	Difficile��6/   $
��Left=�6C   $��356,260,0,0q�6^   $	��Top=�6s   $	��340��6�   $��46��6�   $��20(�6�   ���	#FFF1EEEE��5q      �� 5r      $	 0,1&�6*   $	 0,0&�69   .��5s      � $ 	#FFF3F3F3��6'   $ 0Q�69   � 5t      $ 	#FFEBEBEB��6'   � 5u      $ 	#FFDDDDDD��6'   $ 0.006Q�69   � 5v      $ 	#FF1C7CDC��6'   $ 0.099Q�69   5w      5y      �� 5z      -*   5        $ button_expert��5z      $��Expert��6,   $
��Left=�6=   $��356,324,0,0q�6X   $	��Top=�6m   $	��340��6�   $��46��6�   $��20(�6�   ���	#FFF1EEEE��5{      �� 5|      $	 0,1&�6*   $	 0,0&�69   .��5}      � $ 	#FFF3F3F3��6'   $ 0Q�69   � 5~      $ 	#FFEBEBEB��6'   � 5      $ 	#FFDDDDDD��6'   $ 0.006Q�69   � 5�      $ 	#FF1C7CDC��6'   $ 0.099Q�69   5�      5�      �� 5�      -+   5        $ button_Legende��5�      $��Légendaire��6-   $
��Left=�6B   $��356,390,0,0q�6]   $	��Top=�6r   $	��340��6�   $��46��6�   $��20(�6�   ���	#FFF1EEEE��5�      �� 5�      $	 0,1&�6*   $	 0,0&�69   .��5�      � $ 	#FFF3F3F3��6'   $ 0Q�69   � 5�      $ 	#FFEBEBEB��6'   � 5�      $ 	#FFDDDDDD��6'   $ 0.006Q�69   � 5�      $ 	#FF1C7CDC��6'   $ 0.099Q�69   5�      5�      5�      � 5�   
   -,   5        $ panel_inventaire��5�      $
��Left=�6)   $	��261��6D   $��446,422,0,0q�6Q   $	��Top=�6f   $	��676��6~   $y�Hidden=�6�   ��5�      �� 5�      $! Images/background-menu2.jpg��6   .+�5�      �� 
���   �$��8q�6)   $
��Left=�6=   $	��261��6X   $	��Top=�6e   $	��676��6}   �� 5�      --   5        $ button_pokeball��5�      $
��Left=�6.   $��	28,55,0,0q�6I   $	��Top=�6\   $	��133��6t   $	��120��6�   ��6�   Z� .��5�      �� -.   5        $ image_pokeball��5�      $
��Left=�60   $	��110��6K   $	��Top=�6X   $	��133��6p   $$��Images/pokeball-inventaire.png��6|   5�      �� 5�      -/   5        $ button_potion_vie��5�      $
��Left=�60   $��
192,55,0,0q�6K   $	��Top=�6_   $	��134��6w   $	��120��6�   ��6�   Z� .��5�      �� -0   5        $ image1_Copy��5�      $
��Left=�6-   $	��120��6H   $	��Top=�6U   $	��133��6m   $��Images/potion-mauve.png��6y   5�      �� 5�      -1   5        $ button_potion_max��5�      $
��Left=�60   $	��Top=�6K   $	��134��6c   $	��120��6o   $��
519,55,0,0q�6�   ��6|   Z� .��5�      �� -2   5        $ image1_Copy2��5�      $
��Left=�6.   $	��120��6I   $	��Top=�6V   $	��133��6n   $��Images/potion-or.png��6z   5�      �� 5�      -3   5        $ button_potion_mana��5�      $
��Left=�61   $��
356,55,0,0q�6L   $	��Top=�6`   $	��134��6x   $	��120��6�   ��6�   Z� .��5�      �� -4   5        $ image1_Copy1��5�      $
��Left=�6.   $	��120��6I   $	��Top=�6V   $	��133��6n   $��Images/potion-max.png��6z   5�      �� 5�      -5   5        $ label_pokeball��5�      $
��x 10��6,   $
��Left=�6;   $��
60,198,0,0q�6V   $	��Top=�6j   $��40��6�   $��66��6�   ���	#FFF5F0F0$��24(�6�   �� 5�      -6   5        $ label_potion_mauve��5�      $
��x 10��60   $
��Left=�6?   $��228,198,0,0q�6Z   $	��Top=�6o   $��40��6�   $��66��6�   ���	#FFF5F0F0$��24(�6�   �� 5�      -7   5        $ label_potion_mana��5�      $
��x 10��6/   $
��Left=�6>   $��387,198,0,0q�6Y   $	��Top=�6n   $��40��6�   $��66��6�   ���	#FFF5F0F0$��24(�6�   �� 5�      -8   5        $ label_potion_or��5�      $
��x 10��6-   $
��Left=�6<   $��546,198,0,0q�6W   $	��Top=�6l   $��40��6�   $��66��6�   ���	#FFF5F0F0$��24(�6�   5�      5�      5�      