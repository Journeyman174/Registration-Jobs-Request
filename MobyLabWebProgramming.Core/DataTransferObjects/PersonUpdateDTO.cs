namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class PersonUpdateDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Initials { get; set; }
    public int Age { get; set; }
}
