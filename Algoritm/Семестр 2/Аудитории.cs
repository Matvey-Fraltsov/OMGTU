using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApplication22
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Audit> auditList = new List<Audit>();
            Menu menu = new Menu();
            menu.ShowMenu(auditList);
           
        }
    }

    class Menu
    {
        public void ShowMenu(List<Audit> auditList) 
        {
            int number;
            int places;
            bool pc_class;
            bool projector;
            int choice;
            int user_places;
            bool user_projector;
            bool user_pc;
            int user_floor;
            bool flag = true;


            while (flag)
            {
                Console.WriteLine("Меню" + "\n" + "Выберите действие:" +
                    "\n" + "0. Вывести аудитории" +
                    "\n" + "1. Добавить аудиторию" +
                    "\n" + "2. Выборка по кол-ву мест" +
                    "\n" + "3. Выборка по наличию проектора" +
                    "\n" + "4. Выборка по наличию ПК" +
                    "\n" + "5. Выборка по этажу" +
                    "\n" + "6. Выход из меню");

                Console.WriteLine();
                Console.Write("Ваш выбор: ");
                while ((!int.TryParse(Console.ReadLine(), out choice)))
                {
                    Console.WriteLine("Ошибка ввода! Введите правильное число");
                    Console.Write("Ваш выбор: ");
                }
                
                switch(choice)
                {
                    default: 
                        Console.WriteLine("Введите число от 0 до 6" + "\n");
                        break;

                    case 0:
                        if (auditList.Count != 0)
                        {
                            Console.WriteLine("Список аудиторий: ");
                            foreach (Audit audit in auditList)
                            {
                                audit.PrintDetails();
                            }
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Аудиторий пока нет" + "\n");
                        break;

                    case 1:
                        do 
                        {
                            Console.Write("Введите номер аудитории: ");
                            if (int.TryParse(Console.ReadLine(), out number) && number >= 100 && number <= 999) break;
                            else Console.WriteLine("Введите число от 100 до 999");
                        } 
                        while(true);

                        do
                        {
                            Console.Write("Введите кол-во мест: ");
                            if (int.TryParse(Console.ReadLine(), out places) && places > 0 && places <= 300) break;
                            else Console.WriteLine("Введите число от 1 до 300");
                        }
                        while (true);

                        do
                        {
                            Console.Write("ПК-класс? (true/false): ");
                            if (bool.TryParse(Console.ReadLine(), out pc_class) ) break;
                            else Console.WriteLine("Выберите true или false");
                        }
                        while (true);

                        if (pc_class == true) projector = true;
                        else
                        {
                            do
                            {
                                Console.Write("Наличие проектора? (true/false): ");
                            if (bool.TryParse(Console.ReadLine(), out projector)) break;
                            else Console.WriteLine("Выберите true или false");
                            }
                            while (true);
                        }

                        Audit newAudit = new Audit(number,places,pc_class,projector);
                        auditList.Add(newAudit);
                        Console.WriteLine();
                        break;
                    
                    case 2:
                        if (auditList.Count != 0)
                        {
                            do
                            {
                                Console.Write("Введите кол-во мест: ");
                                if (int.TryParse(Console.ReadLine(), out user_places) && user_places > 0 && user_places <= 300) break;
                                else Console.WriteLine("Введите число от 1 до 300");
                            }
                            while (true);

                            foreach (Audit audit in auditList)
                            {
                                audit.Place_Count(user_places);
                            }
                            
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Аудиторий пока нет"); 
                        Console.WriteLine();
                        break;

                    case 3:
                        if (auditList.Count != 0)
                        {
                            do
                            {
                                Console.Write("Аудитория имеет проектор?: ");
                                if (bool.TryParse(Console.ReadLine(), out user_projector)) break;
                                else Console.WriteLine("Выберите true или false");
                            }
                            while (true);

                            foreach (Audit audit in auditList)
                            {
                                audit.Has_Projector(user_projector);
                            }
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Аудиторий пока нет");
                        Console.WriteLine();
                        break;

                    case 4:
                        if (auditList.Count != 0)
                        {
                            do
                            {
                                Console.Write("Аудитория имеет ПК?: ");
                                if (bool.TryParse(Console.ReadLine(), out user_pc)) break;
                                else Console.WriteLine("Выберите true или false");
                            }
                            while (true);

                            foreach (Audit audit in auditList)
                            {
                                audit.Is_It_PC_Class(user_pc);
                            }
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Аудиторий пока нет");
                        Console.WriteLine();
                        break;

                    case 5:
                        if (auditList.Count != 0)
                        {
                            do
                            {
                                Console.Write("Введите этаж аудитории: ");
                                if (int.TryParse(Console.ReadLine(), out user_floor) && user_floor > 0 && user_floor <= 9) break;
                                else Console.WriteLine("Введите число от 1 до 9");
                            }
                            while (true);
                            
                            foreach (Audit audit in auditList)
                            {
                                audit.Is_This_Floor(user_floor);
                            }
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Аудиторий пока нет");
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.WriteLine("Конец программы");
                        flag = false;
                        break;
                } 
            }
            
        }

    }


    class Audit
    {

        public int Number { get; set; }
        public int Places { get; set; }
        public bool PC_Class { get; set; }
        public bool Projector { get; set; }


        public Audit(int number, int places, bool pc_class, bool projector)
        {
            Number = number;
            Places = places;
            PC_Class = pc_class;
            Projector = projector;
        }

        public void PrintDetails()
        {
            Console.WriteLine("Номер: {0}  Места: {1}  ПК-класс: {2} Проектор: {3}", Number, Places, PC_Class, Projector);
        }

        public void Place_Count(int N)
        {
            if (N <= Places) PrintDetails();
            else Console.WriteLine("Таких аудиторий нет");
        }

        public void Is_It_PC_Class(bool N)
        {
            if (N == false && N == PC_Class) PrintDetails();
            if (N == true && N == PC_Class) PrintDetails();
        }
        public void Is_This_Floor(int N)
        {
            int floor = Number / 100;
            if (N == floor) PrintDetails();
        }

        public void Has_Projector(bool N)
        {  
            if (N == false && N == Projector) PrintDetails(); 
            if (N == true && N == Projector) PrintDetails();    
        }
    }
}
