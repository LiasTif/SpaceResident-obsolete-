using System;

namespace SpaceResidentClient.Models.CharacterCreation
{
    internal class CharCreationSkillPointsProcessor
    {
        /// <summary>
        /// Increase skill and get a new point value
        /// </summary>
        /// <param name="points">Current points</param>
        /// <param name="value">Current value of skill</param>
        /// <returns>New points value</returns>
        public int IncreaseSkill(int points, byte value)
        {
            if (points < 1 && value >= 20)
                return points;

            if (value < _pointsThresholdArr[0] && points > 0)
                return --points;

            for (int i = 0; i < _pointsThresholdArr.Length - 1; i++)
            {
                if (value > _pointsThresholdArr[i] - 1 && value < _pointsThresholdArr[i + 1] && points >= i + 2)
                {
                    return points -= Convert.ToByte(i + 2);
                }
            }
            return points;
        }

        /// <summary>
        /// Decrease skill and get a new point value
        /// </summary>
        /// <param name="points">Current points</param>
        /// <param name="value">Current value of skill</param>
        /// <returns>New points value</returns>
        public int DecreaseSkill(int points, byte value)
        {
            if (value <= 1)
                return points;

            if (value <= _pointsThresholdArr[0])
                return ++points;

            for (int i = 0; i < _pointsThresholdArr.Length - 1; i++)
            {
                if (value > _pointsThresholdArr[i] - 1 && value <= _pointsThresholdArr[i + 1])
                {
                    return points += Convert.ToByte(i + 2);
                }
            }
            return points;
        }

        private readonly byte[] _pointsThresholdArr =
        [
            5,
            8,
            10,
            12,
            14,
            15,
            16,
            17,
            18,
            19,
        ];
    }
}