using BrandUp.SBIS.ApiClient.CRM.Attributes;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    [CrmRpcCommandInfo(Command = "CRMTheme.GetList", RootName = "Param")]
    public class ThemeListRequest
    {
        /// <summary>
        /// Скрывать удаленные темы, по умолчанию «true»
        /// </summary>
        public bool? HideDeleted { get; set; }
        /// <summary>
        /// Показывать папки, по умолчанию «true»
        /// </summary>
        public bool? WithGroup { get; set; }
        /// <summary>
        /// Список дополнительно вычисляемых колонок
        /// </summary>
        public string[] CalcCol { get; set; }
    }
}
