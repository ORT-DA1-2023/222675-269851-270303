using System;
using System.Collections.Generic;
using System.Drawing;

namespace RenderLogic.DataTransferObjects
{
    public class SceneDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Aperture { get; set; }
        public double[] LookFrom { get; set; }
        public double[] LookAt { get; set; }
        public int Fov { get; set; }
        public DateTime LastRenderizationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public Bitmap Preview { get; set; }
        public List<ModelDto> Models { get; set; } 
    }
}
