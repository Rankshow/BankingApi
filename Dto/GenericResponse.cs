using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Dto
{
    public class GenericResponse<T>
    {
        public string? Code { set; get; }
        public string? Message { set; get; }
        public T? Result { set; get; }
    }
}