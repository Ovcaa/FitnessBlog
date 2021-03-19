using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBlog.BaseLogic.Model
{
    public class User
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; } 

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Дата рождение пользователя.
        /// </summary>
        public DateTime BirthDate { get; }

        /// <summary>
        /// Вес пользователя.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Высота пользователя.
        /// </summary>
        public double Height { get; }

        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Некорректное имя пользователя. ", nameof(name));
            }
        }
    }
}
