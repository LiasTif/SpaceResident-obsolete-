namespace CharactersProcessor.Interfaces.Skills
{
    internal interface ISkillAugmentations
    {
        byte NervesPeak { get; private protected set; }
        byte AdaptingSystemsToTheBody { get; private protected set; }

        /// <summary>
        /// kinetics - 50%; naturalistics - 50%
        /// </summary>
        /// <param name="kinetics"></param>
        /// <param name="naturalistics"></param>
        void CalcSkillAugmentations(byte kinetics, byte naturalistics)
        {
            byte result = (byte)(kinetics * 0.5 + naturalistics * 0.5);

            NervesPeak = AdaptingSystemsToTheBody = (byte)(result * 3);
        }
    }
}