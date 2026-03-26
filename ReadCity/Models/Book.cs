using System;
using System.Collections.Generic;

namespace ReadCity.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Isbn { get; set; } = null!;

    public string NameBook { get; set; } = null!;

    public int IdAuthor { get; set; }

    public int IdGenre { get; set; }

    public int IdPublishingHouse { get; set; }

    public int YearOfPublication { get; set; }

    public int Pages { get; set; }

    public int Copies { get; set; }

    public int Available { get; set; }

    public string Annotation { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();

    public virtual Author Author { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;

    public virtual PublishingHouse PublishingHouse { get; set; } = null!;
}
