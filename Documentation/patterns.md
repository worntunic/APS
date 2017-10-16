# Obrasci u aplikaciji Beeffudge

Ovaj dokument opisuje sve prisutne obrasce koji su primenjni u razvoju aplikacije Beeffudge.

Za razvoj aplikacije je korišćen programski jezik C#. U razvoju same aplikacije primenjeni su *Observer*, *Adapter*.

## Observer

Observer prati kada pristignu čet poruke, i ažurira korisnički interfejs dodavanjem poruke.

## Adapter

Kako bismo prilagodili ZeroMq biblioteku potrebama našeg servera, iskoristili smo obrazac Adapter.