using CharactersProcessor.Interfaces;
using CharactersProcessor.Interfaces.ObserverSkillInterfaces;

namespace CharactersProcessor
{
    internal class SkillsProcessor(CharacteristicsProcessor characteristicsProcessor) :
        ISkills, ISkillObserver
    {
        public CharacteristicsProcessor CharacteristicsProcessor { get; set; } = characteristicsProcessor;

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

        public void Update() => CalcAllSkills();

        public static byte CalcSomeSkill(IDictionary<byte, double> characteristicsPersent)
        {
            double result = 0;
            foreach (var c in characteristicsPersent)
            {
                result += c.Value * c.Key;
            }

            result *= 3;
            return (byte)result;
        }
    }
}