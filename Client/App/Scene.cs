using System.Collections;

namespace App
{
    public class Scene
    {
        public Scene()
        {
        }

        public object Client { get; set; }
        public string Name { get; set; }
        public ArrayList PositionedModels { get; set; }
        public int[] CameraPosition { get; set; }
        public int FieldOfView { get; set; }
    }
}