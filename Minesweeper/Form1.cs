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

namespace Minesweeper
{
    public partial class MainForm : Form
    {
        private int[,] martix;//地雷数字矩阵
        private Button[,] btnMartix;//地雷按钮矩阵
        private int row;//行数
        private int col;//列数
        private int mineCount;//地雷数
        private int leftMineCount;//剩余地雷数
        private int time=0;//计时
        private int leftCell;//剩余没开的格子
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            row = 9;
            col = 9;
            mineCount = 10;
            InitGame();
        }

        //初始化地雷矩阵
        private int[,] InitMartix()
        {
            int[,] martix = new int[row, col];
            Random random = new Random();
            //生成地雷 地雷设置为10
            for (int i = 0; i < mineCount; i++)
            {
                int rowIndex = random.Next(0, row - 1);
                int colIndex = random.Next(0, col - 1);
                if (martix[rowIndex, colIndex] == 10)//如果位置重复重新生成地雷
                {
                    i--;
                }
                else
                {
                    martix[rowIndex, colIndex] = 10;
                }
            }

            //生成每个位置周围的雷
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (martix[i, j] != 10)
                    {
                        int mineCount = 0;
                        //上一行
                        if (i - 1 >= 0)
                        {
                            if ((j - 1 >= 0) && (martix[i - 1, j - 1] == 10)) mineCount++;
                            if (martix[i - 1, j] == 10) mineCount++;
                            if ((j + 1 < col) && (martix[i - 1, j + 1] == 10)) mineCount++;
                        }
                        //同一行
                        if ((j - 1 >= 0) && (martix[i, j - 1] == 10)) mineCount++;
                        if ((j + 1 < col) && (martix[i, j + 1] == 10)) mineCount++;
                        //下一行
                        if (i + 1 < row)
                        {
                            if ((j - 1 >= 0) && (martix[i + 1, j - 1] == 10)) mineCount++;
                            if (martix[i + 1, j] == 10) mineCount++;
                            if ((j + 1 < col) && (martix[i + 1, j + 1] == 10)) mineCount++;
                        }
                        martix[i, j] = mineCount;
                    }
                }
            }
            return martix;
        }

        //构建游戏界面
        private void InitGame()
        {

            leftMineCount = mineCount;
            leftMineLabel.Text = leftMineCount.ToString();
            leftCell = row * col - mineCount;
            btnMartix = new Button[row, col];
            martix = InitMartix();

            TableLayoutPanel minePanel = new TableLayoutPanel();//扫雷区域
            minePanel.RowCount = row;
            minePanel.ColumnCount = col;
            minePanel.Anchor = AnchorStyles.Top;
            minePanel.AutoSize = true;
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    Button btn = new Button();
                    btn.Width = 36;
                    btn.Height = 36;
                    btn.Margin = new Padding(0);
                    btn.Padding = new Padding(0);
                    btn.Tag = i + "#" + j;
                    btn.MouseDown += new MouseEventHandler(MineBtnClick);
                    btnMartix[i, j] = btn;
                    minePanel.Controls.Add(btn);
                    
                }
            }
            this.mainPanel.Controls.Add(minePanel);
            //this.mainPanel.SetColumnSpan(minePanel, 4);

        }

        //地雷单机事件
        private void MineBtnClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;

            //判断点击鼠标左键或右键
            if (Mouse_e.Button == MouseButtons.Left)
            {
                MineBtnLeftClick(sender, e);
            }
            else if (Mouse_e.Button == MouseButtons.Right)
            {
                MineBtnRightClick(sender, e);
            }
            else if (Mouse_e.Button == MouseButtons.Middle)
            {
                MineBtnMilddleClick(sender, e);
            }
        }

        //地雷左键点击事件
        private void MineBtnLeftClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text != "") return;//如果这个格子被标记了什么也不做
            if (btn.Tag.ToString().IndexOf("@") != -1) return;//如果是已经翻开的情况不做任何处理
            int rowIndex = int.Parse(btn.Tag.ToString().Split('#')[0]);
            int colIndex = int.Parse(btn.Tag.ToString().Split('#')[1]);
            int number = martix[rowIndex, colIndex];
            //游戏结束
            if (number == 10)
            {
                btn.BackColor = Color.Red;
                btn.Text = "💣";
                if (MessageBox.Show("游戏结束!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK)
                {
                    //重开游戏
                    mainPanel.Controls.Clear();
                    InitGame();
                    time =0;
                }
            }
            else
            {
                //等于零把周围的数字和空格全开
                if (number == 0)
                {
                    btn.BackColor = Color.White;
                    btn.Text ="";
                    btn.Tag+="@";//加@表示被翻开了
                    OpenWhite(rowIndex,colIndex);
                }
                else
                {
                    btn.BackColor = Color.White;
                    btn.Text = number.ToString();
                    btn.Tag += "@";//加@表示被翻开了
                }
                leftCell--;
                if (leftCell == 0)
                {
                    if (MessageBox.Show("恭喜通关!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {

                    }
                }
            }

        }


        //鼠标右键标记地雷
        private void MineBtnRightClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag.ToString().IndexOf("@")!=-1) return;//如果是已经翻开的情况不做任何处理
            //未标记状态
            if (btn.Text == "")
            {
                btn.Text = "⛳";
                btn.ForeColor = Color.Red;
                leftMineCount--;
                leftMineLabel.Text = leftMineCount.ToString();
            }
            else if(btn.Text== "⛳")
            {
                btn.Text = "?";
                btn.ForeColor = Color.Black;
            }
            else
            {
                btn.Text = "";
                btn.ForeColor = Color.Black;
                leftMineCount++;
                leftMineLabel.Text = leftMineCount.ToString();
            }
        }

        //鼠标中键开周围数字
        private void MineBtnMilddleClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag.ToString().IndexOf("@") == -1) return;//如果没有翻开不做任何处理
            if (btn.Text == "") return;//如果翻开了是空不做任何处理
            int number = int.Parse(btn.Text);
            int count = 0;
            string tempTag = btn.Tag.ToString().Substring(0, btn.Tag.ToString().Length - 1);//去掉@
            int rowIndex = int.Parse(tempTag.Split('#')[0]);
            int colIndex = int.Parse(tempTag.Split('#')[1]);

            //上一行
            if (rowIndex - 1 >= 0)
            {
                if ((colIndex - 1 >= 0) && (btnMartix[rowIndex - 1, colIndex - 1].Text == "⛳")) count++;
                if (btnMartix[rowIndex - 1, colIndex].Text == "⛳") count++;
                if ((colIndex + 1 < col) && (btnMartix[rowIndex - 1, colIndex + 1].Text == "⛳")) count++;
            }
            //同一行
            if ((colIndex - 1 >= 0) && (btnMartix[rowIndex, colIndex - 1].Text == "⛳")) count++;
            if ((colIndex + 1 < col) && (btnMartix[rowIndex, colIndex + 1].Text == "⛳")) count++;
            //下一行
            if (rowIndex + 1 < row)
            {
                if ((colIndex - 1 >= 0) && (btnMartix[rowIndex + 1, colIndex - 1].Text == "⛳")) count++;
                if (btnMartix[rowIndex + 1, colIndex].Text == "⛳") count++;
                if ((colIndex + 1 < col) && (btnMartix[rowIndex + 1, colIndex + 1].Text == "⛳")) count++;
            }
            if (count == number)
            {
                //开上一排
                if (rowIndex - 1 >= 0)
                {
                    if (colIndex - 1 >= 0) MineBtnLeftClick(btnMartix[rowIndex - 1, colIndex - 1], EventArgs.Empty);
                    MineBtnLeftClick(btnMartix[rowIndex - 1, colIndex], EventArgs.Empty);
                    if (colIndex + 1 < col) MineBtnLeftClick(btnMartix[rowIndex - 1, colIndex + 1], EventArgs.Empty);
                }
                //同一行
                if (colIndex - 1 >= 0) MineBtnLeftClick(btnMartix[rowIndex, colIndex - 1], EventArgs.Empty);
                if (colIndex + 1 < col) MineBtnLeftClick(btnMartix[rowIndex, colIndex + 1], EventArgs.Empty);
                //下一行
                if (rowIndex + 1 < row)
                {
                    if (colIndex - 1 >= 0) MineBtnLeftClick(btnMartix[rowIndex + 1, colIndex - 1], EventArgs.Empty);
                    MineBtnLeftClick(btnMartix[rowIndex + 1, colIndex], EventArgs.Empty);
                    if (colIndex + 1 < col) MineBtnLeftClick(btnMartix[rowIndex + 1, colIndex + 1], EventArgs.Empty);
                }
            }
        }

        //开周围数字
        private void OpenWhite(int rowIndex,int colIndex)
        {
            //开上一排
            if (rowIndex - 1 >= 0)
            {
                if ((colIndex - 1 >= 0) && (martix[rowIndex - 1, colIndex - 1] != 10)) MineBtnLeftClick(btnMartix[rowIndex - 1, colIndex - 1], EventArgs.Empty);
                if (martix[rowIndex - 1, colIndex] != 10) MineBtnLeftClick(btnMartix[rowIndex - 1, colIndex], EventArgs.Empty);
                if ((colIndex + 1 < col) && (martix[rowIndex - 1, colIndex + 1] != 10)) MineBtnLeftClick(btnMartix[rowIndex - 1, colIndex + 1], EventArgs.Empty);
            }
            //同一行
            if ((colIndex - 1 >= 0) && (martix[rowIndex, colIndex - 1] != 10)) MineBtnLeftClick(btnMartix[rowIndex, colIndex - 1], EventArgs.Empty);
            if ((colIndex + 1 < col) && (martix[rowIndex, colIndex + 1] != 10)) MineBtnLeftClick(btnMartix[rowIndex, colIndex + 1], EventArgs.Empty);
            //下一行
            if (rowIndex + 1 < row)
            {
                if ((colIndex - 1 >= 0) && (martix[rowIndex + 1, colIndex - 1] != 10)) MineBtnLeftClick(btnMartix[rowIndex + 1, colIndex - 1], EventArgs.Empty);
                if (martix[rowIndex + 1, colIndex] != 10) MineBtnLeftClick(btnMartix[rowIndex + 1, colIndex], EventArgs.Empty);
                if ((colIndex + 1 < col) && (martix[rowIndex + 1, colIndex + 1] != 10)) MineBtnLeftClick(btnMartix[rowIndex + 1, colIndex + 1], EventArgs.Empty);
            }
        }

        //计时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            int min = time / 60;
            int sec = time % 60;
            timeLabel.Text = min.ToString().PadLeft(2, '0') + ":" + sec.ToString().PadLeft(2,'0');//不足两位补足0
        }

        private void beginner_Click(object sender, EventArgs e)
        {
            
            row = 9;
            col = 9;
            mineCount = 10;
            this.mainPanel.Controls.Clear();
            InitGame();
            time = 0;
            this.Size = new Size(700, 480);
        }

        private void intermediate_Click(object sender, EventArgs e)
        {
            
            row = 16;
            col = 16;
            mineCount = 40;
            this.mainPanel.Controls.Clear();
            InitGame();
            time = 0;
            this.Size = new Size(700, 480);
        }

        private void advanced_Click(object sender, EventArgs e)
        {
            row = 16;
            col = 30;
            mineCount = 99;
            this.mainPanel.Controls.Clear();
            InitGame();
            time = 0;
        }


    }
}
