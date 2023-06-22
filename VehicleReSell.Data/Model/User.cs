using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;
public class User : BaseModel
{
    public int Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string Hash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    public Role Role { get; set; }

}