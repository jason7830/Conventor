namespace Conventor
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_addFile = new System.Windows.Forms.Button();
            this.btn_addFolder = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cms_ItemsAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.box_pb = new System.Windows.Forms.Panel();
            this.listDisplay = new MyListView();
            this.cmFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Done = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cms_ItemsAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_addFile
            // 
            this.btn_addFile.Location = new System.Drawing.Point(13, 15);
            this.btn_addFile.Name = "btn_addFile";
            this.btn_addFile.Size = new System.Drawing.Size(96, 23);
            this.btn_addFile.TabIndex = 1;
            this.btn_addFile.Text = "加入檔案..";
            this.btn_addFile.UseVisualStyleBackColor = true;
            this.btn_addFile.Click += new System.EventHandler(this.btn_addFile_Click);
            // 
            // btn_addFolder
            // 
            this.btn_addFolder.Location = new System.Drawing.Point(13, 45);
            this.btn_addFolder.Name = "btn_addFolder";
            this.btn_addFolder.Size = new System.Drawing.Size(96, 23);
            this.btn_addFolder.TabIndex = 2;
            this.btn_addFolder.Text = "選擇資料夾..";
            this.btn_addFolder.UseVisualStyleBackColor = true;
            this.btn_addFolder.Click += new System.EventHandler(this.btn_addFolder_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(13, 74);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(96, 23);
            this.btn_Start.TabIndex = 4;
            this.btn_Start.Text = "開始";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_exSetting_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(-58, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // cms_ItemsAction
            // 
            this.cms_ItemsAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lpToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.pauseToolStripMenuItem});
            this.cms_ItemsAction.Name = "contextMenuStrip1";
            this.cms_ItemsAction.Size = new System.Drawing.Size(110, 70);
            // 
            // lpToolStripMenuItem
            // 
            this.lpToolStripMenuItem.Name = "lpToolStripMenuItem";
            this.lpToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.lpToolStripMenuItem.Text = "Start";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            // 
            // box_pb
            // 
            this.box_pb.Location = new System.Drawing.Point(709, 9);
            this.box_pb.Name = "box_pb";
            this.box_pb.Size = new System.Drawing.Size(0, 0);
            this.box_pb.TabIndex = 8;
            // 
            // listDisplay
            // 
            this.listDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cmFileName,
            this.cmPath,
            this.cmStatus});
            this.listDisplay.FullRowSelect = true;
            this.listDisplay.GridLines = true;
            this.listDisplay.Location = new System.Drawing.Point(144, 15);
            this.listDisplay.Name = "listDisplay";
            this.listDisplay.Size = new System.Drawing.Size(744, 194);
            this.listDisplay.TabIndex = 6;
            this.listDisplay.UseCompatibleStateImageBehavior = false;
            this.listDisplay.View = System.Windows.Forms.View.Details;
            this.listDisplay.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pbReDrawThread);
            this.listDisplay.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.pbReDrawThread);
            this.listDisplay.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.pbReDrawThread);
            this.listDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listDisplay_MouseUp);
            // 
            // cmFileName
            // 
            this.cmFileName.Text = "FileName";
            this.cmFileName.Width = 166;
            // 
            // cmPath
            // 
            this.cmPath.Text = "Path";
            this.cmPath.Width = 424;
            // 
            // cmStatus
            // 
            this.cmStatus.Text = "Status";
            this.cmStatus.Width = 150;
            // 
            // btn_Done
            // 
            this.btn_Done.Location = new System.Drawing.Point(13, 103);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(71, 24);
            this.btn_Done.TabIndex = 9;
            this.btn_Done.Text = "完成";
            this.btn_Done.UseVisualStyleBackColor = true;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(7, 214);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 12);
            this.lblStatus.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 230);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btn_Done);
            this.Controls.Add(this.box_pb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listDisplay);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.btn_addFolder);
            this.Controls.Add(this.btn_addFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Conventor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.cms_ItemsAction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_addFile;
        private System.Windows.Forms.Button btn_addFolder;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader cmFileName;
        private System.Windows.Forms.ColumnHeader cmPath;
        private System.Windows.Forms.ColumnHeader cmStatus;
        private MyListView listDisplay;
        private System.Windows.Forms.ContextMenuStrip cms_ItemsAction;
        private System.Windows.Forms.ToolStripMenuItem lpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.Panel box_pb;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.Label lblStatus;
    }
}

