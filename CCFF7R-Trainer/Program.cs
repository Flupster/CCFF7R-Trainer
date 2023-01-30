namespace CCFF7R_Trainer
{
    internal static class Program
    {
        static Form1 MainForm = new Form1();

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(MainForm);
        }
    }
}