using CharactersProcessor.Interfaces.SkillGroups;

namespace CharactersProcessor.SkillGroups
{
    internal class SkillAugmentationsProcessor(SkillsProcessor skillsProcessor) : ISkillAugmentations
    {
        private readonly SkillsProcessor skillsProcessor = skillsProcessor;
        public byte NervesPeak { get; set; }
        public byte AdaptingSystemsToTheBody { get; set; }

        /// <summary>
        /// kinetics - 50%; naturalistics - 50%
        /// </summary>
        /// <param name="kinetics"></param>
        /// <param name="naturalistics"></param>
        public void CalcSkillAugmentations()
        {
            IDictionary<byte, double> characteristicsPersent = new Dictionary<byte, double>
            {
                { skillsProcessor.CharacteristicsProcessor.Kinetics, 0.5 },
                { skillsProcessor.CharacteristicsProcessor.Naturalistics, 0.5 }
            };

            NervesPeak = AdaptingSystemsToTheBody = SkillsProcessor.CalcSomeSkill(characteristicsPersent);
        }
    }
}