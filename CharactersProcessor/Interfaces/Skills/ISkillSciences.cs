namespace CharactersProcessor.Interfaces.Skills
{
    internal interface ISkillSciences
    {
        byte Math { get; private protected set; }
        byte Biology { get; private protected set; }
        byte Physics { get; private protected set; }   
        byte Chemistry { get; private protected set; }
        byte Geography { get; private protected set; }
        byte Astronomy { get; private protected set; }
        byte Philosophy { get; private protected set; }

        /// <summary>
        /// logic - 50%; naturalistics - 50%
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="naturalistics"></param>
        void CalcSkillSciences(byte logic, byte naturalistics)
        {
            byte result = (byte)(logic * 0.75 + naturalistics * 0.25);

            Math = Biology = Physics = Chemistry = Geography = Astronomy = Philosophy = (byte)(result * 3);
        }
    }
}