﻿using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Responses
{
    public class LeadInfoResponse
    {
        /// <summary>
        /// UUID документа
        /// </summary>
        [JsonPropertyName("ИдентификаторДокумента")]
        public string DocumentUUID { get; set; }
        /// <summary>
        /// Идентификатор документа в локальной схеме
        /// </summary>
        [JsonPropertyName("@Документ")]
        public int LocalDocumentID { get; set; }
        /// <summary>
        /// Флаг, который определяет, что сделка новая или уже находится в обработке
        /// </summary>
        [JsonPropertyName("Активность")]
        public bool IsActive { get; set; }
        /// <summary>
        /// Результат, с которым завершилась обработка сделки
        /// </summary>
        [JsonPropertyName("Результат")]
        public bool ProcessingResult { get; set; }
        /// <summary>
        /// Комментарий из последнего события по сделке, либо комментарий из самой сделки
        /// </summary>
        [JsonPropertyName("ПоследнийКомментарий")]
        public string LastComment { get; set; }
        /// <summary>
        /// Дата и время последнего события
        /// </summary>
        [JsonPropertyName("ДатаКомментария")]
        public DateTime CommentDate { get; set; }
        /// <summary>
        /// UUID пользователя, который создал последнее событие
        /// </summary>
        [JsonPropertyName("АвторКомментария")]
        public string CommentAuthorUUID { get; set; }
        /// <summary>
        /// Текст ошибки, если запрос не был выполнен
        /// </summary>
        [JsonPropertyName("Ошибка")]
        public string Error { get; set; }
        /// <summary>
        /// Результат выполнения запроса. Возможные значения: «fail» — если в процессе поиска получили ошибку, «success» — если документ найден
        /// </summary>
        [JsonPropertyName("Статус")]
        public string Status { get; set; }
    }
}