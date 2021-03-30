# RegisterApp
Aplikacja na telefony z Androidem służąca do zautomatyzowania procesu rejestracji w przychodni internistycznej napisana na zajęcia Projektowanie teleinformatycznych systemów internetowych i mobilnych (PWR W4 IMT - Systemy Informatyki w Medycynie).

Przy pomocy usług REST'owych łączy się ona z serwerem postawionym na Azure. Jest to moja część projektu zespołowego, tak więc najprawdopodobniej aktualnie połączenie się z serwerem jest niemożliwe.
W tym projekcie ja zająłem się aplikacją mobilną łączącą się z bazą danych na serwerze.

Aplikacja mobilna zawierająca się w naszym projekcie została napisana w języku C# i środowisku Xamarin.  Dodatkowo do aplikacji zostały dołączone odpowiednie paczki NUGET: 
- Microsoft.AspNet.WebApi.Client (w celu łączenia się z API),
- Newtonsoft.Json (w celu prostego przenoszenia danych w formacie JSON na obiekt klasy C#).

-------- OPIS SPISANY Z PLIKÓW PROJEKTOWYCH, AKTUALNIE NIE MOŻNA URUCHOMIĆ Z POWODU BRAKU SERWERA -------------

Aplikacja zezwala na przegląd wizyt pacjenta, przegląd wszystkich lekarzy oraz ogólną rejestrację. Jest jeszcze logowanie jednorazowe, gdyż często osoby starsze mogą mieć problem z wpisywaniem danych. Rejestracja ogólna pokazuje nam najbliższe możliwe terminy, jest to najlepsza opcja, gdy potrzebna jest szybka lub krótka wizyta u lekarza i nie ma znaczenia, do jakiego lekarza trafimy. Opcja druga jest opcją początkowo pokazującą dane lekarzy dostępnych. Wybierając lekarza dostajemy opcję rejestracji u niego w najbliższych terminach od dzisiaj do końca tygodnia. 
Z bazą danych aplikacja łączy się przez REST Api. Po wysłaniu odpowiedniego komunikatu do Api otrzymujemy dane w formacie JSON. Odpowiedź jest zależna od url. Po otrzymaniu odpowiedzi zmieniamy ją funkcją ReadAsAsync<T> na obiekt klasy T. Jest możliwość również wyboru, jakie dane chcemy otrzymać. Wybieramy je w definicji klasy T. Ważne jest to, aby pola klasy miały taką samą nazwę jak nagłówki otrzymane w odpowiedziach. Przydatną do tego stroną generującą takie klasy jest strona internetowa http://json2csharp.com. 

