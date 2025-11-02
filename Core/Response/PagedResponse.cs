using System.Text.Json.Serialization;
using Core.ValueObjects.ResponseVO;
using Core.Configs;

namespace Core.Response;

public class PagedResponse<TData> : Responses<TData>
{
    [JsonConstructor]
    public PagedResponse
    (TData data,
        int totalCount,
        int currentPage = 1,
        int pageSize = Configuration.PageSize) : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
    
    public PagedResponse
    (TData data,
        string message,
        Code code):base(data,message,code)
    {
    }


    public int CurrentPage { get; set; }
    public int PageSize { get; set; } = Configuration.PageSize;
    public int TotalPage=> (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int TotalCount { get; set; }
}