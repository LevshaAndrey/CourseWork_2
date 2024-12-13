using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CourseWork_2
{

    public class Driver
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime WorkDate { get; set; }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}, Дата работы: {WorkDate.ToShortDateString()}";
        }
    }
}