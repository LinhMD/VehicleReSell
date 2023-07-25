using CrudApiTemplate.Attributes.Update;
using CrudApiTemplate.Repository;

namespace CrudApiTemplate.Request;

public interface IUpdateRequest<TModel> where TModel : class
{
    public bool UpdateModel(ref TModel model, IUnitOfWork work)
    {
        foreach (var updateProperty in GetType().GetProperties())
        {
            var modelProperty = typeof(TModel).GetProperty(updateProperty.Name);
            if (modelProperty is not null)
            {
                var updateIgnores = Attribute.GetCustomAttributes(modelProperty, typeof(UpdateIgnoreAttribute)) as UpdateIgnoreAttribute[] ?? Array.Empty<UpdateIgnoreAttribute>();
                var updateValue = updateProperty.GetValue(this);

                if (updateValue is not null && !updateIgnores.Any())
                    modelProperty?.SetValue(model, updateValue);
            }
        }
        return true;
    }
}