namespace HomeSimulation3.Utilities.Image
{
    public static class FileUploadExtension
    {
        public static string SaveImage(this IFormFile file, IWebHostEnvironment env, string folder)
        {
            string path = Path.Combine(env.WebRootPath, folder);
            string filename = Guid.NewGuid().ToString() + file.FileName;
            string fullpath = Path.Combine(path, filename);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using (FileStream stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return filename;
        }
    }
}
