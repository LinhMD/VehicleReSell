using CrudApiTemplate.CustomBinding;

namespace CrudApiTemplate.Model;

public class SystemLog
{
    public long Id { get; set; }

    [FromClaim("UserId")]
    public int? User { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public string OldRecord { get; set; }  

    public string NewRecord { get; set; }  

    public string RecordType { get; set; }  

}
