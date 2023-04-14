namespace BrandUp.SBIS.ApiClient.CRM.Responses
{
    public class AddEventResponse
    {
        public int EventId { get; set; }
        ///// <summary>
        ///// UUID документа
        ///// </summary>
        //[JsonPropertyName("ИдентификаторДокумента")]
        //public Guid DocumentId { get; set; }

        ///// <summary>
        ///// Идентификатор документа в локальной схеме
        ///// </summary>
        //[JsonPropertyName("@Документ")]
        //public int LocalDocumentId { get; set; }

        ///// <summary>
        ///// Флаг, который определяет, что сделка новая или уже находится в обработке
        ///// </summary>
        //[JsonPropertyName("Активность")]
        //public bool IsActive { get; set; }

        ///// <summary>
        ///// Результат, с которым завершилась обработка сделки
        ///// </summary>
        //[JsonPropertyName("Результат")]
        //public bool Result { get; set; }

        ///// <summary>
        ///// Комментарий из последнего события по сделке или из самой сделки
        ///// </summary>
        //[JsonPropertyName("ПоследнийКомментарий")]
        //public string LastComment { get; set; }

        ///// <summary>
        ///// Дата и время последнего события
        ///// </summary>
        //[JsonPropertyName("ДатаКомментария")]
        //public DateTime CommentDateTime { get; set; }

        ///// <summary>
        ///// UUID пользователя, который создал последнее событие
        ///// </summary>
        //[JsonPropertyName("АвторКомментария")]
        //public Guid CommentAuthorId { get; set; }

        ///// <summary>
        ///// Текст ошибки, если запрос не был выполнен
        ///// </summary>
        //[JsonPropertyName("Ошибка")]
        //public string Error { get; set; }

        ///// <summary>
        ///// Результат выполнения запроса. Возможные значения: «fail» — если в процессе поиска получили ошибку, 
        ///// «success» — если документ найден
        ///// </summary>
        //[JsonPropertyName("Статус")]
        //public string Status { get; set; }
    }
}
