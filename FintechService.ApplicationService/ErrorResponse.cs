using System.Collections.Generic;
using System.Diagnostics;

namespace FintechService.ApplicationService
{
    public class ErrorResponse
    {
        public List<ErrorData> Errors { get; set; }
    }
    public class ErrorData
    {
        public string FieldName { get; set; }
        public string Message { get; set; }

    }
}