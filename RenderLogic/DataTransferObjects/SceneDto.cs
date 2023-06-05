using System;
using System.Collections.Generic;
using System.Drawing;

namespace RenderLogic.DataTransferObjects
{
    public class SceneDto
    {
        public string Name { get; set; }
        public int Aperture { get; set; }
        public int[] LookFrom { get; set; }
        public int[] LookAt { get; set; }
        public int Fov { get; set; }
        public DateTime LastRenderizationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public Bitmap Preview { get; set; }
        public List<ModelDto> Models { get; set; } 
    }
}
