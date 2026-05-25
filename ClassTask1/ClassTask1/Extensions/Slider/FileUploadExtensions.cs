namespace ClassTask1.Extensions.Slider
{
    public static class FileUploadExtensions
    {
        public static string Save(this IFormFile file,IWebHostEnvironment env,string fold)
        {
            string path = Path.Combine(env.WebRootPath, fold);
            string filename = Guid.NewGuid() + file.FileName;
            string fullpath=Path.Combine(path, filename);
            using (FileStream stream = new FileStream(fullpath,FileMode.Create)) {
                file.CopyTo(stream);
            }
            return filename;
        }
    }
}
