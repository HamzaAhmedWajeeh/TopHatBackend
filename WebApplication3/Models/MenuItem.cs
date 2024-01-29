using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Top_Hat_App.Models;

public partial class MenuItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int? Categoryid { get; set; }

    public int? Qty { get; set; }

    public string? Image { get; set; }

    public string? Image1 { get; set; }

    public string? Image2 { get; set; }

    public string? Image3 { get; set; }

    public string? Image4 { get; set; }

    public string? Image5 { get; set; }
    [NotMapped]
    public IFormFile ImageFile { get; set; }

    [NotMapped]
    public IFormFile ImageFile1 { get; set; }
    [NotMapped]
    public IFormFile ImageFile2 { get; set; }
    [NotMapped]
    public IFormFile ImageFile3 { get; set; }

    [NotMapped]
    public IFormFile ImageFile4 { get; set; }

    [NotMapped]
    public IFormFile ImageFile5 { get; set; }
    [JsonIgnore]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    [JsonIgnore]
    public virtual Category? Category { get; set; }
    [JsonIgnore]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
