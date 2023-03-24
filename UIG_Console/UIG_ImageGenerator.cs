using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using SkiaSharp;

namespace UIG_Console
{
    public class UIG_ImageGenerator
    {
        List<string> s_arr = new List<string>();
        int[] b_arr;
        string image_path;
        int file_count = 0;
        int dimension = 0;

        public UIG_ImageGenerator(List<string> _s_arr, int _dimension, string _image_path)
        {
            s_arr = _s_arr;
            image_path = _image_path;
            dimension =  _dimension;
        }

        void CleanUpDir()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(image_path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public void DoIt()
        {
            CleanUpDir();

            Directory.CreateDirectory(image_path);
            int cc = 0;
           
            foreach (var s in s_arr)
            {                
                Rectangle bounds = new Rectangle(0, 0, dimension, dimension);
                SKBitmap bitmap = new SKBitmap(bounds.Width, bounds.Height);

                    string [] pixels = s.Split(',');

                    int p_count = 0;
                    foreach (string p in pixels)                    
                    {
                         int ch_count = 0; 
                         foreach (char ch in p)
                         {
                            if (ch == '1')
                            {
                                bitmap.SetPixel(p_count, ch_count, SKColors.LightGreen);
                            }
                           ch_count++;
                         }
                       p_count++;
                    }

                 file_count++;

                 FileStream fs = new FileStream(image_path + "\\" + "img" + file_count + ".png", FileMode.Create);

                 SKData d = SKImage.FromBitmap(bitmap).Encode(SKEncodedImageFormat.Png, 100);
                 d.SaveTo(fs);

                 fs.Close();
            }
        }

    }
}

