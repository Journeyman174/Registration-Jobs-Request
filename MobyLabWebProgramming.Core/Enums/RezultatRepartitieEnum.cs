using Ardalis.SmartEnum;
using Ardalis.SmartEnum.SystemTextJson;
using System.Text.Json.Serialization;

namespace MobyLabWebProgramming.Core.Enums;

/// <summary>
/// This is and example of a smart enum, you can modify it however you see fit.
/// Note that the class is decorated with a JsonConverter attribute so that it is properly serialized as a JSON.
/// </summary>
[JsonConverter(typeof(SmartEnumNameConverter<RezultatRepartitieEnum, string>))]
public sealed class RezultatRepartitieEnum : SmartEnum<RezultatRepartitieEnum, string>
{
    public static readonly RezultatRepartitieEnum Acceptat = new(nameof(Acceptat), "Acceptat");
    public static readonly RezultatRepartitieEnum Respins = new(nameof(Respins), "Respins");

    private RezultatRepartitieEnum(string name, string value) : base(name, value)
    {
    }
}
