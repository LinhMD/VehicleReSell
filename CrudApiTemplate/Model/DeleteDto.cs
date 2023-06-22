
namespace CrudApiTemplate.Model;

public class DeleteDto : IDto
{
    public DateTime DeleteAt { get; } = DateTime.Now;

    public ModelStatus Status { get; } = ModelStatus.Disable;

    public virtual void InitMapper()
    {
    }
}