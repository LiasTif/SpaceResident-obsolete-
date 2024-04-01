namespace CharactersProcessor.Interfaces
{
    internal interface ICharacterBio
    {
        string FirstName { get; private protected set; }
        string LastName { get; private protected set; }
        char Race { get; private protected set; }
        bool IsFemale { get; private protected set; }
        ushort Age { get; private protected set; }
    }
}