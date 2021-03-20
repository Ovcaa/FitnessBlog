using System;
using System.Collections.Generic;
using System.Linq;
using FitnessBlog.BaseLogic.Model;

namespace FitnessBlog.BaseLogic.Controller
{
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Путь к файлу пользователей.
        /// </summary>
        private const string USER_PATH = "users.dat";

        /// <summary>
        /// Лист пользователей.
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Проверка на нового пользователя.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Добавление в контроллер пользователя.
        /// </summary>
        /// <param name="userName">Имя пользовтеля в контроллере.</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException("Некорректный пользователь.", nameof(userName));

            Users = GetUsers();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        /// <summary>
        /// Сохранение пользователей.
        /// </summary>
        public void SaveUsers()
        {
            Save(USER_PATH, Users);
        }

        /// <summary>
        /// Загрузка пользователей.
        /// </summary>
        /// <returns>Лист пользователей.</returns>
        private List<User> GetUsers()
        {
            return Load<List<User>>(USER_PATH) ?? new List<User>();
        }

        /// <summary>
        /// Добавление свойств в созданный пользователь
        /// </summary>
        /// <param name="id">ID пола пользователя.</param>
        /// <param name="birthDate">Дата рождение пользователя.</param>
        /// <param name="weight">Вес пользователя в кг.</param>
        /// <param name="height">Высота пользователя в см.</param>
        public void SetNewUserDate(int id, DateTime birthDate, double weight = 10, double height = 50)
        {
            Gender gender;
            switch (id)
            {
                case 1:
                    gender = new Gender(1);
                    break;
                case 2:
                    gender = new Gender(2);
                    break;
                default:
                    throw new ArgumentException("Некорректный тип пола. ", nameof(gender));
            }
            if (birthDate < DateTime.Parse("1900.01.01") || birthDate > DateTime.Now)
            {
                throw new ArgumentException("Некорректный пол пользователя. ", nameof(birthDate));
            }
            if (weight < 10.0 || weight > 300.0)
            {
                throw new ArgumentException("Некорректный вес пользователя(Min = 10, Max = 300). ", nameof(weight));
            }
            if (height < 50.0 || height > 300.0)
            {
                throw new ArgumentException("Некорректная высота пользователя(Min = 50, Max = 300). ", nameof(height));
            }

            CurrentUser.Gender = gender;
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            SaveUsers();
        }
    }
}
