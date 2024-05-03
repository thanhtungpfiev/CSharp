using KAutoHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AutoControlAppPC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void open_notepad_Click(object sender, EventArgs e)
        {
            Process.Start("notepad");
        }

        private void open_app_Click(object sender, EventArgs e)
        {
            //Process.Start(AppDomain.CurrentDomain.BaseDirectory + "How Kteam - Free Education.html");

            //Process.Start("How Kteam - Free Education.html");
            Process.Start("https://howkteam.vn/course/dieu-khien-ung-dung-pc-voi-c/chay-lenh-cmd-trong-dieu-khien-ung-dung-pc-2801");
        }

        private void open_cmd_Click(object sender, EventArgs e)
        {
            string strCmdText;
            strCmdText = "/C ping -t howkteam.com";
            Process.Start("CMD.exe", strCmdText);
        }

        private void open_cmd_bg_Click(object sender, EventArgs e)
        {
            string strCmdText;
            strCmdText = @"/C ""How Kteam - Free Education.html""";

            Process p = new Process();

            p.StartInfo.FileName = "CMD.exe";
            p.StartInfo.Arguments = strCmdText;

            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();

            //p.Kill();
        }

        private void open_cmd_bg_with_result_Click(object sender, EventArgs e)
        {
            string cmdCommand = "ping howkteam.com";

            Process cmd = new Process();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;

            cmd.StartInfo = startInfo;
            cmd.Start();

            cmd.StandardInput.WriteLine(cmdCommand);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();

            string result = cmd.StandardOutput.ReadToEnd();

            MessageBox.Show(result);
        }

        private void button_click_one_point_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown_x.Value;
            int y = (int)numericUpDown_y.Value;

            EMouseKey mouseKey = EMouseKey.LEFT;

            if (checkBox_right_mouse.Checked)
            {
                if (checkBox_double_click.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
                else
                {
                    mouseKey = EMouseKey.RIGHT;
                }
            }
            else
            {
                if (checkBox_double_click.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_LEFT;
                }
            }

            AutoControl.MouseClick(x, y, mouseKey);
        }

        private void button_click_one_point_app_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown_x.Value;
            int y = (int)numericUpDown_y.Value;

            //var hWnd = Process.GetProcessById(12012).MainWindowHandle;
            //var hWnd = Process.GetProcessesByName("Remote Desktop Connection")[0].MainWindowHandle;
            IntPtr hWnd = IntPtr.Zero;

            hWnd = AutoControl.FindWindowHandle(null, textBox_window_title.Text);

            // lấy ra tọa độ trên màn hình của tọa độ bên trong cửa sổ
            var pointToClick = AutoControl.GetGlobalPoint(hWnd, x, y);

            EMouseKey mouseKey = EMouseKey.LEFT;

            if (checkBox_right_mouse.Checked)
            {
                if (checkBox_double_click.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
                else
                {
                    mouseKey = EMouseKey.RIGHT;
                }
            }
            else
            {
                if (checkBox_double_click.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_LEFT;
                }
            }

            AutoControl.BringToFront(hWnd);

            AutoControl.MouseClick(pointToClick, mouseKey);
        }

        private void button_click_control_app_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown_x.Value;
            int y = (int)numericUpDown_y.Value;

            IntPtr hWnd = IntPtr.Zero;

            hWnd = AutoControl.FindWindowHandle(null, textBox_window_title.Text);

            var childhWnd = IntPtr.Zero;
            // Tìm ra handle con mà thỏa điều kiện text và class y chang
            //childhWnd = AutoControl.FindWindowExFromParent(hWnd, null, textBox_control_text.Text);

            //Tìm ra handle con mà thỏa text hoặc class giống
            childhWnd = AutoControl.FindHandle(hWnd, textBox_control_text.Text, textBox_control_text.Text);

            // lấy ra tọa độ trên màn hình của tọa độ bên trong cửa sổ
            var pointToClick = AutoControl.GetGlobalPoint(childhWnd, x, y);

            EMouseKey mouseKey = EMouseKey.LEFT;

            if (checkBox_right_mouse.Checked)
            {
                if (checkBox_double_click.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
                else
                {
                    mouseKey = EMouseKey.RIGHT;
                }
            }
            else
            {
                if (checkBox_double_click.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_LEFT;
                }
            }

            AutoControl.BringToFront(hWnd);

            AutoControl.MouseClick(pointToClick, mouseKey);
        }

        private void button_send_key_to_app_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox_window_title.Text);

            AutoControl.BringToFront(hWnd);

            AutoControl.SendKeyFocus(KeyCode.ENTER);
        }

        private void button_send_multikey_to_app_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox_window_title.Text);

            AutoControl.BringToFront(hWnd);

            AutoControl.SendMultiKeysFocus(new KeyCode[] { KeyCode.CONTROL, KeyCode.KEY_V });
        }

        private void button_edit_window_title_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox_window_title.Text);

            AutoControl.SendText(hWnd, "howkteam.com");
        }

        private void button_send_text_to_app_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox_window_title.Text);

            //Tìm ra handle con mà thỏa text hoặc class giống
            var childhWnd = AutoControl.FindHandle(hWnd, "ComboBoxEx32", null);

            AutoControl.SendText(childhWnd, "howkteam.com");
        }

        private void button_click_control_app_2_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox_window_title.Text);

            var childhWnd = AutoControl.FindHandle(hWnd, textBox_control_text.Text, textBox_control_text.Text);

            AutoControl.SendClickOnControlByHandle(childhWnd);
        }

        private void button_click_one_point_app_2_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox_window_title.Text);

            var childhWnd = AutoControl.FindHandle(hWnd, textBox_control_text.Text, textBox_control_text.Text);

            int x = (int)numericUpDown_x.Value;
            int y = (int)numericUpDown_y.Value;

            // Phải click vào handle con. Không thể click vào handle window
            // Không phải ứng dụng nào cũng click được.
            AutoControl.SendClickOnPosition(childhWnd, x, y);
        }

        private void button_send_key_to_app_2_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox_window_title.Text);

            AutoControl.SendKeyBoardPress(hWnd, VKeys.VK_RETURN);

            //AutoControl.SendKeyBoardUp(hWnd, VKeys.VK_RETURN);
            //AutoControl.SendKeyBoardDown(hWnd, VKeys.VK_RETURN);

            /*
             * Bài tập:
             Nhấn vào combobox -> gửi phím down để chọn ip kế tiếp
             Phải chạy ngầm hết
             */
            //var childhWnd = AutoControl.FindHandle(hWnd, textBox_control_text.Text, textBox_control_text.Text);
            //AutoControl.SendClickOnPosition(childhWnd, 230, 14);
        }

        private void button_check_image_Click(object sender, EventArgs e)
        {
            var screen = CaptureHelper.CaptureScreen();
            screen.Save("mainScreen.PNG");

            var subBitmap = ImageScanOpenCV.GetImage("template.PNG");

            var resBitmap = ImageScanOpenCV.Find((Bitmap)screen, subBitmap);
            if (resBitmap != null)
            {
                resBitmap.Save("res.PNG");
            }
        }

        private void button_export_image_position_Click(object sender, EventArgs e)
        {
            var screen = CaptureHelper.CaptureScreen();
            screen.Save("mainScreen.PNG");

            var subBitmap = ImageScanOpenCV.GetImage("template.PNG");

            var resBitmap = ImageScanOpenCV.FindOutPoint((Bitmap)screen, subBitmap);
            if (resBitmap != null)
            {
                MessageBox.Show(resBitmap.ToString());
            }
        }
    }
}
