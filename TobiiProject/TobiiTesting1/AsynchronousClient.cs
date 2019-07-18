using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Tobii.Research;

namespace TobiiTesting1
{
    public static class AsynchronousClient
    {
        // The port number for the remote device.
        //device id: 023b64
        //detail refer to http://developer.empatica.com/windows-streaming-server-commands.html

        private const string ServerAddress = "127.0.0.1";
        private const int ServerPort = 28000;

        // ManualResetEvent instances signal completion.
        private static readonly ManualResetEvent ConnectDone = new ManualResetEvent(false);
        private static readonly ManualResetEvent SendDone = new ManualResetEvent(false);
        private static readonly ManualResetEvent ReceiveDone = new ManualResetEvent(false);

        // The response from the remote device.
        private static String _response = String.Empty;

        private static Socket client;
        private static bool m_startsaving;
        private static string empaticadatasavingpath;

        private static string m_record;//empatica data here

        public static bool StartClient(string str_empaticaDevice = "AB2B64")
        {
            // Connect to a remote device.
            try
            {
                m_startsaving = false;

                // Establish the remote endpoint for the socket.
                var ipHostInfo = new IPHostEntry { AddressList = new[] { IPAddress.Parse(ServerAddress) } };
                var ipAddress = ipHostInfo.AddressList[0];
                var remoteEp = new IPEndPoint(ipAddress, ServerPort);

                // Create a TCP/IP socket.
                //var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // Connect to the remote endpoint.
                try
                {
                    client.BeginConnect(remoteEp, (ConnectCallback), client);
                    ConnectDone.WaitOne();
                }
                catch
                {
                    Console.WriteLine("start client");
                }
                

                /* 
                 * device_connect 9ff167
                 * R device_connect OK
                 * 
                 * device_subscribe bvp ON
                 * R device_subscribe bvp OK
                 * 
                 * E4_Bvp 123345627891.123 31.128
                 * 
                 * device_disconnect
                 * device_disconnect OK
                 * 
                 *  acc - 3-axis acceleration
                    bvp - Blood Volume Pulse
                    gsr - Galvanic Skin Response
                    ibi - Interbeat Interval and Heartbeat
                    tmp - Skin Temperature
                    bat - Device Battery
                    tag - Tag taken from the device (by pressing the button)

                 */
                string[] list_empatica_device_management_msg = { "device_list", "device_connect "+ str_empaticaDevice }; //AB2B64,9ff167, "device_disconnect"

                string[] list_empatica_datatype_msg ={
                    "device_subscribe bvp ON",
                    "device_subscribe gsr ON" };

                /*
                string [] list_empatica_datatype_msg ={
                    "device_subscribe acc ON",
                    "device_subscribe bvp ON",
                    "device_subscribe gsr ON",
                    "device_subscribe ibi ON",
                    "device_subscribe tmp ON",
                    "device_subscribe bat ON",
                    "device_subscribe tag ON" };
                */
                System.Threading.Thread.Sleep(1000);//2000
                foreach (string item in list_empatica_device_management_msg)
                {
                    Send(client, item + Environment.NewLine);
                    SendDone.WaitOne();
                    Receive(client);
                    ReceiveDone.WaitOne();
                    System.Threading.Thread.Sleep(500);//2000
                }
                foreach (string item in list_empatica_datatype_msg)
                {
                    Send(client, item + Environment.NewLine);
                    SendDone.WaitOne();
                    Receive(client);
                    ReceiveDone.WaitOne();
                    System.Threading.Thread.Sleep(100);//2000
                }

                /*
                while (true)
                {
                    var msg = Console.ReadLine();
                    Send(client, msg + Environment.NewLine);
                    SendDone.WaitOne();
                    Receive(client);
                    ReceiveDone.WaitOne();
                }
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }
        public static void StopClient()
        {
            m_startsaving = false;
            Send(client, "device_disconnect" + Environment.NewLine);
            SendDone.WaitOne();
            Receive(client);
            ReceiveDone.WaitOne();
        }


        public static void SavingRecord(string filepath)
        {
            m_startsaving = true;
            
            //GenerateRecordingFile(filepath);

            var local_timestamp = DateTimeOffset.Now.ToString("MM_dd_yyyy hh_mm_ss");
            empaticadatasavingpath = filepath.Replace(".avi", "_") + "EP.txt";

            if (!System.IO.File.Exists(empaticadatasavingpath))
            {
                //create file
                using (var t_file = System.IO.File.Create(empaticadatasavingpath)) ;
            }

            System.IO.File.WriteAllText(empaticadatasavingpath, "STREAM_TYPE,EP_TIMESTAMP,DATA\r\n");

        }

        public static void SavingEverySecond()
        {
            System.IO.File.AppendAllText(empaticadatasavingpath, m_record);
            m_record = "";
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                var client = (Socket)ar.AsyncState;

                // Complete the connection.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint);

                // Signal that the connection has been made.
                ConnectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                var state = new StateObject { WorkSocket = client };

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, ReceiveCallback, state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                var state = (StateObject)ar.AsyncState;
                var client = state.WorkSocket;

                // Read data from the remote device.
                var bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    state.Sb.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));
                    _response = state.Sb.ToString();

                    HandleResponseFromEmpaticaBLEServer(_response);

                    state.Sb.Clear();

                    ReceiveDone.Set();

                    // Get the rest of the data.
                    client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, ReceiveCallback, state);
                }
                else
                {
                    // All the data has arrived; put it in response.
                    if (state.Sb.Length > 1)
                    {
                        _response = state.Sb.ToString();
                    }
                    // Signal that all bytes have been received.
                    ReceiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                
            }
        }

        private static void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            client.BeginSend(byteData, 0, byteData.Length, 0, SendCallback, client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                var t_client = (Socket)ar.AsyncState;
                // Complete sending the data to the remote device.
                t_client.EndSend(ar);
                // Signal that all bytes have been sent.
                SendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void HandleResponseFromEmpaticaBLEServer(string response)
        {
            //Console.Write(response);
            //transfer unixtimestamp to 

            //var local_timestamp3 = DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff").ToString();
            //Console.Write(local_timestamp3 + "\r\n");
            

            if (m_startsaving)
            {
                var local_timestamp = DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff").ToString();
               
                var unixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                //Console.Write(local_timestamp +" " + unixTimestamp + "\r\n");
                //var t_str = String.Format("{0},{1},{2}\r\n",response.Replace(" ",","),unixTimestamp,local_timestamp);
                m_record += response.Replace(" ", ",");
                //System.IO.File.AppendAllText(empaticadatasavingpath, t_str);
            }
            
            //Console.Write("all here");
        }

        private static void GenerateRecordingFile(string filepath)
        {
            //for eyegazedata
            //var systemTimeStamp = EyeTrackingOperations.GetSystemTimeStamp();
            var local_timestamp = DateTimeOffset.Now.ToString("MM_dd_yyyy hh_mm_ss");
            //string t_txtfilename = String.Format("_EP_{0}.txt", local_timestamp);
            //var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            empaticadatasavingpath = filepath.Replace(".", "_") + "EP.txt";

            if (!System.IO.File.Exists(empaticadatasavingpath))
            {
                //create file
                using (var t_file = System.IO.File.Create(empaticadatasavingpath)) ;
            }

            System.IO.File.WriteAllText(empaticadatasavingpath, "STREAM_TYPE,EP_TIMESTAMP,DATA\r\n");

        }
    }
}