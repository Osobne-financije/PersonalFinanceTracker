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
F02 | Unos prihoda i rashoda | Korisnik može unositi prihode (pokloni, plaća...) i rashode (putovanja, hrana, zabava...). Svaki unos mora sadržavati kategoriju, iznos, datum i opis.
FO3 | Pregled financijske povijesti | Korisnik može pregledati sve prethodno unesene prihode i rashode kroz tablični prikaz. Moguće je filtriranje podataka po datumu i kategoriji radi lakšeg pretraživanja.
FO4 | Postavljanje limita potrošnje | Omogućuje korisniku definiranje limita potrošnje za određene kategorije. Limit se može ažurirati, a stanje potrošnje po kategorijama se prati.
FO5 |Prikaz statistike | Korisniku se prikazuju statistički podaci u obliku pie charta, koji jasno vizualizira udjele po kategorijama troškova ili prihoda, olakšavajući analizu financijskog ponašanja.
FO6 | Dodavanje vlastitih kategorija | Aplikacija omogućuje korisniku dodavanje novih kategorija prihoda i troškova prema vlastitim potrebama.
FO7 | Postavljanje cilja štednje | Aplikacija omogućuje korisniku postavljanje financijskog cilja (npr. 2000 €) koji se prikazuje na formi zajedno s trenutnom uštedom.
FO8 | Izvještaji o financijama po vremenskim razdobljima | Korisnik može generirati izvještaje o prihodima i rashodima za odabrani vremenski period (tjedan, mjesec, 6 mjeseci, godina ili određeni datumi). Podaci se prikazuju u obliku tortnog grafikona i tablice s podacima po kategorijama.

## Tehnologije i oprema
U projektu koristim .NET Framework 4.8 i C# programski jezik uz Windows Forms (WinForms) za izradu korisničkog sučelja. Baza podataka izrađena je u Microsoft SQL Serveru, a pristup podacima realiziran je korištenjem ADO.NET i DBLayer klase s vježbi.
Za razvoj aplikacije koristim Visual Studio Community 2022, dok za upravljanje bazom koristim SQL Server Management Studio (SSMS). Verzije koda pratim putem Gita i GitHub repozitorija, gdje također vodim tehničku dokumentaciju u GitHub Wiki sekciji te planiram zadatke koristeći GitHub Projects.
