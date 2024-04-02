namespace CharactersProcessor.Interfaces.SkillGroups
{
    internal interface ISkillTransport
    {
        byte UnderwaterTransport { get; private protected set; }
        byte GroundTransport { get; private protected set; }
        byte AirTransport { get; private protected set; }

        /// <summary>
        /// logic - 75%; kinetics - 25%
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="kinetics"></param>
        void CalcSkillTransport(byte logic, byte kinetics)
        {
            byte result = (byte)(logic * 0.5 + kinetics * 0.5);

            UnderwaterTransport = GroundTransport = AirTransport = (byte)(result * 3);
        }
    }
}