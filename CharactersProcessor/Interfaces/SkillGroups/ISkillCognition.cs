namespace CharactersProcessor.Interfaces.SkillGroups
{
    internal interface ISkillCognition
    {
        byte Styding { get; private protected set; }

        /// <summary>
        /// existentialism - 40%; space - 40%; linguistics - 20%
        /// </summary>
        /// <param name="existentialism"></param>
        /// <param name="space"></param>
        /// <param name="linguistics"></param>
        void CalcSkillCognition(byte existentialism, byte space, byte linguistics)
        {
            byte result = (byte)(existentialism * 0.4 + space * 0.4 + linguistics * 0.2);

            Styding = (byte)(result * 3);
        }
    }
}