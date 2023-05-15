using Serilog;

namespace demoWinForm6
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose() // �]�w�̧C��ܼh��   �w�]: Information
                .WriteTo.Debug() // ��X�� ���O����
                .WriteTo.File("log-.log",
                    rollingInterval: RollingInterval.Day, // �C�Ѥ@���ɮ�
                    outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u5}] {Message:lj}{NewLine}{Exception}"
                ) // ��X���ɮ� �ɦW�d��: log-20211005.log
                .CreateLogger();

            Log.Information("Init Ruyut");

            Log.Debug("debug");

            int i = 1;
            Log.Debug("i={i}", i);

            string s = "test string";
            Log.Debug("s={s}", s);

            

            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new frmSplash(true));
            Application.Run(new Form4());

            //try
            //{
            //    throw new Exception("throw test exception");
            //}
            //catch (Exception e)
            //{
            //    Log.Error("catch exception:{exception}", e);
            //}

            Log.CloseAndFlush();
        }
    }
}