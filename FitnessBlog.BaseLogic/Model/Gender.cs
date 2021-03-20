using System;

namespace FitnessBlog.BaseLogic.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название пола.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Создание пола.
        /// </summary>
        /// <param name="id">ID пола.</param>
        public Gender(int id)
        {
            switch(id)
            {
                case 1:
                    Name = "Male";
                    break;
                case 2:
                    Name = "Female";
                    break;
                default:
                    throw new ArgumentException("Некорректный тип пола. ", nameof(Name));
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
