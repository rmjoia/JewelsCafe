using JewelsCafe.Models;
using Microsoft.Extensions.Logging;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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

            string targetFileName = $"JewelsCaffe_{date}_{DateTime.Now.Ticks}.txt";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"        Jewels Caffe         ");
            sb.AppendLine($"        {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}         ");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.Append($"Customer Name: {order.CustomerName}");
            sb.Append($"Customer Telephone Number: {order.CustomerPhoneNumber}");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.Append($"Order Items");
            sb.Append("________________________________________________________");

            foreach (var item in order.OrderItems)
            {
                sb.AppendLine();
                sb.Append($"Item: {item.Food.Name}");
                sb.Append($"Quantity: {item.Quantity}");
                sb.Append($"Price: {item.Price}");
            }

            sb.AppendLine("________________________________________________________");
            sb.AppendLine("________________________________________________________");
            sb.AppendLine();
            sb.AppendLine($"Total: {order.OrderItems.Sum(items => items.Price * items.Quantity)}");


            // Write the file content to the app data directory @"/storage/emulated/0/Documents"
            string targetFile = System.IO.Path.Combine(@"/storage/emulated/0/Download", targetFileName);

            try
            {
                using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
                using StreamWriter streamWriter = new StreamWriter(outputStream);

                await streamWriter.WriteAsync(sb);

                return targetFile;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex.Message);
            }

            return null;
        }
    }
}
