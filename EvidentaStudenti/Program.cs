using LibrarieEntitati;
using System;


namespace ManagementStudenti
{
    class Program
    {
        static void Main(string[] args)
        {

            Student s = new Student("Ionescu");
            Menu(s, args);
        }

        static void Menu(Student s, string[] args)
        {
            string menu = "S: Citire note de la tastura ca un sir de caractere\n";
            menu += "T: Citire note de la tastatura (cate o nota pe rand)\n";
            menu += "C: Citire note din linia de comanda\n";
            menu += "A: Afisare note\n";
            menu += "I: Info autor\n";
            menu += "F: Citire format fisier(id, Prenuma, Nume, Note)\n";
            menu += "X: Iesire\n";
            do
            {
                Console.WriteLine(menu);
                string optiune = Console.ReadLine();
                optiune = optiune.ToUpper();
                switch (optiune)
                {
                    case "S":
                        var note_citite = Console.ReadLine();
                        s.SetNote(note_citite);
                        Console.ReadKey();
                        break;
                    case "A":
                        Console.WriteLine(s.ConversieLaSir());
                        s.NumarareNote(1, out int valSub5,out int valPeste5);
                        Console.WriteLine("\nNumarul notelor sub 5 este: " + valSub5);
                        Console.WriteLine("\nNumarul notelor peste 5 este: " + valPeste5);
                        Console.ReadKey();
                        break;
                    case "T":
                        int n, nota;
                        int[] note;
                        string str_n;
                        do
                        {
                            Console.WriteLine("Introdu numarul de note: ");
                            str_n = Console.ReadLine();
                        }while(!System.Int32.TryParse(str_n, out n));
                        note = new int[n];
                        int j = 0;
                        for(int i=0; i<n; i++)
                        {
                            bool Rez = System.Int32.TryParse(Console.ReadLine(), out nota); 
                            if(Rez)
                            {
                                note[j] = nota;
                                j++;
                            }
                        }
                        s.SetNote(2, note);
                        Console.ReadKey();
                        break;
                    case "C":
                        s.SetNote(String.Join(" ", args));
                        Console.ReadKey();
                        break;
                    case "I":
                        Console.WriteLine("Andronic Tudor\nGrupa 3121 A");
                        Console.ReadKey();
                        break;
                    case "F":
                        
                        string date_fisier;
                        string[] date;
                        do
                        {
                            date_fisier = Console.ReadLine();
                            date = date_fisier.Split(',');
                            if (date.Length != 4)
                                Console.WriteLine("Date introduse nu sunt valide\n");
                        } while (date.Length != 4);
                        Student s_fisier = new Student(System.Convert.ToInt32(date[0]), date[1], date[2], date[3]);
                        Console.WriteLine(s_fisier.ConversieLaSir());
                        Console.ReadKey();
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiunea aleasa nu este valida");
                        return;
                }
                Console.Clear();
            } while (true);

        }
    }
}
