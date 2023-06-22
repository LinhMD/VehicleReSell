using CrudApiTemplate.CustomBinding;

namespace CrudApiTemplate.Model;

public class SystemLog
{
    public long Id { get; set; }

    [FromClaim("UserId")]
    public int? User { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public string OldRecord { get; set; } = string.Empty;

    public string NewRecord { get; set; } = string.Empty;

    public string RecordType { get; set; } = string.Empty;

}
