using System.Text.Json.Serialization;

namespace VehicleReSell.Data.Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ItemReceiptStatus
{
    VehicleOwnerOpen,
    WaitingForAssessment,
    Submit,
    Approved,
    Reject
}
