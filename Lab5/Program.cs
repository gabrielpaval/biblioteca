using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect
{
    class Program
    {
        static void Main(string[] args)
        {
            Carte[] carti = new Carte[10];
            Carte c1 = new Carte("Mandrie si Prejudecata", "Jane Austin", "Corint", 2014, 3, 3);
            string s1 = c1.Info();
            carti[0] = c1;
            //Console.WriteLine(s1);

            Carte c2 = new Carte("Marele Gatsby,F. Scott Fitzgerald,HUMANITAS,2018,2,5");
            string s2 = c2.Info();
            carti[1] = c2;


            Carte c3 = new Carte("Fluturi,Irina Binder,HUMANITAS,2018,1,3");
            s2 = c3.Info();
            carti[2] = c3;


            Carte c4 = new Carte("Metode numerice,George Mahalu,HUMANITAS,2018,3,4");
            s2 = c4.Info();
            carti[3] = c4;

            //Console.WriteLine(s2);

            Persoana p1 = new Persoana("Paval", "Gabriel", 22, 0, "0744545", "gabrielpaval@", 2);
            string s3 = p1.InfoPersoana();
            //Console.WriteLine(s3);

            Persoana p2 = new Persoana("Paval, Dan, 22, 4, 092384,danpaval@,2");
            string s4 = p2.InfoPersoana();
            //Console.WriteLine(s4);
            //Compara cine a imprumutat mai multe carti dintre 2 persoane
            string s5 = p1.compara(p2);
            //Console.WriteLine(s5);

            //Compara 2 carti -> va afisa cartea care are mai multe exemplare
            string s6 = c1.ComparaCarte(c2);
            // Console.WriteLine(s6);

            //Alegerea genului de carte dorit:
            Console.WriteLine("Alegeti ce gen de carte doriti: ");
            Console.WriteLine("1. Copii\n" +
                              "2. Drama\n" +
                              "3. Romantism\n" +
                              "4. Specialitate\n" +
                              "5. Fictiune\n");
            int opt = Convert.ToInt32(Console.ReadLine());
            while (opt < 1 && opt > 5)
            { opt = Convert.ToInt32(Console.ReadLine()); }
            bool ok = false;
            for (int i = 0; i < 4; i++)
            {
                if (carti[i].CautareGenCarte(opt) == true)
                {
                    Console.WriteLine(carti[i].Info());
                    ok = true;
                }
            }
            if (ok == false)
                Console.WriteLine("Nu avem nicio carte in acest gen");


            //Cautarea cartii dupa nume si modificarea numarului de exemplare
            Console.WriteLine("Dati numele cartii pe care doriti sa o cautati: ");
            string _nume = Console.ReadLine();
            ok = false;
            for (int i = 0; i < 4; i++)
            {
                if (carti[i].CautareNume(_nume) == true)
                {
                    Console.WriteLine("Numarul de exemplare in prezent este: ");
                    int nr = Convert.ToInt32(Console.ReadLine());
                    carti[i].NrExemplare = nr;
                    s2 = carti[i].Info();
                    Console.WriteLine(s2);
                    ok = true;
                }
            }
            if (ok == false)
                Console.WriteLine("Nu avem cartea pe care ati cautat-o");
            adminCarti.UpdateCarte(carti, 4);

            Console.ReadKey();


        }

        //Functie in care se apeleaza proprietatile auto-implemented
        public static Persoana CitirePersoanaTastatura()
        {
            Console.WriteLine("Numele persoanei: ");
            string nume = Console.ReadLine();
            Console.WriteLine("Prenumele persoanei: ");
            string prenume = Console.ReadLine();
            Console.WriteLine("Varsta persoanei: ");
            int varsta = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Numar carti imprumutate: ");
            int NrCartiImprumutate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Numarul de telefon: ");
            string NrTelefon = Console.ReadLine();
            Console.WriteLine("Adresa de mail: ");
            string AdresaMail = Console.ReadLine();
            Console.WriteLine("Statutul persoanei: ");
            int st = Convert.ToInt32(Console.ReadLine());
            Persoana p = new Persoana(nume, prenume, varsta, NrCartiImprumutate, NrTelefon, AdresaMail, st);
            return p;
        }

        public static Carte CitireCarteTastatura()
        {
            Console.WriteLine("Numele car?ii: ");
            string nume = Console.ReadLine();
            Console.WriteLine("Numele autorului: ");
            string autor = Console.ReadLine();
            Console.WriteLine("Numele editurii: ");
            string editura = Console.ReadLine();
            Console.WriteLine("An apari?ie: ");
            int AnAparitie = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Numar exemplare: ");
            int NrExemplare = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Genul cartii: ");
            int GenCarte = Convert.ToInt32(Console.ReadLine());
            Carte c = new Carte(nume, autor, editura, AnAparitie, NrExemplare, GenCarte);
            return c;
        }
    }
}
