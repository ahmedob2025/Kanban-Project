namespace PresentationLayer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 👇 استدعِ الدالة من DAL، واحصل على النص، ثم اعرضه بـ MessageBox
            string result = DataAccessLayer.DatabaseHelper.TestConnection();
            MessageBox.Show(result, "نتيجة اختبار قاعدة البيانات");

            // بعد الاختبار، افتح الفورم الأساسي (علّق عليه حتى تتأكد من نجاح الاختبار)
            // Application.Run(new Forms.LoginForm());
        }
    }
}