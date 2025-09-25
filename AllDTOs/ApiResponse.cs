namespace onlatn_tv_project.AllDTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public T? Data { get; set; }
        public IDictionary<string, object>? Meta { get; set; }
    }
}
