using BitDataIO;
using System;

namespace NetBitDataIO
{
    public class NetBitDataWriter : BitDataWriter
    {
        public NetBitDataWriter() => EnsureSize(_lengthBits = 3);
        public NetBitDataWriter(int capacity) => EnsureSize(_lengthBits = 3 + capacity);

        public new byte[] Data
        {
            get
            {
                var lengthBytes = (_lengthBits + 7) >> 3;
                var data = new byte[lengthBytes];
                Array.Copy(_data, data, data.Length);
                WriteByte((byte)((lengthBytes << 3) - _lengthBits), 3, data, 0);
                return data;
            }
        }

        public new int LengthBits => _lengthBits - 3;
        public new int LengthBytes => (_lengthBits - 3 + 7) >> 3;

        public void WriteAngle(float value, int bits)
        {
            var maxVal = 1 << bits;
            var packedRadians = (int)Math.Round((Util.WrapAngle(value) + Util.PI) / Util.TwoPI * maxVal);
            if (packedRadians == maxVal)
                packedRadians = 0;
            Write((uint)packedRadians, bits);
        }
    }
}