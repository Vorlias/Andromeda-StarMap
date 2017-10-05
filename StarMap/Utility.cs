using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarMap
{
    class Utility
    {
        public static void GenerateGridTexture(out RenderTexture target, uint scale = 8, uint width = 64, uint height = 64)
        {
            target = new RenderTexture(width * scale, height * scale);
            width = width * scale;
            height = height * scale;
            
            for (uint x = 0; x < width; x += scale)
            {
                for (uint y = 0; y < height; y += scale)
                {
                    var rect = new RectangleShape(new Vector2f(scale, scale))
                    {
                        Position = new Vector2f(x, y),
                        FillColor = new Color(75, 75, 75),
                        OutlineColor = new Color(50, 50, 50),
                        OutlineThickness = 1
                    };
                    target.Draw(rect);
                }
            }

            target.Display();
        }
    }
}
