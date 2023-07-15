using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CrudApiTemplate.CustomBinding;

//https://www.davidkaya.com/custom-from-attribute-for-controller-actions-in-asp-net-core/ - found it here
public class FromClaimAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider
{
    public BindingSource BindingSource => ClaimValueProviderFactory.Claim;

    public FromClaimAttribute(string fieldName)
    {
        Name = fieldName;
    }

    public string Name { get; }
}