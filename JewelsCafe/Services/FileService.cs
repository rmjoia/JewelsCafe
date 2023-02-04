using JewelsCafe.Models;
using Microsoft.Extensions.Logging;
using System.Text;
#if WINDOWS
using Windows.Storage.Pickers;
#endif


namespace JewelsCafe.Services
{
    public class FileService
    {
        private readonly ILogger<FileService> _logger;

        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }

        public async Task<string> SaveToFileAsync(Order order)
        {
            var date = DateOnly.FromDateTime(DateTime.Now);

            string targetFileName = $"JewelsCaffe_{date.ToString("dd_MM_yyyy")}_{DateTime.Now.Ticks}.txt";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"        Jewels Caffe         ");
            sb.AppendLine($"        {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}         ");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine($"Name: {order.CustomerName}");
            sb.AppendLine($"Telephone Number: {order.CustomerPhoneNumber}");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine($"Order Items");
            sb.AppendLine("________________________________________________________");

            foreach (var item in order.OrderItems)
            {
                sb.AppendLine();
                sb.Append($"Item: {item.Food.Name}      ");
                sb.Append($"Quantity: {item.Quantity}       ");
                sb.AppendLine($"Price uty: {item.Food.Price}      x      Price: {item.Food.Price * item.Quantity}");
            }

            sb.AppendLine("________________________________________________________");
            sb.AppendLine("________________________________________________________");
            sb.AppendLine();
            sb.AppendLine($"Total: {order.OrderItems.Sum(items => items.Food.Price * items.Quantity)}");


            string folder = "";

#if WINDOWS

            var folderPicker = new FolderPicker();

            folderPicker.FileTypeFilter.Add("*");

            var hwnd = ((MauiWinUIWindow)Application.Current.Windows[0].Handler.PlatformView).WindowHandle;

            WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

            var path = await folderPicker.PickSingleFolderAsync();

            folder = path.Path;
#else
            folder = FileSystem.Current.AppDataDirectory;
#endif

            string targetFile = System.IO.Path.Combine(folder, targetFileName);

            try
            {

                using FileStream outputStream = File.OpenWrite(targetFile);
                using StreamWriter streamWriter = new(outputStream);

                await streamWriter.WriteAsync(sb.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex.Message);
            }

            return targetFile;
        }
    }
}
