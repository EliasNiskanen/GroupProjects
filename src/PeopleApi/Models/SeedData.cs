using Microsoft.EntityFrameworkCore;
using PeopleApi.Data;
using PeopleLib;

namespace PeopleApi.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new PeopleContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<PeopleContext>>()))
        {
            if (context == null)
            {
                throw new ArgumentNullException("Null PeopleContext");
            }

            context.Database.EnsureCreated();


            if (context.Renters.Any())
            {
                return;   // DB has been seeded
                // To re-seed the db: delete the existing *.db file and let the app create a new one
            }

            context.Renters.AddRange(
                new Renter
                {
                    IdRenter = 2,
                    FirstName = "Keijo",
                    LastName = "Kojootti",
                    NickName = "Kepe",
                    Locality = "Rovaniemi",
                    Presentation = "Rumpali",
                    Picture = File.ReadAllBytes("images/user_default_images/profilePic2.png"),
                    Email = "keijo.kojootti@hotmail.com",
                    Password = "TurvallinenSalasana2"
                },
                new Renter
                {
                    IdRenter = 3,
                    FirstName = "Testi",
                    LastName = "K�ytt�j�",
                    NickName = "TestiK�ytt�j�",
                    Locality = "Rovaniemi",
                    Presentation = "Kitaristi",
                    Picture = File.ReadAllBytes("images/user_default_images/profilePic3.png"),
                    Email = "salasana",
                    Password = "salasana"
                },
                new Renter
                {
                    IdRenter = 4,
                    FirstName = "Jorma",
                    LastName = "Er�nen",
                    NickName = "Er�Jorma666",
                    Locality = "Kuopio",
                    Presentation = "Kosketinsoittaja",
                    Picture = File.ReadAllBytes("images/user_default_images/profilePic4.png"),
                    Email = "salasana2",
                    Password = "salasana"
                },
                new Renter
                {
                    IdRenter = 5,
                    FirstName = "Riina",
                    LastName = "Virtanen",
                    NickName = "RaneVir",
                    Locality = "Lahti",
                    Presentation = "Basisti",
                    Picture = File.ReadAllBytes("images/user_default_images/profilePic5.png"),
                    Email = "salasana3",
                    Password = "salasana"
                },
                new Renter
                {
                    IdRenter = 6,
                    FirstName = "Niina",
                    LastName = "Lahtinen",
                    NickName = "NiinaL",
                    Locality = "Kuopio",
                    Presentation = "Kitaristi",
                    Picture = File.ReadAllBytes("images/user_default_images/profilePic6.png"),
                    Email = "salasana4",
                    Password = "salasana"
                },
                new Renter
                {
                    IdRenter = 7,
                    FirstName = "Sanna",
                    LastName = "Suttuparta",
                    NickName = "SannaS",
                    Locality = "Kuopio",
                    Presentation = "Solisti",
                    Picture = File.ReadAllBytes("images/user_default_images/profilePic7.png"),
                    Email = "salasana5",
                    Password = "salasana"
                },
                new Renter
                {
                    IdRenter = 8,
                    FirstName = "Samuli",
                    LastName = "Sopuli",
                    NickName = "SamuXD",
                    Locality = "H�meenlinna",
                    Presentation = "Kitaristi",
                    Picture = File.ReadAllBytes("images/user_default_images/profilePic8.png"),
                    Email = "salasana6",
                    Password = "salasana"
                },
                new Renter
                {
                    IdRenter = 9,
                    FirstName = "Tero",
                    LastName = "Tuppurainen",
                    NickName = "TeroMies69",
                    Locality = "Kuopio",
                    Presentation = "Rumpali",
                    Picture = File.ReadAllBytes("images/user_default_images/profilePic9.png"),
                    Email = "salasana7",
                    Password = "salasana"
                },
                new Renter
                {
                    IdRenter = 10,
                    FirstName = "Jenna",
                    LastName = "Jokipakka",
                    NickName = "Jespersson",
                    Locality = "Mikkeli",
                    Presentation = "Rumpali",
                    Picture = File.ReadAllBytes("images/user_default_images/profilePic10.png"),
                    Email = "salasana8",
                    Password = "salasana"
                }
            );

            context.RentalInstruments.AddRange(
                new RentalInstrument
                {
                    IdRentalInstrument = 3,
                    IdRenter = 3,
                    Type = "Kitara",
                    Model = "Gibson",
                    Price = 50,
                    InstrumentInfo = "Hyv� kitara kielet vasta vaihdettu",
                    ModelYear = "1945",
                    Picture = File.ReadAllBytes("images/instrument_images/kitara1.jpg"),
                    Lainattu = false,
                    Lainauspyynto = false,

                },
                new RentalInstrument
                {
                    IdRentalInstrument = 4,
                    IdRenter = 3,
                    Type = "Kitara",
                    Model = "Les Paul",
                    Price = 60,
                    InstrumentInfo = "Hyv� kitara kielet vasta vaihdettu, kopassa reik�",
                    ModelYear = "1969",
                    Picture = File.ReadAllBytes("images/instrument_images/kitara2.jpg"),
                    Lainattu = false,
                    Lainauspyynto = false,
                }, 
                new RentalInstrument
                {
                    IdRentalInstrument = 5,
                    IdRenter = 3,
                    Type = "Viulu",
                    Model = "Vanha ven�l�inen",
                    Price = 500,
                    InstrumentInfo = "Hyv� peli, joskaan ei halvin",
                    ModelYear = "1925",
                    Picture = File.ReadAllBytes("images/instrument_images/viulu1.jpg"),
                    Lainattu = false,
                    Lainauspyynto = false,
                },
                new RentalInstrument
                {
                    IdRentalInstrument = 6,
                    IdRenter = 4,
                    Type = "Viulu",
                    Model = "Vanha it�valtalainen",
                    Price = 450,
                    InstrumentInfo = "Paras, joskaan ei halvin pel�",
                    ModelYear = "1907",
                    Picture = File.ReadAllBytes("images/instrument_images/viulu2.jpg"),
                    Lainattu = false,
                    Lainauspyynto = false,
                }, 
                new RentalInstrument
                {
                    IdRentalInstrument = 7,
                    IdRenter = 4,
                    Type = "Sello",
                    Model = "Hyv� sello",
                    Price = 250,
                    InstrumentInfo = "Uudet kielet",
                    ModelYear = "1875",
                    Picture = File.ReadAllBytes("images/instrument_images/sello1.jpg"),
                    Lainattu = false,
                    Lainauspyynto = false,
                },
                new RentalInstrument
                {
                    IdRentalInstrument = 8,
                    IdRenter = 5,
                    Type = "Sello",
                    Model = "Paras sello",
                    Price = 250,
                    InstrumentInfo = "Uudet kielet, ja jousi",
                    ModelYear = "1885",
                    Picture = File.ReadAllBytes("images/instrument_images/sello2.jpg"),
                    Lainattu = false,
                    Lainauspyynto = false,
                },
                new RentalInstrument
                {
                    IdRentalInstrument = 9,
                    IdRenter = 5,
                    Type = "Rummut",
                    Model = "Pearl",
                    Price = 150,
                    InstrumentInfo = "Uudet kalvot ja pellit",
                    ModelYear = "1975",
                    Picture = File.ReadAllBytes("images/instrument_images/rummut1.jpg"),
                    Lainattu = false,
                    Lainauspyynto = false,
                },
                new RentalInstrument
                {
                    IdRentalInstrument = 10,
                    IdRenter = 4,
                    Type = "Rummut",
                    Model = "Monenlaisia rumpuja",
                    Price = 100,
                    InstrumentInfo = "Kaikenlaisia rumpuja vuokralla",
                    ModelYear = "Milloin vaan",
                    Picture = File.ReadAllBytes("images/instrument_images/rummut2.jpg"),
                    Lainattu = false,
                    Lainauspyynto = false,
                }

            );
            //    new Trip
            //    {
            //        IdRenter = 2,
            //        HeadLine = "Matka Puijon metsiin",
            //        Picture = File.ReadAllBytes("images/trip_images/trip2_image1.png"),
            //        StartDate = DateTime.Today,
            //        EndDate = DateTime.Today,
            //        Private = false,
            //        IdTrip = 2
            //    },
            //    new Trip
            //    {
            //        IdRenter = 3,
            //        HeadLine = "Matka Kallavedelle",
            //        Picture = File.ReadAllBytes("images/trip_images/trip3_image1.png"),
            //        StartDate = DateTime.Today,
            //        EndDate = DateTime.Today,
            //        Private = false,
            //        IdTrip = 3
            //    },
            //    new Trip
            //    {
            //        IdRenter = 4,
            //        HeadLine = "Reissu Turun saaristoon",
            //        Picture = File.ReadAllBytes("images/trip_images/trip4_image1.png"),
            //        StartDate = DateTime.Today,
            //        EndDate = DateTime.Today,
            //        Private = false,
            //        IdTrip = 4
            //    },
            //    new Trip
            //    {
            //        IdRenter = 5,
            //        HeadLine = "Matka muumimaailmaan",
            //        Picture = File.ReadAllBytes("images/trip_images/trip5_image1.png"),
            //        StartDate = DateTime.Today,
            //        EndDate = DateTime.Today,
            //        Private = false,
            //        IdTrip = 5
            //    },
            //    new Trip
            //    {
            //        IdRenter = 6,
            //        HeadLine = "Vaeltaen Lappiin",
            //        Picture = File.ReadAllBytes("images/trip_images/trip6_image1.png"),
            //        StartDate = DateTime.Today,
            //        EndDate = DateTime.Today,
            //        Private = false,
            //        IdTrip = 6
            //    }
            //);

            //context.Stories.AddRange(
            //    new Story
            //    {
            //        IdStory = 1,
            //        Date = DateTime.Today,
            //        StoryText = "Kuopion Kulkijat olivat j�rjest�neet telttaretken vuoristoon, ja heid�n valitsemansa paikka oli henke�salpaava. Korkealla vuoristossa, ymp�rill� oli jyrkki� kallioita, joita peittiv�t kauniit kukkakent�t. Vaikka ryhm� oli v�synyt pitk�n vaelluksen j�lkeen, heid�n innostuksensa oli korkealla, sill� he tiesiv�t, ett� y�taivas olisi uskomaton.Kun aurinko laskeutui, Kuopion Kulkijat alkoivat pystytt�� telttojaan. Heid�n leirins� sijaitsi pienell� kumpareella, josta oli upeat n�kym�t vuorille ja laaksoon. Ryhm� p��tti sytytt�� nuotion ja grillata makkarat. Ilmassa oli tunnelmaa ja yhteishenke�, joka syntyi vaelluksen yhteisest� kokemuksessta.Kun y� saapui, taivas oli t�ynn� t�hti�, ja Kuopion Kulkijat makasivat telttansa sis�ll� ja ihailivat t�t� n�kym��. He olivat kaukana kaupungin valoista, joten heid�n ymp�rill��n oli t�ydellinen pimeys, joka vain korosti t�htitaivasta. He kuuntelivat vuoriston hiljaisuutta, joka vain satunnaisesti rikkoutui l�hell� olevan joen pauhulla.Ryhm� nautti t�ysin siemauksin telttaretkens� y�taivaasta ja he huomasivat, ett� t�m� oli heille ainutlaatuinen kokemus. He nauttivat yhdess�olosta ja ymp�r�iv�n luonnon kauneudesta, ja t�m� retki oli tullut heille ikimuistoiseksi kokemukseksi.Seuraavana aamuna, he her�siv�t auringon ensimm�isiin s�teisiin ja nauttivat aamiaistaan ennen telttojen purkua. Vaikka heid�n telttaretkens� oli p��ttym�ss�, he tunsivat yhteenkuuluvuutta ja tyytyv�isyytt�, joka oli syntynyt yhteisest� kokemuksesta. Ja he tiesiv�t, ett� he voisivat aina palata t�lle vuoristolle, joka oli tarjonnut heille niin paljon.",
            //        IdTravelDestination = 1,
            //        IdTrip = 1,
            //        IdRenter = 3
            //    },
            //    new Story
            //    {
            //        IdStory = 2,
            //        Date = DateTime.Today,
            //        StoryText = "Kuopion kulkijat niminen ryhm� oli suunnitellut pitk�n viikonlopun vaellusretken Puijon metsiin. Ryhm� koostui seitsem�st� retkeilij�st�, jotka kaikki olivat kokeneita vaeltajia. Heid�n tavoitteenaan oli nauttia luonnosta, telttailla mets�ss� ja nauttia hyv�st� ruoasta yhdess�. Matka alkoi perjantai-iltana, kun ryhm� kokoontui Kuopion rautatieasemalle. He ottivat junan Puijon suuntaan ja saapuivat perille noin tunnin kuluttua. Heid�n ensimm�inen pys�kkins� oli Puijon torni, jossa he nauttivat upeista n�kymist� kaupunkiin ja ymp�r�iv��n luontoon. Sen j�lkeen he aloittivat vaelluksensa kohti mets��, jossa he aikovat telttailla. Matka oli noin nelj� kilometri�, mutta vaellus oli haastava, sill� heid�n t�ytyi kiivet� jyrkki� m�ki� yl�s ja alas. Kuitenkin he p��siv�t perille noin tunnin kuluttua. Ryhm� pystytti telttansa kauniille paikalle mets�n keskelle ja aloitti ruoanlaiton. He olivat suunnitelleet etuk�teen, mit� he aikovat sy�d�, ja jokainen retkeilij� oli tuonut omat ruokatarvikkeensa. He valmistivat nuotiolla herkullisen aterian ja nauttivat yhdess� hyv�st� ruoasta ja tunnelmasta. Seuraavana p�iv�n� ryhm� her�si varhain ja aloitti p�iv�n vaelluksen. He vaelsivat useita tunteja ja ihailivat upeita maisemia, kunnes he l�ysiv�t kauniin pienen j�rven. He uivat ja rentoutuivat j�rven rannalla ennen kuin jatkoivat matkaa. Illalla he palasivat teltalle ja aloittivat taas ruoanlaiton. He nauttivat hyv�st� ruoasta, nauttivat yhdess� olosta ja kuuntelivat mets�n ��ni�. He viettiv�t y�n teltassa kuunnellen sateen ropinaa ja tuulen huminaa mets�n l�pi.Kolmantena p�iv�n� ryhm� aloitti paluumatkan kohti kaupunkia. He k�veliv�t rauhallisesti nauttien viel� viimeisist� hetkist��n mets�ss�. Saapuessaan kaupunkiin, he tunsivat v�symyksen mutta my�s tyytyv�isyyden siit�, ett� olivat selviytyneet vaelluksesta.",
            //        IdTravelDestination = 1,
            //        IdTrip = 2,
            //        IdRenter = 2
            //    },
            //    new Story
            //    {
            //        IdStory = 3,
            //        Date = DateTime.Today,
            //        StoryText = "Kuopion kulkijat niminen retkiryhm� oli suunnitellut viikon mittaisen veneilyn Kallavedelle. Ryhm� oli innoissaan matkasta, joka sis�lsi kalastusta, telttailua ja upeita maisemia.Retki sujui suunnitelmien mukaan, ja retkeilij�t nauttivat upeista n�kymist� ja kalastuksesta. He l�ysiv�t upean rauhallisen lahden, johon he p��ttiv�t telttailla. He asettivat telttansa kauniille hiekkarannalle ja aloittivat ruoanlaiton. He valmistivat nuotiolla herkullisen aterian ja nauttivat yhdess� hyv�st� ruoasta ja tunnelmasta. He katselivat auringonlaskua rannalla ja ihailivat kaunista n�kym��. Seuraavana p�iv�n� he l�htiv�t veneell� tutkimaan aluetta. He l�ysiv�t upeita hiekkarantoja, salmia ja saaria. He p��ttiv�t pys�hty� er��lle saarelle lounaalle. He valmistivat nuotiolla herkullisen aterian ja nauttivat yhdess� hyv�st� ruoasta. Kun he olivat valmiita jatkamaan matkaansa, vene ei k�ynnistynyt. He yrittiv�t kaikkea mahdollista, mutta mik��n ei auttanut. He olivat huolissaan ja pettyneit�, sill� heid�n olisi pit�nyt olla jo seuraavalla telttapaikalla. Mutta yht�kki� er�s ryhm�n j�senist� huomasi l�hell� olevan m�kin. He l�htiv�t k�velem��n sinne ja kysyiv�t avukseen. M�kin asukas oli yst�v�llinen ja auttoi heid�t korjaamaan veneen moottorin. Ryhm� oli kiitollinen saamastaan avusta. He jatkoivat matkaansa ja saapuivat onnistuneesti seuraavalle telttapaikalle. He nauttivat lopun matkasta upeista maisemista ja yhdess�olosta. Matka p��ttyi onnellisesti, ja ryhm� oli onnellinen siit�, ett� he selvisiv�t kaikista haasteista. He p��ttiv�t, ett� seuraavalla retkell� he tarkistaisivat veneen moottorin huolellisesti ennen l�ht��.",
            //        IdTravelDestination = 1,
            //        IdTrip = 3,
            //        IdRenter = 3
            //    },
            //    new Story
            //    {
            //        IdStory = 4,
            //        Date = DateTime.Today,
            //        StoryText = "Kuopion kulkijat, nelj�n hengen yst�v�porukka, olivat jo pitk��n haaveilleet lomasta Turun saaristossa. He p��ttiv�t vihdoin toteuttaa unelmansa ja aloittivat matkan huolellisella suunnittelulla.\r\n\r\nMatka alkoi aikaisin aamulla Kuopiosta, josta he hypp�siv�t bussiin kohti Helsinki�. Bussimatka sujui mukavasti maisemia ihaillen ja matkapahoinvointia v�ltellen. Helsinkiin saavuttuaan he l�htiv�t tutustumaan kaupunkiin, jonne heill� oli muutama tunti aikaa ennen laivan l�ht�� kohti Turun saaristoa.\r\n\r\nKuopion kulkijat k�veliv�t kaupungilla, shoppailivat ja nauttivat kauniista kes�s��st�. He k�viv�t my�s lounaalla ravintolassa ja maistelivat paikallisia herkkuja. Aikaa kului nopeasti ja pian he olivatkin jo satamassa valmiina laivaan nousuun.\r\n\r\nLaiva oli suuri ja moderni, ja Kuopion kulkijat l�ysiv�t helposti paikkansa laivan kannella. He ihastelivat merimaisemia, kun laiva suuntasi kohti Saaristomerta. Laivan ravintolassa he nauttivat runsaan aamiaisen, joka antoi hyv�n pohjan p�iv�n seikkailuille.\r\n\r\nPerill� heit� odotti vuokrattu m�kki, joka sijaitsi upealla paikalla meren rannalla. M�kki oli tilava ja kodikas, ja sielt� avautui upea n�kym� merelle. Kuopion kulkijat ihastuivat heti m�kin rauhalliseen ja kauniiseen ymp�rist��n, ja he tiesiv�t, ett� heid�n lomastaan tulisi unohtumaton.\r\n\r\nHe k�yttiv�t lomansa tutustuen saaristoon, meloen kajakeilla, k�vellen luontopoluilla ja veneilem�ll� merell�. He vierailivat monissa saariston kiehtovissa pikkukyliss�, joissa he tapasivat paikallisia asukkaita ja s�iv�t herkullista paikallista ruokaa ravintoloissa.\r\n\r\nYhten� p�iv�n� Kuopion kulkijat p��ttiv�t l�hte� veneretkelle merelle. He vuokrasivat pienen purjeveneen ja l�htiv�t tutkimaan saaristoa omatoimisesti. Veneily oli hauskaa, mutta samalla hieman j�nnitt�v��, sill� he olivat ensikertalaisia veneilij�it�. He onnistuivat kuitenkin ohjaamaan venett� varovasti ja nauttivat upeasta merimaisem",
            //        IdTravelDestination = 1,
            //        IdTrip = 4,
            //        IdRenter = 4
            //    },
            //    new Story
            //    {
            //        IdStory = 5,
            //        Date = DateTime.Today,
            //        StoryText = "Kuopion kulkijat ovat ryhm� innokkaita retkeilij�it�, jotka rakastivat seikkailuja ja uusien paikkojen l�yt�mist�. Heid�n joukossaan oli niin nuoria kuin vanhempiakin seikkailijoita, jotka yhdisti intohimo luontoon ja liikuntaan.\r\n\r\nT�ll� kertaa Kuopion kulkijat olivat p��tt�neet l�hte� Muumimaailmaan, joka oli monelle heist� tuttu lapsuudestaan. He suunnittelivat reissua yhdess� ja jakoivat teht�vi� matkan toteuttamiseksi. Jokainen heist� oli innokas ja valmis tekem��n oman osansa, jotta matka Muumimaailmaan toteutuisi sujuvasti ja onnistuneesti.\r\n\r\nHe suuntasivat matkaan aikaisin aamulla junalla kohti Turun satamaa, josta Muumimaailman laivat l�htiv�t. Junamatka oli mukava, ja Kuopion kulkijat keskustelivat vilkkaasti matkan tarkoituksesta ja tulevista seikkailuista.\r\n\r\nPerill� Muumimaailmassa heid�n silm�ns� loistivat innostuksesta. He p��ttiv�t aloittaa seikkailunsa Muumipeikon kodista, joka oli rakennettu t�ydelliseen Muumi-tyyliin. He tapasivat Muumipeikon ja h�nen yst�v�ns�, seikkailivat Muumitalossa, kulkivat Nipsun polkua ja tutustuivat Pikku Myyn kotiin. He s�iv�t Muumimamman valmistamaa herkullista ruokaa ja nauttivat makeisia Muumi-kaupassa.\r\n\r\nHe viettiv�t koko p�iv�n Muumimaailmassa, ja jokainen hetki oli t�ynn� iloa ja seikkailua. He yhdess� kokivat unohtumattomia hetki�, kuten Muumipeikon yll�tt�v�n esiintymisen ja Pikku Myyn hullunkurisen temppuilun. P�iv� Muumimaailmassa oli ollut kaikille mahtava kokemus.\r\n\r\nPaluumatka oli haikea, mutta samalla t�ynn� innostusta ja uusia suunnitelmia. Kuopion kulkijat olivat kiitollisia yst�vyydest��n ja siit�, ett� heill� oli toisensa ja mahdollisuus kokea uusia seikkailuja yhdess�.",
            //        IdTravelDestination = 1,
            //        IdTrip = 5,
            //        IdRenter = 5
            //    },
            //     new Story
            //     {
            //         IdStory = 6,
            //         Date = DateTime.Today,
            //         StoryText = "Kuopion kulkijat olivat jo pitk��n haaveilleet vaellusmatkasta Pohjois-Suomen upeissa maisemissa. He olivat kartoittaneet reitin tarkkaan ja suunnitelleet matkaa jo kuukausia etuk�teen. He olivat hankkineet tarvittavat varusteet ja varautuneet kaikkiin mahdollisiin haasteisiin.\r\n\r\nMatka alkoi aikaisin aamulla Kuopion rautatieasemalta, josta he hypp�siv�t junaan kohti pohjoista. Junamatka kesti useita tunteja, mutta Kuopion kulkijat eiv�t tylsistyneet, sill� maisemat vaihtuivat kauniiksi ja erilaisiksi sit� mukaan kun juna eteni kohti pohjoista.\r\n\r\nPerill� Rovaniemell� he aloittivat vaelluksensa kohti Korvatunturin upeita maisemia. Heid�n reittins� kulki l�pi upeiden tunturimaisemien ja er�maiden, joiden kauneus vei heid�t hetkeksi aivan toiseen maailmaan. He pys�htyiv�t v�lill� lep��m��n, nauttimaan ev�it� ja ihailemaan maisemia.\r\n\r\nHeid�n matkansa jatkui aina Inarij�rvelle saakka, jossa he y�pyiv�t kauniissa m�kiss� j�rven rannalla. Seuraavana p�iv�n� he jatkoivat matkaansa kohti Saariselk��, jossa heid�n oli tarkoitus y�py� useamman p�iv�n. Saariselk� oli upea paikka, joka tarjosi monenlaisia aktiviteetteja, kuten hiihtoa, moottorikelkkasafareita ja poronk�ristysillallisia.\r\n\r\nKuopion kulkijat nauttivat jokaisesta hetkest�, jonka he viettiv�t tunturimaisemissa. Heid�n matkansa oli t�ynn� seikkailuja ja yll�tyksi�, kuten yll�tt�vi� lumipyryj� ja jylhi� rotkoja, joiden yli heid�n t�ytyi kiivet�.\r\n\r\nLopulta oli aika l�hte� paluumatkalle. Heid�n paluumatkansa kulki samalla reitill�, mutta he pys�htyiv�t matkan varrella viel� muutamassa uudessa paikassa, jotka he olivat j�tt�neet n�kem�tt� matkan aikana.\r\n\r\nKun he palasivat Kuopioon, he olivat uupuneita, mutta samalla t�ynn� uusia kokemuksia ja unohtumattomia muistoja. He olivat onnistuneet toteuttamaan haaveensa vaellusmatkasta ja he tunsivat olevansa entist� vahvempia ihmisin�.",
            //         IdTravelDestination = 1,
            //         IdTrip = 6,
            //         IdRenter = 6
            //     }



          //  );

          //  context.TravelDestinations.AddRange(
           //    new TravelDestination
           //    {
           //        IdTravelDestination = 1,
           //        DestinationName = "Puijon torni",
           //        Country = "Suomi",
           //        City = "Kuopio",
           //        DestinationInfo = "Puijon torni on Kuopion Puijolla sijaitseva 75 metri� korkea linkki- ja n�k�torni.\r\n\r\nPuijon m�en korkeus on noin 150 metri� Kallaveden pinnasta mitattuna. Tornin on suunnitellut arkkitehti Seppo Ruotsalainen. Torni avattiin yleis�lle ensimm�ist� kertaa 27. hein�kuuta 1963.\r\n\r\nTornista k�ytet��n my�s nimityksi� Suurtorni, Linkkitorni ja \"Pottunuija\". Tornin valmistumisen j�lkeen sit� on saneerattu useita kertoja. Viimeisin saneeraus p��ttyi vuonna 2019.\r\n\r\nTornia k�ytet��n matkailun ohella my�s langattoman tietoliikenteen linkkiasemana ja puhelinpalvelujen tukiasemana. Aloite nykyisen tornin rakentamisesta tuli Posti- ja lenn�tinhallituksen taholta. Puhelinliikenteen automatisointi vaati linkkitornin rakentamista Kuopioon puhelinyhteyksien parantamiseksi.",
           //        Picture = File.ReadAllBytes("images/travel_destination_images/travel_destination1_image1.png")
           //    },
           //     new TravelDestination
           //     {
           //         IdTravelDestination = 2,
           //         DestinationName = "Iidesj�rven lintutorni",
           //         Country = "Suomi",
           //         City = "Tampere",
           //         DestinationInfo = "Iidesj�rvi on lintuj�rvi Tampereen kaupungin syd�mess�. Lintujen tarkkailua varten on j�rven it�p��ss� lintutorni, joka on vastik��n kunnostettu. Paras aika lintujen tarkkailuun on kev�t. J�rvell� ja sen ruovikossa pesii edelleen monipuolinen linnusto mm. naurulokkiyhdyskunta, silkkiuikku, telkk�, nokikana, liejukana, satakieli sek� ruoko- ja rytikerttunen.\r\n\r\nIidesj�rven luontopolku alkaa lintutornilta ja on pituudeltaan noin 7 km. Lintujen lis�ksi reitilt� l�ytyy niitty�, luhtaniitty� ja rantapensaikkoa niiden monpuolisine kasvillisuuksineen.",
           //         Picture = File.ReadAllBytes("images/travel_destination_images/travel_destination2_image1.png")
           //     },
           //      new TravelDestination
           //      {
           //          IdTravelDestination = 3,
           //          DestinationName = "Abiskon kansallispuisto",
           //          Country = "Ruotsi",
           //          City = "Kiiruna",
           //          DestinationInfo = "Abiskon kansallispuisto on kansallispuisto Kiirunan kunnassa Norrbottenin l��niss� Pohjois-Ruotsissa l�hell� Norjan rajaa. Se on perustettu vuonna 1909 ja on pinta-alaltaan 77 neli�kilometrin laajuinen. Kansallispuisto rajoittuu Tornioj�rveen ja ulottuu siit� noin viidentoista kilometrin p��h�n lounaaseen. Se sijaitsee noin 200 kilometri� napapiirin pohjoispuolella.\r\n\r\nAbiskon kansallispuiston tavoitteina on s�ilytt�� pohjoinen tunturimaisema luonnontilaisena ja samalla mahdollistaa tieteellinen tutkimus. Kansallispuisto on suosittu matkailukohde.\r\n\r\nKansallispuiston luontopolku Kungsleden seurailee vuorijonoa ja alkaa pienest� Abiskon kyl�st�. My�s Kalottireitti kulkee kansallispuiston l�vitse.\r\n\r\nAlueella on useita majoittumismahdollisuuksia sek� itse alueella ett� Abiskon kyl�ss�. Abisko Turiststation -nimisen rautatieseisakkeen l�hell� on kansallispuiston k�vij�iden suosima majatalo.",
           //          Picture = File.ReadAllBytes("images/travel_destination_images/travel_destination3_image1.png")
           //      },
           //      new TravelDestination
           //      {
           //          IdTravelDestination = 4,
           //          DestinationName = "Helvetin kolu",
           //          Country = "Suomi",
           //          City = "Ruovesi",
           //          DestinationInfo = "Helvetinkolu on kalliomuodostuma Helvetinj�rven kansallispuistossa Ruovedell�. Helvetinkolu on 40 metri� pitk�, 38 metri� syv� ja vain pari metri� leve� sola, joka laskee jyrk�sti Ison Helvetinj�rven rantaan.\r\n\r\nHelvetinkolu on my�s Helvetinj�rven kansallispuiston tunnus. Helvetinkolu muodostui noin 150�200 miljoonaa vuotta sitten, kun maankuori liikahteli. Samaan aikaan syntyi my�s noin 20 kilometri� pitk� Isosta Helvetinj�rvest� Luomaj�rven kautta Koveroj�rveen p��ttyv� rotkoj�rvien jono. Helvetinkolu tuli tunnetuksi n�ht�vyydeksi jo 1800-luvulla. Siell� on vierailleet monet kuuluisat taiteilijat ja kirjailijat, kuten Akseli Gallen-Kallela ja J. L. Runeberg. Helvetinkolun alue suojeltiin 1950-luvulla. Sit� on k�ytetty my�s susiansana. Helvetinkolusta sai visuaalisia vaikutteita ja nimens� Suomen paviljonki Sevillan maailmann�yttelyss� vuonna 1992. Rakennuksen suunnittelivat Juha J��skel�inen, Juha Kaakko, Petri Rouhiainen, Matti Sanaksenaho ja Jari Tirkkonen.",
           //          Picture = File.ReadAllBytes("images/travel_destination_images/travel_destination4_image1.png")
           //      },
           //       new TravelDestination
           //       {
           //           IdTravelDestination = 5,
           //           DestinationName = "Jotunheimenin kansallispuisto",
           //           Country = "Norja",
           //           City = "Oppland",
           //           DestinationInfo = "Jotunheimenin kansallispuisto on kansallispuisto Opplandin ja Sognin ja Fjordanen l��nien alueella Norjassa. Kansallispuisto sijaitsee Jotunheimenin vuoristoalueella Etel�-Norjassa. Kansallispuisto perustettiin vuonna 1980 ja sen pinta-ala on 1 151 neli�kilometri�.\r\n\r\nKansallispuiston alueella sijaitsevat muun muassa kaksi Norjan korkeinta vuorta: Galdh�piggen ylt�� 2 469 metrin korkeuteen merenpinnasta, lumihuppuinen Glittertinden on muutaman metrin matalampi. Alueen ter�vimm�t vuorenhuiput sijaitsevat Hurrunganevuoristossa, jossa sijaitsee maan kolmanneksi korkein vuori, Store Skagast�lstind, 2 403 metri� merenpinnasta. Laajin j��tikk� on Sm�rstabbreen, joka peitt�� noin 15 neli�kilometrin laajuisen alueen.",
           //           Picture = File.ReadAllBytes("images/travel_destination_images/travel_destination5_image1.png")
           //       },

           //        new TravelDestination
           //        {
           //            IdTravelDestination = 6,
           //            DestinationName = "Hyvink��",
           //            Country = "Suomi",
           //            City = "Hyvink��",
           //            DestinationInfo = "Helsingist� 60km pohjoiseen sijaitsee entinen kauppala, nykyinen Kaupunki. Kaupunkin merkitt�vimm�t rakennukset on ovat Villatehdas, kenk�tehdas, KONE-tehdasalue ja VR-konepaja. Hyvink��ll� sijaitsese Sveitsin lenkkeilymaastot",
           //            Picture = File.ReadAllBytes("images/travel_destination_images/hyvinkaa.png")
           //        }
           //);

           // context.TravelDestinationPictures.AddRange(
           //     new TravelDestinationPicture
           //     {
           //         IdTravelDestinationPicture = 1,
           //         Picture = "images/travel_destination_images/travel_destination1_image1.png",
           //         IdTravelDestination = 1
           //     },
           //     new TravelDestinationPicture
           //     {
           //         IdTravelDestinationPicture = 2,
           //         Picture = "images/travel_destination_images/travel_destination1_image2.png",
           //         IdTravelDestination = 1
           //     },
           //     new TravelDestinationPicture
           //     {
           //         IdTravelDestinationPicture = 3,
           //         Picture = "images/travel_destination_images/travel_destination2_image1.png",
           //         IdTravelDestination = 2
           //     },
           //     new TravelDestinationPicture
           //     {
           //         IdTravelDestinationPicture = 4,
           //         Picture = "images/travel_destination_images/travel_destination2_image2.png",
           //         IdTravelDestination = 2
           //     }
           // );

           // context.StoryPictures.AddRange(
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 1,
           //         Picture = File.ReadAllBytes("images/story_images/story1_image1.png"),
           //         IdStory = 1
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 2,
           //         Picture = File.ReadAllBytes("images/story_images/story1_image2.png"),
           //         IdStory = 1
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 3,
           //         Picture = File.ReadAllBytes("images/story_images/story2_image1.png"),
           //         IdStory = 2
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 4,
           //         Picture = File.ReadAllBytes("images/story_images/story2_image2.png"),
           //         IdStory = 2
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 5,
           //         Picture = File.ReadAllBytes("images/story_images/story3_image1.png"),
           //         IdStory = 3
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 6,
           //         Picture = File.ReadAllBytes("images/story_images/story3_image2.png"),
           //         IdStory = 3
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 7,
           //         Picture = File.ReadAllBytes("images/story_images/story3_image3.png"),
           //         IdStory = 3
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 8,
           //         Picture = File.ReadAllBytes("images/story_images/story4_image1.png"),
           //         IdStory = 4
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 9,
           //         Picture = File.ReadAllBytes("images/story_images/story4_image2.png"),
           //         IdStory = 4
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 10,
           //         Picture = File.ReadAllBytes("images/story_images/story4_image3.png"),
           //         IdStory = 4
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 11,
           //         Picture = File.ReadAllBytes("images/story_images/story5_image1.png"),
           //         IdStory = 5
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 12,
           //         Picture = File.ReadAllBytes("images/story_images/story5_image2.png"),
           //         IdStory = 5
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 13,
           //         Picture = File.ReadAllBytes("images/story_images/story5_image3.png"),
           //         IdStory = 5
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 14,
           //         Picture = File.ReadAllBytes("images/story_images/story6_image1.png"),
           //         IdStory = 6
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 15,
           //         Picture = File.ReadAllBytes("images/story_images/story6_image2.png"),
           //         IdStory = 6
           //     },
           //     new StoryPicture
           //     {
           //         IdStoryPicture = 16,
           //         Picture = File.ReadAllBytes("images/story_images/story6_image3.png"),
           //         IdStory = 6
           //     }
         //   );

            context.ProfileDefaultPictures.AddRange(
             new ProfileDefaultPicture
             {
                 Id = 1,
                 Picture = File.ReadAllBytes("images/user_default_images/profilePic1.png"),
             },
             new ProfileDefaultPicture
             {
                 Id = 2,
                 Picture = File.ReadAllBytes("images/user_default_images/profilePic2.png"),
             },
             new ProfileDefaultPicture
             {
                 Id = 3,
                 Picture = File.ReadAllBytes("images/user_default_images/profilePic3.png"),
             },
             new ProfileDefaultPicture
             {
                 Id = 4,
                 Picture = File.ReadAllBytes("images/user_default_images/profilePic4.png"),
             },
             new ProfileDefaultPicture
             {
                 Id = 5,
                 Picture = File.ReadAllBytes("images/user_default_images/profilePic5.png"),
             },
             new ProfileDefaultPicture
             {
                 Id = 6,
                 Picture = File.ReadAllBytes("images/user_default_images/profilePic6.png"),
             },
             new ProfileDefaultPicture
             {
                 Id = 7,
                 Picture = File.ReadAllBytes("images/user_default_images/profilePic7.png"),
             },
             new ProfileDefaultPicture
             {
                 Id = 8,
                 Picture = File.ReadAllBytes("images/user_default_images/profilePic8.png"),
             },
             new ProfileDefaultPicture
             {
                 Id = 9,
                 Picture = File.ReadAllBytes("images/user_default_images/profilePic9.png"),
             },
             new ProfileDefaultPicture
             {
                 Id = 10,
                 Picture = File.ReadAllBytes("images/user_default_images/profilePic10.png"),
             }
         );





            context.SaveChanges();
        }
    }
}
