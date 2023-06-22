using System.Text.Json.Serialization;

namespace VehicleReSell.Data.Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EntityType
{
    Customer,
    VehicleOwner,
    Staff,
    Assessor,
    Seller
}
