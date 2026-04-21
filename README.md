# Access, Please- Symulator Active Directory

**Access, Please** to gra edukacyjna typu symulator, inspirowana mechaniką *Papers, Please*. Projekt został stworzony w ramach modułu „Infrastruktura teleinformatyczna” na kierunku Informatyka (Semestr 4). Gracz wciela się w rolę administratora IT, którego zadaniem jest zarządzanie uprawnieniami użytkowników w dynamicznym środowisku korporacyjnym.

## Cel projektu

Głównym celem aplikacji jest praktyczne przedstawienie zagadnień związanych z zarządzaniem tożsamością i dostępem oraz bezpieczeństwem infrastruktury teleinformatycznej. Gra uczy krytycznego myślenia w obliczu prób socjotechnicznych oraz wdrażania rygorystycznych polityk bezpieczeństwa.

## Kluczowe funkcje

  * **System Ticketowy:** Analiza 20 unikalnych scenariuszy opartych na realnych problemach IT (od zapomnianych haseł po próby wpięcia nieautoryzowanych urządzeń).
  * **Zarządzanie strukturą OU:** Przypisywanie pracowników do odpowiednich Jednostek Organizacyjnych.
  * **Konfiguracja Security Groups:** Nadawanie precyzyjnych uprawnień.
  * **System Audytu:** Każda decyzja jest oceniana pod kątem zgodności z "Księgą Zasad". Na koniec dnia gracz otrzymuje raport z punktacją.

## Poruszane zagadnienia IT

Projekt implementuje i promuje następujące koncepcje:

  * **Principle of Least Privilege:** Minimalizacja uprawnień w celu ograniczenia wektorów ataku.
  * **Role-Based Access Control:** Dostęp oparty na rolach zdefiniowanych w macierzy uprawnień.
  * **Zero Trust:** Brak domyślnego zaufania- każdy wniosek (nawet od CEO) musi być zweryfikowany.
  * **Social Engineering:** Rozpoznawanie prób manipulacji i wywierania presji.
  * **Shadow IT:** Identyfikacja zagrożeń płynących z nieautoryzowanego oprogramowania i sprzętu.

## Technologie

  * **Silnik:** Unity
  * **Język:** C\#
  * **Architektura:** Scriptable Objects (zarządzanie danymi pracowników i ticketów), wzorzec Singleton (Managerowie).

-----

*Projekt zrealizowany na Wydziale Matematyki Stosowanej w ramach przedmiotu Zarządzanie Systemami Informatycznymi.*
