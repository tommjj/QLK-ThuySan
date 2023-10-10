namespace QL_ThuySan.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TTPhieuXuat")]
    public partial class TTPhieuXuat
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_px { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_ts { get; set; }

        public int so_luong { get; set; }

        [Column(TypeName = "money")]
        public decimal gia_xuat { get; set; }

        public virtual PhieuXuat PhieuXuat { get; set; }

        public virtual ThuySan ThuySan { get; set; }
    }
}
