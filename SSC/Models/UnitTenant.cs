using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace SSC.Models
{
    public class UnitTenant
    {
        [Key]
        public int UnitNo { get; set; }

        [StringLength(100)]
        public string? TenantName { get; set; }
        [StringLength(100)]
        public string? TenantSurname { get; set; }
        

        [StringLength(50)]
        public string? TenantContactNo { get; set; }

        [StringLength(100)]
        public string? TenantEmail { get; set; }
        [StringLength(100)]
        public string? NoOfPersonsStaying { get; set; }

        


    }
}
