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
            //Instantierea unui obiect de tip Carte utilizand constructorul fara parametrii

            var ob1 = new Carte();
            string s1 = ob1.Info();
            Console.WriteLine(s1);

            //Instantierea unui obiect de tip Carte utilizand constructorul cu parametrii

            Carte ob2 = new Carte("Mandrie si Prejudecata", "Jane Austin", "Corint", 2014, 3);
            string s2 = ob2.Info();
            Console.WriteLine(s2);

            //Instantierea unui obiect de tip Persoana utilizand constructorul fara parametrii

            var ob3 = new Persoana();
            string s3 = ob3.InfoPersoana();
            Console.WriteLine(s3);

            //Instantierea unui obiect de tip Carte utilizand constructorul cu parametrii

            Persoana ob4 = new Persoana("Paval", "Gabriel", 22, 0, "0725544", "gabrielpaval@");
            string s4 = ob4.InfoPersoana();
            Console.WriteLine(s4);

            Console.ReadKey();
        }
    }
}
