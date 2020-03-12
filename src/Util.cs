using System;

namespace NetBitDataIO
{
    static class Util
    {
        public const float PI = (float)Math.PI,
            TwoPI = PI * 2;
        public const float Deg2Rad = 0.017453292519943295769236907684886f;

        public static float WrapAngle(float angle)
        {
            if (angle > -PI && angle <= PI)
                return angle;
            angle %= TwoPI;
            if (angle <= -PI)
                return angle + TwoPI;
            if (angle > PI)
                return angle - TwoPI;
            return angle;
        }
    }
}