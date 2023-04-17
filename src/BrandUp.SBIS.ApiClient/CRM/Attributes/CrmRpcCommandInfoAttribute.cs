using BrandUp.SBIS.ApiClient.Base.Attributes;

namespace BrandUp.SBIS.ApiClient.CRM.Attributes
{
    internal class CrmRpcCommandInfoAttribute : RpcCommandInfoAttribute
    {
        public bool WithOptions { get; set; } = false;
    }
}
