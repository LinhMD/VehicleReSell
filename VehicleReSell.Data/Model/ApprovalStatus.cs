using System.Text.Json.Serialization;

namespace VehicleReSell.Data.Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApprovalStatus
{
    Open,
    PendingApproval,
    Approved,
    Reject
}
