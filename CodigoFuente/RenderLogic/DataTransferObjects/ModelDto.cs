using System.Drawing;

namespace Render3D.RenderLogic.DataTransferObjects
{
    public class ModelDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public FigureDto Figure { get; set; }
        public MaterialDto Material { get; set; }
        public Bitmap Preview { get; set; }

    }
}
