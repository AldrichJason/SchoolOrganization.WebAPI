using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOrganization.Integration.Entities
{
    public class ResourceData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Pantone_Value { get; set; }

        public ResourceData(int id, string name, int year, string color, string pantone_Value)
        {
            Id = id;
            Name = name;
            Year = year;
            Color = color;
            Pantone_Value = pantone_Value;
        }
    }
}
