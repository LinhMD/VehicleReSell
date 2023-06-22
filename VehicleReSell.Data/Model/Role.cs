using System.Text.Json.Serialization;

namespace VehicleReSell.Data.Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Role
{
    Admin,
    Assessor,
    Seller,
    Staff
}
