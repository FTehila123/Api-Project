namespace chineseAction.Services.Logger
{
    public class FileLoggerService : ILoggerService
    {
        private string _filePath;

        public FileLoggerService(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(string message,string path)
        {
            try
            {
                _filePath = path;
                using (StreamWriter writer = new StreamWriter(_filePath, append: true))
                {
                    writer.WriteLine($"{DateTime.Now}:{message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"failed to log message: {ex.Message}");
            }
        }
    }
}
