using System;

namespace SpaceResidentClient.Models.CharacterCreation
{
    public class CharacterCreationSkillPointsProcessor
    {
        public byte[] PointsThreshold =
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

        public byte IncreaseSkill(byte points, byte value)
        {
            if (points >= 1 && value < 20)
            {
                if (value < PointsThreshold[0] && points > 0)
                    return --points;

                for (int i = 0; i < PointsThreshold.Length - 1; i++)
                {
                    if (value > PointsThreshold[i] - 1 && value < PointsThreshold[i + 1] && points >= i + 2)
                    {
                        if (points < i + 2)
                            return points;

                        return points -= Convert.ToByte(i + 2);
                    }
                }
            }
            return points;
        }

        public byte DecreaseSkill(byte points, byte value)
        {
            if (value > 1)
            {
                if (value <= PointsThreshold[0])
                    return ++points;

                for (int i = 0; i < PointsThreshold.Length - 1; i++)
                {
                    if (value > PointsThreshold[i] - 1 && value <= PointsThreshold[i + 1])
                    {
                        return points += Convert.ToByte(i + 2);
                    }
                }
            }
            return points;
        }
    }
}