using System;
using SkiaSharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Drawing;
using Dapper;

namespace Gahfour_web_shop_2.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public string Short_Name { get; set; }
        //public Manufacturer Manufacturer{ get; set; }
        public string Image_File { get; set; }
        public Mark Mark { get; set; }
        public DateTime Created_Date { get; set; }

        public int Size { get; set; }
        public SizeUnit Size_Unit{ get; set; }
        public int Price { get; set; }

        public string Description { get; set; }

        public bool imgIsVertical
        {
            get
            {
                //FileInfo file = new FileInfo("images/"+Image_File);
                //var sizeInBytes = file.Length;
                using (var input = File.OpenRead("wwwroot/images/" + Image_File))
                {
                    using (var inputStream = new SKManagedStream(input))
                    {
                        using (var original = SKBitmap.Decode(inputStream))
                        {
                            //int width, height;
                            if (original.Width >= original.Height)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }

            }
        }
        

        public string toJson()
        {
            return "{" +
                "'id':'" + Id + "'," +
                "'full_name':'" + Full_Name + "'," +
                "'short_name':'" + Short_Name + "'," +
                "'mark':'" + Mark.Name + "'," +
                "'img':'" + Image_File + "',"+
                "'description':'" + Description + "',"+
                "'size':'"+Size + "'," +
                "'size_unit':'" + Size_Unit.Name.ToLower() + "',"+
                "'price':'" + Price + "'," +
                "'img_vertical':'" + imgIsVertical + "'}";
        }
    }
}
