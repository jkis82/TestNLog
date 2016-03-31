using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace TestNLog
{
   public partial class Form1 : Form
   {
      private Logger _logger = LogManager.GetCurrentClassLogger();

      public Form1()
      {
         InitializeComponent();
      }

      private void btnStart_Click(object sender, EventArgs e)
      {
         _logger.Info("Start");
      }

      private void btnStop_Click(object sender, EventArgs e)
      {
         _logger.Info("Stop");
      }

      private void btnBurst_Click(object sender, EventArgs e)
      {
         DurationLogger dlg = new DurationLogger("btnBurst_Click()");

         for (int i = 0; i < 1000; i++)
         {
            dlg.Counter++;

            _logger.Info("Burst item #{0}", i);
         }

         dlg.LogDuration(_logger, ePostText.Records);
      }
   }
}
