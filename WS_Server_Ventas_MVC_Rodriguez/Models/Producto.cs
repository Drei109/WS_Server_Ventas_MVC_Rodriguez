namespace WS_Server_Ventas_MVC_Rodriguez.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            DetallePedido = new HashSet<DetallePedido>();
        }

        [Key]
        public int producto_id { get; set; }

        public int categoria_id { get; set; }

        [Required]
        [StringLength(150)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        public decimal precio { get; set; }

        public int stock { get; set; }

        [StringLength(250)]
        public string imagen { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
}
