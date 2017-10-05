using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarMap
{
    public class BinaryFormats
    {

        public const int ACX_VERSION = 1;
        public const string EXTENSION_STARMAP_COLLIDER = ".smc";
        public const string EXTENSION_POLYEDIT_COLLIDER = ".ac";

        public static void ReadDotSMC(string file, out Vector2i[] vertices, out bool autoSize, out Vector2u size)
        {
            if (!file.EndsWith(EXTENSION_STARMAP_COLLIDER))
                throw new InvalidOperationException("Invalid file type!");

            int version, vertexCount;
            List<Vector2i> verticesTmp = new List<Vector2i>();

            using (AndromedaBinaryReader reader = new AndromedaBinaryReader(file))
            {
                version = reader.ReadByte();
                autoSize = reader.ReadBool();
                size = reader.ReadVector2u();

                vertexCount = reader.ReadInt32();

                for (int i = 0; i < vertexCount; i++)
                {
                    Vector2i vertex = reader.ReadVector2i();
                    verticesTmp.Add(vertex);
                }
            }

            vertices = verticesTmp.ToArray();
        }

        public static void WriteDotSMC(string file, Vector2u size, IEnumerable<Vector2i> vertices, bool useSize = false)
        {
            if (!file.EndsWith(EXTENSION_STARMAP_COLLIDER))
                file += EXTENSION_STARMAP_COLLIDER;

            using (AndromedaBinaryWriter writer = new AndromedaBinaryWriter(file))
            {
                // write the version of this file
                writer.WriteByte(ACX_VERSION);

                // whether or not we're using size
                writer.WriteBool(useSize);

                if (!useSize)
                {
                    // write the size of the collider
                    writer.WriteVector2u(size);
                }
                else
                    writer.WriteVector2u(new Vector2u(0, 0));

                writer.WriteInt32(vertices.Count());

                foreach (var vertice in vertices)
                {
                    writer.WriteVector2i(vertice);
                }

                writer.Close();
            }
        }

        public static void WriteDotAC(string file, IEnumerable<Vector2i> vertices)
        {
            if (!file.EndsWith(".ac"))
                file += ".ac";

            using (AndromedaBinaryWriter writer = new AndromedaBinaryWriter(file))
            {
                foreach (var vertice in vertices)
                {
                    writer.WriteUInt16((ushort)vertice.X);
                    writer.WriteUInt16((ushort)vertice.Y);
                }

                writer.Close();
            }
        }

        /// <summary>
        /// For reading the old file formats
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The polygon vertices as a Vector2 array</returns>
        public static Vector2i[] ReadDotAC(string file)
        {
            if (!file.EndsWith(".ac"))
                throw new InvalidOperationException("Operation can only be done on a .ac file!");

            List<Vector2i> vertices = new List<Vector2i>();

            using (Stream fs = new FileStream(file, FileMode.Open))
            {
                while (fs.Position != fs.Length)
                {
                    byte[] xCoord = new byte[sizeof(ushort)];
                    byte[] yCoord = new byte[sizeof(ushort)];
                    fs.Read(xCoord, 0, sizeof(ushort));
                    fs.Read(yCoord, 0, sizeof(ushort));

                    ushort x = BitConverter.ToUInt16(xCoord, 0);
                    ushort y = BitConverter.ToUInt16(yCoord, 0);

                    //polygon.Add(new Vector2f(x, y));
                    vertices.Add(new Vector2i(x, y));
                }

                fs.Close();
            }

            return vertices.ToArray();
        }
    }
}
