namespace CharactersProcessor.Interfaces.SkillGroups
{
    internal interface ISkillInformatics
    {
        byte Software { get; private protected set; }
        byte Algorithms { get; private protected set; }
        byte ProgrammingLanguages { get; private protected set; }
        byte AI { get; private protected set; }
        byte Cybersecurity { get; private protected set; }

        /// <summary>
        /// logic - 50%; space - 50%
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="space"></param>
        void CalcSkillInformatics(byte logic, byte space)
        {
            byte result = (byte)(logic * 0.5 + space * 0.5);

            Software = Algorithms = ProgrammingLanguages = AI = Cybersecurity = (byte)(result * 3);
        }
    }
}