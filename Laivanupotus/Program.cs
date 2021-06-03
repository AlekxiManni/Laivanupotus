using System;
namespace Laivanupotus
{
    class Program
    {
        static void Main(string[] args)
        {
            bool taistelu = true;
            string[,] koordinaatit = new string[5, 5];
            string[,] vihollisenKoordinaatit = new string[5, 5];
            koordinaatit = LaivanKoordinaatit();
            vihollisenKoordinaatit = VihollisenLaiva();
            while (taistelu)
            {
                PiirraVihollinen(vihollisenKoordinaatit);
                PiirraOmaLaiva(koordinaatit);
                // alla oleva oli alunperin näin: bool taistelu = Tulitus(vihollisenKoordinaatit) == VihollisenTulitus(koordinaatit). Korjattu alla olevalla tavalla.
                taistelu = Tulitus(vihollisenKoordinaatit);
                if (taistelu)
                {
                    taistelu = VihollisenTulitus(koordinaatit);
                }
            }
        }
        /// <summary>
        /// Viholliselle annetaan parametrina pelaajan laivan koordinaatit. Random vihollien arpoo tulituksen paikan mihin tietokone "ampuu"
        /// </summary>
        /// <param name="koordinaatit"></param>
        /// <returns></returns>
        static bool VihollisenTulitus(string[,] koordinaatit)
        {
            bool ammuUudestaan;
            bool taisteluJatkuu = true;
            Random vihollinen = new Random();
            do
            {
                int tulituksenKorkeus = vihollinen.Next(0, 5);
                int tulituksenLeveys = vihollinen.Next(0, 5);
                
                Console.WriteLine();
                Console.WriteLine("Vihollinen tulittaa!");
                if (koordinaatit[tulituksenKorkeus, tulituksenLeveys] == "X")
                {
                    Console.WriteLine("Vihollinen ampui jo ampumaansa kohtaan ja ampuu uudelleen");
                    ammuUudestaan = true;
                }
                else if (koordinaatit[tulituksenKorkeus, tulituksenLeveys] == "S")
                {
                    ammuUudestaan = false;
                    
                    Console.WriteLine("Sait osuman ja laivasi on upotettu! Hävisit pelin");
                    taisteluJatkuu = false;
                }
                else
                {
                    ammuUudestaan = false;
                    Console.WriteLine("Vihollinen ampui ohi!");
                    Console.WriteLine();
                    koordinaatit[tulituksenKorkeus, tulituksenLeveys] = "X";
                    taisteluJatkuu = true;
                }
            } while (ammuUudestaan);
            
            return taisteluJatkuu;
        }
        /// <summary>
        /// Tuodaan vihollisen koordinaatit parametrina ohjelmaan. Ohjelma piirtää ruudukon minkä mukaan aletaan tulittamaan kohti vastustajan laivaa. Jos viholliseen osuu, pelaaja voittaa.
        /// </summary>
        /// <param name="vihollisenKoordinaatit"></param>
        static bool Tulitus(string[,] vihollisenKoordinaatit)
        {
            bool kysyUudelleen;
            bool taisteluJatkuu;
            int tykinLeveys;
            int tykinKorkeus;
            Console.WriteLine("Valitse koordinaatit väliltä 0-4. Jos valitset yli 4, asetetaan koordinaatti automaattisesti kohtaan 4. Anna vain numeroita");
            Console.WriteLine("Valitse tähtäimen leveys: ");
            kysyUudelleen = int.TryParse(Console.ReadLine(), out tykinLeveys);
            while (!kysyUudelleen)
            {
                if (kysyUudelleen)
                {
                    if (tykinLeveys > 4)
                    {
                        tykinLeveys = 4;
                    }
                }
                else
                {
                    Console.WriteLine("Anna numero!");
                    kysyUudelleen = int.TryParse(Console.ReadLine(), out tykinLeveys);
                }
            }
            
            Console.WriteLine("Valitse tähtäimen korkeus:  ");
            kysyUudelleen = int.TryParse(Console.ReadLine(), out tykinKorkeus);
            while (!kysyUudelleen)
            {
                if (kysyUudelleen)
                {
                    if (tykinKorkeus > 4)
                    {
                        tykinKorkeus = 4;
                    }
                }
                else
                {
                    Console.WriteLine("Anna numero!");
                    kysyUudelleen = int.TryParse(Console.ReadLine(), out tykinKorkeus);
                }
               
            }
            if (tykinKorkeus > 4)
            {
                tykinKorkeus = 4;
            }
            Console.Clear();
            Console.WriteLine("T U L T A !!!");
            Console.WriteLine();
            if (vihollisenKoordinaatit[tykinKorkeus, tykinLeveys] == "S")
            {
                Console.WriteLine("Osuma! Vihollisen laiva upotettu");
                vihollisenKoordinaatit[tykinKorkeus, tykinLeveys] = "U";
                taisteluJatkuu = false;
            }
            else
            {
                Console.WriteLine("Ammuit ohi!");
                Console.WriteLine();
                vihollisenKoordinaatit[tykinKorkeus, tykinLeveys] = "X";
                taisteluJatkuu = true;
            }
            return taisteluJatkuu;
        }
        /// <summary>
        /// Toimii samalla periaatteella mitä pelaajan koordinaattien valitseminen, mutta Random vihollinen arpoo paikan.
        /// </summary>
        /// <returns></returns>
        static string[,] VihollisenLaiva()
        {
            Random vihollinen = new Random();
            int vihollisenLeveys = vihollinen.Next(0, 5);
            int vihollisenKorkeus = vihollinen.Next(0, 5);
            string[,] koordinaatit = new string[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    koordinaatit[i, j] = "~";
                }
            }
            int laivanleveys = vihollisenLeveys;
            int laivankorkeus = vihollisenKorkeus;
            switch (laivankorkeus)
            {
                case 0:
                    koordinaatit[laivanleveys, laivankorkeus] = "S";
                    break;

                case 1:
                    koordinaatit[laivanleveys, laivankorkeus] = "S";
                    break;

                case 2:
                    koordinaatit[laivanleveys, laivankorkeus] = "S";
                    break;

                case 3:
                    koordinaatit[laivanleveys, laivankorkeus] = "S";
                    break;

                case 4:
                    koordinaatit[laivanleveys, laivankorkeus] = "S";
                    break;

               
            }
            return koordinaatit;
        }
        private static void PiirraOmaLaiva(string[,] vihollisenKoordinaatit)
        {
            Console.WriteLine("Oma laiva");
            Console.WriteLine("--01234");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i + "|");
                for (int j = 0; j < 5; j++)
                {
                    if (vihollisenKoordinaatit[j, i] == "S")
                    {
                        Console.Write("S");
                    }
                    else
                        Console.Write(vihollisenKoordinaatit[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        private static void PiirraVihollinen(string[,] koordinaatit)
        {
            Console.WriteLine();
            Console.WriteLine("Vihollisen laiva");
            Console.WriteLine("--01234");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i+"|");
                for (int j = 0; j < 5; j++)
                {
                    if (koordinaatit[j, i] == "S")
                    {
                        Console.Write("~");
                    }
                    else
                        Console.Write(koordinaatit[j, i]);
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Valitaan oman laivan paikka. Koordinaatit ovat kaksiulotteisessa string taulukossa. laivan leveys valitaan int muuttujalla laivanleveys, mikä valitsee taulukon pelilaudan vaakasuunnassa.
        /// Laivan korkeus valitaan switch casella, mikä valitsee paikkansa syötteen mukaan 2 ulotteisen taulukon toiselta paikalta.
        /// </summary>
        /// <returns></returns>
        static string[,] LaivanKoordinaatit()
        {
            bool kysyUudelleen;
            int laivanLeveys;
            int laivanKorkeus;
            //Selkeyden vuoksi ohjelmoinnin ja testauksen aikana koordinaatit olivat muodossa  string[,] koordinaatit = { { "0", "1", "2", "3", "4" }, { "0","1"...jne
            string[,] koordinaatit = new string[5, 5];//= { { "0", "1", "2", "3", "4" }, { "0", "1", "2", "3", "4" }, { "0", "1", "2", "3", "4" }, { "0", "1", "2", "3", "4" }, { "0", "1", "2", "3", "4" } };
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    koordinaatit[i, j] = "~";
                }
            }
            Console.WriteLine("Pelilauta:");
            Console.WriteLine("--01234");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i + "|");
                for (int j = 0; j < 5; j++)
                    Console.Write(koordinaatit[j, i]);
                Console.WriteLine();
            }
            Console.WriteLine("Anna laivan leveys väliltä 0-4. Yli 4 menevä on automaattisesti kohdassa 4: ");

            kysyUudelleen = int.TryParse(Console.ReadLine(), out laivanLeveys);
            while (!kysyUudelleen)
            {
                if (kysyUudelleen)
                {
                    if (laivanLeveys > 4)
                    {
                        laivanLeveys = 4;
                    }
                }
                else
                {
                    Console.WriteLine("Anna numero!");
                    kysyUudelleen = int.TryParse(Console.ReadLine(), out laivanLeveys);
                }
            }


            Console.WriteLine("Anna laivan korkeus");
            kysyUudelleen = int.TryParse(Console.ReadLine(), out laivanKorkeus);
            while (!kysyUudelleen)
            {
                if (kysyUudelleen)
                {
                    if (laivanKorkeus > 4)
                    {
                        laivanKorkeus = 4;
                    }
                }
                else
                {
                    Console.WriteLine("Anna numero!");
                    kysyUudelleen = int.TryParse(Console.ReadLine(), out laivanKorkeus);
                }
            }


            //Tässä kohtaa oli hankaluuksia, koska tein vastaavan switch casen myös laivan leveyden kanssa eikä se alkuun tahtonut toimia. Otin sen kokonaan pois että sain haluamani lopputuloksen.
            //Myöhemmin lisätty vielä int.TryParse syötteen tarkistuksen vuoksi.
            switch (laivanKorkeus)
            {
                case 0:
                    koordinaatit[laivanLeveys, laivanKorkeus] = "S";
                    break;

                case 1:
                    koordinaatit[laivanLeveys, laivanKorkeus] = "S";
                    break;

                case 2:
                    koordinaatit[laivanLeveys, laivanKorkeus] = "S";
                    break;

                case 3:
                    koordinaatit[laivanLeveys, laivanKorkeus] = "S";
                    break;

                case 4:
                    koordinaatit[laivanLeveys, laivanKorkeus] = "S";
                    break;

                default:
                    Console.WriteLine("Laitoit yli 4, asetetaan korkeus paikalle 4!");
                    koordinaatit[laivanLeveys, 4] = "S";
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Asetettu laivan paikka");
            Console.WriteLine("--01234");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i + "|");
                for (int j = 0; j < 5; j++)
                    Console.Write(koordinaatit[j, i]);
                Console.WriteLine();
            }
            return koordinaatit;
        }
    }
}
