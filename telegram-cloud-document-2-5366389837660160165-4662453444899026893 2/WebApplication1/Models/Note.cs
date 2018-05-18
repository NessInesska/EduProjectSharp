using System;

namespace WebApplication1.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
    }
}