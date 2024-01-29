using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Top_Hat_App.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int? Userid { get; set; }

    public string Cardnumber { get; set; } = null!;

    public DateTime Expirydate { get; set; }

    public string Cardholdername { get; set; } = null!;
    [JsonIgnore]
    public virtual User IdNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
