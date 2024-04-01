using CharactersProcessor.Interfaces.Skills;

namespace CharactersProcessor.Interfaces
{
    internal interface ISkills : ICharacteristics, ISkillSciences, ISkillInformatics,
        ISkillSpacecrafts, ISkillCognition, ISkillTransport, ISkillCommunication,
        ISkillPolitics, ISkillPsychology, ISkillAugmentations, ISkillBuisness
    {
        void CalcAllSkills();
    }
}