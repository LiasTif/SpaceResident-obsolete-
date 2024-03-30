namespace CharactersProcessor.Interfaces.Skills
{
    internal interface ISkillSpacecrafts
    {
        byte Corvettes { get; private protected set; }
        byte Destroyers { get; private protected set; }
        byte Cruisers { get; private protected set; }
        byte Battleships { get; private protected set; }
        byte Carriers { get; private protected set; }
        byte Titans { get; private protected set; }

        /// <summary>
        /// logic - 50%; kinetics - 50%
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="kinetics"></param>
        void CalcSkillSpacecrafts(byte logic, byte kinetics)
        {
            byte result = (byte)(logic * 0.5 + kinetics * 0.5);

            Corvettes = Destroyers = Cruisers = Battleships = Carriers = Titans = (byte)(result * 3);
        }
    }
}