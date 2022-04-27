using System;
    namespace Program
    {
        interface Iaccount
        {
         
            void put(double summa);
          
            void get(double summa);
            void percent();
        }
        interface Ibonus
        {
            
            double bonus();
        }
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
        class Shop_Client : Ibonus
        {
            double summa_shop; 
            double summa_buy; 
            public double Summa_buy
            { 
                get { return summa_buy; }
                set { summa_buy = value; }
            }
            public Shop_Client()
            { 
                summa_shop = 0; summa_buy = 0;
            }



 public double bonus()
            {
                double add_bonus = 0.0;
                if (summa_shop > 40000)
                    add_bonus = summa_buy * 0.05;
                else
                if (summa_shop > 30000)
                    add_bonus = summa_buy * 0.02;
                return (add_bonus);
            }
            public void New_Buy()
            { 
                Console.WriteLine("Введите сумму покупки");
                summa_buy = int.Parse(Console.ReadLine());
                summa_shop += summa_buy;
            }
        }
        class Program
        {
            public static void Main()
            {
                Bank_Client client = new Bank_Client(
                "Ivanov", 1234567, 2000000, 2015, 1, 9);
                client.put(50000); client.get(20000);
                client.Person_Display();
                client.percent();
                // в конце года к вкладу добавляется бонус
                client.put(client.bonus());
                Console.WriteLine
                (" сумма вклада: " + client.Summa_bank);
                //===================================
                Shop_Client client1 = new Shop_Client();
                client1.New_Buy(); // первая покупка
                client1.Summa_buy -= client1.bonus();
                Console.WriteLine
                ("к оплате: " + client1.Summa_buy);
                client1.New_Buy(); // вторая покупка
                client1.Summa_buy -= client1.bonus();
                Console.WriteLine
           

              ("к оплате: " + client1.Summa_buy);
            Console.ReadLine();
            }
        }
    }
