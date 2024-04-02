namespace CharactersProcessor.Interfaces.SkillGroups
{
    internal interface ISkillAugmentations
    {
        byte NervesPeak { get; set; }
        byte AdaptingSystemsToTheBody { get; set; }

        void CalcSkillAugmentations();
    }
}