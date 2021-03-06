﻿using System;
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
    public class PolygonEditorApplication : CanvasApplication
    {
        RenderTexture grid;
        List<Vector2i> vertices = new List<Vector2i>();
        uint scale = 8;
        uint width, height;
        bool active = false;
        bool _autoSize = false;
        Texture backgroundTexture;
        string _textureFile;

        public uint EditorScale => scale;

        public Texture BackgroundTexture
        {
            get => backgroundTexture;
        }

        public string TextureFile
        {
            get => _textureFile;
            set
            {
                backgroundTexture = new Texture(value);
                _textureFile = value;
            }
        }

        public bool AutoSize
        {
            get => _autoSize;
            set => _autoSize = value;
        }

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
            get => Keyboard.IsKeyPressed(Keyboard.Key.LControl);
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
            if (height > 128 && gridScale > 4)
                gridScale = 4;

            this.width = width;
            this.height = height;
            Utility.GenerateGridTexture(out grid, gridScale, width, height);
            scale = gridScale;
        }

        public PolygonEditorApplication(DrawingSurface handle) : base(handle)
        {
            handle.Resized += SurfaceResized;

        }

        bool mouseDown = false;



        public void DebugRects()
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                FloatRect vertexRect = new FloatRect(
                    new Vector2f(
                        (float)Math.Floor((float)(vertices[i].X / scale)) * scale,
                        (float)Math.Floor((float)(vertices[i].Y / scale)) * scale
                    ),
                    new Vector2f(
                        scale,
                        scale
                    )
                );



                RectangleShape rs = new RectangleShape(new Vector2f(vertexRect.Width, vertexRect.Height));
                rs.Position = new Vector2f(vertexRect.Left, vertexRect.Top);
                Window.Draw(rs);
            }
        }

        int selectedIndex = -1;
        MouseMode mode = MouseMode.None;

        enum MouseMode
        {
            None,
            Drag,
            Add,
            Delete,
        }

        private void MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (selectedIndex >= 0)
            { 
                if (mode == MouseMode.Drag)
                    vertices[selectedIndex] = new Vector2i((int)(MousePositionScaled.X / EditorScale), (int)(MousePositionScaled.Y / EditorScale));
                else if (mode == MouseMode.Add)
                {
                    vertices.Insert(selectedIndex + 1, new Vector2i((int)(MousePositionScaled.X / EditorScale), (int)(MousePositionScaled.Y / EditorScale)));
                }
            }

            selectedIndex = -1;
        }

        private void MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            FloatRect mouseRect = new FloatRect(MousePositionScaled.X, MousePositionScaled.Y, 2, 2);

            for (int i = 0; i < vertices.Count; i++)
            {
                FloatRect vertexRect = new FloatRect(
                    new Vector2f(
                        (float)Math.Floor((float)(vertices[i].X * scale)),
                        (float)Math.Floor((float)(vertices[i].Y * scale))
                    ),
                    new Vector2f(
                        scale,
                        scale
                    )
                );

                if (e.Button == Mouse.Button.Middle)
                {
                    mode = MouseMode.Drag;
                }
                else if (e.Button == Mouse.Button.Left)
                {
                    if (IsShiftKeyDown)
                        mode = MouseMode.Delete;
                    else
                        mode = MouseMode.Add;
                }
                else
                    mode = MouseMode.None;


                if (mouseRect.Intersects(vertexRect) && mode != MouseMode.Delete)
                {
                    selectedIndex = i;
                    break;
                }

                if (mouseRect.Intersects(vertexRect) && mode == MouseMode.Delete)
                {
                    vertices.RemoveAt(i);
                    break;
                }
            }
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

                if (backgroundTexture != null)
                {
                    Sprite bgSprite = new Sprite(backgroundTexture);
                    bgSprite.Color = new Color(255, 255, 255, 100);
                    bgSprite.Scale = new Vector2f(EditorScale, EditorScale);
                    Window.Draw(bgSprite);
                }

                VertexArray vertexArray = new VertexArray(PrimitiveType.LineStrip);

                int i = 0;
                foreach (var vertice in vertices.ToArray())
                {
                    RectangleShape rs = new RectangleShape(new Vector2f(scale, scale));
                    rs.Position = new Vector2f(vertice.X * scale, vertice.Y * scale);

                    if (selectedIndex == i && mode != MouseMode.Add)
                        rs.FillColor = Color.Transparent;

                    vertexArray.Append(new Vertex(new Vector2f(vertice.X * scale + scale / 2, vertice.Y * scale + scale / 2), Color.Yellow));
                    Window.Draw(rs);
                    i++;
                }

                if (vertices.Count > 1)
                    vertexArray.Append(new Vertex(vertices.First().ToFloat() * scale + (new Vector2f(scale / 2, scale / 2)), Color.Yellow));

                Window.Draw(vertexArray);

                RectangleShape mouseRect = new RectangleShape(new Vector2f(scale, scale));
                mouseRect.FillColor = new Color(150, 150, 150, 100);
                mouseRect.Position = MousePositionScaled;
                

                if (selectedIndex >= 0)
                {
                    if (mode == MouseMode.Drag)
                        mouseRect.FillColor = Color.White;
                    else if (mode == MouseMode.Add)
                    { 
                        mouseRect.FillColor = Color.Green;

                        VertexArray vert = new VertexArray(PrimitiveType.LineStrip);

                       

                        if (selectedIndex < vertices.Count - 1)
                        {
                            var first = vertices[selectedIndex];
                            var second = vertices[selectedIndex + 1];

                            vert.Append(new Vertex(first.ToFloat() * scale));
                            vert.Append(new Vertex(MousePositionScaled));
                            vert.Append(new Vertex(second.ToFloat() * scale));
                        }
                        else if (vertices.Count > 0)
                        {
                            var second = vertices[0];
                            var first = vertices[selectedIndex];


                            vert.Append(new Vertex(first.ToFloat() * scale));
                            vert.Append(new Vertex(MousePositionScaled));
                            vert.Append(new Vertex(second.ToFloat() * scale));
                        }

                        Window.Draw(vert);
                    }
                }

                Window.Draw(mouseRect);
            }
        }

        bool eventsSetup = false;

        public override void BeforeWork()
        {
            Window.MouseButtonPressed += MouseButtonPressed;
            Window.MouseButtonReleased += MouseButtonReleased;
        }

        protected override void Update()
        {
            if (!eventsSetup)
            {
                Console.WriteLine("Setup evts");
                eventsSetup = true;

            }
        }
    }
}
