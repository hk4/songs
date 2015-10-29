using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FSound;
using PlaySongs;

namespace DrumTune
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlaySongs.ContinuousPhaseAccumulation.playKick(
                (double)trackBarVolume.Value / 1000.0,
                (double)trackBarPitch.Value,
                (double)trackBarAttack.Value / 1000.0,
                (double)trackBarPeak.Value/1000.0,
                (double)trackBarDecay.Value/ 1000.0,
                (double)trackBarSustainVolume.Value / 1000.0,
                (double)trackBarSustainTime.Value / 1000.0,
                (double)trackBarReleaseTime.Value / 1000.0
                );
        }

        private void trackBarPitch_Scroll(object sender, EventArgs e)
        {
            labelFreqHz.Text = trackBarPitch.Value + " HZ";
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            labelVolume.Text = trackBarVolume.Value/10 + "% Vol";
        }

        private void trackBarPeak_Scroll(object sender, EventArgs e)
        {
            labelPeak.Text = trackBarPeak.Value / 10 + "% Peak\n" + (trackBarPitch.Value * trackBarPeak.Value / 1000) + " HZ";
        }

        private void trackBarAttack_Scroll(object sender, EventArgs e)
        {
            labelAttack.Text = trackBarAttack.Value + " ms";
        }

        private void trackBarRelease_Scroll(object sender, EventArgs e)
        {
            labelDecay.Text = trackBarDecay.Value + " ms";
        }

        private void trackBarSustainTime_Scroll(object sender, EventArgs e)
        {
            labelSusTime.Text = trackBarSustainTime.Value + " ms Sus";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBarSustainVolume_Scroll(object sender, EventArgs e)
        {
            labelSusVol.Text = trackBarSustainVolume.Value / 10 + "% Sus\n" + (trackBarPitch.Value * trackBarSustainVolume.Value / 1000) + " HZ";
        }

        private void labelDecay_Click(object sender, EventArgs e)
        {

        }

        private void trackBarReleaseTime_Scroll(object sender, EventArgs e)
        {
            labelReleaseTime.Text = trackBarReleaseTime.Value + " ms Release";
        }
    }
}
