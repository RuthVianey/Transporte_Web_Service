namespace Transporte_Web_Service.Entity
{
    public class ApiResponse<T>
    {
        public bool Ok { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ApiResponse<T> Success(T data, string mensaje = "OK")
        {
            return new ApiResponse<T>
            {
                Ok = true,
                Mensaje = mensaje,
                Data = data
            };
        }

        public static ApiResponse<T> Fail(string mensaje)
        {
            return new ApiResponse<T>
            {
                Ok = false,
                Mensaje = mensaje,
                Data = default
            };
        }
    }
}
