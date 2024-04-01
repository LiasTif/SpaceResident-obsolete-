using CharactersProcessor.Interfaces;

namespace CharactersProcessor
{
    internal class CharacteristicsProcessor : ICharacteristics, ICharacteristicsObservable
    {
        public byte Linguistics { get; set; }
        public byte Naturalistics { get; set; }
        public byte Existentialism { get; set; }
        public byte Relationships { get; set; }
        public byte Logic { get; set; }
        public byte Space { get; set; }
        public byte Kinetics { get; set; }
        public List<ISkillObserver> Observers { get; set; } = [];

        public void AddObserver(ISkillObserver o) => Observers.Add(o);
        public void RemoveObserver(ISkillObserver o) => Observers.Remove(o);
        public void NotifyObservers()
        {
            foreach (ISkillObserver o in Observers)
            {
                o.Update();
            }
        }

        public void SetCharacteristics(List<byte> characteristics)
        {
            characteristics[0] = Linguistics;
            characteristics[1] = Naturalistics;
            characteristics[2] = Existentialism;
            characteristics[3] = Relationships;
            characteristics[4] = Logic;
            characteristics[5] = Space;
            characteristics[6] = Kinetics;
            characteristics[7] = Logic;
            characteristics[8] = Space;
            characteristics[9] = Kinetics;

            NotifyObservers();
        }
    }
}