namespace CharactersProcessor.Interfaces.SkillGroups
{
    internal interface ISkillPolitics
    {
        byte Debates { get; private protected set; }
        byte CommunicationWithThePublic { get; private protected set; }
        byte Propaganda { get; private protected set; }

        /// <summary>
        /// relationships - 50%; linguistics - 50%
        /// </summary>
        /// <param name="relationships"></param>
        /// <param name="linguistics"></param>
        void CalcSkillPolitics(byte relationships, byte linguistics)
        {
            byte result = (byte)(relationships * 0.5 + linguistics * 0.5);

            Debates = CommunicationWithThePublic = Propaganda = (byte)(result * 3);
        }
    }
}