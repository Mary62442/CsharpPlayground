using BlMusic.Enum;

namespace BlMusic.Interfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        string Surname { get; set; }
        string FullName();

        string Nationality { get; set;}
        string Location { get; set; }
        int Age { get; set; }

        string Email { get; set; }

        Genders Gender { get; set; }
        void Genderify();

    }
}
