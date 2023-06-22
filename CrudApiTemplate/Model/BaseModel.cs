using System.Linq.Expressions;
using System.Text.Json.Serialization;
using CrudApiTemplate.OrderBy;

namespace CrudApiTemplate.Model;

public class BaseModel
{
    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }
    public ModelStatus Status { get; set; }

    public int? CreateById { get; set; }


    public int? UpdateById { get; set; }


    public int? DeleteById { get; set; }
    public static void SetUpOrderBy<TModel>() where TModel : BaseModel
    {
        Expression<Func<TModel, DateTime?>> createAt = m => m.CreateAt;
        Expression<Func<TModel, DateTime?>> updateAt = m => m.UpdateAt;
        Expression<Func<TModel, DateTime?>> deleteAt = m => m.DeleteAt;
        Expression<Func<TModel, ModelStatus>> orderByStatus = m => m.Status;
        Expression<Func<TModel, int?>> createBy = m => m.CreateById;
        Expression<Func<TModel, int?>> updateBy = m => m.UpdateById;
        Expression<Func<TModel, int?>> deleteBy = m => m.DeleteById;
        var orderFields = new List<(string, dynamic)>()
        {
            (nameof(CreateAt), createAt),
            (nameof(UpdateAt), updateAt),
            (nameof(DeleteAt), deleteAt),
            (nameof(Status), orderByStatus),
            (nameof(CreateById), createBy),
            (nameof(UpdateById), updateBy),
            (nameof(DeleteById), deleteBy)
        };
        foreach (var (name, expression) in orderFields)
        {
            OrderByProvider<TModel>.OrderByDic.Add(name, expression);
        }
    }

}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ModelStatus
{
    Active,
    Disable
}