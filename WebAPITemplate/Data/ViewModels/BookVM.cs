﻿namespace WebAPITemplate.Data.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public bool isRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rating { get; set; }
        public string CoverUrl { get; set; }
    }
}