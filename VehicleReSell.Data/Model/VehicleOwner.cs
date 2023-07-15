using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public class VehicleOwner : Entity, IOrderAble
{
    public new void ConfigOrderBy()
    {
        SetUpOrderBy<VehicleOwner>();
    }
}
