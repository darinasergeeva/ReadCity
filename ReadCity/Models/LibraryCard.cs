using System;
using System.Collections.Generic;

namespace ReadCity.Models;

public partial class LibraryCard
{
    public int Id { get; set; }

    public string NameLibraryCard { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
