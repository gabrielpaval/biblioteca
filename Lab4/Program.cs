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
            Carte c1= new Carte("Mandrie si Prejudecata", "Jane Austin", "Corint", 2014, 3);
            string s1 = c1.Info();
            Console.WriteLine(s1);

            Carte c2= new Carte("Marele Gatsby,F. Scott Fitzgerald,HUMANITAS,2018,2");
            string s2 = c2.Info();
            Console.WriteLine(s2);

            Persoana p1 = new Persoana("Paval", "Gabriel", 22, 0, "0725544", "gabrielpaval@");
            string s3 = p1.InfoPersoana();
            Console.WriteLine(s3);

            Persoana p2 = new Persoana("Paval, Dan, 22, 4, 092384,danpaval@");
            string s4 = p2.InfoPersoana();
            Console.WriteLine(s4);
            //Compara cine a imprumutat mai multe carti dintre 2 persoane
            string s5=p1.compara(p2);
            Console.WriteLine(s5);

            //Compara 2 carti -> va afisa cartea care are mai multe exemplare
            string s6 = c1.ComparaCarte(c2);
            Console.WriteLine(s6);

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
            Persoana p = new Persoana(nume, prenume, varsta, NrCartiImprumutate, NrTelefon, AdresaMail);
            return p;
        }

        public static Carte CitireCarteTastatura()
        {
            Console.WriteLine("Numele cărții: ");
            string nume = Console.ReadLine();
            Console.WriteLine("Numele autorului: ");
            string autor = Console.ReadLine();
            Console.WriteLine("Numele editurii: ");
            string editura = Console.ReadLine();
            Console.WriteLine("An apariție: ");
            int AnAparitie = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Numar exemplare: ");
            int NrExemplare = Convert.ToInt32(Console.ReadLine());
            Carte c = new Carte(nume, autor, editura, AnAparitie, NrExemplare);
            return c;
        }
    }
}
