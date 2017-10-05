using SFML.System;
using System;
using System.IO;
using System.Text;

namespace StarMap
{
    public class AndromedaBinaryReader : FileStream
    {
        public AndromedaBinaryReader(string path) : base(path, FileMode.Open)
        {

        }

        public bool ReadBool()
        {
            int size = sizeof(bool);
            byte[] value = new byte[size];
            Read(value, 0, size);
            return BitConverter.ToBoolean (value, 0);
        }

        public Vector2i ReadVector2i()
        {
            int x = ReadInt32();
            int y = ReadInt32();
            return new Vector2i(x, y);
        }

        public Vector2u ReadVector2u()
        {
            uint x = ReadUInt32();
            uint y = ReadUInt32();
            return new Vector2u(x, y);
        }

        public string ReadText()
        {
            int length = ReadInt32();
            byte[] buffer = new byte[length];
            Read(buffer, 0, length);
            return Encoding.ASCII.GetString(buffer);
        }

        public UInt32 ReadUInt32()
        {
            int size = sizeof(UInt32);
            byte[] value = new byte[size];
            Read(value, 0, size);
            return BitConverter.ToUInt32(value, 0);
        }

        public Int32 ReadInt32()
        {
            int size = sizeof(Int32);
            byte[] value = new byte[size];
            Read(value, 0, size);
            return BitConverter.ToInt32(value, 0);
        }

        public Int64 ReadInt64()
        {
            int size = sizeof(Int64);
            byte[] value = new byte[size];
            Read(value, 0, size);
            return BitConverter.ToInt64(value, 0);
        }

        public Int16 ReadInt16()
        {
            int size = sizeof(Int32);
            byte[] value = new byte[size];
            Read(value, 0, size);
            return BitConverter.ToInt16(value, 0);
        }
    }
}
