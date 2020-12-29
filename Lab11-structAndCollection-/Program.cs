using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_structAndCollection_
{
    enum Zodiak {
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
        
    }
    struct ZNAK : IComparable
    {
        string Name;
        string Surname;
        Zodiak zodiak;
        int[]  Birthday;

        ZNAK(string Name, string Surname, Zodiak zk) {
            this.Name     = Name;
            this.Surname  = Surname;
            this.zodiak   = zk;
            this.Birthday = new int[] { 0, 0, 0 };
        }

        public int CompareTo(object obj)
        {
            ZNAK temp = (ZNAK) obj;
            if (this.zodiak > temp.zodiak) return 1;
            if (this.zodiak < temp.zodiak) return -1;
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {


        }
    }
}
