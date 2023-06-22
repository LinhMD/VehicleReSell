using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.CustomerDto;

public class CreateCustomer : CreateEntity, ICreateRequest<Customer>
{
    public EntityType EntityType => EntityType.Customer;
}
