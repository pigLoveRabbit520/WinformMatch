using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace SalamanderWinformMatch
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        enum LinkType//定义两个方块相连的类型
        {
            LineType,
            OneCornerType,
            TwoCornerType
        }

        private Bitmap[] source = { SalamanderWinformMatch.Properties.Resources.NARUTO, SalamanderWinformMatch.Properties.Resources.animals };//源图片
        private int img_cs = 0;//默认为第一套
        private int delta = 31;//坐标偏移量
        private int img_width = 40;//产生的图片大小
        private const int BLANK_STATE = -1;//表示为空的状态
        private int[] map = new int[10 * 10];//标识整个图片各个方块
        private bool select_first = false;//是否以选中第一个方块
        private int x1, y1;//第一个选中点坐标
        private int x2, y2;//第二个选中点坐标
        private LinkType LType;//两个方块相连的类型
        private Point flex_point1;//第一个拐点
        private Point flex_point2;//第二个拐点
        private int search_num = 0;



        /// <summary>
        /// 用来产生匹配内部标识的图片
        /// </summary>
        /// <param name="n">标识图片的序号</param>
        /// <returns></returns>
        private Bitmap MatchImage(int n)
        {
            Bitmap bmp = new Bitmap(img_width, img_width);
            Graphics g = Graphics.FromImage(bmp);
            Rectangle destRect = new Rectangle(0, 0, img_width, img_width);
            Rectangle srcRect = new Rectangle(n * 40, 0, 40, 40);
            if (img_cs == 0)
            {
                g.DrawImage(source[0], destRect, srcRect, GraphicsUnit.Pixel);
            }
            else
            {
                g.DrawImage(source[1], destRect, srcRect, GraphicsUnit.Pixel);
            }
            g.Dispose();
            return bmp;
        }


        /// <summary>
        /// 清理游戏图片
        /// </summary>
        private void ClearGameImage()
        {
            Graphics g = Graphics.FromImage(picBoard.Image);
            SolidBrush myBrush=new SolidBrush(picBoard.BackColor);
            g.FillRectangle(myBrush, 0, 0, picBoard.Image.Width, picBoard.Image.Height);
            myBrush.Dispose();
            g.Dispose();
        }


        /// <summary>
        /// 初始化游戏
        /// </summary>
        private void InitGame()
        {
            if(picBoard.Image == null)//第一次的情况
            {
                int width=img_width*10+(delta-1)*2+2;
                Bitmap bmp = new Bitmap(width, width);
                picBoard.Image = bmp;
            }
            else
            {
                ClearGameImage();
            }
            

            //所有方块都置空
            for (int i = 0; i < 100; i++)
            {
                map[i] = BLANK_STATE;
            }
            // 一种算法
            List<int> tmpmap = new List<int>();
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tmpmap.Add(i);
                }
            }
            Random r = new Random();//用来产生随机数
            for(int i=0;i<100;i++)
            {
                int index = r.Next(0, tmpmap.Count);
                map[i] = tmpmap[index];
                tmpmap.RemoveAt(index);
            }

            InitGameImage();
            picBoard.Refresh();

        }


        /// <summary>
        /// 根据内部标记初始化要用到的图片，直接在图片对象上画图
        /// </summary>
        private void InitGameImage()
        {
            Graphics g = Graphics.FromImage(picBoard.Image);
            for (int i = 0; i < 100; i++)
            {
                Rectangle destRect = new Rectangle(i % 10 * img_width + delta, i / 10 * img_width + delta, img_width, img_width);
                Rectangle srcRect = new Rectangle(0, 0, img_width, img_width);
                Bitmap bmp = MatchImage(map[i]);
                g.DrawImage(bmp, destRect, srcRect, GraphicsUnit.Pixel);
                bmp.Dispose();
            }
            g.Dispose();
        }


        /// <summary>
        /// 找到内部标记，各种情况的判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;
            int x = (e.X - delta) / img_width;
            int y = (e.Y - delta) / img_width;//真正要用到的内部记号
            if (x < 0 || x > 9 || y < 0 || y > 9)
                return;
            int index = x + y * 10;
            if (map[index] == BLANK_STATE)
                return;
            if (select_first == false)
            {
                DrawSelectedRect(x, y);
                x1 = x;
                y1 = y;
                select_first = true;
                return;
            }
            if (x == x1 && y == y1)
            {
                ClearSelectedRect(x, y);
                select_first = false;
                return;
            }
            x2 = x;
            y2 = y;//记录第二个方格的坐标
            if (IsSame(x1, y1, x2, y2))
            {
                if (IsLink(x1, y1, x2, y2))
                {
                    if (LType == LinkType.LineType)
                    {
                        DrawSelectedRect(x2, y2);
                        DrawLinkLine();
                        SoundPlayer sn = new SoundPlayer(SalamanderWinformMatch.Properties.Resources.score);
                        sn.Play();
                        Clear();
                        if (JudgeGameResult())
                        {
                            toolStripStatusLabel1.Text = "游戏结束";
                            frmCongratulation frm = new frmCongratulation();
                            frm.ShowDialog();
                            picBoard.Enabled = false;
                        }
                    }
                    else if (LType == LinkType.OneCornerType)
                    {
                        DrawSelectedRect(x2, y2);
                        DrawLinkLine();
                        SoundPlayer sn = new SoundPlayer(SalamanderWinformMatch.Properties.Resources.score);
                        sn.Play();
                        Clear();
                        if (JudgeGameResult())
                        {
                            toolStripStatusLabel1.Text = "游戏结束";
                            frmCongratulation frm = new frmCongratulation();
                            frm.ShowDialog();
                            picBoard.Enabled = false;
                        }
                    }
                    else
                    {
                        DrawSelectedRect(x2, y2);
                        DrawLinkLine();
                        SoundPlayer sn = new SoundPlayer(SalamanderWinformMatch.Properties.Resources.score);
                        sn.Play();
                        Clear();
                        if (JudgeGameResult())
                        {
                            toolStripStatusLabel1.Text = "游戏结束";
                            frmCongratulation frm = new frmCongratulation();
                            frm.ShowDialog();
                            picBoard.Enabled = false;
                        }
                    }
                }
                else
                {
                    ClearSelectedRect(x1, y1);
                    DrawSelectedRect(x2, y2);
                    x1 = x2;
                    y1 = y2;
                }
            }
            else
            {
                ClearSelectedRect(x1, y1);
                DrawSelectedRect(x2, y2);
                x1 = x2;
                y1 = y2;
            }

        }

        /// <summary>
        /// 清除选中方块的图片和画出的矩形和连接线
        /// </summary>
        private void Clear()
        {
            Thread.Sleep(100);//停顿一定时间
            ClearLinkLine();
            ClearSelectedRect(x1, y1);
            ClearSelectedRect(x2, y2);
            ClearImage(x1, y1);
            ClearImage(x2, y2);
            map[x1 + y1 * 10] = BLANK_STATE;
            map[x2 + y2 * 10] = BLANK_STATE;
            select_first = false;
        }


        /// <summary>
        /// 画出选中方块的矩形
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void DrawSelectedRect(int x, int y)
        {
            Pen myPen = new Pen(Color.Red, 2);
            Rectangle rect = new Rectangle(x * img_width + delta, y * img_width + delta, img_width, img_width);
            Graphics g = Graphics.FromImage(picBoard.Image);
            g.DrawRectangle(myPen, rect);
            myPen.Dispose();
            g.Dispose();
            picBoard.Refresh();
        }



        /// <summary>
        /// 清理画出的矩形，用背景色重新画一遍的方法达到
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void ClearSelectedRect(int x, int y)
        {
            Color color = picBoard.BackColor;
            Pen myPen = new Pen(color, 2);
            Rectangle rect = new Rectangle(x * img_width + delta, y * img_width + delta, img_width, img_width);
            Graphics g = Graphics.FromImage(picBoard.Image);
            g.DrawRectangle(myPen, rect);
            myPen.Dispose();
            g.Dispose();
            picBoard.Refresh();
        }

        /// <summary>
        /// 画出连接线
        /// </summary>
        private void DrawLinkLine()
        {
            Pen myPen = new Pen(Color.Red, 2);
            Graphics g = Graphics.FromImage(picBoard.Image);
            if (LType == LinkType.LineType)
            {
                Point p1 = new Point(x1 * img_width + delta + img_width / 2, y1 * img_width + delta + img_width / 2);
                Point p2 = new Point(x2 * img_width + delta + img_width / 2, y2 * img_width + delta + img_width / 2);
                g.DrawLine(myPen, p1, p2);
                picBoard.Refresh();
            }
            else if (LType == LinkType.OneCornerType)
            {
                Point p1 = new Point(x1 * img_width + delta + img_width / 2, y1 * img_width + delta + img_width / 2);
                Point p2 = new Point(x2 * img_width + delta + img_width / 2, y2 * img_width + delta + img_width / 2);
                Point fp = new Point(flex_point1.X * img_width + delta + img_width / 2, flex_point1.Y * img_width + delta + img_width / 2);
                g.DrawLine(myPen, p1, fp);
                g.DrawLine(myPen, p2, fp);
                picBoard.Refresh();
            }
            else
            {
                Point p1 = new Point(x1 * img_width + delta + img_width / 2, y1 * img_width + delta + img_width / 2);
                Point p2 = new Point(x2 * img_width + delta + img_width / 2, y2 * img_width + delta + img_width / 2);
                Point fp1 = new Point(flex_point1.X * img_width + delta + img_width / 2, flex_point1.Y * img_width + delta + img_width / 2);
                Point fp2 = new Point(flex_point2.X * img_width + delta + img_width / 2, flex_point2.Y * img_width + delta + img_width / 2);
                g.DrawLine(myPen, fp1, fp2);
                if (flex_point1.X == x1 || flex_point1.Y == y1)
                {
                    g.DrawLine(myPen, fp1, p1);
                    g.DrawLine(myPen, fp2, p2);
                }
                if (flex_point1.X == x2 || flex_point1.Y == y2)
                {
                    g.DrawLine(myPen, fp1, p2);
                    g.DrawLine(myPen, fp2, p1);
                }
                picBoard.Refresh();
            }
            myPen.Dispose();
            g.Dispose();
        }

        /// <summary>
        /// 清除连接线
        /// </summary>
        private void ClearLinkLine()
        {
            Pen myPen = new Pen(picBoard.BackColor, 2);
            Graphics g = Graphics.FromImage(picBoard.Image);
            if (LType == LinkType.LineType)
            {
                Point p1 = new Point(x1 * img_width + delta + img_width / 2, y1 * img_width + delta + img_width / 2);
                Point p2 = new Point(x2 * img_width + delta + img_width / 2, y2 * img_width + delta + img_width / 2);
                g.DrawLine(myPen, p1, p2);
                picBoard.Refresh();
            }
            else if (LType == LinkType.OneCornerType)
            {
                Point p1 = new Point(x1 * img_width + delta + img_width / 2, y1 * img_width + delta + img_width / 2);
                Point p2 = new Point(x2 * img_width + delta + img_width / 2, y2 * img_width + delta + img_width / 2);
                Point fp = new Point(flex_point1.X * img_width + delta + img_width / 2, flex_point1.Y * img_width + delta + img_width / 2);
                g.DrawLine(myPen, p1, fp);
                g.DrawLine(myPen, p2, fp);
                picBoard.Refresh();
            }
            else
            {
                Point p1 = new Point(x1 * img_width + delta + img_width / 2, y1 * img_width + delta + img_width / 2);
                Point p2 = new Point(x2 * img_width + delta + img_width / 2, y2 * img_width + delta + img_width / 2);
                Point fp1 = new Point(flex_point1.X * img_width + delta + img_width / 2, flex_point1.Y * img_width + delta + img_width / 2);
                Point fp2 = new Point(flex_point2.X * img_width + delta + img_width / 2, flex_point2.Y * img_width + delta + img_width / 2);
                g.DrawLine(myPen, fp1, fp2);
                if (flex_point1.X == x1 || flex_point1.Y == y1)
                {
                    g.DrawLine(myPen, fp1, p1);
                    g.DrawLine(myPen, fp2, p2);
                }
                if (flex_point1.X == x2 || flex_point1.Y == y2)
                {
                    g.DrawLine(myPen, fp1, p2);
                    g.DrawLine(myPen, fp2, p1);
                }
                picBoard.Refresh();
            }
            myPen.Dispose();
            g.Dispose();
        }

        /// <summary>
        /// 清理图片
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void ClearImage(int x,int y)
        {
            SolidBrush myBrush = new SolidBrush(picBoard.BackColor);
            Rectangle rect = new Rectangle(x * img_width + delta, y * img_width + delta, img_width, img_width);
            Graphics g = Graphics.FromImage(picBoard.Image);
            g.FillRectangle(myBrush, rect);
            myBrush.Dispose();
            g.Dispose();
            picBoard.Refresh();
        }

        /// <summary>
        /// 判断两个选中方块的图片是否相同
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        private bool IsSame(int x1,int y1,int x2,int y2)
        {
            if (map[x1 + y1 * 10] == map[x2 + y2 * 10] && map[x1 + y1 * 10] != BLANK_STATE)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判断两个选中方块是否连通，并输出连通类型
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        private bool IsLink(int x1,int y1,int x2,int y2)
        {
            if(x1==x2)
            {
                if(XLink(x1,y1,y2))
                {
                    LType = LinkType.LineType;
                    return true;
                }
            }
            if(y1==y2)
            {
                if(YLink(x1,x2,y1))
                {
                    LType = LinkType.LineType;
                    return true;
                }
            }
            if(x1!=x2&&y1!=y2)
            {
                if(OneCornerLink(x1,y1,x2,y2))
                {
                    LType = LinkType.OneCornerType;
                    return true;
                }
            }
            if(TwoCornerLink(x1,y1,x2,y2))
            {
                LType = LinkType.TwoCornerType;
                return true;
            }
            return false;
        }


        /// <summary>
        /// 垂直方向是否贯通
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        private bool XLink(int x,int y1,int y2)
        {
            if(y1>y2)
            {
                int temp = y1;
                y1 = y2;
                y2 = temp;
            }
            bool islink = true;
            for (int i = y1 + 1; i <= y2 - 1; i++)
            {
                if(map[x+i*10]!=BLANK_STATE)
                {
                    islink = false;
                    break;
                }
            }
            return islink;
        }
        

        /// <summary>
        /// 水平方向是否贯通
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool YLink(int x1, int x2, int y)
        {
            if(x1>x2)
            {
                int temp = x1;
                x1 = x2;
                x2 = temp;
            }
            bool islink = true;
            for (int i = x1 + 1; i <= x2 - 1; i++)
            {
                if(map[i+y*10]!=BLANK_STATE)
                {
                    islink = false;
                    break;
                }
            }
            return islink;
        }


        /// <summary>
        /// 是否是一个拐点的贯通
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        private bool OneCornerLink(int x1,int y1,int x2,int y2)
        {
            if (y1 > y2)
            {
                int temp = y1;
                y1 = y2;
                y2 = temp;
                temp = x1;
                x1 = x2;
                x2 = temp;
            }//交换两点坐标
            if (XLink(x1, y1, y2) && YLink(x1, x2, y2) && map[x1 + y2 * 10] == BLANK_STATE)
            {
                flex_point1.X = x1;
                flex_point1.Y = y2;
                return true;
            }
            if (XLink(x2, y1, y2) && YLink(x1, x2, y1) && map[x2 + y1 * 10] == BLANK_STATE)
            {
                flex_point1.X = x2;
                flex_point1.Y = y1;
                return true;
            }
            return false;
        }



        /// <summary>
        /// 是否是两个拐点的贯通
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        private bool TwoCornerLink(int x1,int y1,int x2,int y2)
        {
            if (x1 != x2 && y1 != y2)
            {
                if (y1 > y2)//交换坐标
                {
                    int temp = x1;
                    x1 = x2;
                    x2 = temp;
                    temp = y1;
                    y1 = y2;
                    y2 = temp;
                }
                for (int i = y1 + 1; i < y2; i++)
                {
                    if (XLink(x1, y1, i) && YLink(x1, x2, i) && XLink(x2, i, y2) && map[x1 + i * 10] == BLANK_STATE && map[x2 + i * 10] == BLANK_STATE)
                    {
                        flex_point1.X = x1;
                        flex_point1.Y = i;
                        flex_point2.X = x2;
                        flex_point2.Y = i;
                        return true;
                    }
                }

                int a = x1 < x2 ? x1 : x2;//a取横坐标较小的数
                int b = x1 + x2 - a;//b取横坐标较大的数
                for (int i = a + 1; i < b; i++)
                {
                    if (YLink(x1, i, y1) && XLink(i, y1, y2) && YLink(i, x2, y2) && map[i + y1 * 10] == BLANK_STATE && map[i + y2 * 10] == BLANK_STATE)
                    {
                        flex_point1.X = i;
                        flex_point1.Y = y1;
                        flex_point2.X = i;
                        flex_point2.Y = y2;
                        return true;
                    }
                }
            }
            if(x1!=x2)
            {
                int a = y1 < y2 ? y1 : y2;//a取纵坐标较小的数
                int b = y1 + y2 - a;//b取纵坐标较大的数
                for (int i = a - 1; i > -1; i--)
                {
                    if (XLink(x1, i, y1) && YLink(x1, x2, i) && XLink(x2, i, y2) && map[x1 + i * 10] == BLANK_STATE && map[x2 + i * 10] == BLANK_STATE)
                    {
                        flex_point1.X = x1;
                        flex_point1.Y = i;
                        flex_point2.X = x2;
                        flex_point2.Y = i;
                        return true;
                    }
                }
                if (XLink(x1, y1, -1) && XLink(x2, y2, -1))
                {
                    flex_point1.X = x1;
                    flex_point1.Y = -1;
                    flex_point2.X = x2;
                    flex_point2.Y = -1;
                    return true;
                }
                for (int i = b + 1; i < 10; i++)
                {
                    if (XLink(x1, i, y1) && YLink(x1, x2, i) && XLink(x2, i, y2) && map[x1 + i * 10] == BLANK_STATE && map[x2 + i * 10] == BLANK_STATE)
                    {
                        flex_point1.X = x1;
                        flex_point1.Y = i;
                        flex_point2.X = x2;
                        flex_point2.Y = i;
                        return true;
                    }
                }
                if (XLink(x1, y1, 10) && XLink(x2, y2, 10))
                {
                    flex_point1.X = x1;
                    flex_point1.Y = 10;
                    flex_point2.X = x2;
                    flex_point2.Y = 10;
                    return true;
                }
            }
            if(y1!=y2)
            {
                int a = x1 < x2 ? x1 : x2;//a取横坐标较小的数
                int b = x1 + x2 - a;//b取横坐标较大的数
                for (int i = a - 1; i > -1; i--)
                {
                    if (XLink(i, y1, y2) && YLink(i, x1, y1) && YLink(i, x2, y2) && map[i + y1 * 10] == BLANK_STATE && map[i + y2 * 10] == BLANK_STATE)
                    {
                        flex_point1.X = i;
                        flex_point1.Y = y1;
                        flex_point2.X = i;
                        flex_point2.Y = y2;
                        return true;
                    }
                }
                if (YLink(-1, x1, y1) && YLink(-1, x2, y2))
                {
                    flex_point1.X = -1;
                    flex_point1.Y = y1;
                    flex_point2.X = -1;
                    flex_point2.Y = y2;
                    return true;
                }
                for (int i = b + 1; i < 10; i++)
                {
                    if (XLink(i, y1, y2) && YLink(i, x1, y1) && YLink(i, x2, y2) && map[i + y1 * 10] == BLANK_STATE && map[i + y2 * 10] == BLANK_STATE)
                    {
                        flex_point1.X = i;
                        flex_point1.Y = y1;
                        flex_point2.X = i;
                        flex_point2.Y = y2;
                        return true;
                    }
                }
                if (YLink(10, x1, y1) && YLink(10, x2, y2))
                {
                    flex_point1.X = 10;
                    flex_point1.Y = y1;
                    flex_point2.X = 10;
                    flex_point2.Y = y2;
                    return true;
                }

            }
            return false;
        }


        /// <summary>
        /// 智能查找的算法
        /// </summary>
        /// <returns></returns>
        private bool Search_AI()
        {
            bool bFound = false;
            for (int i = 0; i < 100; i++)
            {
                if (bFound)
                    break;
                if (map[i] == BLANK_STATE)
                    continue;
                for (int j = i + 1; j < 100; j++)
                {
                    if (map[j] == BLANK_STATE)
                        continue;
                    if(map[j]==map[i]&&IsLink(i%10,i/10,j%10,j/10))
                    {
                        bFound = true;
                        DrawSelectedRect(i % 10, i / 10);
                        DrawSelectedRect(j % 10, j / 10);
                        picBoard.Refresh();
                        break;
                    }
                }
            }
            return bFound;
        }

        /// <summary>
        /// 判断游戏结果
        /// </summary>
        /// <returns></returns>
        private bool JudgeGameResult()
        {
            bool isend=true;
            for(int i=0;i<100;i++)
            {
                if (map[i] != BLANK_STATE)
                    isend = false;
            }
            return isend;
        }

        private void 新游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picBoard.Enabled = true;
            search_num = 0;
            toolStripStatusLabel1.Text = "游戏开始";
            InitGame();
        }

        private void 退出游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 关于游戏ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("作者：火蜥蜴\r\n规则：玩家可以将 2 个相同图案的对子连接起来，连接线不多于 3 根直线，就可以成功将对子消除。当所有对子消去时，玩家获胜。"+
                "\r\n游戏说明：玩家拥有5次机会使用智能查找的功能。");
        }

        private void 神奇宝贝ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            img_cs = 1;
            神奇宝贝ToolStripMenuItem.Image = SalamanderWinformMatch.Properties.Resources.seleced;
            火影忍者ToolStripMenuItem.Image = null;
        }

        private void 火影忍者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            img_cs = 0;
            火影忍者ToolStripMenuItem.Image = SalamanderWinformMatch.Properties.Resources.seleced;
            神奇宝贝ToolStripMenuItem.Image = null;
        }

        private void 智能查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(picBoard.Enabled==false)
            {
                MessageBox.Show("游戏未开始", "提示");
            }
            else
            {
                if (search_num >= 5)
                {
                    MessageBox.Show("查找次数已满5次。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!Search_AI())
                    {
                        search_num++;
                        MessageBox.Show("查找无结果！", "提示");
                    }
                    else
                    {
                        search_num++;
                    }
                }
            }
        }

        
    }
}
