namespace SpaceResidentClient.Models.CharacterCreation.Interfaces
{
    internal interface ISkillObservable
    {
        public void AddObverver();
        public void NotifyObververs();
        public void RemoveObverver();
    }
}