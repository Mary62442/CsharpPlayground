using BlMusic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BlMusic.Enum;

namespace BlMusic.Classes
{
    [Serializable]
    public class Musician : IPerson
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Genders Gender { get; set; }
        public void Genderify()
        {
            if (this.Gender == Genders.MALE) this.Name = $"Mr {this.Name}";
            else if (this.Gender == Genders.FEMALE) this.Name = $"Miss {this.Name}";
        }
        public string FullName()
        {
            this.Genderify();
            return $"{Name} {Surname}";
        }

        public List<IInstrument> Instruments { get; set; }
        private string proficiency { get; set; }
        public string Proficiency
        {
            get => proficiency;
            set => proficiency = value;
        }

        private int yearsOfStudy { get; set; }
        public int YearsOfStudy
        {
            get { return yearsOfStudy; }
            set { yearsOfStudy = value; }

        }

        public MusicStyles MusicStyle { get; set; }

    }
}
