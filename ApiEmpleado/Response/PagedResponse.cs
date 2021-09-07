namespace ApiEmpleado.Response
{
    public class PagedResponse<T> : ApiResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int TotalRegistros { get; set; }
        public PagedResponse()
        {
            this.Succeeded = true;
        }
        public PagedResponse(T data, int pageNumber, int pageSize, int totalRegistros)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalRegistros = totalRegistros;
            this.Data = data;
            this.Message = null;
        }
        
    }
}