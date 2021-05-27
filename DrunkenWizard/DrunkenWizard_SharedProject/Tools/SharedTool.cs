using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DrunkenWizard_SharedProject.Tools
{
    public static class SharedTool
    {
        public const string SESSION_STARTED = "Session started";
        public const string SESSION_PAUSED = "Session paused";
        public const string SESSION_RESUMED = "Session resumed";

        public static Dictionary<string, string> GetAppCenterDetails()
        {
            // brug til at sende info til analytics, som f.eks brugernavn
            //if (!Dms.IsInitialized)
            return new Dictionary<string, string>();

            //return new Dictionary<string, string>
            //    {
            //        { "Employee", Dms.LoggedInUser?.EmployeeId },
            //        { "User Name", Dms.LoggedInUser?.EmployeeName},
            //        { "Enrollment", Dms.ServiceHeader.EnrollmentKey}
            //    };
        }

        [Conditional("DEBUG")]
        public static void WriteExceptionMessagesToOutputBox(Exception e)
        {
            List<string> exceptions = e.GetExceptionMessagesAsList();

            Debug.WriteLine("=> An exception was thrown:");
            foreach (var errMsg in exceptions)
            {
                Debug.WriteLine("+ " + errMsg);
            }
        }

        public static List<string> GetExceptionMessagesAsList(this Exception ex)
        {
            List<string> exceptions = new List<string>();

            while (ex != null)
            {
                exceptions.Add(ex.Message);
                ex = ex.InnerException;
            }
            return exceptions;
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
