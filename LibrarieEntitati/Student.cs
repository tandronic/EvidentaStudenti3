namespace LibrarieEntitati
{
    public class Student
    {
        // date membre private
        string nume, prenume;
        int[][] note;
        int id;

        // contructor implicit
        public Student()
        {
        }

        // constructor cu parametri
        public Student(string _nume, string _prenume)
        {
            nume = _nume;
            prenume = _prenume;
            note = new int[4][];
        }

        public Student(string date_fisier)
        {
            string[] date;
            date = date_fisier.Split(',');
            id = System.Convert.ToInt32(date[0]);
            prenume = date[1];
            nume = date[2];
            note = new int[4][];
            SetNote(date[3]);
        }

        public void SetNote(string sirNote)
        {
            string[] sir_note_an = sirNote.Split(',');
            string[] sir_note_obiecte;
            for(int i=0; i < sir_note_an.Length; i++)
            {
                sir_note_obiecte = sir_note_an[i].Split(' ');
                int[] note_temp = new int[sir_note_obiecte.Length];
                int k = 0;
                for(int j=0; j< sir_note_obiecte.Length; j++)
                {
                    int nota_int;
                    bool Rez = System.Int32.TryParse(sir_note_obiecte[j], out nota_int);
                    if (Rez == true)
                    { 
                        if (nota_int > 0 && nota_int <= 10)
                        {
                            note_temp[k] = nota_int;
                            k++;
                        }
                    }
                }
                System.Array.Resize(ref note_temp, k);
                note[i] = note_temp;
            }
        }

        public void SetNote(int an, int[] _note)
        {
            note[an-1] = _note;
        }
        public string ConversieLaSir()
        {
            string sNote = "Nu exista (Nu ati apelat metoda **setNote**)";
            string nume_complet = nume;
            if (note != null)
            {
                for(int i=0; i<4;i++)
                {
                    sNote += string.Format("\nAnul {0}: \n", i);
                    foreach(var nota in note[i])
                        sNote += nota + " ";

                }
            }
            if (string.IsNullOrEmpty(prenume) == false)
                nume_complet += " " + prenume;
            string s = string.Format("Studentul {0} are notele:.... {1}", nume_complet, sNote);

            return s;
        }

        public void NumarareNote(int an, out int valSub5,out int valPeste5)
        {
            valSub5 = valPeste5 = 0;
            for(int i=0; i<note[i].Length; i++)
            {
                if (note[an][i] < 5)
                    valSub5++;
                else
                    valPeste5++;
            }
        }
    }
}
