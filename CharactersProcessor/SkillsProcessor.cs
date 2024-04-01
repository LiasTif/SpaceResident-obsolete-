using CharactersProcessor.Interfaces;

namespace CharactersProcessor
{
    internal class SkillsProcessor : ISkills, ISkillObserver
    {
        public void CalcAllSkills()
        {
            //CalcSkillAugmentations(Kinetics, Naturalistics);
            //CalcSkillBuisness(Relationships, Existentialism);
            //CalcSkillCognition(Existentialism, Space, Linguistics);
            //CalcSkillCommunication(Relationships, Linguistics, Existentialism, Naturalistics);
            //CalcSkillInformatics(Logic, Space);
            //CalcSkillPolitics(Relationships, Naturalistics);
            //CalcSkillPsychology(Existentialism, Naturalistics, Linguistics);
            //CalcSkillSciences(Logic, Naturalistics);
            //CalcSkillSpacecrafts(Logic, Kinetics);
            //CalcSkillTransport(Logic, Kinetics);
        }

        public void SetCharacteristics(List<byte> characteristics)
        {
            throw new NotImplementedException();
        }

        public void Update() => CalcAllSkills();
    }
}