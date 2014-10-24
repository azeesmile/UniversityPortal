

namespace UniversityPortal.Common
{
    public static class Constants
    {
        public const string RegNumberPattern = "^\\d{4}-[A-Z]{3,4}-[A-Z]{2,4}-[A-Z]{2,4}-\\d{1,3}$";

        public static int[] isApproved = new[] {0, 1};
        public static int[] JobType = new[] {4, 8};

        #region Dummy Data

        public static string[] EventRoles = new[] { "Students", "Teachers", "Staff", "All" };

        #endregion
    }
}