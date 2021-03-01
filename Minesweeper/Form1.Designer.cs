
namespace Minesweeper
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.leftMineLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabelPanel = new System.Windows.Forms.TableLayoutPanel();
            this.custom = new System.Windows.Forms.Button();
            this.advanced = new System.Windows.Forms.Button();
            this.intermediate = new System.Windows.Forms.Button();
            this.beginner = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftMineLabel
            // 
            this.leftMineLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leftMineLabel.AutoSize = true;
            this.leftMineLabel.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.leftMineLabel.ForeColor = System.Drawing.Color.Red;
            this.leftMineLabel.Location = new System.Drawing.Point(45, 13);
            this.leftMineLabel.Name = "leftMineLabel";
            this.leftMineLabel.Size = new System.Drawing.Size(80, 18);
            this.leftMineLabel.TabIndex = 2;
            this.leftMineLabel.Text = "leftMine";
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeLabel.ForeColor = System.Drawing.Color.Red;
            this.timeLabel.Location = new System.Drawing.Point(572, 13);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(53, 18);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "00:00";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.tabelPanel.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("仿宋", 25F);
            this.label1.Location = new System.Drawing.Point(300, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "扫雷";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabelPanel
            // 
            this.tabelPanel.ColumnCount = 4;
            this.tabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tabelPanel.Controls.Add(this.custom, 3, 1);
            this.tabelPanel.Controls.Add(this.leftMineLabel, 0, 0);
            this.tabelPanel.Controls.Add(this.advanced, 2, 1);
            this.tabelPanel.Controls.Add(this.intermediate, 1, 1);
            this.tabelPanel.Controls.Add(this.timeLabel, 3, 0);
            this.tabelPanel.Controls.Add(this.beginner, 0, 1);
            this.tabelPanel.Controls.Add(this.label1, 1, 0);
            this.tabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabelPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tabelPanel.Location = new System.Drawing.Point(0, 0);
            this.tabelPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tabelPanel.Name = "tabelPanel";
            this.tabelPanel.RowCount = 2;
            this.tabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tabelPanel.Size = new System.Drawing.Size(684, 90);
            this.tabelPanel.TabIndex = 2;
            // 
            // custom
            // 
            this.custom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.custom.Location = new System.Drawing.Point(558, 52);
            this.custom.Name = "custom";
            this.custom.Size = new System.Drawing.Size(81, 29);
            this.custom.TabIndex = 5;
            this.custom.Text = "自定义";
            this.custom.UseVisualStyleBackColor = true;
            // 
            // advanced
            // 
            this.advanced.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.advanced.Location = new System.Drawing.Point(387, 52);
            this.advanced.Name = "advanced";
            this.advanced.Size = new System.Drawing.Size(81, 29);
            this.advanced.TabIndex = 4;
            this.advanced.Text = "高级";
            this.advanced.UseVisualStyleBackColor = true;
            this.advanced.Click += new System.EventHandler(this.advanced_Click);
            // 
            // intermediate
            // 
            this.intermediate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.intermediate.Location = new System.Drawing.Point(216, 52);
            this.intermediate.Name = "intermediate";
            this.intermediate.Size = new System.Drawing.Size(81, 29);
            this.intermediate.TabIndex = 3;
            this.intermediate.Text = "中级";
            this.intermediate.UseVisualStyleBackColor = true;
            this.intermediate.Click += new System.EventHandler(this.intermediate_Click);
            // 
            // beginner
            // 
            this.beginner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.beginner.Location = new System.Drawing.Point(45, 52);
            this.beginner.Name = "beginner";
            this.beginner.Size = new System.Drawing.Size(81, 29);
            this.beginner.TabIndex = 2;
            this.beginner.Text = "初级";
            this.beginner.UseVisualStyleBackColor = true;
            this.beginner.Click += new System.EventHandler(this.beginner_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainPanel.Location = new System.Drawing.Point(0, 90);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 1;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            this.mainPanel.Size = new System.Drawing.Size(684, 360);
            this.mainPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(684, 441);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.tabelPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫雷";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabelPanel.ResumeLayout(false);
            this.tabelPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label leftMineLabel;
        private System.Windows.Forms.TableLayoutPanel tabelPanel;
        private System.Windows.Forms.Button custom;
        private System.Windows.Forms.Button advanced;
        private System.Windows.Forms.Button intermediate;
        private System.Windows.Forms.Button beginner;
        private System.Windows.Forms.TableLayoutPanel mainPanel;
    }
}

