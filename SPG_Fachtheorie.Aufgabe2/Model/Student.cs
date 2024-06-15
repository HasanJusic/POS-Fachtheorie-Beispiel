using System;

namespace SPG_Fachtheorie.Aufgabe2.Model
{
    public class Student 
    { 
        public Guid Id { get; set; }
        public string Firstname { get; set; } = default!;
        public string Lastname { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
    }
}
