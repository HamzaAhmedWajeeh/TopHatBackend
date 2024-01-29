using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Top_Hat_App.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int? Userid { get; set; }

    public string Feedbacktext { get; set; } = null!;

    public DateTime? Submissiondate { get; set; }
    [JsonIgnore]
    public virtual User? User { get; set; }
}
