using System;
using System.ComponentModel.DataAnnotations;

namespace SPG_Fachtheorie.Aufgabe2.Model
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid OfferId { get; set; }
        public Offer Offer { get; set; } = default!;
        public Guid StudentId { get; set; }
        public Student Student { get; set; } = default!;
        public DateTime Date { get; set; }
        public string? Location { get; set; }
        public AppointmentState State { get; set; }
    }
}
