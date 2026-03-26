using System;
using System.Collections.Generic;

namespace ReadCity.Models;

public partial class User
{
    public int Id { get; set; }

    public int IdRole { get; set; }

    public string FullName { get; set; } = null!;

    public int IdLibraryCard { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual LibraryCard LibraryCard { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
