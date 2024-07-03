using Ardalis.SmartEnum;
using Ardalis.SmartEnum.SystemTextJson;
using System.Text.Json.Serialization;

namespace MobyLabWebProgramming.Core.Enums;

/// <summary>
/// This is and example of a smart enum, you can modify it however you see fit.
/// Note that the class is decorated with a JsonConverter attribute so that it is properly serialized as a JSON.
/// </summary>
[JsonConverter(typeof(SmartEnumNameConverter<OlmStareEnum, string>))]
public sealed class OlmStareEnum : SmartEnum<OlmStareEnum, string>
{
    public static readonly OlmStareEnum Activ = new(nameof(Activ), "Activ");
    public static readonly OlmStareEnum Expirat = new(nameof(Expirat), "Expirat");
    private OlmStareEnum(string name, string value) : base(name, value)
    {
    }
}
