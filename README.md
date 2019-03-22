# OrderForm
Interview task - a simple Win Form for adding a new order.


Nie miałem dotąd doświadczenia z WinForms co wywołało duże problemy z
obsługą DataGridView, walidacji i sprawnym manipulowaniem danymi.
Zapis do bazy danych został wykonany w ADO.NET

Bazę danych przeniosłem do Service-based Database żeby łatwiej było Państwu uruchomić aplikację.
Niestety oznacza to pracę na koncie użytkownika z pełnymi prawami do bazy danych.
Korzystam z Visual Studio 2017 i w tej wersji nie powinno być problemów z obsługą bazy, wszystko działa z poziomu środowiska.
W innym przypadku trzeba będzie zbudować bazę według załączonego skryptu i zmodyfikować connection string. Przy połączeniu proszę użyć specjalnie stworzonego użytkownika bazodanowego stworzonego w skrypcie.
W katalogu DB jest dołączony plik DPS_SQL.sql z kodem tworzącym
tabele, procedury i użytkownika z ograniczonymi uprawnieniami.


Problemy których nie zdążyłem rozwiązać to
- możliwość  dublowania produktu na liście zamówienia.
- przenoszenie focusa, tak by łatwo było obsługiwać aplikację samą klawiaturą.
- trudności z obsługą zdarzenia cell leave / cell value changed.
- nie napisałem Unit testów gdyż tylko dwie metody walidujące nadają się do tego celu. Niestety architektura WinForms nie jest najłatwiejsza do pokrycia unit testami.

Starałem się podążać za zasadami SOLID. Kilka przykładów:
- S - Single Responsibility. Metoda Read w DBRespository wyłącznie czyta z bazy dane. Przypisanie tych danych do combobox na gridzie jest już zrobione w innej metodzie.
- L - Listkov Principle - XMLRepository implementuje wyłącznie IWriteRepository a nie IReadWriteRepository.
- I - Interface Segregation - stworzyłem IReadRepository, IWriteRepository oraz IReadWriteRepository
- D - Dependency Inversion - zmienne dla xmlRepository i dbRepository są zadeklarowane przy użyciu interfejsów.

Rozwiazanie jest bezpieczne przed SQL Injection dzięki użyciu sparametryzowanych poleceń do bazy.
Wszystkie odwołania do bazy odbywaja się za pośrednictwem  procedur.
Zapisywanie danych z formularza do bazy dokonuje się za pomocą procedury zawierającej transakcję.
Do zapisu w plikach XML dodałem okno dialogowe z prośbą o podanie lokalizacji i nazwy pliku.

Długo rozważalem czy dla dodawania/modyfikacji produktu otwierać nowe okno ale ostatecznie zdecydowałem się na robienie tych operacji bezpośrednio na gridzie. Do tego podejścia trochę nie pasuje przycisk "zmień produkt". Do tej pory nie jestem pewny czy to poprawne rozwiązanie. W rzeczywistym projekcie  skonsultowałbym  to z Project Ownerem lub business Analyst.

W opisie zadania nie było wielu wymagań, zatem zastosowałem podstawowe np. odnośnie dlugości pól dla imienia i nazwiska oraz ograniczyłem zakres daty urodzenia.
Pola w bazie stworzone zostały jako nvarchar by akceptowały unicode, zatem także polskie znaki. Cena jest przechowywana jako smallmoney a w C# jako decimal ograniczone do dwóch miejsc po przecinku.


Do obsługi komunikacji z bazą danych zaimplementowałem wzorzec Repozytorium.
Rozwżałem zaimpelemntowanie FactoryPattern ale uznałem ostatecznie że byłoby to wprowadzenie go trochę na siłę.
