using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBlog.BaseLogic.Model
{
    public class User
    {
        public string Name { get; } 
        public Gender gender { get; }
        public DateTime birthDate { get; }
    }
}
