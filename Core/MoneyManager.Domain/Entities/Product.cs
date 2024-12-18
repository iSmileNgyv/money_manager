﻿using System.ComponentModel.DataAnnotations;
using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Domain.Entities;

public class Product : BaseEntity
{
     [MaxLength(100)]
     public required string Name { get; set; }
     [MaxLength(1000)]
     public required string Image { get; set; }
     [MaxLength(2000)]
     public string? Description { get; set; }
     public required Guid CategoryId { get; set; }
     public ProductCategory? Category { get; set; }
}