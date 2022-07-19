﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public int Age;

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }

    public class School
    {
        public string Name;
        public List<Student> Students;

        public School(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public void PrintStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("В школе пока нет учеников");
            }
            else
            {
                Console.WriteLine("{0, -10} {1, -10} {2, -10}", "Имя", "Фамилия", "Возраст");

                foreach (var student in Students)
                {
                    Console.WriteLine("{0, -10} {1, -10} {2, -10}", student.FirstName, student.LastName, student.Age);
                }
            }
        }

        internal void AddNewStudent()
        {
            Console.WriteLine("Введите имя ученика");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилие ученика");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введите возраст ученика");
            int age = Convert.ToInt32(Console.ReadLine());

            var student = new Student(firstName, lastName, age);
            Console.WriteLine($"Ученик {student.FirstName} успешно добавлен в школу {Name}");

            Students.Add(student);
        }

        public void DeleteStudent()
        {
            Console.WriteLine("Выберите номер ученика, которого хотите удалить");

            Console.WriteLine("{0, -10} {1, -10} {2, -10} {3, -10}", "№", "Имя", "Фамилия", "Возраст");

            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine("{0, -10} {1, -10} {2, -10} {3, -10}", i + 1, Students[i].FirstName, Students[i].LastName, Students[i].Age);
            }

            int studentIndex;
            while (true)
            {
                try
                {
                    studentIndex = Convert.ToInt32(Console.ReadLine());
                    if (studentIndex < 1)
                    {
                        Console.WriteLine("Неверно выбранный номер!");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите число!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Неверно выбранный номер!");
                }
            }
            Students.RemoveAt(studentIndex - 1);
            Console.WriteLine($"Ученик с номером {studentIndex} успешно удален");
        }
    }
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
