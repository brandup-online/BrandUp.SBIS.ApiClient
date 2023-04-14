namespace BrandUp.SBIS.ApiClient.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class RpcCommandInfoAttribute : Attribute
    {
        public string Command { get; set; }
        public string RootName { get; set; }
    }
}
