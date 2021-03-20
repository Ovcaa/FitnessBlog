using System;

namespace FitnessBlog.BaseLogic.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождение пользователя.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Вес пользователя в кг.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Высота пользователя в см.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <param name="gender">Пол пользователя.</param>
        /// <param name="birthDate">Дата рождение пользователя.</param>
        /// <param name="weight">Вес пользователя в кг.</param>
        /// <param name="height">Высота пользователя в см.</param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Некорректное имя пользователя. ", nameof(name));
            }
            if (birthDate < DateTime.Parse("1900.01.01") || birthDate > DateTime.Now)
            {
                throw new ArgumentException("Некорректный пол пользователя. ", nameof(birthDate));
            }
            if (weight < 10.0 || weight > 300.0)
            {
                throw new ArgumentException("Некорректный вес пользователя(Min = 10, Max = 300). ", nameof(weight));
            }
            if(height < 50.0 || height > 300.0)
            {
                throw new ArgumentException("Некорректная высота пользователя(Min = 50, Max = 300). ", nameof(height));
            }

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        /// <summary>
        /// Создание просто пользователя.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Некорректное имя пользователя. ", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {Gender} {BirthDate}";
        }
    }
}
