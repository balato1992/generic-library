using System;
using System.Drawing;

namespace GenericModel.Other
{
    public static class RandomHelper
    {
        private static readonly Random _StaticRandom = new Random();

        /// <summary>
        /// Get a static Random value, avoid duplicate random value
        /// </summary>
        public static Random StaticRandom
        {
            get
            {
                return _StaticRandom;
            }
        }

        /// <summary>
        /// Get a 32-bit signed integer that is greater than or equal to 0, and less than upperBound Value, then take the integer divided By dividedByValue
        /// </summary>
        public static double GetMyRandom(int upperBound, int dividedByValue = 1)
        {
            return RandomHelper.StaticRandom.Next(upperBound) / (double)dividedByValue;
        }

        public static DateTime GetDateTime(DateTime startTime)
        {
            double minutes = RandomHelper.StaticRandom.NextDouble() * 10000;

            return startTime.AddMinutes(minutes);
        }

        public static T GetEnum<T>()
        {
            Array values = Enum.GetValues(typeof(T));

            return (T)values.GetValue(StaticRandom.Next(values.Length));
        }

        /// <summary>
        /// Get random color.
        /// Reference: https://stackoverflow.com/questions/5805774/how-to-generate-random-color-names-in-c-sharp
        /// </summary>
        /// <returns>Random Color</returns>
        public static Color GetColor()
        {
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[_StaticRandom.Next(names.Length)];
            Color randomColor = Color.FromKnownColor(randomColorName);

            return randomColor;
        }
    }
}
