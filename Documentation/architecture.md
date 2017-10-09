# Arhitekturni obrasci aplikacije Beeffudge

U ovom dokumentu će biti objašnjeni upotrebljeni obrasci u projektovanju aplikacije Grafaro. Takođe će biti dat i pregled osnovnih komponenti kroz pogled implementacije (*implementation view*) sistema.

## Slojeviti obrazac

Osnovni arhitekturni obrazac je slojeviti (*layered*) obrazac u 2 sloja. Slojevi su:

1. Serverski sloj - sloj koji implementira kompletnu serversku logiku
2. Klijentski sloj - sloj u kome je implementirana kompletna domenska logika aplikacije

Pored ovog osnovnog obrasca, u projektovanju aplikacije su primenjena i još dva obrasca: **publish-subscribe** za razmenu poruka između klijenata i **request-reply** (ili *request-response*) za (manje-više) sve ostalo, koji će biti zasebno objašnjeni u ostatku dokumenta.

### Serverski sloj

### Klijentski sloj

Implementira osnovne funkcionalnosti aplikacije i korisnički interfejs sa odgovarajućim kontrolerima.

## Publish-subscribe

Sistem za razmenu poruka se zasniva na publish-subscribe obrascu.

## Request-reply (request-response)
