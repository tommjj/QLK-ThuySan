namespace QL_ThuySan.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TTPhieuNhap")]
    public partial class TTPhieuNhap
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_pn { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_ts { get; set; }

        public int so_luong { get; set; }

        [Column(TypeName = "money")]
        public decimal gia_nhap { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }

        public virtual ThuySan ThuySan { get; set; }
    }
}
