var httpClient = new HttpClient();

//var parameters = new Dictionary<string, string>()
//{
//    { "id", "173" },
//    {"withPrices", "true" },
//    { "product", "retail" }
//};

//try
//{
//    var response = await client.GetAsync<SalesPointResponse>("retail/point/list", parameters, default);
//    Console.WriteLine(response);

//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//var priceList = await client.GetAsync<string>("/retail/nomenclature/price-list", new Dictionary<string, string>() { { "pointId", "173" }, { "actualDate", "2023-04-07" } }, default);
//Console.WriteLine(priceList);

//var company = await client.GetAsync<string>("/retail/company/list", new Dictionary<string, string>(), default);
//Console.WriteLine(company);

//var warehouse = await client.GetAsync<string>("retail/company/warehouses", new Dictionary<string, string>() { { "companyId", "173" } }, default);
//Console.WriteLine(warehouse);

Console.ReadKey();
