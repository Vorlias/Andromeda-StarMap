using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndromedaCanvas.Canvas;
using SFML.Graphics;
using SFML.System;

namespace StarMap
{
    class PolygonEditorApplication : CanvasApplication
    {
        RenderTexture grid;
        List<Vector2i> vertices = new List<Vector2i>();
        uint scale = 8;
        uint width, height;
        bool active = false;

        public bool IsActive
        {
            get => active;
            set => active = value;
        }

        public List<Vector2i> Vertices
        {
            get => vertices;
        }

        public void UpdateGrid(uint width, uint height, uint gridScale = 8)
        {
            this.width = width;
            this.height = height;
            Utility.GenerateGridTexture(out grid, gridScale, width, height);
            scale = gridScale;
        }

        public PolygonEditorApplication(DrawingSurface handle) : base(handle)
        {
            //Utility.GenerateGridTexture(out grid, 8);
        }

        protected override void Render()
        {
            if (active)
            { 
                if (grid != null)
                { 
                    Sprite sp = new Sprite(grid.Texture);
                    Window.Draw(sp);
                }

                foreach (var vertice in vertices.ToArray())
                {
                    RectangleShape rs = new RectangleShape(new Vector2f(scale, scale));
                    rs.Position = new Vector2f(vertice.X * scale, vertice.Y * scale);
                    Window.Draw(rs);
                }
            }
        }

        protected override void Update()
        {
            
        }
    }
}
