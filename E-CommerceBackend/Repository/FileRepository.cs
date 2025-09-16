using E_CommerceBackend.Repository.IRepository;

namespace E_CommerceBackend.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileRepository(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string subfolder)
        {
            //webroot with subfolder => wwwroot/images/products
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, subfolder);

            if(!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            //creating unique file names
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(uploadPath, uniqueFileName);

            //saving the file
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Path.Combine(uploadPath, uniqueFileName).Replace("\\", "/");
        }
    }
}
