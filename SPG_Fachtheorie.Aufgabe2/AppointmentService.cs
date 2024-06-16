using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG_Fachtheorie.Aufgabe2
{
    public class AppointmentService
    {
        private readonly AppointmentContext _db;
        private Guid userId;

        public AppointmentService(AppointmentContext db)
        {
            _db = db;
        }

        public bool AskForAppointment(Guid offerId, Guid studentId, DateTime date)
        {
            // TOTO: Implementiere die Methode
            var offer = _db.Offers.FirstOrDefault(o => o.Id == offerId);
            if (offer == null)
            {
                return false;
            }

            // Überprüfen, ob das Datum im Bereich des Angebots liegt
            if (date < offer.From || date > offer.To)
            {
                return false;
            }

            // Neues Appointment erstellen
            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                OfferId = offerId,
                StudentId = studentId,
                Date = date,
                State = AppointmentState.AskedFor
            };

            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return true;
        }

        public bool ConfirmAppointment(Guid appointmentId)
        {
            // TOTO: Implementiere die Methode
            var appointment = _db.Appointments.FirstOrDefault(a => a.Id == appointmentId);
            if (appointment == null)
            {
                return false;
            }

            // Überprüfen, ob der Status geändert werden kann
            if (appointment.State == AppointmentState.Confirmed ||
                appointment.State == AppointmentState.Cancelled ||
                appointment.State == AppointmentState.TookPlace)
            {
                return false;
            }

            // Status auf Confirmed setzen
            appointment.State = AppointmentState.Confirmed;
            _db.SaveChanges();
            return true;
        }

        public bool CancelAppointment(Guid appointmentId, Guid studentId)
        {
            // TOTO: Implementiere die Methode
            var appointment = _db.Appointments.Include(a => a.Offer).ThenInclude(o => o.Teacher).FirstOrDefault(a => a.Id == appointmentId);
            if (appointment == null)
            {
                return false;
            }

            // Überprüfen, ob der Benutzer der Coach oder der Student ist
            bool isCoach = appointment.Offer.TeacherId == userId;
            bool isStudent = appointment.StudentId == userId;

            // Überprüfen, ob der Termin abgesagt werden kann
            if (isStudent && appointment.State == AppointmentState.AskedFor)
            {
                appointment.State = AppointmentState.Cancelled;
                _db.SaveChanges();
                return true;
            }

            if (isCoach && (appointment.State == AppointmentState.AskedFor || appointment.State == AppointmentState.Confirmed))
            {
                appointment.State = AppointmentState.Cancelled;
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
