using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab11_structAndCollection_
{
    public delegate bool del (Zodiak zk);

    public enum Zodiak {
        Aries,       //Овен
        Taurus,      //Телец
        Gemini,      //Близнецы
        Cancer,      //Рак
        Leo,         //Лев
        Virgo,       //Дева
        Libra,       //Весы
        Scorpio,     //Скорпион
        Sagittarius, //Стрелец
        Capicorn,    //Козерог
        Aquarius,    //Водолей 
        Pisces       //Рыба
        
    } //Zodiak
    struct ZNAK : IComparable
    {
        string Name;
        string Surname;
        Zodiak zodiak;
        int[]  Birthday;

        public ZNAK(string Name, string Surname, Zodiak zk, int[] Birthday = null)
        {
            this.Name     = Name;
            this.Surname  = Surname;
            this.zodiak   = zk;
            this.Birthday = Birthday;
        }
        public void PrintInfo() {
            Console.WriteLine("Имя:           " + (Name ?? "Нет данных"));
            Console.WriteLine("Фамилия:       " + (Surname ?? "Нет данных"));
            Console.WriteLine("Знак зодиака:  " + (Enum.GetName(typeof(Zodiak), zodiak) ?? "Нет данных"));
            Console.WriteLine("Дата рождения: " + Birthday[0] + "." + Birthday[1] + "." + Birthday[2]);
        }

        public Zodiak Zod {
            get { return this.zodiak; }
        } 
        public int CompareTo(object obj)
        {
            ZNAK temp = (ZNAK) obj;
            if (this.zodiak > temp.zodiak) return 1;
            if (this.zodiak < temp.zodiak) return -1;
            return 0;
        }

        public static bool operator >(ZNAK zk1, ZNAK zk2)
        {
            return zk1.Zod > zk2.Zod;
        }

        public static bool operator <(ZNAK zk1, ZNAK zk2)
        {
            return zk1.Zod < zk2.Zod;
        }
    } // ZNAK
    class Program
    {
        public static ZNAK InputPeople()
        {

            string name;
            string surname;
            string[] data;
            int[]    digitalNum = new int[3] { 0,0,0};
            Zodiak zk;
           
            Console.Write("Введите Имя:          ");
            name = Console.ReadLine();

            Console.Write("Введите Фамилию:      ");
            surname = Console.ReadLine();

            Console.Write("Введите знак зодиака: ");

            zk = (Zodiak)Enum.Parse(enumType: typeof(Zodiak), value: Console.ReadLine(), ignoreCase: true);

            Console.WriteLine("Введите дату рождения (xx.xx.xxxx):");
            data = Console.ReadLine().Split('.');

            for (int i = 0; i < data.Length; i++)
            {
                digitalNum[i] = Int32.Parse(data[i]);
            }

            return new ZNAK(name, surname, zk, digitalNum);
        }

        public static void PrintPeopleWithZnak(in List<ZNAK> ZnakList, del isZodiak) {

            foreach (ZNAK item in ZnakList) 
            {
                if (isZodiak(item.Zod)) {
                    item.PrintInfo();
                }
            }
	 
        }
        static void Main(string[] args)
        {
            List<ZNAK> people = new List<ZNAK>();

            people.Add(InputPeople());
            people.Add(InputPeople());
            people.Add(InputPeople());
            people.Add(InputPeople());
            people.Add(InputPeople());

            PrintPeopleWithZnak(people, zk => zk == Zodiak.Virgo);
        } // main
    } // Programm
}
