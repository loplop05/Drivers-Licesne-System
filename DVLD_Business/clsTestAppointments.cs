using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public static class clsTestAppointments
    {
        public const int VisionTestTypeID = 1;
        public const int WrittenTestTypeID = 2;
        public const int StreetTestTypeID = 3;

        public static DataTable GetStreetAppointments(int localApplicationID) => clsTestAppointmentsData.GetAppointments(StreetTestTypeID, localApplicationID);
        public static int GetPassedTestCount(int localApplicationID) => clsTestAppointmentsData.GetPassedTestCount(localApplicationID);
        public static bool HasActiveStreetAppointment(int localApplicationID) => clsTestAppointmentsData.DoesActiveAppointmentExist(StreetTestTypeID, localApplicationID);
        public static bool HasPassedStreetTest(int localApplicationID) => clsTestAppointmentsData.HasPassedTest(StreetTestTypeID, localApplicationID);
        public static int AddStreetAppointment(int localApplicationID, DateTime appointmentDate, decimal paidFees, int createdByUserID)
        {
            if (localApplicationID <= 0 || createdByUserID <= 0 || appointmentDate.Date < DateTime.Today || HasActiveStreetAppointment(localApplicationID) || HasPassedStreetTest(localApplicationID)) return -1;
            return clsTestAppointmentsData.AddTestAppointment(StreetTestTypeID, localApplicationID, appointmentDate.Date, paidFees, createdByUserID);
        }
        public static bool CompleteStreetAppointment(int appointmentID, bool result, string notes, int userID) => appointmentID > 0 && userID > 0 && clsTestAppointmentsData.CompleteAppointment(appointmentID, result, notes, userID);
        public static bool UpdateStreetAppointmentDate(int appointmentID, DateTime appointmentDate)
        {
            if (appointmentID <= 0 || appointmentDate.Date < DateTime.Today) return false;
            return clsTestAppointmentsData.UpdateAppointmentDate(appointmentID, appointmentDate.Date);
        }

        public static int AddVisionAppointment(int localApplicationID, DateTime appointmentDate, decimal paidFees, int createdByUserID)
        {
            if (localApplicationID <= 0 || createdByUserID <= 0 || appointmentDate.Date < DateTime.Today || HasActiveVisionAppointment(localApplicationID) || HasPassedVisionTest(localApplicationID))
                return -1;
            return clsTestAppointmentsData.AddTestAppointment(VisionTestTypeID, localApplicationID, appointmentDate, paidFees, createdByUserID);
        }

        public static bool HasActiveVisionAppointment(int localApplicationID)
        {
            return clsTestAppointmentsData.DoesActiveAppointmentExist(VisionTestTypeID, localApplicationID);
        }

        public static bool HasPassedVisionTest(int localApplicationID)
        {
            return clsTestAppointmentsData.HasPassedTest(VisionTestTypeID, localApplicationID);
        }

        public static bool HasPassedWrittenTest(int localApplicationID)
        {
            return clsTestAppointmentsData.HasPassedTest(WrittenTestTypeID, localApplicationID);
        }

        public static DataTable GetVisionAppointments(int localApplicationID)
        {
            return clsTestAppointmentsData.GetAppointments(VisionTestTypeID, localApplicationID);
        }

        public static DataTable GetWrittenAppointments(int localApplicationID)
        {
            return clsTestAppointmentsData.GetAppointments(WrittenTestTypeID, localApplicationID);
        }

        public static bool HasActiveWrittenAppointment(int localApplicationID)
        {
            return clsTestAppointmentsData.DoesActiveAppointmentExist(WrittenTestTypeID, localApplicationID);
        }

        public static int AddWrittenAppointment(int localApplicationID, DateTime appointmentDate, decimal paidFees, int createdByUserID)
        {
            if (localApplicationID <= 0 || createdByUserID <= 0 || appointmentDate.Date < DateTime.Today ||
                HasActiveWrittenAppointment(localApplicationID) || HasPassedWrittenTest(localApplicationID))
                return -1;
            return clsTestAppointmentsData.AddTestAppointment(WrittenTestTypeID, localApplicationID, appointmentDate, paidFees, createdByUserID);
        }

        public static bool UpdateVisionAppointmentDate(int appointmentID, DateTime appointmentDate)
        {
            if (appointmentID <= 0 || appointmentDate.Date < DateTime.Today)
                return false;

            return clsTestAppointmentsData.UpdateAppointmentDate(appointmentID, appointmentDate.Date);
        }

        public static bool CompleteVisionAppointment(int appointmentID, bool result, string notes, int userID)
        {
            return appointmentID > 0 && userID > 0 &&
                clsTestAppointmentsData.CompleteAppointment(appointmentID, result, notes, userID);
        }

        public static bool CompleteWrittenAppointment(int appointmentID, bool result, string notes, int userID)
        {
            return appointmentID > 0 && userID > 0 &&
                clsTestAppointmentsData.CompleteAppointment(appointmentID, result, notes, userID);
        }
    }
}
