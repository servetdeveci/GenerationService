using System;
using System.Collections.Generic;
using System.Text;

namespace PowerPlant.Domain.ViewModels
{
    public class ApiResponse<T> where T : class
    {
        public bool Status { get; set; }
        public string StatusMessage { get; set; }
        public T Data { get; set; }
    }
}
