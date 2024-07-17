namespace SalamanderWinformMatch
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnu = new System.Windows.Forms.MenuStrip();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.智能查找ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图片类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.火影忍者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.神奇宝贝ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssr = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.picBoard = new System.Windows.Forms.PictureBox();
            this.mnu.SuspendLayout();
            this.ssr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(512, 25);
            this.mnu.TabIndex = 3;
            this.mnu.Text = "menuStrip1";
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新游戏ToolStripMenuItem,
            this.智能查找ToolStripMenuItem,
            this.退出游戏ToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.游戏ToolStripMenuItem.Text = "游戏";
            // 
            // 新游戏ToolStripMenuItem
            // 
            this.新游戏ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新游戏ToolStripMenuItem.Image")));
            this.新游戏ToolStripMenuItem.Name = "新游戏ToolStripMenuItem";
            this.新游戏ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新游戏ToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.新游戏ToolStripMenuItem.Text = "新游戏(&N)";
            this.新游戏ToolStripMenuItem.Click += new System.EventHandler(this.新游戏ToolStripMenuItem_Click);
            // 
            // 智能查找ToolStripMenuItem
            // 
            this.智能查找ToolStripMenuItem.Name = "智能查找ToolStripMenuItem";
            this.智能查找ToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.智能查找ToolStripMenuItem.Text = "智能查找";
            this.智能查找ToolStripMenuItem.Click += new System.EventHandler(this.智能查找ToolStripMenuItem_Click);
            // 
            // 退出游戏ToolStripMenuItem
            // 
            this.退出游戏ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("退出游戏ToolStripMenuItem.Image")));
            this.退出游戏ToolStripMenuItem.Name = "退出游戏ToolStripMenuItem";
            this.退出游戏ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.退出游戏ToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.退出游戏ToolStripMenuItem.Text = "退出游戏(&X)";
            this.退出游戏ToolStripMenuItem.Click += new System.EventHandler(this.退出游戏ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图片类型ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 图片类型ToolStripMenuItem
            // 
            this.图片类型ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.火影忍者ToolStripMenuItem,
            this.神奇宝贝ToolStripMenuItem});
            this.图片类型ToolStripMenuItem.Name = "图片类型ToolStripMenuItem";
            this.图片类型ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.图片类型ToolStripMenuItem.Text = "图片类型";
            // 
            // 火影忍者ToolStripMenuItem
            // 
            this.火影忍者ToolStripMenuItem.Image = global::SalamanderWinformMatch.Properties.Resources.seleced;
            this.火影忍者ToolStripMenuItem.Name = "火影忍者ToolStripMenuItem";
            this.火影忍者ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.火影忍者ToolStripMenuItem.Text = "火影忍者";
            this.火影忍者ToolStripMenuItem.Click += new System.EventHandler(this.火影忍者ToolStripMenuItem_Click);
            // 
            // 神奇宝贝ToolStripMenuItem
            // 
            this.神奇宝贝ToolStripMenuItem.Name = "神奇宝贝ToolStripMenuItem";
            this.神奇宝贝ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.神奇宝贝ToolStripMenuItem.Text = "神奇宝贝";
            this.神奇宝贝ToolStripMenuItem.Click += new System.EventHandler(this.神奇宝贝ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于游戏ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 关于游戏ToolStripMenuItem
            // 
            this.关于游戏ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("关于游戏ToolStripMenuItem.Image")));
            this.关于游戏ToolStripMenuItem.Name = "关于游戏ToolStripMenuItem";
            this.关于游戏ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关于游戏ToolStripMenuItem.Text = "关于游戏";
            this.关于游戏ToolStripMenuItem.Click += new System.EventHandler(this.关于游戏ToolStripMenuItem1_Click);
            // 
            // ssr
            // 
            this.ssr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.ssr.Location = new System.Drawing.Point(0, 521);
            this.ssr.Name = "ssr";
            this.ssr.Size = new System.Drawing.Size(512, 22);
            this.ssr.TabIndex = 4;
            this.ssr.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel1.Text = "欢迎使用连连看游戏";
            // 
            // picBoard
            // 
            this.picBoard.BackColor = System.Drawing.SystemColors.Info;
            this.picBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoard.Enabled = false;
            this.picBoard.Location = new System.Drawing.Point(25, 45);
            this.picBoard.Name = "picBoard";
            this.picBoard.Size = new System.Drawing.Size(462, 462);
            this.picBoard.TabIndex = 0;
            this.picBoard.TabStop = false;
            this.picBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoard_MouseDown);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 543);
            this.Controls.Add(this.ssr);
            this.Controls.Add(this.picBoard);
            this.Controls.Add(this.mnu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnu;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "连连看吧！";
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.ssr.ResumeLayout(false);
            this.ssr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoard;
        private System.Windows.Forms.MenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出游戏ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip ssr;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图片类型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 神奇宝贝ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 火影忍者ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 智能查找ToolStripMenuItem;
    }
}

