using System;
using System.Collections.Generic;

namespace ReadCity.Models;

public partial class PublishingHouse
{
    public int Id { get; set; }

    public string NamePublishingHouse { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
