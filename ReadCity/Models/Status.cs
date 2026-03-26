using System;
using System.Collections.Generic;

namespace ReadCity.Models;

public partial class Status
{
    public int Id { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
}
