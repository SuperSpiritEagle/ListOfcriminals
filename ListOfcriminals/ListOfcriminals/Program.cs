﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfcriminals
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchCriminals searchCriminals = new SearchCriminals();
            searchCriminals.Search();
        }
    }

    class Criminal
    {
        private string _surname;
        private string _name;
        private string _patronymic;

        public Criminal(string surname, string name, string patronymic, string nationality, int growth, int weight, bool remandedСustody)
        {
            _surname = surname;
            _name = name;
            _patronymic = patronymic;

            Nationality = nationality;

            Growth = growth;
            Weight = weight;

            RemandedСustody = remandedСustody;
        }

        public int Growth { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }
        public bool RemandedСustody { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Фамилия {_surname}, Имя {_name}, Отчество {_patronymic}, рост {Growth}, вес {Weight}");
        }
    }

    class SearchCriminals
    {

        private List<Criminal> _criminals = new List<Criminal>
        {   new  Criminal("Иванов", "Иван", "Иванович", "Русский", 170, 84, true),
            new  Criminal("Петров", "Петр", "Петрович", "Американец", 160, 55, false),
            new  Criminal("Сидоров", "Сидр", "Сидорович", "Якут", 190, 94, false),
            new  Criminal("Степанов", "Степан", "Иванович", "Русский", 160, 70, false),
            new  Criminal("Кулибин", "Кулиб", "Кулибович", "Русский", 180, 60, false),
        };

        public void Search()
        {
            int growth;
            int weight;

            string nationality;

            Console.WriteLine("Введите данные приступника");
            Console.WriteLine("Введите рост преступника...");

            growth = ReadInt();

            Console.WriteLine("Введите вес преступника...");
            weight = ReadInt();

            Console.WriteLine("Введите национальность...");
            nationality = Console.ReadLine();

            var filter = from criminal in _criminals where criminal.Growth <= growth && criminal.Weight<=weight&& criminal.Nationality == nationality && criminal.RemandedСustody == false select criminal;

            Console.WriteLine("Найденные преступники:");
            
            foreach (var criminals in filter)
            {
                criminals.ShowInfo();
            }
        }

        private int ReadInt()
        {
            int userInputNumber = 0;
            bool isWork = true;

            while (isWork)
            {
                string userInput = Console.ReadLine();

                bool isNumber = int.TryParse(userInput, out userInputNumber);

                if (isNumber == false || userInputNumber <= 0)
                {
                    Console.WriteLine("Некорректный формат данных... Попробуйте ещё раз ввести число...");
                }
                else
                {
                    isWork = false;
                }
            }

            return userInputNumber;
        }
    }
}
