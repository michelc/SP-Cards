Création cartes pour Solitaire-Play
===================================

Version n° 1 du 13/08/2014 (card-phone du 15/03/2015)


* card-game.html          Base HTML pour construire card-game.png

* /svg                    Les 52 cartes SVG créées par Chris Aguilar (v 1.3)
                          (http://sourceforge.net/projects/vector-cards/)

* /png                    Images sources
  - back-bellot           dos carte David Bellot (http://svg-cards.sourceforge.net/)
  - back-autre            dos carte (source perdue)
  - joker-bellot          joker David Bellot (http://svg-cards.sourceforge.net/)
  - joker-autre           joker coloré (source perdue)
  - back-phone            dos et jokers retravaillés manuellement pour card-phone

* /png                    Images générées
  - card-game-original    cartes pour pc et tablettes
  - card-game             idem après réduction de 1/3 et optimisation (https://tinypng.com)
  - card-phone-original   cartes pour smartphones
  - card-phone            idem après optimisation (https://tinypng.com)

* /MakeCard               Programme C# pour créer card-phone (à partir de card-game)
