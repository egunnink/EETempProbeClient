using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using Twilio;
using Twilio.Model;

namespace EETempProbeClient
{
    public partial class EETempProbeClient : Form
    {
        // time axis constants (past time (s))
        private const double MIN_TIME = 0.0;
        private const double MAX_TIME = 300.0;
        private const double MINOR_TIME_TICK = 1.0;
        private const double MAJOR_TIME_TICK = 100.0;

        // temp axis constants (deg (C))
        private const double MIN_TEMP = 10.0;
        private const double MAX_TEMP = 50.0;
        private const double MINOR_TEMP_TICK = 1.0;
        private const double MAJOR_TEMP_TICK = 10.0;

        private PlotModel _graphModel;
        private TempSampleSeries _series;
        // TODO use app config
        private const string NUMBER = "INSERT-PHONE-NUMBER";
        private const string ACCOUNT_SID = "ACCOUNT-SID";
        private const string ACCOUNT_TOKEN = "ACCOUNT-TOKEN";
        private System.Timers.Timer _testTick;

        public EETempProbeClient()
        {
            //var twilio = new TwilioRestClient(ACCOUNT_SID, ACCOUNT_TOKEN);
            //var msg = twilio.SendMessage(NUMBER, "NUMBER", "get schwifty!");
            //Console.WriteLine(msg.Sid);

            InitializeComponent();

            FormClosing += EETempProbeClient_FormClosing;
            _graphModel = new PlotModel()
            {
                Title = "Temperature"
            };
            _graphModel.Axes.Add(new LinearAxis()
                {
                    Title = "Past Time (Seconds)",
                    Position = AxisPosition.Bottom,
                    Minimum = -1.0 * MAX_TIME,
                    AbsoluteMinimum = -1.0 * MAX_TIME,
                    Maximum = MIN_TIME,
                    AbsoluteMaximum = MIN_TIME,
                    MinorStep = MINOR_TIME_TICK,
                    MajorStep = MAJOR_TIME_TICK
                });
            _graphModel.Axes.Add(new LinearAxis()
            {
                Title = "Temperatur (Degrees C)",
                Position = AxisPosition.Left,
                Minimum = MIN_TEMP,
                AbsoluteMinimum = MIN_TEMP,
                Maximum = MAX_TEMP,
                AbsoluteMaximum = MAX_TEMP,
                MinorStep = MINOR_TEMP_TICK,
                MajorStep = MAJOR_TEMP_TICK
            });
            _series = new TempSampleSeries();
            _graphModel.Series.Add(_series);
            pvGraph.Model = _graphModel;

            _testTick = new System.Timers.Timer(50.0);
            _testTick.Elapsed += OnTick;
            _testTick.Start();
        }

        void EETempProbeClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TODO add shutdown logic
            e.Cancel = false;
        }

        private Random _rng = new Random();
        private void OnTick(object sender, System.Timers.ElapsedEventArgs e)
        {
            double sample = (_rng.NextDouble() * MAX_TEMP) + MIN_TEMP;
            _series.PushSample(sample);
            _graphModel.InvalidatePlot(true);
        }

        private void EETempProbeClient_Load(object sender, EventArgs e)
        {

        }

        private void cbComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
