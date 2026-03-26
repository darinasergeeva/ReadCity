using System;
using System.Collections.Generic;

namespace ReadCity.Models;

public partial class BookLoan
{
    public int Id { get; set; }

    public int IdLibraryCard { get; set; }

    public int IdBooks { get; set; }

    public DateOnly DateOfIssue { get; set; }

    public DateOnly PlannedReturnDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public int IdStatus { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual LibraryCard LibraryCard { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
