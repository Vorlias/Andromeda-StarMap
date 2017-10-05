using Newtonsoft.Json.Linq;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarMap
{
    public class ProjectFormat
    {
        public struct ProjectFile
        {
            public string BackgroundImage;
            public Vector2i[] Vertices;
            public Vector2u Size;
        }

        public const string PROJECT_FILE_FORMAT = ".smp";

        public static void Save(string file, PolygonEditorApplication app)
        {
            ProjectFile projectFile = new ProjectFile() { BackgroundImage = app.TextureFile, Size = app.EditorSize, Vertices = app.Vertices.ToArray() };
            string result = JObject.FromObject(projectFile).ToString();
            File.WriteAllText(file, result);
        }

        public static void Load(string file, PolygonEditorApplication app)
        {
            ProjectFile project = JObject.Parse(File.ReadAllText(file)).ToObject<ProjectFile>();
            app.IsActive = false;
            app.EditorSize = project.Size;
            app.UpdateGrid(app.EditorSize.X, app.EditorSize.Y);
            app.Vertices.Clear();
            app.Vertices.AddRange(project.Vertices);

            if (project.BackgroundImage != null)
                app.TextureFile = project.BackgroundImage;

            app.IsActive = true;
        }
    }
}
