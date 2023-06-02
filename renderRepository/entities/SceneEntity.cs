using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renderRepository.entities
{
    public class SceneEntity
    {
        [Key]
        public int Id { get; set; }
        public ClientEntity Client { get; set; }
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime? LastRenderizationDate { get; set; }
        public virtual ICollection<ModelEntity> ModelEntities { get; set; }
       // public Bitmap Preview {get; set; }

        //Camera
    }
}
