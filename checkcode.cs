/*
 * Created by dairoot.
 * author: dairoot
 * email:  623815825@qq.com
 * url:    https://github.com/dairoot/zfxfzb-code-data
 * 
 */
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace zfcode
{
    class Program{
        public static Random random = new Random();
        public static void Main(string[] args){

         if (!Directory.Exists("img/zfxfzb_code")){
             Directory.CreateDirectory("img/zfxfzb_code");
         }
            Console.Title = "dairoot";
            String show_str = "Captcha generator by dairoot \n\n" +
                "author: dairoot\n" +
                "github: https://github.com/dairoot/zfxfzb-code-data \n\n" +
                "输入生成数量：";
            Console.Write(show_str);
            int number = ReadInt();
            for(int i=0; i<number; i++){
                String rstr = getStr();
                checkCodeimg(rstr);
                Console.WriteLine(rstr);
            }
            
           Console.Write("验证码已生成，按任意键退出。。。");
            Console.ReadKey(true);
        }
        
        public static int ReadInt(){
            int number = 0;
             while (true){
                try{
                    number = Convert.ToInt32(Console.ReadLine());
                    return number;
                }
                catch{
                    Console.Write("输入有误，重新输入：");
                }
            }
        }
        
         public static string getStr(){
            string str = "012345678abcdefghijklmnpqrstuvwxy";
            string text = string.Empty;
            for (int i = 0; i < 4; i++)
            text += str.Substring(random.Next(str.Length), 1);
            return text;
        }
        
        public static void checkCodeimg(string checkCode){
            int num = 25;
            Bitmap bitmap;
            Graphics graphics;
            char[] array;
            StringFormat stringFormat;
            int num3;
            checked{
                int width = checkCode.Length * 18;
                bitmap = new Bitmap(width, 27);
                graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.White);
                array = checkCode.ToCharArray();
                stringFormat = new StringFormat(StringFormatFlags.NoClip);
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                int num2 = 0;
                do{
                    int x = random.Next(bitmap.Width);
                    int y = random.Next(bitmap.Height);
                    bitmap.SetPixel(x, y, Color.FromArgb(random.Next()));
                    num2++;
                }
                while (num2 <= 150);
                graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, bitmap.Width - 1, bitmap.Height - 1);

                num3 = array.Length - 1;
            }
            for (int num2 = 0; num2 <= num3; num2 = checked(num2 + 1)){

                Font font = new Font("Arial", 16f, FontStyle.Bold);
                Brush brush = new SolidBrush(Color.FromArgb(255, 0, 0, 153));
                Point point = new Point(10, 10);
                Point point2 = point;
                double num6 = (double)random.Next(checked(-num), num);
                graphics.TranslateTransform((float)point2.X, (float)point2.Y);
                graphics.RotateTransform((float)num6);
                graphics.DrawString(array[num2].ToString(), font, brush, 1f, 1f, stringFormat);
                graphics.RotateTransform((float)(0.0 - num6));
                graphics.TranslateTransform(2f, (float)checked(-point2.Y));
            }

            bitmap.Save("img/zfxfzb_code/"+checkCode + ".gif", ImageFormat.Gif);

        }

    }
}