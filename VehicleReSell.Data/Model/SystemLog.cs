using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public class SystemLog : BaseModel
{
    public long Id { get; set; }

    public int? UserId { get; set; }

    public string OldRecord { get; set; } = string.Empty;

    public string NewRecord { get; set; } = string.Empty;

    public string RecordType { get; set; } = string.Empty;

}
