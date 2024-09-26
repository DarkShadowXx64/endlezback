//using Core.Interfaces;
//using Microsoft.AspNetCore.Http;


//namespace Business.Service
//{
//    public class BufferedFileUploadLocalService : IBufferedFileUploadService
//    {
//        public async Task<string> UploadFile(IFormFile file, string route = "UploadedFiles")
//        {
//            string path = "";
//            try
//            {
//                if (file.Length > 0)
//                {
//                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, route));

//                    if (!Directory.Exists(path))
//                    {
//                        Directory.CreateDirectory(path);
//                    }
//                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
//                    {
//                        await file.CopyToAsync(fileStream);
//                        path = "/" + route + "/" + file.FileName;
//                    }
//                }

//            }
//            catch (Exception ex)
//            {
//                throw new Exception("File Copy Failed", ex);
//            }
//            return path;
//        }
//    }
//}