namespace HomeSimulation.Utilities.Image
{
    public static class FileUploadExtensions
    {
        public static string SaveImage(this IFormFile file,IWebHostEnvironment env,string folder)
        {
            string path=Path.Combine(env.WebRootPath,folder);
            string filename=Guid.NewGuid().ToString()+file.FileName;
            string fullpath=Path.Combine(path,filename);

            using(FileStream stream =new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return filename;
        }
    }
}
