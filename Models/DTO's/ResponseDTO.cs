﻿namespace MoviesAPIS.Models.DTO_s
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; } = true;

        public object? Data { get; set; }

        public string? DisplayMessage { get; set; }

        public List<string>? ErrorMessages { get; set; }
    }
}
