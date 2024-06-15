using System;
using System.Collections.Generic;

namespace SPG_Fachtheorie.Aufgabe2.Model
{
    public class Offer 
    { 
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public Coach Teacher { get; set; } = default!;
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; } = default!;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public List<Appointment> Appointments { get; set; } = new();

    }
}
