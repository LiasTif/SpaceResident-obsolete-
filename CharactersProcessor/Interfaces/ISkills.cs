using CharactersProcessor.Interfaces.Skills;

namespace CharactersProcessor.Interfaces
{
    internal interface ISkills : ICharacteristics, ISkillSciences, ISkillInformatics,
        ISkillSpacecrafts, ISkillCognition, ISkillTransport, ISkillCommunication,
        ISkillPolitics, ISkillPsychology, ISkillAugmentations, ISkillBuisness
    {
        void CalcAllSkills()
        {
            CalcSkillAugmentations(Kinetics, Naturalistics);
            CalcSkillBuisness(Relationships, Existentialism);
            CalcSkillCognition(Existentialism, Space, Linguistics);
            CalcSkillCommunication(Relationships, Linguistics, Existentialism, Naturalistics);
            CalcSkillInformatics(Logic, Space);
            CalcSkillPolitics(Relationships, Naturalistics);
            CalcSkillPsychology(Existentialism, Naturalistics, Linguistics);
            CalcSkillSciences(Logic, Naturalistics);
            CalcSkillSpacecrafts(Logic, Kinetics);
            CalcSkillTransport(Logic, Kinetics);
        }
    }
}