namespace BashNY
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEnemyStats = new System.Windows.Forms.Label();
            this.lblHeroStats = new System.Windows.Forms.Label();
            this.btnLoot3 = new System.Windows.Forms.Button();
            this.btnLoot2 = new System.Windows.Forms.Button();
            this.btnLoot1 = new System.Windows.Forms.Button();
            this.hpBarEnemy = new System.Windows.Forms.ProgressBar();
            this.hpBarHero = new System.Windows.Forms.ProgressBar();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.pbEnemy = new System.Windows.Forms.PictureBox();
            this.pbHero = new System.Windows.Forms.PictureBox();
            this.timerHero = new System.Windows.Forms.Timer(this.components);
            this.timerEnemy = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHero)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblEnemyStats);
            this.panel1.Controls.Add(this.lblHeroStats);
            this.panel1.Controls.Add(this.btnLoot3);
            this.panel1.Controls.Add(this.btnLoot2);
            this.panel1.Controls.Add(this.btnLoot1);
            this.panel1.Controls.Add(this.hpBarEnemy);
            this.panel1.Controls.Add(this.hpBarHero);
            this.panel1.Controls.Add(this.rtbLog);
            this.panel1.Controls.Add(this.pbEnemy);
            this.panel1.Controls.Add(this.pbHero);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // lblEnemyStats
            // 
            this.lblEnemyStats.AutoSize = true;
            this.lblEnemyStats.Location = new System.Drawing.Point(607, 5);
            this.lblEnemyStats.Name = "lblEnemyStats";
            this.lblEnemyStats.Size = new System.Drawing.Size(35, 13);
            this.lblEnemyStats.TabIndex = 9;
            this.lblEnemyStats.Text = "label1";
            // 
            // lblHeroStats
            // 
            this.lblHeroStats.AutoSize = true;
            this.lblHeroStats.Location = new System.Drawing.Point(10, 5);
            this.lblHeroStats.Name = "lblHeroStats";
            this.lblHeroStats.Size = new System.Drawing.Size(35, 13);
            this.lblHeroStats.TabIndex = 8;
            this.lblHeroStats.Text = "label1";
            // 
            // btnLoot3
            // 
            this.btnLoot3.Location = new System.Drawing.Point(449, 251);
            this.btnLoot3.Name = "btnLoot3";
            this.btnLoot3.Size = new System.Drawing.Size(112, 23);
            this.btnLoot3.TabIndex = 7;
            this.btnLoot3.Text = "button3";
            this.btnLoot3.UseVisualStyleBackColor = true;
            this.btnLoot3.Visible = false;
            this.btnLoot3.Click += new System.EventHandler(this.btnLoot_Click);
            // 
            // btnLoot2
            // 
            this.btnLoot2.Location = new System.Drawing.Point(339, 251);
            this.btnLoot2.Name = "btnLoot2";
            this.btnLoot2.Size = new System.Drawing.Size(104, 23);
            this.btnLoot2.TabIndex = 6;
            this.btnLoot2.Text = "button2";
            this.btnLoot2.UseVisualStyleBackColor = true;
            this.btnLoot2.Visible = false;
            this.btnLoot2.Click += new System.EventHandler(this.btnLoot_Click);
            // 
            // btnLoot1
            // 
            this.btnLoot1.Location = new System.Drawing.Point(240, 251);
            this.btnLoot1.Name = "btnLoot1";
            this.btnLoot1.Size = new System.Drawing.Size(93, 23);
            this.btnLoot1.TabIndex = 5;
            this.btnLoot1.Text = "button1";
            this.btnLoot1.UseVisualStyleBackColor = true;
            this.btnLoot1.Visible = false;
            this.btnLoot1.Click += new System.EventHandler(this.btnLoot_Click);
            // 
            // hpBarEnemy
            // 
            this.hpBarEnemy.Location = new System.Drawing.Point(610, 295);
            this.hpBarEnemy.Name = "hpBarEnemy";
            this.hpBarEnemy.Size = new System.Drawing.Size(178, 23);
            this.hpBarEnemy.TabIndex = 4;
            // 
            // hpBarHero
            // 
            this.hpBarHero.Location = new System.Drawing.Point(13, 295);
            this.hpBarHero.Name = "hpBarHero";
            this.hpBarHero.Size = new System.Drawing.Size(178, 23);
            this.hpBarHero.TabIndex = 3;
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(240, 96);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(321, 148);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.Text = "";
            // 
            // pbEnemy
            // 
            this.pbEnemy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbEnemy.Location = new System.Drawing.Point(610, 21);
            this.pbEnemy.Name = "pbEnemy";
            this.pbEnemy.Size = new System.Drawing.Size(178, 267);
            this.pbEnemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEnemy.TabIndex = 1;
            this.pbEnemy.TabStop = false;
            // 
            // pbHero
            // 
            this.pbHero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHero.Location = new System.Drawing.Point(12, 21);
            this.pbHero.Name = "pbHero";
            this.pbHero.Size = new System.Drawing.Size(179, 267);
            this.pbHero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHero.TabIndex = 0;
            this.pbHero.TabStop = false;
            // 
            // timerHero
            // 
            this.timerHero.Tick += new System.EventHandler(this.timerHero_Tick);
            // 
            // timerEnemy
            // 
            this.timerEnemy.Tick += new System.EventHandler(this.timerEnemy_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbEnemy;
        private System.Windows.Forms.PictureBox pbHero;
        private System.Windows.Forms.Label lblHeroStats;
        private System.Windows.Forms.Button btnLoot3;
        private System.Windows.Forms.Button btnLoot2;
        private System.Windows.Forms.Button btnLoot1;
        private System.Windows.Forms.ProgressBar hpBarEnemy;
        private System.Windows.Forms.ProgressBar hpBarHero;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label lblEnemyStats;
        private System.Windows.Forms.Timer timerHero;
        private System.Windows.Forms.Timer timerEnemy;
    }
}

