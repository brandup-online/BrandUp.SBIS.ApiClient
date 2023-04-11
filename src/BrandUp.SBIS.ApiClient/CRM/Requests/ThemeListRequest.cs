using BrandUp.SBIS.ApiClient.CRM.Attributes;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    [RpcCommandInfo(Command = "CRMTheme.GetList", RootName = "Param")]
    public class ThemeListRequest
    {
        public bool? HideDeleted { get; set; }
        public bool? WithGroup { get; set; }
        public string[] CalcCol { get; set; }
    }
}
