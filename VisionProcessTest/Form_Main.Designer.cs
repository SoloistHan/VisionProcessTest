
namespace VisionProcessTest
{
    partial class Form_Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.reToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ch01ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGLowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ch02ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayGreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binaryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.outlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ch04ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binary04ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outline04ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PictureBox_Main = new System.Windows.Forms.PictureBox();
            this.MenuStrip_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip_Main
            // 
            this.MenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reToolStripMenuItem,
            this.openToolStripMenuItem,
            this.ch01ToolStripMenuItem,
            this.ch02ToolStripMenuItem,
            this.ch04ToolStripMenuItem});
            this.MenuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip_Main.Name = "MenuStrip_Main";
            this.MenuStrip_Main.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip_Main.TabIndex = 0;
            this.MenuStrip_Main.Text = "menuStrip1";
            // 
            // reToolStripMenuItem
            // 
            this.reToolStripMenuItem.Name = "reToolStripMenuItem";
            this.reToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.reToolStripMenuItem.Text = "Re";
            this.reToolStripMenuItem.Click += new System.EventHandler(this.reToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // ch01ToolStripMenuItem
            // 
            this.ch01ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.blueToolStripMenuItem,
            this.rGBToolStripMenuItem,
            this.rGLowToolStripMenuItem,
            this.binaryToolStripMenuItem,
            this.negativeToolStripMenuItem});
            this.ch01ToolStripMenuItem.Name = "ch01ToolStripMenuItem";
            this.ch01ToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ch01ToolStripMenuItem.Text = "Ch_01";
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.redToolStripMenuItem_Click);
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.greenToolStripMenuItem.Text = "Green";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.blueToolStripMenuItem.Text = "Blue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
            // 
            // rGBToolStripMenuItem
            // 
            this.rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            this.rGBToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.rGBToolStripMenuItem.Text = "RGB";
            this.rGBToolStripMenuItem.Click += new System.EventHandler(this.rGBToolStripMenuItem_Click);
            // 
            // rGLowToolStripMenuItem
            // 
            this.rGLowToolStripMenuItem.Name = "rGLowToolStripMenuItem";
            this.rGLowToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.rGLowToolStripMenuItem.Text = "RG Low";
            this.rGLowToolStripMenuItem.Click += new System.EventHandler(this.rGLowToolStripMenuItem_Click);
            // 
            // binaryToolStripMenuItem
            // 
            this.binaryToolStripMenuItem.Name = "binaryToolStripMenuItem";
            this.binaryToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.binaryToolStripMenuItem.Text = "Binary";
            this.binaryToolStripMenuItem.Click += new System.EventHandler(this.binaryToolStripMenuItem_Click);
            // 
            // negativeToolStripMenuItem
            // 
            this.negativeToolStripMenuItem.Name = "negativeToolStripMenuItem";
            this.negativeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.negativeToolStripMenuItem.Text = "Negative";
            this.negativeToolStripMenuItem.Click += new System.EventHandler(this.negativeToolStripMenuItem_Click);
            // 
            // ch02ToolStripMenuItem
            // 
            this.ch02ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayGreenToolStripMenuItem,
            this.aveToolStripMenuItem,
            this.binaryToolStripMenuItem1,
            this.outlineToolStripMenuItem});
            this.ch02ToolStripMenuItem.Name = "ch02ToolStripMenuItem";
            this.ch02ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ch02ToolStripMenuItem.Text = "Ch_0203";
            // 
            // grayGreenToolStripMenuItem
            // 
            this.grayGreenToolStripMenuItem.Name = "grayGreenToolStripMenuItem";
            this.grayGreenToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.grayGreenToolStripMenuItem.Text = "GrayGreen";
            this.grayGreenToolStripMenuItem.Click += new System.EventHandler(this.grayGreenToolStripMenuItem_Click);
            // 
            // aveToolStripMenuItem
            // 
            this.aveToolStripMenuItem.Name = "aveToolStripMenuItem";
            this.aveToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.aveToolStripMenuItem.Text = "Ave";
            this.aveToolStripMenuItem.Click += new System.EventHandler(this.aveToolStripMenuItem_Click);
            // 
            // binaryToolStripMenuItem1
            // 
            this.binaryToolStripMenuItem1.Name = "binaryToolStripMenuItem1";
            this.binaryToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.binaryToolStripMenuItem1.Text = "Binary";
            this.binaryToolStripMenuItem1.Click += new System.EventHandler(this.binaryToolStripMenuItem1_Click);
            // 
            // outlineToolStripMenuItem
            // 
            this.outlineToolStripMenuItem.Name = "outlineToolStripMenuItem";
            this.outlineToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.outlineToolStripMenuItem.Text = "Outline";
            this.outlineToolStripMenuItem.Click += new System.EventHandler(this.outlineToolStripMenuItem_Click);
            // 
            // ch04ToolStripMenuItem
            // 
            this.ch04ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.binary04ToolStripMenuItem,
            this.outline04ToolStripMenuItem,
            this.targetsToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.sortToolStripMenuItem});
            this.ch04ToolStripMenuItem.Name = "ch04ToolStripMenuItem";
            this.ch04ToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ch04ToolStripMenuItem.Text = "Ch-04";
            // 
            // binary04ToolStripMenuItem
            // 
            this.binary04ToolStripMenuItem.Name = "binary04ToolStripMenuItem";
            this.binary04ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.binary04ToolStripMenuItem.Text = "Binary_04";
            this.binary04ToolStripMenuItem.Click += new System.EventHandler(this.binary04ToolStripMenuItem_Click);
            // 
            // outline04ToolStripMenuItem
            // 
            this.outline04ToolStripMenuItem.Name = "outline04ToolStripMenuItem";
            this.outline04ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.outline04ToolStripMenuItem.Text = "Outline_04";
            this.outline04ToolStripMenuItem.Click += new System.EventHandler(this.outline04ToolStripMenuItem_Click);
            // 
            // targetsToolStripMenuItem
            // 
            this.targetsToolStripMenuItem.Name = "targetsToolStripMenuItem";
            this.targetsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.targetsToolStripMenuItem.Text = "Targets";
            this.targetsToolStripMenuItem.Click += new System.EventHandler(this.targetsToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sortToolStripMenuItem.Text = "Sort";
            this.sortToolStripMenuItem.Click += new System.EventHandler(this.sortToolStripMenuItem_Click);
            // 
            // PictureBox_Main
            // 
            this.PictureBox_Main.Location = new System.Drawing.Point(389, 200);
            this.PictureBox_Main.Name = "PictureBox_Main";
            this.PictureBox_Main.Size = new System.Drawing.Size(100, 50);
            this.PictureBox_Main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_Main.TabIndex = 2;
            this.PictureBox_Main.TabStop = false;
            this.PictureBox_Main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Main_MouseDown);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PictureBox_Main);
            this.Controls.Add(this.MenuStrip_Main);
            this.MainMenuStrip = this.MenuStrip_Main;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vision Process Test";
            this.MenuStrip_Main.ResumeLayout(false);
            this.MenuStrip_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.PictureBox PictureBox_Main;
        private System.Windows.Forms.ToolStripMenuItem ch01ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGLowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negativeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ch02ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayGreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binaryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem outlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ch04ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem targetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binary04ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outline04ToolStripMenuItem;
    }
}

