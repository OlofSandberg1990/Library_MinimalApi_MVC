﻿namespace LibraryMVC.Models
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public Object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}
