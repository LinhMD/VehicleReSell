namespace VehicleReSell.Data.Model;

public class VehicleImg
{
    public int Id { get; set; }

    public Vehicle? Vehicle { get; set; }
    
    public int? VehicleId { get; set; }

    public string Image { get; set; }
}