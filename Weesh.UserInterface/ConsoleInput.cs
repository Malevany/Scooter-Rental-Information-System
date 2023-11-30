using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weesh.BusinessLogic;

namespace Weesh.UserInterface
{
    public class ConsoleInput
    {
        public static void SayHelloToUser()
        {
            Console.WriteLine("\nДобро пожаловать в информационную систему Weesh!");
        }

        public static string InputTimeStart()
        {
            Console.WriteLine("\nУкажите время начала:");
            Console.WriteLine("\nВведите время в формате Час:Минуты (например, 12:34):");
            return Console.ReadLine();
        }

        public static bool IsUserRegistered()
        {
            Console.WriteLine("У вас есть аккаунт?");
            Console.WriteLine("Y - Да N - Нет");
            while(true)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case (ConsoleKey.Y):
                        return true;
                    case (ConsoleKey.N):
                        return false;
                }
            }
        }

        public static void TimeStartError()
        {
            Console.WriteLine("\nОшибка! Введено некорректное время.");
        }
        
        public static string InputDuration()
        {
            Console.WriteLine("\nУкажите длительность поездки в часах:");
            return Console.ReadLine();
        }

        public static void DurationError()
        {
            Console.WriteLine("\nНеверное время!");
        }

        public static void MaxDurationError()
        {
            Console.WriteLine("\nМаксимальное время 8ч.");
        }

        public static string InputAge()
        {
            Console.Write("\nВведите возраст: ");
            return Console.ReadLine();
        }

        public static void MinAgeError() 
        {
            Console.WriteLine("\nОшибка!\nУкажите правильный возраст. Минимальный возраст 14 лет.");
        }

        public static void AgeError()
        {
            Console.WriteLine("Некоректный ввод, повторите попытку!");
        }

        public static ConsoleKey InputSelectTypeOfScooter()
        {
            Console.WriteLine("\nВыберите тип самоката: ");
            Console.WriteLine("\nВиды самокатов: \n" +
                "1. С сиденьем \n" +
                "2. Без сиденья \n");
            return Console.ReadKey().Key;
        }

        public static void ShowConfig(Equipment equipment)
        {
            Console.WriteLine("\nВаша комплектация:");
            if (equipment.AgeTypeOfScooter == "Child")
                Console.WriteLine("\nТип самоката: Детский"); 
            else
                Console.WriteLine("\nТип самоката: Взрослый");
            if(equipment.Seat == "Seat")
                Console.WriteLine("\nКомплектация самоката: С сиденьем");
            else
                Console.WriteLine("\nКомплектация самоката: Без сиденья");
        }

        public static ConsoleKey InputConfirmOrder()
        {
            Console.WriteLine("\nВы готовы подтвердить поездку? Да/Нет (Y/N)");
            return Console.ReadKey().Key;
        }
        
        public static void OrderCancel()
        {
            Console.WriteLine("\nВозвращайтесь к нам как только будете готовы взять наш самокат!");
        }

        public static void FileNotFound()
        {
            Console.WriteLine("\nФайла с таким именем не существует или файл заполнен некорректно");
        }

        public static void FileNotExists()
        {
            Console.WriteLine("\nФайла с таким именем не существует");
        }
        
        public static void ScooterNotFound()
        {
            Console.WriteLine("\nК сожалению, сейчас у нас нет подходящего для вас самоката, попробуйте позже или измените комплектацию");
        }

        public static void WishUserLuck()
        {
            Console.WriteLine("\nУдачной поездки!");
        }

        public static string InputLogin()
        {
            Console.WriteLine("\nВведите логин");
            return Console.ReadLine();
        }

        public static void IncorrectLogin()
        {
            Console.WriteLine("\nТакой логин уже занят, попробуйте другой");
        }

        public static string InputPassword()
        {
            Console.WriteLine("\nВведите пароль");
            return Console.ReadLine();
        }

        public static void IncorrectLoginOrPassword()
        {
            Console.WriteLine("\nНеверный логин или пароль");
        }

        public static void AutorizationComplete()
        {
            Console.WriteLine("\nВы успешно авторизировались");
        }

        public static void Authorization()
        {
            Console.WriteLine("\nАвторизация...");
        }
        public static ConsoleKey WriteOffBonuses()
        {
            Console.WriteLine("\nХотите ли вы списать бонусы? Да/Нет (Y/N)");
            return Console.ReadKey().Key;
        }
    }
}
