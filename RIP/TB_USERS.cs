namespace RIP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_USERS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CL_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string CL_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string CL_LOGIN { get; set; }

        [Required]
        [StringLength(50)]
        public string CL_PASSWORD { get; set; }

        public int CL_IdCOMPANY { get; set; }

        public virtual TB_COMPANY TB_COMPANY { get; set; }
    }
}
