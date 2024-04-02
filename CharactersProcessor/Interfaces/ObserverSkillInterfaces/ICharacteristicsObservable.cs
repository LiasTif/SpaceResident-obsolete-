namespace CharactersProcessor.Interfaces.ObserverSkillInterfaces
{
    internal interface ICharacteristicsObservable
    {
        List<ISkillObserver> Observers { get; private protected set; }

        void AddObserver(ISkillObserver o);
        void RemoveObserver(ISkillObserver o);
        void NotifyObservers();
    }
}