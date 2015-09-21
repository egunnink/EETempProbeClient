using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Threading;

namespace EETempProbeClient
{
    public delegate void DataDumpDelegate(double[] dumpedData, int length);
    public delegate void SampleDelegate(double sample);

    public class TempInterface : IDisposable
    {
        private const int MAX_SAMPLES = 300;
        private const int MAX_BAUD_RATE = 9600;

        private const char DUMP_CMD_ID = 'D';
        private const char DUMP_MSG_ID = 'd';

        private SerialPort _port;
        private Thread _thread;

        private volatile bool _running = false;
        private double[] _sampleBuffer = new double[MAX_SAMPLES];

        public string PortName { get { return _port.PortName; } set { _port.PortName = value; } }

        public event DataDumpDelegate OnDump;
        public event SampleDelegate OnSample;

        public TempInterface(string portName)
        {
            _port = new SerialPort();
        }

        public void Run()
        {
            if (_running)
                return;

            try
            {
                _port.Open();
                _port.ReadTimeout = 200;
            }
            catch (Exception e)
            {
                throw new Exception("failed to open port!", e);
            }

            try
            {
                _running = true;
                _thread = new Thread(RunInterface);
                _thread.Start();
            }
            catch (OutOfMemoryException e)
            {
                _running = false;
                throw new Exception("unable to allocate memory for thread!", e);
            }
        }

        private void RunInterface()
        {
            RequestDump();

            byte[] buffer = new byte[MAX_SAMPLES * sizeof(short)];
            while (_running)
            {
                try
                {
                    int id = _port.ReadByte();
                    switch (id)
                    {
                        case DUMP_MSG_ID:
                            int numRead = _port.Read(buffer, 0, 2);
                            if(numRead < 2)
                            {
                                Console.Error.WriteLine("not enough data read!");
                            }
                            ushort size = (ushort)(((ushort)buffer[0] << 8) | (ushort)buffer[1]);
                            
                            break;
                    }
                }
                catch (TimeoutException)
                {
                    Console.Error.WriteLine("interface read timed out");
                }
            }
        }

        private void RequestDump()
        {
            _port.Write(new char[] { DUMP_CMD_ID }, 0, 1);
        }

        public void Dispose()
        {
            Stop();
        }

        public void Stop()
        {
            if (!_running)
                return;

            _running = false;
            if (_port != null)
            {
                try
                {
                    _port.Close();
                }
                catch (IOException e)
                {
                    Console.Error.WriteLine("temp interface port in invalid state! " + e);
                }
            }
        }
    }
}
