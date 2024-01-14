namespace SpaceResidentClient.Models.Interfaces
{
    interface ICharacter
    {
        string Name { get; set; }
        string Surname { get; set; }
        bool IsFemale { get; set; }
        int Age { get; set; }
        char Race { get; set; }
    }
}