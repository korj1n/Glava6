using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glava6
{
    class Bank_Client : Iaccount, Ibonus
    {
        string name;
        int passport;
        double summa_bank;
        DateTime date;
        public double Summa_bank
        { // свойство
            get { return summa_bank; }
        }

        public Bank_Client(string name,
        int passport, double summa_bank,
        int year, int month, int day)
        {
            this.name = name;
            this.passport = passport;
            this.summa_bank = summa_bank;
            date = new DateTime(year, month, day);
        }

        public void Person_Display()
        {
            Console.WriteLine(" " + name + " " + passport +
            " " + summa_bank + " " + date);
        }

        public void put(double summa)
        {
            summa_bank += summa;
        }

        public void get(double summa)
        {
            if (summa <= summa_bank)
                summa_bank -= summa;
        }



        public void percent()
        {
            DateTime today = DateTime.Today;
            if ((today - date).Days == 365)
                summa_bank *= 1.1;
        }

        public double bonus()
        {
            double add_bonus = 0.0;
            DateTime today = DateTime.Today;
            DateTime endOfYear =
            new DateTime(today.Year, 12, 31);
            if (today == endOfYear)
            {
                int summa_days =
                (endOfYear - date).Days;
                if (summa_bank > 1000000 &&
                summa_days > 180)
                    add_bonus = summa_bank * 0.005;
                Console.WriteLine
                (" Бонус начислен" + add_bonus);
            }
            return (add_bonus);
        }
    }
}
