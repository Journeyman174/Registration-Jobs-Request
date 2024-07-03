using Ardalis.SmartEnum;
using Ardalis.SmartEnum.SystemTextJson;
using System.Text.Json.Serialization;

namespace MobyLabWebProgramming.Core.Enums;

/// <summary>
/// This is and example of a smart enum, you can modify it however you see fit.
/// Note that the class is decorated with a JsonConverter attribute so that it is properly serialized as a JSON.
/// </summary>
[JsonConverter(typeof(SmartEnumNameConverter<DosarStareEnum, string>))]
public sealed class DosarStareEnum : SmartEnum<DosarStareEnum, string>
{
    public static readonly DosarStareEnum Activ = new(nameof(Activ), "Activ");
    public static readonly DosarStareEnum Incetat = new(nameof(Incetat), "Incetat");
    private DosarStareEnum(string name, string value) : base(name, value)
    {
    }
}
