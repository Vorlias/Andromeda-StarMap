using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndromedaCanvas.Canvas;
using SFML.Graphics;
using SFML.System;
using Andromeda2D.System.Utility;
using SFML.Window;

namespace StarMap
{
    class PolygonEditorApplication : CanvasApplication
    {
        RenderTexture grid;
        List<Vector2i> vertices = new List<Vector2i>();
        uint scale = 8;
        uint width, height;
        bool active = false;

        public Vector2u EditorSize
        {
            get => new Vector2u(width, height);
            set
            {
                width = value.X;
                height = value.Y;
            }
        }

        public bool IsShiftKeyDown
        {
            get => Keyboard.IsKeyPressed(Keyboard.Key.LShift);
        }

        public bool IsControlKeyDown
        {
            get => Keyboard.IsKeyPressed(Keyboard.Key.LShift);
        }

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
            handle.Resized += SurfaceResized;
        }

        protected new void ResizeViews()
        {
            
        }

        private void SurfaceResized(Vector2i size)
        {
            Window.SetView(new View(size.ToFloat() / 2, size.ToFloat()));
        }

        public Vector2f MousePositionScaled
        {
            get => new Vector2f((float)Math.Floor((float)(MousePosition.X / scale)) * scale, (float)Math.Floor((float)(MousePosition.Y / scale)) * scale);
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

                VertexArray vertexArray = new VertexArray(PrimitiveType.LineStrip);

                foreach (var vertice in vertices.ToArray())
                {
                    RectangleShape rs = new RectangleShape(new Vector2f(scale, scale));
                    rs.Position = new Vector2f(vertice.X * scale, vertice.Y * scale);
                    vertexArray.Append(new Vertex(new Vector2f(vertice.X * scale + scale / 2, vertice.Y * scale + scale / 2), Color.Yellow));
                    Window.Draw(rs);
                    
                }

                if (vertices.Count > 1)
                    vertexArray.Append(new Vertex(vertices.First().ToFloat() * scale + (new Vector2f(scale / 2, scale / 2)), Color.Yellow));

                Window.Draw(vertexArray);

                RectangleShape mouseRect = new RectangleShape(new Vector2f(scale, scale));
                mouseRect.Position = MousePositionScaled;
                Window.Draw(mouseRect);
            }
        }

        protected override void Update()
        {
            
        }
    }
}
