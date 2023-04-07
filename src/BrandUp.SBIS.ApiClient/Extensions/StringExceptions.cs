namespace BrandUp.SBIS.ApiClient.Extensions
{
    public static class StringExceptions
    {
        public static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            if (value.Length == 1) return value.ToLower();

            return value[..1].ToLower() + value[1..];
        }
    }
}
