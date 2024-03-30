namespace CharactersProcessor.Interfaces
{
    internal interface ICharacterBio
    {
        string FirstName { get; }
        string LastName { get; }
        char Race { get; }
        bool IsFemale { get; }
        ushort Age { get; }
    }
}