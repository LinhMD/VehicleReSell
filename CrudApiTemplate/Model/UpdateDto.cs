
using CrudApiTemplate.CustomBinding;

namespace CrudApiTemplate.Model;

public class UpdateDto : IDto
{
    public DateTime UpdateAt { get; } = DateTime.Now;

    [FromClaim("UserId")]
    public int UpdateBy { get; set; }

    public virtual void InitMapper()
    {
    }
}