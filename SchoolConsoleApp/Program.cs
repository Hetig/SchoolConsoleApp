using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp
{    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, введите название школы");
            string schoolName = Console.ReadLine();
            var school = new School(schoolName);
            Console.WriteLine($"Школа {school.Name} успешно создана");

            while (true)
            {
                Console.WriteLine("Хотите добавить нового ученика? Введите да или нет");
                if (GetUserChoice())
                {
                    school.AddNewStudent();
                }

                Console.WriteLine("Хотите посмотреть список всех учеников? Введите да или нет");
                if (GetUserChoice())
                {
                    school.PrintStudents();
                }

                Console.WriteLine("Хотите удалить ученика? Введите да или нет");
                if (GetUserChoice())
                {
                    school.DeleteStudent();
                }
            }
        }

        public static bool GetUserChoice()
        {
            while (true)
            {
                string userAnswer = Console.ReadLine().ToLower();
                if (userAnswer == "да")
                {
                    return true;
                }
                else if (userAnswer == "нет")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Введите да или нет");
                }
            }
        }
    }
}
