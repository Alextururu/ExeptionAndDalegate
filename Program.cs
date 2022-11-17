using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeptionAndDalegate
{
    internal class Program
    {
        public static List<string> ListLastName;
        static void Main(string[] args)
        {
            SortLastNames sortLastNames = new SortLastNames();
            sortLastNames.SortLastNamesEvent += SortLastNames;
            ListLastName = new List<string> { "Иванов", "Петров", "Сидоров", "Степанов", "Миронов" };
            try
            {
                sortLastNames.Read();
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
            Console.ReadLine();
        }
        static void SortLastNames(int number)
        {
            switch(number)
            {
                case 1:
                    ListLastName.Sort();
                    foreach (string s in ListLastName)
                    {
                        Console.WriteLine(s);
                    }
                    break;

                case 2:
                    ListLastName.Sort();
                    ListLastName.Reverse();
                    foreach (string s in ListLastName)
                    {
                        Console.WriteLine(s);
                    }
                    break;
            }
        }
    }
    public class SortLastNames
    {
        public delegate void SortLastNamesDelegate(int number);
        public event SortLastNamesDelegate SortLastNamesEvent;
        public int number;
        public void Read()
        {
            Console.WriteLine();
            Console.WriteLine("Введите 1 для сортировки А-Я или введите 2 для сортировки Я-А");
            number = Convert.ToInt32(Console.ReadLine());
            if(number != 1 && number !=2)
            {
                throw new FormatException();
            }
            SortLastNamesEntered(number);
        }
        protected virtual void SortLastNamesEntered(int number)
        {
            SortLastNamesEvent?.Invoke(number);
        }

    }


    public class MyException : Exception
    {
        public MyException()
        { 
        }

        public MyException(string message)
            : base(message)
        { }
    }
    public class Exeptions
    {
        public void MainWorkExeptions()
        {
            Exception[] arrayException = new Exception[5];
            arrayException[0] = new MyException("Мое исключение!");
            arrayException[1] = new ArgumentNullException();
            arrayException[2] = new DivideByZeroException();
            arrayException[3] = new FormatException();
            arrayException[4] = new IndexOutOfRangeException();

            foreach (Exception ex in arrayException)
            {
                try
                {
                    throw ex;
                }
                catch
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.Read();
        }
    }
}
