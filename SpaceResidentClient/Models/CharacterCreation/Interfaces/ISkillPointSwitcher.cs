namespace SpaceResidentClient.Models.CharacterCreation.Interfaces
{
    internal interface ISkillPointSwitcher
    {
        byte Skill { get; set; }
        string SkillName { get; }
    }
}