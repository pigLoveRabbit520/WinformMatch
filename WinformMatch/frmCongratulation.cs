using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace SalamanderWinformMatch
{
    public partial class frmCongratulation : Form
    {
        public frmCongratulation()
        {
            InitializeComponent();
        }

        Bitmap[] Frames = new Bitmap[5]{SalamanderWinformMatch.Properties.Resources.con1,SalamanderWinformMatch.Properties.Resources.con2,
        SalamanderWinformMatch.Properties.Resources.con3,SalamanderWinformMatch.Properties.Resources.con4,SalamanderWinformMatch.Properties.Resources.con5};
        int Iframe = 0;

        private void tmrClose_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCongratulation_Load(object sender, EventArgs e)
        {
            SoundPlayer sn = new SoundPlayer(SalamanderWinformMatch.Properties.Resources.Victory);
            sn.Play();
        }

        private void tmrAnimate_Tick(object sender, EventArgs e)
        {
            this.BackgroundImage = Frames[Iframe];
            Iframe++;
            if(Iframe==5)
            {
                tmrAnimate.Stop();
            }
        }
    }
}
