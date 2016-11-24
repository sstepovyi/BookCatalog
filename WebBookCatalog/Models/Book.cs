using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Drawing;

namespace WebBookCatalog.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Annotation { get; set; }
        public byte [] Image { get; set; }

    }

    class ImageConverter
    {
       
         
        public byte[] imageToByteArray(string path)
        {
              
            using (MemoryStream ms = new MemoryStream())
            {
                
                Image img = Image.FromFile(path);
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);           
                return returnImage;
            }
        }
    }

}