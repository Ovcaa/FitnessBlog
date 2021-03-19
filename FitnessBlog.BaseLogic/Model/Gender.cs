using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBlog.BaseLogic.Model
{
    public class Gender
    {
        /// <summary>
        /// Название пола.
        /// </summary>
        public string Name { get; }

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
    }
}
