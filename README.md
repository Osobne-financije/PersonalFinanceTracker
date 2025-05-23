## Softver za praćenje osobnih financija

## Projektni tim

    Jan Biro  |    jbiro23@foi.hr   | 0010241827 | Jbiro23



## Opis domene
Praćenje osobnih financija često predstavlja izazov, pogotovo studentima koji se prvi put susreću s financijskom neovisnošću. Mnogi studenti teško prate svoje prihode i troškove, a ručno zapisivanje često dovodi do pogrešaka ili nejasne slike o tome kako troše novac.
Kako bi im se olakšalo vođenje financija, ovaj softver će im omogućiti jednostavno praćenje prihoda i rashoda, pregled financijskih aktivnosti, postavljanje financijskih ciljeva i kontrolu potrošnje kroz limite. Aplikacija omogućuje unos podataka o prihodima i rashodima prema različitim kategorijama, prikazuje statističke podatke u obliku grafikona, te omogućuje generiranje izvještaja koji korisnicima pomažu da bolje razumiju svoje financijske navike. Osim toga, aplikacija upozorava korisnike kada pređu postavljene limite potrošnje, što dodatno pomaže u boljoj kontroli troškova. Cilj aplikacije je pomoći studentima da lakše upravljaju svojim financijama i razviju bolje navike u trošenju i štednji.

![image](https://github.com/user-attachments/assets/fde8a05f-f33f-4d32-af3a-91c43c6f152a)  ![image](https://github.com/user-attachments/assets/f013a363-0f82-4db2-94c5-328cc94558c3)  ![image](https://github.com/user-attachments/assets/b2805132-afb9-4c19-84d3-fde065c21295)

![image](https://github.com/user-attachments/assets/cf629498-a780-4469-9f5c-78a785e31f62)  ![image](https://github.com/user-attachments/assets/5fbbc50e-37be-4ab0-adac-a1f2f388c89c)  ![image](https://github.com/user-attachments/assets/03703e1a-bcfd-41b1-93ec-428cd0a3bf26)







## Specifikacija projekta

Oznaka | Naziv | Kratki opis 
------ | ----- | ----------- 
F01 | Prijava korisnika | Aplikacija omogućava korisniku da se prijavi pomoću korisničkog imena i lozinke. Pristup financijskim podacima moguć je samo nakon uspješne autentikacije.
F02 | Unos prihoda i rashoda | Korisnik može unositi prihode (pokloni, plaća...) i rashode (putovanja, hrana, zabava...), svaki unos je kategoriziran i pohranjen u bazu podataka. 
FO3 | Pregled financijske povijesti | Aplikacija omogućava pregled svih unesenih prihoda i rashoda kroz tablični prikaz s filtriranjem po datumu i kategoriji.
FO4 | Postavljanje limita potrošnje | Korisnik može postaviti limit trošenja za svaku kategoriju. Aplikacija šalje sigurnosno upozorenje kada je limit premašen.
FO5 |Prikaz statistike | Aplikacija prikazuje statističke podatke u obliku pie charta kako bi korisnik lakše razumio potrošnju po kategorijama.
FO6 | Sigurnosno upozorenje | Kada korisnik premaši postavljeni limit trošenja u nekoj kategoriji, aplikacija prikazuje upozorenje.

## Tehnologije i oprema
U projektu koristim .NET Framework 4.8 i C# programski jezik uz Windows Forms (WinForms) za izradu korisničkog sučelja. Baza podataka izrađena je u Microsoft SQL Serveru, a pristup podacima realiziran je korištenjem ADO.NET i DBLayer klase s vježbi.
Za razvoj aplikacije koristim Visual Studio Community 2022, dok za upravljanje bazom koristim SQL Server Management Studio (SSMS). Verzije koda pratim putem Gita i GitHub repozitorija, gdje također vodim tehničku dokumentaciju u GitHub Wiki sekciji te planiram zadatke koristeći GitHub Projects.
