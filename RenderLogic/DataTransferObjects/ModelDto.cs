using System.Drawing;

namespace RenderLogic.DataTransferObjects
{
    public class ModelDto
    {
        public string Name { get; set; }
        public FigureDto Figure { get; set; }
        public MaterialDto Material { get; set; }
        public Bitmap Preview { get; set; }

    }
}
