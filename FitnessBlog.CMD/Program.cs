using System;
using FitnessBlog.BaseLogic.Controller;

namespace FitnessBlog.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует программа FitnessBlog!");

            Console.Write("Введите своё имя: ");
            var userName = Console.ReadLine();

            var usCon = new UserController(userName);

            if(usCon.IsNewUser)
            {
                Console.Write("Введите свой пол (1 = Мужской, 2 = Женский): ");
                var id = int.Parse(Console.ReadLine());

                Console.Write("Введите свою дату рождение (дд.мм.гггг): ");
                var birthDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Введите свой вес: ");
                var weight = double.Parse(Console.ReadLine());

                Console.Write("Введите свою высоту: ");
                var height = double.Parse(Console.ReadLine());

                usCon.SetNewUserDate(id, birthDate, weight, height);
            }

        }
    }
}
