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
