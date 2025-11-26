using Microsoft.Identity.Client;

namespace CavityDetection.Services
{
    public class RasberyPiService
    {
        DentalCheckUpContext _context;
        public RasberyPiService(DentalCheckUpContext context)
        {
            _context = context;
        }

        public async Task SaveImageData(string username, double confidenceLevel, IFormFile file)
        {
            // 1️⃣ Create folder
            var folderPath = Path.Combine("wwwroot", "uploads");
            Directory.CreateDirectory(folderPath);

            // 2️⃣ Generate file path
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(folderPath, fileName);

            // 3️⃣ Save file to disk
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // 4️⃣ Get user id
            Guid userId = _context.Users
                .Where(u => u.Username == username)
                .Select(u => u.Id)
                .FirstOrDefault();

            // If user not found → handle it
            if (userId == Guid.Empty)
                throw new Exception("User not found!");

            // 5️⃣ Save IMAGE first
            var image = new ImageDbo
            {
                FilePath = filePath
            };

            _context.Images.Add(image);
            await _context.SaveChangesAsync(); // 🔥 ImageId is now valid

            // 6️⃣ Now insert RECORD using valid ImageId
            var record = new RecordDbo
            {
                ConfidenceLevel = confidenceLevel,
                ImageId = image.ImageId,
                UserId = userId
            };

            _context.Records.Add(record);
            await _context.SaveChangesAsync();
        }

    }
}
