using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication2 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        public static Bitmap ReadImageFile(string path) {
            FileStream fs = File.OpenRead(path); //OpenRead
            int filelength = 0;
            filelength = (int)fs.Length; //获得文件长度 
            Byte[] image = new Byte[filelength]; //建立一个字节数组 
            fs.Read(image, 0, filelength); //按字节流读取 
            System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
            fs.Close();
            Bitmap bit = new Bitmap(result);
            return bit;
        }

        private void button1_Click(object sender, EventArgs e) {
            string randomValuesStr = "";
            Random rand = new Random();
            float f;
            Bitmap bmp = ReadImageFile("123.png");
            for (int i = 0; i < bmp.Width; i++) {
                for (int j = 0; j < bmp.Height; j++) {
                    //获取该点的像素的RGB的颜色
                    Color color = bmp.GetPixel(i, j);
                    if (color.R != 0 || color.G!=0 || color.B!=0) {
                        //白色 0.1-1
                        f = (float)(rand.Next(50, 100)*0.01);
                        color = Color.FromArgb((int)(255*f), (int)(255 * f), (int)(255 * f));
                        f = (float)Math.Round(f, 2);
                        randomValuesStr += f;
                    }
                    else {
                        //黑色 0
                        randomValuesStr += "0";
                    }
                    if (j != bmp.Height - 1) {
                        randomValuesStr += " ";
                    }
                    bmp.SetPixel(i, j, color);
                }
                if (i != bmp.Width - 1) {
                    randomValuesStr += ",";
                }
            }

            bmp.Save("x.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            this.textBox1.Text = randomValuesStr;

            Write("xxx.txt", randomValuesStr);
            this.textBox1.Text +="\r\n down!!!";

        }
        public void Write(string path,string str) {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(str);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
    }
}
