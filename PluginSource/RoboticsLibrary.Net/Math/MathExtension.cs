using System.Collections.Generic;

namespace RoboticsLibrary.Net.Math
{
    public static class MathExtension
    {
        public static double DegreesToRadians(this double d)
        {
            return d * System.Math.PI / 180d;
        }

        public static double RadiansToDegrees(this double d)
        {
            return d / System.Math.PI * 180d;
        }

        public static T DegreesToRadians<T>(this T data) where T : IList<double>
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = data[i].DegreesToRadians();
            }

            return data;
        }

        public static T RadiansToDegrees<T>(this T data) where T : IList<double>
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = data[i].RadiansToDegrees();
            }

            return data;
        }
    }
}