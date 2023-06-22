using CrudApiTemplate.Request;

namespace CrudApiTemplate.Model;

public class SoftDeleteDto<TModel> : UpdateDto, IUpdateRequest<TModel> where TModel : class
{
    public ModelStatus Status { get; } = ModelStatus.Disable;
}
