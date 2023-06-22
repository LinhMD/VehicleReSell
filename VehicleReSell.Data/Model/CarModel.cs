using System.Text.Json.Serialization;

namespace VehicleReSell.Data.Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CarModel
{
    Sedan,
    SUV,
    Truck,
    Micro,
    Van
}
