using System;

namespace Laboratorium_2.Models 
{
    public class BirthModel
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && BirthDate.HasValue && BirthDate.Value < DateTime.Now;
        }

        public int Age()
        {
            if (!BirthDate.HasValue)
            {
                return 0;
            }
            var age = DateTime.Now.Year - BirthDate.Value.Year;
            if (DateTime.Now < BirthDate.Value.AddYears(age)) age--;
            return age;
        }
    }
}
