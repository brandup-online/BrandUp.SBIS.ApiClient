using BrandUp.SBIS.ApiClient.EDM.Models;

namespace BrandUp.SBIS.ApiClient.EDM
{
    public static class DocumentBuilder
    {
        public static Document CheckFromLead(Guid leadId)
        {
            return new()
            {
                //Id = Guid.NewGuid().ToString(),
                Type = "СчетИсх",
                Regulation = new()
                {
                    Id = "bccdc2e6-7fd6-11e2-aa7a-d79063093e8a",
                    Name = "Счет"
                },
                DocumentBase = new InnerArray[]
                {
                    new()
                    {
                        Inner = new()
                        {
                            Id = leadId.ToString()
                        }
                    }
                }
            };
        }
    }
}
