namespace PolicyAPI.Service
{
    public interface IQuotesExternalService
    {
        public int GetQuote(int BusinessValue, int PropertyValue, string authtoken);

    }
}
