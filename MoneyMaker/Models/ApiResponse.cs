using System.ComponentModel.DataAnnotations;

namespace MoneyMaker.Models
{
    public class ApiResponse
    {
        public string? Code { get; set; }

        public Dictionary<string, object>? Data { get; set; }

        public ApiResponse()
        {
            Data = new Dictionary<string, object>();
        }
    }
}