using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SPG_Fachtheorie.Aufgabe2;
using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe2.Model;

namespace SPG_Fachtheorie.Aufgabe2.Test
{
    [Collection("Sequential")]
    public class AppointmentServiceTests
    {
        /// <summary>
        /// Legt die Datenbank an und befüllt sie mit Musterdaten. Die Datenbank ist
        /// nach Ausführen des Tests ServiceClassSuccessTest in
        /// SPG_Fachtheorie\SPG_Fachtheorie.Aufgabe2.Test\bin\Debug\net6.0\Appointment.db
        /// und kann mit SQLite Manager, DBeaver, ... betrachtet werden.
        /// </summary>
        private AppointmentContext GetAppointmentContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite("Data Source=Appointment.db")
                .Options;

            var db = new AppointmentContext(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            db.Seed();
            return db;
        }
        [Fact]
        public void ServiceClassSuccessTest()
        {
            using var db = GetAppointmentContext();
            Assert.True(db.Students.Count() > 0);
            var service = new AppointmentService(db);
        }
        [Fact]
        public void AskForAppointmentSuccessTest()
        {
            using var db = GetAppointmentContext();
            var service = new AppointmentService(db);

            var offer = db.Offers.First();
            var student = db.Students.First();
            var date = offer.From.AddDays(1);

            var result = service.AskForAppointment(offer.Id, student.Id, date);

            Assert.True(result);
            Assert.Contains(db.Appointments, a => a.OfferId == offer.Id && a.StudentId == student.Id && a.Date == date);
        }
        [Fact]
        public void AskForAppointmentReturnsFalseIfNoOfferExists()
        {
            using var db = GetAppointmentContext();
            var service = new AppointmentService(db);

            var student = db.Students.First();
            var result = service.AskForAppointment(Guid.NewGuid(), student.Id, DateTime.Now);

            Assert.False(result);
        }
        [Fact]
        public void AskForAppointmentReturnsFalseIfOutOfDate()
        {
            using var db = GetAppointmentContext();
            var service = new AppointmentService(db);

            var offer = db.Offers.First();
            var student = db.Students.First();
            var date = offer.From.AddDays(-1);

            var result = service.AskForAppointment(offer.Id, student.Id, date);

            Assert.False(result);
        }
        [Fact]
        public void ConfirmAppointmentSuccessTest()
        {
            using var db = GetAppointmentContext();
            var service = new AppointmentService(db);

            var appointment = db.Appointments.First(a => a.State == AppointmentState.AskedFor);
            var result = service.ConfirmAppointment(appointment.Id);

            Assert.True(result);
            Assert.Equal(AppointmentState.Confirmed, db.Appointments.First(a => a.Id == appointment.Id).State);
        }
        [Fact]
        public void ConfirmAppointmentReturnsFalseIfStateIsInvalid()
        {
            using var db = GetAppointmentContext();
            var service = new AppointmentService(db);

            var invalidStates = new[] { AppointmentState.Confirmed, AppointmentState.Cancelled, AppointmentState.TookPlace };
            var appointment = db.Appointments.First(a => invalidStates.Contains(a.State));

            var result = service.ConfirmAppointment(appointment.Id);

            Assert.False(result);
        }
        [Fact]
        public void CancelAppointmentStudentSuccessTest()
        {
            using var db = GetAppointmentContext();
            var service = new AppointmentService(db);

            var appointment = db.Appointments.First(a => a.State == AppointmentState.AskedFor);
            var result = service.CancelAppointment(appointment.Id, appointment.StudentId);

            Assert.True(result);
            Assert.Equal(AppointmentState.Cancelled, db.Appointments.First(a => a.Id == appointment.Id).State);
        }
        [Fact]
        public void CancelAppointmentCoachSuccessTest()
        {
            using var db = GetAppointmentContext();
            var service = new AppointmentService(db);

            var appointment = db.Appointments.First(a => a.State == AppointmentState.AskedFor || a.State == AppointmentState.Confirmed);
            var result = service.CancelAppointment(appointment.Id, appointment.Offer.TeacherId);

            Assert.True(result);
            Assert.Equal(AppointmentState.Cancelled, db.Appointments.First(a => a.Id == appointment.Id).State);
        }

        [Fact]
        public void ConfirmAppointmentStudentReturnsFalseIfStateIsInvalid()
        {
            using var db = GetAppointmentContext();
            var service = new AppointmentService(db);

            var invalidStates = new[] { AppointmentState.Confirmed, AppointmentState.Cancelled, AppointmentState.TookPlace };
            var appointment = db.Appointments.First(a => invalidStates.Contains(a.State));
            var result = service.ConfirmAppointment(appointment.Id);

            Assert.False(result);
        }
        [Fact]
        public void ConfirmAppointmentCoachReturnsFalseIfStateIsInvalid()
        {
            using var db = GetAppointmentContext();
            var service = new AppointmentService(db);

            var invalidStates = new[] { AppointmentState.Confirmed, AppointmentState.Cancelled, AppointmentState.TookPlace };
            var appointment = db.Appointments.First(a => invalidStates.Contains(a.State));
            var result = service.ConfirmAppointment(appointment.Id);

            Assert.False(result);
        }
    }
}
