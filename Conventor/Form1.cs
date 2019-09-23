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
using System.Collections;
using FormDLL;
using System.Diagnostics;
using System.Threading;

namespace Conventor
{
    public partial class Form1 : Form
    {
        static Form startForm;
        static Process p = new Process();
        static Panel buffer = new Panel();
        static FolderBrowserDialog fbd = new FolderBrowserDialog();
        static exForm exf = new exForm();
        static string[] searchPattern = new string[] { "*.mp4","*.mov", "*.flv","*.wmv","*.avi","*.mkv","*.rmvb" };
        static List<ProgressBar> pb = new List<ProgressBar>();
        static List<ListViewItem> lvi = new List<ListViewItem>();
        static ContextMenuStrip cm = new ContextMenuStrip();
        static int index = -1;
        public Form1()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            this.MaximizeBox = false;
            createExSettingFM();
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1,20);
            listDisplay.SmallImageList = imgList;
            listDisplay.ShowItemToolTips = true;
            btn_Done.Parent = exf;
            exf.Controls.Add(btn_Done);
            btn_Done.Location = new Point(429,46);
            
        }

        private int TimeToSec(DateTime dt)
        {
            return dt.Hour * 60 * 60 + dt.Minute * 60 + dt.Second;
        }

        private void btn_addFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = openFile();
            addItems(ofd.FileNames);
        }

        private void btn_exSetting_Click(object sender, EventArgs e)
        {
            exf.setSavePath("");
            exf.ShowDialog();
            btn_Start.Enabled = false;
        }
        public void createExSettingFM()
        {
            startForm = new Form();
            startForm.Location = new Point(this.Location.X+50,this.Location.Y+20);
            startForm.Width = 500;
            startForm.Height = 300;
        }

        public OpenFileDialog openFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "影片|*.mov;*.mp4;*.mkv;*.flv;*.rmvb;*.avi;*.wmv;*.swf|All files(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "選取影片檔案";
            ofd.ShowDialog();
            return ofd;
        }

        public string openFolder()
        {
            fbd.ShowDialog();
            return fbd.SelectedPath;
        }

        public void addItems(string[] s)
        {
            listDisplay.BeginUpdate();
            int c = 0;
            int t = lvi.Count;
            for (int i = t; i < s.Length+t; i++)
            {
                lvi.Add(new ListViewItem());
                lvi[i].Font = label1.Font;
                lvi[i].Text = Path.GetFileName(s[c]);
                lvi[i].SubItems.Add(s[c]);
                lvi[i].SubItems.Add("");
                listDisplay.Items.Add(lvi[i]);

                pb.Add(new ProgressBar());
                pb[i].Parent = listDisplay;
                Rectangle barSize =lvi[i].SubItems[2].Bounds;
                barSize.Width = cmStatus.Width;
                pb[i].SetBounds(barSize.X, barSize.Y, barSize.Width, barSize.Height);
                pb[i].Visible = true;
                c += 1;
            }
            pbReDraw();
            listDisplay.EndUpdate();
        }
        private void btn_addFolder_Click(object sender, EventArgs e)
        {
            string p = openFolder();
            fbd.Reset();
            if (p != null &&  p!= "")
            {
                foreach (string s in searchPattern)
                {
                    addItems(Directory.GetFiles(p, s, SearchOption.TopDirectoryOnly));
                }
            }
        }

        private void pbReDrawThread(object sender, EventArgs e)
        {
            pbReDraw();
        }
        
        public void pbReDraw()
        {
            for (int i = 0; i < pb.Count; i++)
            {
                Rectangle temp = listDisplay.Items[i].SubItems[2].Bounds;
                if (temp.Y < 24) pb[i].Visible = false;
                if (pb[i].Location.Y < 24 && temp.Y >= 24) pb[i].Visible = true;
                pb[i].Location = new Point(temp.X, temp.Y);
                pb[i].Width = cmStatus.Width;
            }
        }

        private void listDisplay_MouseUp(object sender, MouseEventArgs e)
        {
                if (e.Button == MouseButtons.Right)
                if (listDisplay.SelectedItems.Count > 0)
                {
                    cms_ItemsAction.Show(Cursor.Position.X, Cursor.Position.Y);
                }
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            exf.done();
            new Thread(creatProcess).Start();
        }

        async Task ConsumeOutput(TextReader reader, Action<string> callback)
        {
            char[] buffer = new char[256];
            int cch;
            while ((cch = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                callback(new string(buffer, 0, cch));
            }
        }

        public void creatProcess()
        {
            try
            {
            //Duration: 00:00:21.67, start: 0.000000, bitrate: 7784 kb / s
                for (int i = 0; i < listDisplay.Items.Count; i++) //照ListView中項目的順序轉檔
                {
                    
                    index = i;             //取得Item的索引值
                    p = new Process();
                    p.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + "\\ffmpeg.exe"; //Mencoder與程式放於同目錄
                    string cmd = exf.getCommandLine(listDisplay.Items[index].SubItems[1].Text);  //exf為進階設定的視窗
                    p.StartInfo.Arguments = cmd;   //設定進程命令參數    
                    p.StartInfo.UseShellExecute = false;  //為讓Mencoder回傳的訊息至輸出留須設False
                    p.StartInfo.RedirectStandardOutput = true; //開啟標準輸出流
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true; //不顯示Mencoder視窗
                    p.Start();
                    string ops = "";
                    float time = 0;
                    int status = 0;
                    while (time == 0)
                    {
                        ops = p.StandardError.ReadLine();
                        Console.WriteLine(ops);
                        if(ops.IndexOf("Duration") >= 0)
                        {
                            time = TimeToSec(Convert.ToDateTime(ops.Split(',')[0].Substring(11)));
                        }
                    }
                    while (!p.HasExited && p.StandardError.EndOfStream != true)   //進程還沒結束的話就不斷取得Mecoder回傳的進度百分比給ProgressBar
                    {
                        try
                        {
                            ops = p.StandardError.ReadLine();  //及時轉檔狀態監測
                            Console.WriteLine(ops);
                            if (ops.IndexOf("frame") != 0) continue;
                            status = (int)((TimeToSec(Convert.ToDateTime(ops.Substring(48, 8))) / time) * 100);//從Mencoder傳給輸出流的訊息取的進度百分比
                            lblStatus.Text = ops;
                            lbl_percent.Text = "" + status + "%";
                            this.Text = "Conventor ("+i+"/"+listDisplay.Items.Count+" - "+status+"%)";
                            pb[index].Value = status;
                        }
                        catch (Exception ex) {  }
                    }
                    pb[index].Value = 100;
                }
                lbl_percent.Text = lblStatus.Text = "";
                this.Text = "Conventor (ALL DONE!)";

            }
            catch (Exception ex) { }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                p.Kill();
                p.Dispose();
                p.Close();
            }
            catch (Exception ex) { }
        }

        private void pbReDrawThread(object sender, ScrollEventArgs e)
        {

        }

        private void pbReDrawThread(object sender, ColumnWidthChangedEventArgs e)
        {

        }

        private void pbReDrawThread(object sender, ColumnWidthChangingEventArgs e)
        {

        }
    }
}

class MyListView : ListView
{
    public event ScrollEventHandler Scroll;
    protected virtual void OnScroll(ScrollEventArgs e) //改寫Scroll事件
    {
        ScrollEventHandler handler = this.Scroll;
        if (handler != null) handler(this, e);
    }

    protected override void WndProc(ref Message m)   //攔截系統訊息  訊息為VScroll時觸發OnScroll事件
    {
        base.WndProc(ref m);
        if (m.Msg == 0x114 || m.Msg == 0x115)  
        {
            OnScroll(new ScrollEventArgs((ScrollEventType)(m.WParam.ToInt32() & 0xffff), 0));
        }
    }
    //0x114 => WM_VSCROLL  vertical (垂直Scroll)
    //0x115 => WM_VSCROLL  horizen  (水平Scroll)
}


/*
 0x114 = HScroll >> Horizen  Scroll
 0x115 = VScroll >> Vertical Scroll
 
 
 */