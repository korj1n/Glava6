﻿using System;
    namespace Glava6
    {
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
