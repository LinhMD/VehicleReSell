using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public abstract class Entity : BaseModel, IOrderAble
{
    public int Id { get; set; }

    public string Name { get; set; }  

    public string Phone { get; set; }  

    public string? Address { get; set; }  

    public EntityType EntityType { get; set; }
    public void ConfigOrderBy()
    {
        SetUpOrderBy<Entity>();
    }
}
