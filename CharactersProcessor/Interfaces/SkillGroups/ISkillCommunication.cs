namespace CharactersProcessor.Interfaces.SkillGroups
{
    internal interface ISkillCommunication
    {
        byte VunLainLanguage { get; private protected set; }
        byte VunMisakTicking { get; private protected set; }
        byte VunTiVibrations { get; private protected set; }
        byte VunFlantCommunicationByFungal { get; private protected set; }

        /// <summary>
        /// relationships - 35%; linguistics - 35%; existentialism - 15%; naturalistics - 15%
        /// </summary>
        /// <param name="relationships"></param>
        /// <param name="linguistics"></param>
        /// <param name="existentialism"></param>
        /// <param name="naturalistics"></param>
        void CalcSkillCommunication(byte relationships, byte linguistics, byte existentialism, byte naturalistics)
        {
            byte result = (byte)(relationships * 0.35 + linguistics * 0.35 + existentialism * 0.15 + naturalistics * 0.15);

            VunLainLanguage = VunMisakTicking = VunTiVibrations = VunFlantCommunicationByFungal = (byte)(result * 3);
        }
    }
}