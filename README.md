# ElasticSearchAPI

API omogućava pretragu predefinisanog Elastic Search indeksa po zadatom kriterijumu.

##  Osnovna ideja

Indeks sadrži sledeća polja (fields): Module (MatchOnlyText), ObjectTypeId (LongNumber), ObjectId (LongNumber), TextTypeId (Keyword), Text (Text).
Pretraga se vrši prema kombinaciji vrednosti TextTypeId polja i sadržaja Text polja.

## Podržane funkcije

API omogućava prosleđivanje filtera u sledećem obliku:
 ```
  {
    "from": 0,
    "size": 100,
    "textTypeId": 10,
    "keywords": ["a", "b"]
  }
  ```
from : Otklon (Pogodno za implementaciju paginacije na frontu)
size : Maksimalan broj rezultata u odgovoru servisa
textTypeId : Vrednost Text Type identifikatora
keywords : Jedna ili više kljucnih reči koje učestvuju u pretrazi

Korišćenjem ugrađene Scalar API dokumentacije je moguće testirati API:
https://localhost:7139/scalar/v1

Aplikacija će u Development režimu automatski kreirati index na Elastiku i popunitiga testnim podacima, bez potrebe ručnog unosa radi testiranja. Testni podaci se mogu modifikovati unutar TestData klase. 

<img width="1871" height="801" alt="image" src="https://github.com/user-attachments/assets/7681a6fc-14b1-49b1-b629-25d682a259df" />

## Osnovne vrste pretrage

<img width="1264" height="656" alt="image" src="https://github.com/user-attachments/assets/fadd1268-ebc1-4731-80d4-89bcf92313e2" />

<img width="1264" height="775" alt="image" src="https://github.com/user-attachments/assets/6cec63c2-fe5c-4a9f-a916-87ba592557b1" />

Dodavanjem više reči u niz za pretragu, sistem će vratiti samo one objekte koji sadrže svaku od navedenih reči u Text polju (AND ponašanje):

<img width="1252" height="659" alt="image" src="https://github.com/user-attachments/assets/70f413a0-4c27-4cc2-b5c7-1af5830ba4ce" />

<img width="1249" height="615" alt="image" src="https://github.com/user-attachments/assets/9e0fe334-ccfd-4550-89ab-6be436abb090" />

Upisom više od jedne reči unutar jednog elementa niza filtera, sistem će vratiti sve objekte koji sadrže makar jednu od traženih reči u Text polju (OR ponašanje):

<img width="1259" height="716" alt="image" src="https://github.com/user-attachments/assets/f409bd0e-28da-42ea-aef8-d5f82b83e61a" />

## Napredne vrste pretrage (Pretrage koje uključuju kontekst jezika sadržanog u Text polju)

Aplikacija trenutno omogućava korišćenje napredne pretrage prema srpskom jeziku, implementiranjem specijalnog Serbian ES language analyser-а https://www.elastic.co/docs/reference/text-analysis/analysis-lang-analyzer#serbian-analyzer/

Benefiti ovog pristupa su sposobnost pretrage reči, nezavisno od toga da li je tekst zapisan u punom latiničnom, ćiriličnom ili krnjem latiničnom pismu (bez kukica).

Kako se u Elastiku sadržaj teksta skladišti kao multi-field (pomoćno polje, polja Text označenog na indeksu kao text.serbian) ovu opciju moguće isključiti ili konfigurisati za drugi ili više jezika u isto vreme.

U samom filteru pretrage, po trenutnoj implementaciji, nije potrebno navesti jezik na kome se vrši pretraga, jer sistem u isto vreme pretražuje sva postojeća pod polja i vraća rezultat prema definisanom jeziku na njima.

<img width="1301" height="680" alt="image" src="https://github.com/user-attachments/assets/729ef844-1755-481a-b9f8-26681c604c43" />

<img width="1302" height="722" alt="image" src="https://github.com/user-attachments/assets/6f8e7ee6-1136-411d-986b-3064dc2d21f9" />

<img width="1303" height="656" alt="image" src="https://github.com/user-attachments/assets/78928283-79b3-4e36-8127-f1363e7d44de" />

Ovim pristupom nije moguće detektovati krnje oblike latinice koji umesti ispravnog oblika jednog karaktera (đ), koriste više karaktera (dj), kao u primeru reči "djordjevic".

Ukoliko je potrebno da sistem detektuje i takve oblike, neispravnog teksta, potrebno je izraditi neku vrstu konvertera koji bi vršio specijalnu pretragu i po takvim slučajevima.

<img width="1306" height="677" alt="image" src="https://github.com/user-attachments/assets/26a455e1-b5f0-4742-95c1-5b77a7301a68" />

<img width="1305" height="672" alt="image" src="https://github.com/user-attachments/assets/3d8632fd-5df9-40a7-8367-ae5736c46cf5" />

## Tehnologije 

.NET 10

ElasticSearch-9.2.1

Kibana-9.2.1 (nije neophodna)

## Uputstvo za instalaciju

Preuzeti Elastic Search za windows sa https://www.elastic.co/downloads/elasticsearch 

Elastycsearch .yml konfiguraciju unutar elasticsearch-9.2.1\config foldera je nakon preuzimanja potrebno modifikovati i modifikovati "xpack.security.enabled: false", kako bi bilo moguće uspostaviti jednustavnu komunikaciju između aplikacije ili Kibane sa Elastikom.

Pokrenuti Elastic kroz konzolu pozivanjem elasticsearch-9.2.1\bin\elasticsearch.bat

Aplikacija je konfigurisana tako da kontaktira difoltni port 9200 na Elastik Serveru (http://localhost:9200).

API nakon pokretanja is VS u debug modu, otvara stranicu https://localhost:7139/scalar/v1 gde je moguće testirati endpoint.

Index i testni podaci su automatski učitani na Elastic nakon pokretanja.

Logovi se prikazuju u konzolnom prozoru, pa ukoliko aplikacija ima problem da kontaktira Elastic Server, konsultovati log.

Opciono je moguće preuzeti i Kibanu i pokrenuti je bez dodatnih podešavanja kroz kibana-9.2.1\bin\kiubana.bat

## Auth 

Trenutno nije implementirana, endpoint je public.




