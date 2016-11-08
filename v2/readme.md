Création cartes pour Solitaire-Play
===================================

Version n° 2 du 20/07/2016


* card-game.html          Base HTML pour construire card-game.png
* card-phone.html         Base HTML pour construire card-phone.png

* /svg                    Les 12 figures SVG créées par Chris Aguilar (v 1.3)
                          (http://sourceforge.net/projects/vector-cards/)

* /png                    Images sources
  - back-game             dos carte David Bellot (http://svg-cards.sourceforge.net/)
  - back-phone            idem retravaillé manuellement pour card-phone

* /png                    Images générées
  - card-game-original    cartes pour pc et tablettes
  - card-game             idem après optimisation
  - card-phone-original   cartes pour smartphones
  - card-phone            idem après optimisation


Optimisation
------------
> pngquant --speed 1 --nofs 24 %~n1.png -o %~n1-min1.png
> zopflipng %~n1-min1.png %~n1-min2.png


Attention
---------
Il existe aussi d'autres cartes (SVG-cards-1.3 ?) nommées ace_of_clubs.svg,
2_of_clubs.svg, ..., jack_of_clubs.svg, jack_of_clubs2.svg, etc... Elles
ressemblent beaucoup aux cartes de Chris Aguilar, mais les traits des visages
sont en bleu (et pas en noir) et surtout ils paraissent plus "grossiers"
(d'autant plus quand on réduit la taille).
