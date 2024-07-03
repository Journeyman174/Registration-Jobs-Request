namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class PersonAddDTO
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Initials { get; set; }
    public int Age { get; set; }
}
