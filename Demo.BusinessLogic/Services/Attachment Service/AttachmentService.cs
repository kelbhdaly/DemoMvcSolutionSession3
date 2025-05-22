using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Attachment_Service
{
    public class AttachmentService : IAttachmentService
    {
       private List<string> allowExtensions = [".png" , ".jpg" , ".Jpeg"];
       private const  int maxSize = 2_097_152; //1024 * 1024 * 2 
        public string? Upload(IFormFile file, string FolderName)
        {
            //Check Extension
            var extension = Path.GetExtension(file.FileName);
            if (!allowExtensions.Contains(extension)) return null; 
            //Check Size
            if(file.Length ==0 || file.Length > maxSize) return null;

            //Get Located Folder Path
            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);
            //Make AttachmentService Name Unique -- GUID

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            //Get File Path
            var filePath = Path.Combine(FolderPath, fileName);

            // Create File Stream To Copy File [Unmanaged]
           using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            // Use Stream To Copy 
            file.CopyTo(fileStream);
            //return File name To Store In DataBase
            return fileName;
        }
        public bool Delete(string filePath)
        {
    
            if(!File.Exists(filePath)) return false;
            else
            {
                File.Delete(filePath);
                return true;
            }
        }

    }
}
