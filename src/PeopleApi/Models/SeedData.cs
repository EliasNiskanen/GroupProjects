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
                    LastName = "Käyttäjä",
                    NickName = "TestiKäyttäjä",
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
                    LastName = "Eränen",
                    NickName = "EräJorma666",
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
                    Locality = "Hämeenlinna",
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
                    InstrumentInfo = "Hyvä kitara kielet vasta vaihdettu",
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
                    InstrumentInfo = "Hyvä kitara kielet vasta vaihdettu, kopassa reikä",
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
                    Model = "Vanha venäläinen",
                    Price = 500,
                    InstrumentInfo = "Hyvä peli, joskaan ei halvin",
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
                    Model = "Vanha itävaltalainen",
                    Price = 450,
                    InstrumentInfo = "Paras, joskaan ei halvin pelí",
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
                    Model = "Hyvä sello",
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
            //        StoryText = "Kuopion Kulkijat olivat järjestäneet telttaretken vuoristoon, ja heidän valitsemansa paikka oli henkeäsalpaava. Korkealla vuoristossa, ympärillä oli jyrkkiä kallioita, joita peittivät kauniit kukkakentät. Vaikka ryhmä oli väsynyt pitkän vaelluksen jälkeen, heidän innostuksensa oli korkealla, sillä he tiesivät, että yötaivas olisi uskomaton.Kun aurinko laskeutui, Kuopion Kulkijat alkoivat pystyttää telttojaan. Heidän leirinsä sijaitsi pienellä kumpareella, josta oli upeat näkymät vuorille ja laaksoon. Ryhmä päätti sytyttää nuotion ja grillata makkarat. Ilmassa oli tunnelmaa ja yhteishenkeä, joka syntyi vaelluksen yhteisestä kokemuksessta.Kun yö saapui, taivas oli täynnä tähtiä, ja Kuopion Kulkijat makasivat telttansa sisällä ja ihailivat tätä näkymää. He olivat kaukana kaupungin valoista, joten heidän ympärillään oli täydellinen pimeys, joka vain korosti tähtitaivasta. He kuuntelivat vuoriston hiljaisuutta, joka vain satunnaisesti rikkoutui lähellä olevan joen pauhulla.Ryhmä nautti täysin siemauksin telttaretkensä yötaivaasta ja he huomasivat, että tämä oli heille ainutlaatuinen kokemus. He nauttivat yhdessäolosta ja ympäröivän luonnon kauneudesta, ja tämä retki oli tullut heille ikimuistoiseksi kokemukseksi.Seuraavana aamuna, he heräsivät auringon ensimmäisiin säteisiin ja nauttivat aamiaistaan ennen telttojen purkua. Vaikka heidän telttaretkensä oli päättymässä, he tunsivat yhteenkuuluvuutta ja tyytyväisyyttä, joka oli syntynyt yhteisestä kokemuksesta. Ja he tiesivät, että he voisivat aina palata tälle vuoristolle, joka oli tarjonnut heille niin paljon.",
            //        IdTravelDestination = 1,
            //        IdTrip = 1,
            //        IdRenter = 3
            //    },
            //    new Story
            //    {
            //        IdStory = 2,
            //        Date = DateTime.Today,
            //        StoryText = "Kuopion kulkijat niminen ryhmä oli suunnitellut pitkän viikonlopun vaellusretken Puijon metsiin. Ryhmä koostui seitsemästä retkeilijästä, jotka kaikki olivat kokeneita vaeltajia. Heidän tavoitteenaan oli nauttia luonnosta, telttailla metsässä ja nauttia hyvästä ruoasta yhdessä. Matka alkoi perjantai-iltana, kun ryhmä kokoontui Kuopion rautatieasemalle. He ottivat junan Puijon suuntaan ja saapuivat perille noin tunnin kuluttua. Heidän ensimmäinen pysäkkinsä oli Puijon torni, jossa he nauttivat upeista näkymistä kaupunkiin ja ympäröivään luontoon. Sen jälkeen he aloittivat vaelluksensa kohti metsää, jossa he aikovat telttailla. Matka oli noin neljä kilometriä, mutta vaellus oli haastava, sillä heidän täytyi kiivetä jyrkkiä mäkiä ylös ja alas. Kuitenkin he pääsivät perille noin tunnin kuluttua. Ryhmä pystytti telttansa kauniille paikalle metsän keskelle ja aloitti ruoanlaiton. He olivat suunnitelleet etukäteen, mitä he aikovat syödä, ja jokainen retkeilijä oli tuonut omat ruokatarvikkeensa. He valmistivat nuotiolla herkullisen aterian ja nauttivat yhdessä hyvästä ruoasta ja tunnelmasta. Seuraavana päivänä ryhmä heräsi varhain ja aloitti päivän vaelluksen. He vaelsivat useita tunteja ja ihailivat upeita maisemia, kunnes he löysivät kauniin pienen järven. He uivat ja rentoutuivat järven rannalla ennen kuin jatkoivat matkaa. Illalla he palasivat teltalle ja aloittivat taas ruoanlaiton. He nauttivat hyvästä ruoasta, nauttivat yhdessä olosta ja kuuntelivat metsän ääniä. He viettivät yön teltassa kuunnellen sateen ropinaa ja tuulen huminaa metsän läpi.Kolmantena päivänä ryhmä aloitti paluumatkan kohti kaupunkia. He kävelivät rauhallisesti nauttien vielä viimeisistä hetkistään metsässä. Saapuessaan kaupunkiin, he tunsivat väsymyksen mutta myös tyytyväisyyden siitä, että olivat selviytyneet vaelluksesta.",
            //        IdTravelDestination = 1,
            //        IdTrip = 2,
            //        IdRenter = 2
            //    },
            //    new Story
            //    {
            //        IdStory = 3,
            //        Date = DateTime.Today,
            //        StoryText = "Kuopion kulkijat niminen retkiryhmä oli suunnitellut viikon mittaisen veneilyn Kallavedelle. Ryhmä oli innoissaan matkasta, joka sisälsi kalastusta, telttailua ja upeita maisemia.Retki sujui suunnitelmien mukaan, ja retkeilijät nauttivat upeista näkymistä ja kalastuksesta. He löysivät upean rauhallisen lahden, johon he päättivät telttailla. He asettivat telttansa kauniille hiekkarannalle ja aloittivat ruoanlaiton. He valmistivat nuotiolla herkullisen aterian ja nauttivat yhdessä hyvästä ruoasta ja tunnelmasta. He katselivat auringonlaskua rannalla ja ihailivat kaunista näkymää. Seuraavana päivänä he lähtivät veneellä tutkimaan aluetta. He löysivät upeita hiekkarantoja, salmia ja saaria. He päättivät pysähtyä eräälle saarelle lounaalle. He valmistivat nuotiolla herkullisen aterian ja nauttivat yhdessä hyvästä ruoasta. Kun he olivat valmiita jatkamaan matkaansa, vene ei käynnistynyt. He yrittivät kaikkea mahdollista, mutta mikään ei auttanut. He olivat huolissaan ja pettyneitä, sillä heidän olisi pitänyt olla jo seuraavalla telttapaikalla. Mutta yhtäkkiä eräs ryhmän jäsenistä huomasi lähellä olevan mökin. He lähtivät kävelemään sinne ja kysyivät avukseen. Mökin asukas oli ystävällinen ja auttoi heidät korjaamaan veneen moottorin. Ryhmä oli kiitollinen saamastaan avusta. He jatkoivat matkaansa ja saapuivat onnistuneesti seuraavalle telttapaikalle. He nauttivat lopun matkasta upeista maisemista ja yhdessäolosta. Matka päättyi onnellisesti, ja ryhmä oli onnellinen siitä, että he selvisivät kaikista haasteista. He päättivät, että seuraavalla retkellä he tarkistaisivat veneen moottorin huolellisesti ennen lähtöä.",
            //        IdTravelDestination = 1,
            //        IdTrip = 3,
            //        IdRenter = 3
            //    },
            //    new Story
            //    {
            //        IdStory = 4,
            //        Date = DateTime.Today,
            //        StoryText = "Kuopion kulkijat, neljän hengen ystäväporukka, olivat jo pitkään haaveilleet lomasta Turun saaristossa. He päättivät vihdoin toteuttaa unelmansa ja aloittivat matkan huolellisella suunnittelulla.\r\n\r\nMatka alkoi aikaisin aamulla Kuopiosta, josta he hyppäsivät bussiin kohti Helsinkiä. Bussimatka sujui mukavasti maisemia ihaillen ja matkapahoinvointia vältellen. Helsinkiin saavuttuaan he lähtivät tutustumaan kaupunkiin, jonne heillä oli muutama tunti aikaa ennen laivan lähtöä kohti Turun saaristoa.\r\n\r\nKuopion kulkijat kävelivät kaupungilla, shoppailivat ja nauttivat kauniista kesäsäästä. He kävivät myös lounaalla ravintolassa ja maistelivat paikallisia herkkuja. Aikaa kului nopeasti ja pian he olivatkin jo satamassa valmiina laivaan nousuun.\r\n\r\nLaiva oli suuri ja moderni, ja Kuopion kulkijat löysivät helposti paikkansa laivan kannella. He ihastelivat merimaisemia, kun laiva suuntasi kohti Saaristomerta. Laivan ravintolassa he nauttivat runsaan aamiaisen, joka antoi hyvän pohjan päivän seikkailuille.\r\n\r\nPerillä heitä odotti vuokrattu mökki, joka sijaitsi upealla paikalla meren rannalla. Mökki oli tilava ja kodikas, ja sieltä avautui upea näkymä merelle. Kuopion kulkijat ihastuivat heti mökin rauhalliseen ja kauniiseen ympäristöön, ja he tiesivät, että heidän lomastaan tulisi unohtumaton.\r\n\r\nHe käyttivät lomansa tutustuen saaristoon, meloen kajakeilla, kävellen luontopoluilla ja veneilemällä merellä. He vierailivat monissa saariston kiehtovissa pikkukylissä, joissa he tapasivat paikallisia asukkaita ja söivät herkullista paikallista ruokaa ravintoloissa.\r\n\r\nYhtenä päivänä Kuopion kulkijat päättivät lähteä veneretkelle merelle. He vuokrasivat pienen purjeveneen ja lähtivät tutkimaan saaristoa omatoimisesti. Veneily oli hauskaa, mutta samalla hieman jännittävää, sillä he olivat ensikertalaisia veneilijöitä. He onnistuivat kuitenkin ohjaamaan venettä varovasti ja nauttivat upeasta merimaisem",
            //        IdTravelDestination = 1,
            //        IdTrip = 4,
            //        IdRenter = 4
            //    },
            //    new Story
            //    {
            //        IdStory = 5,
            //        Date = DateTime.Today,
            //        StoryText = "Kuopion kulkijat ovat ryhmä innokkaita retkeilijöitä, jotka rakastivat seikkailuja ja uusien paikkojen löytämistä. Heidän joukossaan oli niin nuoria kuin vanhempiakin seikkailijoita, jotka yhdisti intohimo luontoon ja liikuntaan.\r\n\r\nTällä kertaa Kuopion kulkijat olivat päättäneet lähteä Muumimaailmaan, joka oli monelle heistä tuttu lapsuudestaan. He suunnittelivat reissua yhdessä ja jakoivat tehtäviä matkan toteuttamiseksi. Jokainen heistä oli innokas ja valmis tekemään oman osansa, jotta matka Muumimaailmaan toteutuisi sujuvasti ja onnistuneesti.\r\n\r\nHe suuntasivat matkaan aikaisin aamulla junalla kohti Turun satamaa, josta Muumimaailman laivat lähtivät. Junamatka oli mukava, ja Kuopion kulkijat keskustelivat vilkkaasti matkan tarkoituksesta ja tulevista seikkailuista.\r\n\r\nPerillä Muumimaailmassa heidän silmänsä loistivat innostuksesta. He päättivät aloittaa seikkailunsa Muumipeikon kodista, joka oli rakennettu täydelliseen Muumi-tyyliin. He tapasivat Muumipeikon ja hänen ystävänsä, seikkailivat Muumitalossa, kulkivat Nipsun polkua ja tutustuivat Pikku Myyn kotiin. He söivät Muumimamman valmistamaa herkullista ruokaa ja nauttivat makeisia Muumi-kaupassa.\r\n\r\nHe viettivät koko päivän Muumimaailmassa, ja jokainen hetki oli täynnä iloa ja seikkailua. He yhdessä kokivat unohtumattomia hetkiä, kuten Muumipeikon yllättävän esiintymisen ja Pikku Myyn hullunkurisen temppuilun. Päivä Muumimaailmassa oli ollut kaikille mahtava kokemus.\r\n\r\nPaluumatka oli haikea, mutta samalla täynnä innostusta ja uusia suunnitelmia. Kuopion kulkijat olivat kiitollisia ystävyydestään ja siitä, että heillä oli toisensa ja mahdollisuus kokea uusia seikkailuja yhdessä.",
            //        IdTravelDestination = 1,
            //        IdTrip = 5,
            //        IdRenter = 5
            //    },
            //     new Story
            //     {
            //         IdStory = 6,
            //         Date = DateTime.Today,
            //         StoryText = "Kuopion kulkijat olivat jo pitkään haaveilleet vaellusmatkasta Pohjois-Suomen upeissa maisemissa. He olivat kartoittaneet reitin tarkkaan ja suunnitelleet matkaa jo kuukausia etukäteen. He olivat hankkineet tarvittavat varusteet ja varautuneet kaikkiin mahdollisiin haasteisiin.\r\n\r\nMatka alkoi aikaisin aamulla Kuopion rautatieasemalta, josta he hyppäsivät junaan kohti pohjoista. Junamatka kesti useita tunteja, mutta Kuopion kulkijat eivät tylsistyneet, sillä maisemat vaihtuivat kauniiksi ja erilaisiksi sitä mukaan kun juna eteni kohti pohjoista.\r\n\r\nPerillä Rovaniemellä he aloittivat vaelluksensa kohti Korvatunturin upeita maisemia. Heidän reittinsä kulki läpi upeiden tunturimaisemien ja erämaiden, joiden kauneus vei heidät hetkeksi aivan toiseen maailmaan. He pysähtyivät välillä lepäämään, nauttimaan eväitä ja ihailemaan maisemia.\r\n\r\nHeidän matkansa jatkui aina Inarijärvelle saakka, jossa he yöpyivät kauniissa mökissä järven rannalla. Seuraavana päivänä he jatkoivat matkaansa kohti Saariselkää, jossa heidän oli tarkoitus yöpyä useamman päivän. Saariselkä oli upea paikka, joka tarjosi monenlaisia aktiviteetteja, kuten hiihtoa, moottorikelkkasafareita ja poronkäristysillallisia.\r\n\r\nKuopion kulkijat nauttivat jokaisesta hetkestä, jonka he viettivät tunturimaisemissa. Heidän matkansa oli täynnä seikkailuja ja yllätyksiä, kuten yllättäviä lumipyryjä ja jylhiä rotkoja, joiden yli heidän täytyi kiivetä.\r\n\r\nLopulta oli aika lähteä paluumatkalle. Heidän paluumatkansa kulki samalla reitillä, mutta he pysähtyivät matkan varrella vielä muutamassa uudessa paikassa, jotka he olivat jättäneet näkemättä matkan aikana.\r\n\r\nKun he palasivat Kuopioon, he olivat uupuneita, mutta samalla täynnä uusia kokemuksia ja unohtumattomia muistoja. He olivat onnistuneet toteuttamaan haaveensa vaellusmatkasta ja he tunsivat olevansa entistä vahvempia ihmisinä.",
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
           //        DestinationInfo = "Puijon torni on Kuopion Puijolla sijaitseva 75 metriä korkea linkki- ja näkötorni.\r\n\r\nPuijon mäen korkeus on noin 150 metriä Kallaveden pinnasta mitattuna. Tornin on suunnitellut arkkitehti Seppo Ruotsalainen. Torni avattiin yleisölle ensimmäistä kertaa 27. heinäkuuta 1963.\r\n\r\nTornista käytetään myös nimityksiä Suurtorni, Linkkitorni ja \"Pottunuija\". Tornin valmistumisen jälkeen sitä on saneerattu useita kertoja. Viimeisin saneeraus päättyi vuonna 2019.\r\n\r\nTornia käytetään matkailun ohella myös langattoman tietoliikenteen linkkiasemana ja puhelinpalvelujen tukiasemana. Aloite nykyisen tornin rakentamisesta tuli Posti- ja lennätinhallituksen taholta. Puhelinliikenteen automatisointi vaati linkkitornin rakentamista Kuopioon puhelinyhteyksien parantamiseksi.",
           //        Picture = File.ReadAllBytes("images/travel_destination_images/travel_destination1_image1.png")
           //    },
           //     new TravelDestination
           //     {
           //         IdTravelDestination = 2,
           //         DestinationName = "Iidesjärven lintutorni",
           //         Country = "Suomi",
           //         City = "Tampere",
           //         DestinationInfo = "Iidesjärvi on lintujärvi Tampereen kaupungin sydämessä. Lintujen tarkkailua varten on järven itäpäässä lintutorni, joka on vastikään kunnostettu. Paras aika lintujen tarkkailuun on kevät. Järvellä ja sen ruovikossa pesii edelleen monipuolinen linnusto mm. naurulokkiyhdyskunta, silkkiuikku, telkkä, nokikana, liejukana, satakieli sekä ruoko- ja rytikerttunen.\r\n\r\nIidesjärven luontopolku alkaa lintutornilta ja on pituudeltaan noin 7 km. Lintujen lisäksi reitiltä löytyy niittyä, luhtaniittyä ja rantapensaikkoa niiden monpuolisine kasvillisuuksineen.",
           //         Picture = File.ReadAllBytes("images/travel_destination_images/travel_destination2_image1.png")
           //     },
           //      new TravelDestination
           //      {
           //          IdTravelDestination = 3,
           //          DestinationName = "Abiskon kansallispuisto",
           //          Country = "Ruotsi",
           //          City = "Kiiruna",
           //          DestinationInfo = "Abiskon kansallispuisto on kansallispuisto Kiirunan kunnassa Norrbottenin läänissä Pohjois-Ruotsissa lähellä Norjan rajaa. Se on perustettu vuonna 1909 ja on pinta-alaltaan 77 neliökilometrin laajuinen. Kansallispuisto rajoittuu Torniojärveen ja ulottuu siitä noin viidentoista kilometrin päähän lounaaseen. Se sijaitsee noin 200 kilometriä napapiirin pohjoispuolella.\r\n\r\nAbiskon kansallispuiston tavoitteina on säilyttää pohjoinen tunturimaisema luonnontilaisena ja samalla mahdollistaa tieteellinen tutkimus. Kansallispuisto on suosittu matkailukohde.\r\n\r\nKansallispuiston luontopolku Kungsleden seurailee vuorijonoa ja alkaa pienestä Abiskon kylästä. Myös Kalottireitti kulkee kansallispuiston lävitse.\r\n\r\nAlueella on useita majoittumismahdollisuuksia sekä itse alueella että Abiskon kylässä. Abisko Turiststation -nimisen rautatieseisakkeen lähellä on kansallispuiston kävijöiden suosima majatalo.",
           //          Picture = File.ReadAllBytes("images/travel_destination_images/travel_destination3_image1.png")
           //      },
           //      new TravelDestination
           //      {
           //          IdTravelDestination = 4,
           //          DestinationName = "Helvetin kolu",
           //          Country = "Suomi",
           //          City = "Ruovesi",
           //          DestinationInfo = "Helvetinkolu on kalliomuodostuma Helvetinjärven kansallispuistossa Ruovedellä. Helvetinkolu on 40 metriä pitkä, 38 metriä syvä ja vain pari metriä leveä sola, joka laskee jyrkästi Ison Helvetinjärven rantaan.\r\n\r\nHelvetinkolu on myös Helvetinjärven kansallispuiston tunnus. Helvetinkolu muodostui noin 150–200 miljoonaa vuotta sitten, kun maankuori liikahteli. Samaan aikaan syntyi myös noin 20 kilometriä pitkä Isosta Helvetinjärvestä Luomajärven kautta Koverojärveen päättyvä rotkojärvien jono. Helvetinkolu tuli tunnetuksi nähtävyydeksi jo 1800-luvulla. Siellä on vierailleet monet kuuluisat taiteilijat ja kirjailijat, kuten Akseli Gallen-Kallela ja J. L. Runeberg. Helvetinkolun alue suojeltiin 1950-luvulla. Sitä on käytetty myös susiansana. Helvetinkolusta sai visuaalisia vaikutteita ja nimensä Suomen paviljonki Sevillan maailmannäyttelyssä vuonna 1992. Rakennuksen suunnittelivat Juha Jääskeläinen, Juha Kaakko, Petri Rouhiainen, Matti Sanaksenaho ja Jari Tirkkonen.",
           //          Picture = File.ReadAllBytes("images/travel_destination_images/travel_destination4_image1.png")
           //      },
           //       new TravelDestination
           //       {
           //           IdTravelDestination = 5,
           //           DestinationName = "Jotunheimenin kansallispuisto",
           //           Country = "Norja",
           //           City = "Oppland",
           //           DestinationInfo = "Jotunheimenin kansallispuisto on kansallispuisto Opplandin ja Sognin ja Fjordanen läänien alueella Norjassa. Kansallispuisto sijaitsee Jotunheimenin vuoristoalueella Etelä-Norjassa. Kansallispuisto perustettiin vuonna 1980 ja sen pinta-ala on 1 151 neliökilometriä.\r\n\r\nKansallispuiston alueella sijaitsevat muun muassa kaksi Norjan korkeinta vuorta: Galdhøpiggen yltää 2 469 metrin korkeuteen merenpinnasta, lumihuppuinen Glittertinden on muutaman metrin matalampi. Alueen terävimmät vuorenhuiput sijaitsevat Hurrunganevuoristossa, jossa sijaitsee maan kolmanneksi korkein vuori, Store Skagastølstind, 2 403 metriä merenpinnasta. Laajin jäätikkö on Smørstabbreen, joka peittää noin 15 neliökilometrin laajuisen alueen.",
           //           Picture = File.ReadAllBytes("images/travel_destination_images/travel_destination5_image1.png")
           //       },

           //        new TravelDestination
           //        {
           //            IdTravelDestination = 6,
           //            DestinationName = "Hyvinkää",
           //            Country = "Suomi",
           //            City = "Hyvinkää",
           //            DestinationInfo = "Helsingistä 60km pohjoiseen sijaitsee entinen kauppala, nykyinen Kaupunki. Kaupunkin merkittävimmät rakennukset on ovat Villatehdas, kenkätehdas, KONE-tehdasalue ja VR-konepaja. Hyvinkäällä sijaitsese Sveitsin lenkkeilymaastot",
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
