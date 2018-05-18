using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public static class Repo
    {
        public static ICollection<Note> Notes { get; } = new HashSet<Note>();

        static Repo()
        {
            Notes.Add(new Note()
            {
                Id = Guid.NewGuid(),
                Text = "Test note",
                Author = "SYSTEM"
            });
        }
    }
}