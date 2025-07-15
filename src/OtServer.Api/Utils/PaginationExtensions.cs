namespace OtServer.Api.Utils
{
    public static class PaginationExtensions
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }

}
