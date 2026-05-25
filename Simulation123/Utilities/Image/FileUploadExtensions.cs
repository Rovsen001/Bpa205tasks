using Microsoft.AspNetCore.Routing.Constraints;

namespace Simulation123.Utilities.Image
{
    public static class FileUploadExtensions
    {
        public static string SaveImage(this IFormFile file, IWebHostEnvironment env, string folder)
        {
            string path = Path.Combine(env.WebRootPath, folder);
            string filename = Guid.NewGuid() + file.FileName;
            string fullpath = Path.Combine(path, filename);

            using (FileStream stream = new FileStream(path,FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return filename;
        }
    }
}
