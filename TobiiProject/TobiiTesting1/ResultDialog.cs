using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TobiiTesting1ML.Model;

namespace VirtualCoach
{
    public partial class ResultDialog : Form
    {
        public ResultDialog(iThrivTask task, int sessionIndex, int trialIndex, TimeSpan runtime, IEnumerable<double> accMagnitudes)
        {
            InitializeComponent();

            label5.Text = task.ToString();
            label6.Text = trialIndex.ToString();
            label7.Text = runtime.ToString(@"mm\:ss");

            try 
            {
                var mean_acc = accMagnitudes.Average();
                var var_acc = accMagnitudes.Select(a => Math.Pow(a - mean_acc, 2)).Average();

                var input = new ModelInput
                {
                    Task           = task.ToString(),
                    Session_index  = sessionIndex,
                    Trial_index    = trialIndex,
                    Trial_time     = (float)runtime.TotalSeconds,
                    Min_acc        = (float)accMagnitudes.Min(),
                    Sd_acc         = (float)Math.Sqrt(var_acc)
                };

                ModelOutput result = ConsumeModel.Predict(input);
                
                label8.Text = Convert.ToInt32(result.Score).ToString();
            }
            catch
            {
                label8.Text = "An error occured";
            }
            

            
            
        }
    }
}
