namespace CharactersProcessor.Interfaces
{
    internal interface ICharacteristics
    {
        byte Linguistics { get; private protected set; }
        byte Naturalistics { get; private protected set; }
        byte Existentialism { get; private protected set; }
        byte Relationships { get; private protected set; }
        byte Logic { get; private protected set; }
        byte Space { get; private protected set; }
        byte Kinetics { get; private protected set; }

        void SetCharacteristics(List<byte> characteristics);
    }
}