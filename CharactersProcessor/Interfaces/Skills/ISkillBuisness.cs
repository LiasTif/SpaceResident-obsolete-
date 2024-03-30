namespace CharactersProcessor.Interfaces.Skills
{
    internal interface ISkillBuisness
    {
        byte HR { get; private protected set; }
        byte Marketing { get; private protected set; }
        byte MacrofinancialManagement { get; private protected set; }
        byte BusinessPlanning { get; private protected set; }
        byte StationManagement { get; private protected set; }

        /// <summary>
        /// relationships - 75%; existentialism - 25%
        /// </summary>
        /// <param name="relationships"></param>
        /// <param name="existentialism"></param>
        void CalcSkillBuisness(byte relationships, byte existentialism)
        {
            byte result = (byte)(relationships * 0.75 + existentialism * 0.25);

            HR = Marketing = MacrofinancialManagement = BusinessPlanning = StationManagement = (byte)(result * 3);
        }
    }
}