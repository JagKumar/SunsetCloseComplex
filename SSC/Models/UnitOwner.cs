using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace SSC.Models;

public partial class UnitOwner
{
   
    public int Id { get; set; }

    [Key]
    public int UnitNo { get; set; }

    [StringLength(100)]
    public string? OwnerName { get; set; }

    [StringLength(50)]
    public string? ContactNo { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    
    public string? IsResidentInComplex { get; set; }

    
    
}
