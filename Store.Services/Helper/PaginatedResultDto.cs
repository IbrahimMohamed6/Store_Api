

using Azure;

namespace Store.Services.Helper
{
    public class PaginatedResultDto<T>
    {
        public PaginatedResultDto(int pageIndex, int pageISize, int totalCount, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageISize = pageISize;
            TotalCount = totalCount;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageISize { get; set; }
        public int TotalCount { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
