﻿namespace Domain.Response
{
    public class ErrorResponse
    {
        public bool Success { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; }
    }
}
