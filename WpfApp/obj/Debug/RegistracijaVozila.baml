   M S B A M L   `   `   `  ????A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.RegistracijaVozila   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   -   5          ? Title$  	LoginView??5   	   $
??1000??6   $
??1870??6)    ? WindowStyle$
 None=?5	   	    ? 
ResizeMode$ NoResize=?5
   	    ? WindowStartupLocation$ CenterScreen=?5   	   
??????  ? AllowsTransparency . .??5      ??  ?? CornerRadius$ 12??6   ??5   
   ?? 5       ?? ImageSource$ 
slika2.jpg??6    j? Stretch$
 None=?5      ._?5   
   ?? $ 10??6   $??2q?5       J? Opacity$
 0.95Q?5      ??5      ?? 5      	 ?? 
StartPoint$		 0,0&?6&   
 ?? EndPoint$	
 1,1&?67   .??5      ?  ? Color$ #462AD8??6#    ? Offset$ 0Q?63   ? 5      $ #DA34AE??6#   $
 0.75Q?63   ? 5      $ #8A16C1??6#   $ 1Q?63   5      ??5      ?? 5      $		 0,1&?6&   $	
 1,0&?67   .??5       ? $ #060531??6#   $ 0Q?63   ? 5!      $ #1B1448??6#   $ 1Q?63   5"      ._?5$      ?  ? RowDefinitions 5%      ?? 5&      $??30 ?6$   ?? 5'      .+?5)      ? $??0??6    ? ColumnDefinitions 5*      ?? 5+      ?? 5,      $??25 ?6+   ?? 5-      $??25 ?6+   ?? 5.      $??5 ?6+   .+?50      ?? 
???????$??10(?52       $??Spectral)?53       $??0??54       $??Center=?55       $??10,0,0,0q?56       ?? 57      -   5         ??Name$ btnMinimize??57      $??0q?58      $??-??59      
???????$??16(?5;      $??Spectral)?5<       ? Cursor$
 Hand??5=      $??1??5>      ??5@      ?? 5A       ?? 
TargetType" ??6$   .?5B   "   ??  ?? Property ? ?? ?? Value ?#28AEED6?    ?? Triggers 5C   "   P? 5D   &    P? Property ?@J?IsMouseOver P? Value . . ?5E   *   ??  ? ?? ?#278BEF6G   5F   '   5H      ??5J      ?? 5K       ?? 
TargetType" ??6.   .R?5L   "   ?? $??18??6)   $??18??64   $ 9??5M   )   #??z??5N   )   ._?5O   &   ?? $??Center=?67   $??Center=?5P   7   5Q   #   5R      5T      ?? 5U      -   5        $ btnClose??5U      $??0q?5V      $??X??5W      
???????$??12(?5Y      $??Spectral)?5Z      $
 Hand??5[      $??2??5\      ??5^      ?? 5_      " ??6$   .?5`   "   ??  ? ?? ?#DA34AE6?    5a   "   P? 5b   &    ?@J?IsMouseOver . . ?5c   *   ??  ? ?? ?#C62DAE6G   5d   '   5f      ??5h      ?? 5i      " ??6.   .R?5j   "   ?? $??18??6)   $??18??64   $ 9??5k   )   #??z??5l   )   ._?5m   &   ?? $??Center=?67   $??Center=?5n   7   5o   #   5p      5r      5s      ?? 5t      $&?? 500                             ??6   $??1??5v      $??0,0,0,0q?5w      .+?5x      ??  ?? Orientation$ 
Horizontal=?6!   $??Center=?5y   !   $??0,15,0,0q?5z   !   ?? 5{      $??DATUM??6    
???????$??50(?5}       $??Medium"?5~       $??Spectral)?5       $??Center=?5?       $??150,116,147,0q?6=    J? RenderTransformOrigin$ 0.517,-0.044&?6T   $??90??6y   $	??201??6?   5?      ?? 5?      $	??150??6   $??40??6%   $ 20??5?   )   ._?5?      ?? $??Center=?6'   $??Center=?5?   7   5?      ?? 5?      -   5        $ btnNazad??5?      $??0q?5?      $??NAZAD??5?      
???????$??25(?5?      $??Spectral)?5?      $
 Hand??5?      $??48,31,1584,843q?5?      $??1??5?   ,   ??5?      ?? 5?      " ??6    .?5?      ??  ? ?? ?#462AD86;    5?      P? 5?   "    ?@J?IsMouseOver . . ?5?   &   ??  ? ?? ?#28AEED6C   5?   #   5?      ??5?      ?? 5?      " ??6*   .R?5?      ?? $
??Auto??6%   $-??'90                                     ??62   $ 20??5?   !   #??z??5?   !   $??0,0,0,0q?6K   ._?5?   "   ?? $??Center=?63   $??Center=?5?   %   5?      5?      5?      ?? 5?      -   5        $ btnDodaj??5?      $??0q?5?      $??DODAJ??5?      
???????$??25(?5?      $??Spectral)?5?      $
 Hand??5?      $??354,367,1278,503q?5?      $??1??5?   ,   ??5?      ?? 5?      " ??6    .?5?      ??  ? ?? ?#462AD86;    5?      P? 5?   "    ?@J?IsMouseOver . . ?5?   &   ??  ? ?? ?#28AEED6C   5?   #   5?      ??5?      ?? 5?      " ??6*   .R?5?      ?? $
??Auto??6%   $-??'90                                     ??62   $ 20??5?   !   #??z??5?   !   $??0,0,0,0q?6K   ._?5?   "   ?? $??Center=?63   $??Center=?5?   %   5?      5?      5?      ?? 5?      -   5        $ 	btnObrisi??5?      $??0q?5?      $??OBRIŠI??5?      
???????$??25(?5?      $??Spectral)?5?      $
 Hand??5?      $??822,367,810,503q?5?      $??1??5?   -   ??5?      ?? 5?      " ??6    .?5?      ??  ? ?? ?#462AD86;    5?      P? 5?   "    ?@J?IsMouseOver . . ?5?   &   ??  ? ?? ?#28AEED6C   5?   #   5?      ??5?      ?? 5?      " ??6*   .R?5?      ?? $
??Auto??6%   $-??'90                                     ??62   $ 20??5?   !   #??z??5?   !   $??0,0,0,0q?6K   ._?5?   "   ?? $??Center=?63   $??Center=?5?   %   5?      5?      5?      ?? 5?      -   5        $ 	btnIzmeni??5?      $??0q?5?      $??IZMENI??5?      
???????$??25(?5?      $??Spectral)?5?      $
 Hand??5?      $??1272,367,360,503q?5?      $??1??5?   -   ??5?      ?? 5?      " ??6    .?5?      ??  ? ?? ?#462AD86;    5?      P? 5?   "    ?@J?IsMouseOver . . ?5?   &   ??  ? ?? ?#28AEED6C   5?   #   5?      ??5?      ?? 5?      " ??6*   .R?5?      ?? $
??Auto??6%   $-??'90                                     ??62   $ 20??5?   !   #??z??5?   !   $??0,0,0,0q?6K   ._?5?   "   ?? $??Center=?63   $??Center=?5?   %   5?      5?      5      (  "System.Windows.Controls.DatePicker  5     -   5          Name$ dtPicker??5     $
??Left=?6/   $??863,293,0,0q?6J   $??1??6_   $	??Top=?6l   $??22??6?   $	??145??6?   $??15)?6?   $??10(?6?   $
??Bold"?6?   ??6?   Z? ??5     
? 5     .??5     ? $ 	#7F85899C??6+   $ 0Q?6=   ? 5     $ 	#FF452ACF??6+   $ 1Q?6=   5     5     &   System.Windows.Controls.DataGrid  5	     -	   5          Name$ DataGrid??5	        AutoGenerateColumns .  $
??Left=?6I   $	??413??6d   $??	0,543,0,0q?6q   $??1??6?   $	??Top=?6?   $
??1856??6?   $??15(?6  $??Spectral)?6  $
??Bold"?64  ??6?   Z? ??6?   Z?    Columns 5
     0  *System.Windows.Controls.DataGridTextColumn  5     ,  &System.Windows.Controls.DataGridColumn   Header$ ID Registracije??6D      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6]   1  +System.Windows.Controls.DataGridBoundColumn    Binding  6-   ?? *id+6]     5     $ 	ID Vozila??6K   $ * 6^     6-   ?? *	id_vozila+6^     5     $ Datum isteka registracije??6G   $ * 6j     6-   ?? *datum+6j     5     $ Nove tablice??6N   $ * 6d     6-   ?? *nove_tablice+6d     5     $ Nova saobracajna??6R   $ * 6l     6-   ?? *nova_saobracajna+6l   5     ?? 5     $??/slike/Logo3.png??6   $??822,10,810,847q?62   $??1??6J   ?? 5     -
   5        ! ??Name$! 
cbxTablice??5     $?? ??6/   $
??Left=?6:   $??16??6U   $??691,498,0,0q?6a   $??1??6v   $	??Top=?6?   $	??203??6?   
??????????	#FF4429CE$??Spectral)?6?   $??15(?6?   $??RightToLeft=?6?   $??0q?6  ?? 5     -   5        " ??Name$" txtDatum??5     $y?Hidden=?6,   $
??Left=?6A   $??46??6\   $??487,102,0,0q?6h   $??1??6}   # ?? TextWrapping$
# Wrap=?6?   $??TextBox??6?   $	??Top=?6?   $??59??6?   ?? 5     -   5        $" txtIDReg??5     $y?Hidden=?6,   $
??Left=?6@   $??37??6[   $??586,102,0,0q?6g   $??1??6|   $
# Wrap=?6?   $??TextBox??6?   $	??Top=?6?   $??65??6?   ?? 5     -   5        $! cbxSaobracajna??5     $?? ??63   $
??Left=?6>   $??16??6Y   $??987,498,0,0q?6e   $??1??6z   $	??Top=?6?   $	??267??6?   
??????????	#FF4429CE$??Spectral)?6?   $??15(?6?     5     -   5        $ DataGrid_Vozila??5      .  $
??Left=?6P   $	??214??6k   $??1148,84,0,0q?6x   $??1??6?   $	??Top=?6?   $	??670??6?   $??15(?6?   $??Spectral)?6   $
??Bold"?6C  ??6  Z? ??6-  Z?  5       5     $ 	ID Vozila??6D   $ * 6W     6-   ?? *id+6W     5     $ Tablice vozila??6I   $ * 6a     6-   ?? *	tablice+6a     5     $ Model??6G   $ * 6V     6-   ?? *model+6V     5     $ Marka??6G   $ * 6V     6-   ?? *marka+6V     5     $ Ime Vlasnika??6N   $ * 6d     6-   ?? *ime_vlasnika+6d     5     $ Prezime Vlasnika??6R   $ * 6l     6-   ?? *prezime_vlasnika+6l   5!     ?? 5"     -   5        $" txtIDVozila??5"     $y?Hidden=?6/   $
??Left=?6C   $??43??6^   $??
708,76,0,0q?6j   $??1??6~   $
# Wrap=?6?   $??TextBox??6?   $	??Top=?6?   $??50??6?   ?? 5#     -   5        $" txtIDTeh??5#     $y?Hidden=?6,   $
??Left=?6A   $??36??6\   $??386,158,0,0q?6h   $??1??6}   $
# Wrap=?6?   $??TextBox??6?   $	??Top=?6?   $??30??6?   ?? 5$     
???????$??20(?5&     $??Medium"?5'     $??Spectral)?5(     $
??Left=?5)     $??839,250,0,0q?60   $ 0.517,-0.044&?6E   $??31??6j   $	??198??6v   $	??Top=?6?   $??Disabled=?6?   $ ?? TextAlignment$$ Center=?6?   $??1??6?   ?? 6?   $?IZABRATI DATUM??6?   6  ?? 5*     
???????$??15(?5,     $??Medium"?5-     $??Spectral)?5.     $
??Left=?5/     $??667,495,0,0q?60   $ 0.517,-0.044&?6E   $??22??6j   $	??208??6v   $	??Top=?6?   $??Disabled=?6?   $$ Center=?6?   $??1??6?   $??POTREBNE NOVE TABLICE??6?   ?? 50     
???????$??15(?52     $??Medium"?53     $??Spectral)?54     $
??Left=?55     $??1002,495,0,0q?60   $ 0.517,-0.044&?6F   $??22??6k   $	??260??6w   $	??Top=?6?   $??Disabled=?6?   $$ Center=?6?   $??1??6?   $ ??POTREBNA NOVA SAOBRAĆAJNA??6?   ?? 56     
???????$??20(?58     $??Medium"?59     $??Spectral)?5:     $
??Left=?5;     $??1253,31,0,0q?60   $ 0.517,-0.044&?6E   $??31??6j   $	??475??6v   $	??Top=?6?   $??Disabled=?6?   $$ Center=?6?   $??1??6?   ?? 6?   $+?%VOZILA KOJA SU NA TEHNIČKOM PREGLEDU??6?   ?? 6%  ?? 61  68  5=     5>     5@     5A     