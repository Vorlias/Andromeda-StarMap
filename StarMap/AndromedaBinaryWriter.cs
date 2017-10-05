using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarMap
{

    public class AndromedaBinaryWriter : FileStream
    {
        public AndromedaBinaryWriter(string path) : base(path, FileMode.Create)
        {
            
        }

        public void WriteBool(bool value)
        {
            Write(BitConverter.GetBytes(value), 0, sizeof(bool));
        }

        public void WriteText(string text)
        {
            WriteInt32(text.Length);
            Write(Encoding.ASCII.GetBytes(text), 0, text.Length);
        }

        public void WriteVector2i(Vector2i vector2i)
        {
            WriteInt32(vector2i.X);
            WriteInt32(vector2i.Y);
        }

        public void WriteVector2u(Vector2u vector2u)
        {
            WriteUInt32(vector2u.X);
            WriteUInt32(vector2u.Y);
        }

        public void WriteUInt32(UInt32 integer)
        {
            Write(BitConverter.GetBytes(integer), 0, sizeof(UInt32));
        }

        public void WriteUInt64(UInt64 integer)
        {
            Write(BitConverter.GetBytes(integer), 0, sizeof(UInt64));
        }

        public void WriteInt64(Int64 integer)
        {
            Write(BitConverter.GetBytes(integer), 0, sizeof(Int64));
        }

        public void WriteUInt16(UInt16 integer)
        {
            Write(BitConverter.GetBytes(integer), 0, sizeof(UInt16));
        }

        public void WriteInt16(Int16 integer)
        {
            Write(BitConverter.GetBytes(integer), 0, sizeof(Int16));
        }

        public void WriteInt32(Int32 integer)
        {
            Write(BitConverter.GetBytes(integer), 0, sizeof(Int32));
        }
    }
}
