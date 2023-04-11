namespace BrandUp.SBIS.ApiClient.CRM.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class RpcCommandInfoAttribute : Attribute
    {
        public string Command { get; set; }
        public string RootName { get; set; }
    }
}
