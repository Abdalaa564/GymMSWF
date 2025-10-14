using System.IO.Packaging;

namespace GymMSWF
{
    //public static class AppSettings
    //{
    //    public static int FormWidth = 1800; // ????? ??????
    //}

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();



        
            Application.Run(new Dashboard());

          //  Application.Run(new InstructorForm());

        }
    }
}