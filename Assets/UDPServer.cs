using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class UDPServer : MonoBehaviour
{
    int LOCAL_PORT = 22222;
    static UdpClient udp;
    Thread thread;

    void Start()
    {
        udp = new UdpClient(LOCAL_PORT);
        udp.Client.ReceiveTimeout = 1000000;
        thread = new Thread(new ThreadStart(ThreadMethod));
        thread.Start();
    }

    // void Update()
    // {
    // }

    void OnApplicationQuit()
    {
        thread.Abort();
    }

    private static void ThreadMethod()
    {
        Debug.Log("Start Thread");
        while (true)
        {
            IPEndPoint remoteEP = null;
            byte[] data = udp.Receive(ref remoteEP);
            string text = Encoding.ASCII.GetString(data);
            Debug.Log(text);
        }
    }
}
