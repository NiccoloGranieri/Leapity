//
//	  UnityOSC - Example of usage for OSC receiver
//
//	  Copyright (c) 2012 Jorge Garcia Martin
//	  Last edit: Gerard Llorach 2nd August 2017
//
// 	  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// 	  documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// 	  the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
// 	  and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// 	  The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// 	  of the Software.
//
// 	  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// 	  TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// 	  THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// 	  CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// 	  IN THE SOFTWARE.
//

using UnityEngine;
using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
//using System.Text;
using UnityOSC;

namespace Leap.Unity
{
    public class oscControl : MonoBehaviour
    {
        public GameObject hands;
        public GameObject leftHand;
        public GameObject rightHand;

        static string thumbStr = "/thumb";
        static string indexStr = "/index";
        static string middleStr = "/middle";
        static string ringStr = "/ring";
        static string pinkyStr = "/pinky";
        static string palmStr = "/palm";
        static string wristStr = "/wrist";

        string[] fingerName = {thumbStr, indexStr, middleStr, ringStr, pinkyStr };

        //private OSCServer myServer;

        //public string outIP = "127.0.0.1";
        //public int outPort = 8765;
        //public int inPort = 5678;
        // Buffer size of the application (stores 100 messages from different servers)
        //public int bufferSize = 100;

        // Script initialization
        void Start()
        {
            // init OSC
            hands = GameObject.Find("HandModels");
            leftHand = hands.transform.Find("CapsuleHand_L").gameObject;
            rightHand = hands.transform.Find("CapsuleHand_R").gameObject;

            OSCHandler.Instance.Init();
            // Initialize OSC clients (transmitters)


            // Initialize OSC servers (listeners)
            //myServer = OSCHandler.Instance.CreateServer("myServer", inPort);
            // Set buffer size (bytes) of the server (default 1024)
            //myServer.ReceiveBufferSize = 1024;
            // Set the sleeping time of the thread (default 10)
            //myServer.SleepMilliseconds = 10;

        }

        // Reads all the messages received between the previous update and this one
        void Update() // Empty, (commented) OSC Message Reader
        {
            if (leftHand.gameObject.activeSelf == true)
            {
                Chirality handedness = leftHand.GetComponent<CapsuleHand>().Handedness;

                Vector3 palmPosition = leftHand.GetComponent<CapsuleHand>().getPalmPosition();
                Vector3 wristPosition = leftHand.GetComponent<CapsuleHand>().getWristPosition();
                List<Vector3> fingerPositions = leftHand.GetComponent<CapsuleHand>().getFingerPosition();

                for (int i = 0; i <= 9; i += 2)
                {
                    String thisFinger = fingerName[i / 2];

                    OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + thisFinger + "/knuckle" + "/x", fingerPositions[i].x);
                    OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + thisFinger + "/knuckle" + "/y", fingerPositions[i].y);
                    OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + thisFinger + "/knuckle" + "/z", fingerPositions[i].z);

                    OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + thisFinger + "/joint" + "/x", fingerPositions[i + 1].x);
                    OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + thisFinger + "/joint" + "/y", fingerPositions[i + 1].y);
                    OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + thisFinger + "/joint" + "/z", fingerPositions[i + 1].z);
                }

                OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + palmStr + "/x", palmPosition.x);
                OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + palmStr + "/y", palmPosition.y);
                OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + palmStr + "/z", palmPosition.z);

                OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + wristStr + "/x", wristPosition.x);
                OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + wristStr + "/y", wristPosition.y);
                OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + wristStr + "/z", wristPosition.z);
            }

            if (rightHand.gameObject.activeSelf == true)
            {
                Chirality handedness = rightHand.GetComponent<CapsuleHand>().Handedness;

                Vector3 palmPosition = rightHand.GetComponent<CapsuleHand>().getPalmPosition();
                Vector3 wristPosition = rightHand.GetComponent<CapsuleHand>().getWristPosition();
                List<Vector3> fingerPositions = rightHand.GetComponent<CapsuleHand>().getFingerPosition();

                for (int i = 0; i <= 9; i += 2)
                {
                    String thisFinger = fingerName[i / 2];

                    OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + thisFinger + "/knuckle" + "/x", fingerPositions[i].x);
                    OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + thisFinger + "/knuckle" + "/y", fingerPositions[i].y);
                    OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + thisFinger + "/knuckle" + "/z", fingerPositions[i].z);

                    OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + thisFinger + "/joint" + "/x", fingerPositions[i + 1].x);
                    OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + thisFinger + "/joint" + "/y", fingerPositions[i + 1].y);
                    OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + thisFinger + "/joint" + "/z", fingerPositions[i + 1].z);
                }

                OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + palmStr + "/x", palmPosition.x);
                OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + palmStr + "/y", palmPosition.y);
                OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + palmStr + "/z", palmPosition.z);

                OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + wristStr + "/x", wristPosition.x);
                OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + wristStr + "/y", wristPosition.y);
                OSCHandler.Instance.SendMessageToClient("myClient", "/" + handedness + wristStr + "/z", wristPosition.z);

            }
            
            // Read received messages
            //for (var i = 0; i < OSCHandler.Instance.packets.Count; i++)
            //{
            //    // Process OSC
            //    receivedOSC(OSCHandler.Instance.packets[i]);
            //    // Remove them once they have been read.
            //    OSCHandler.Instance.packets.Remove(OSCHandler.Instance.packets[i]);
            //    i--;
            //}

        }

        // Process incoming OSC messages (Commented)
        //private void receivedOSC(OSCPacket pckt)
        //{
        //    if (pckt == null) { Debug.Log("Empty packet"); return;
        //    // Origin
        //    int serverPort = pckt.server.ServerPort;
        //    // Address
        //    string address = pckt.Address.Substring(1);
        //    // Data at index 0
        //    string data0 = pckt.Data.Count != 0 ? pckt.Data[0].ToString() : "null";
        //    // Print out messages
        //    Debug.Log("Input port: " + serverPort.ToString() + "\nAddress: " + address + "\nData [0]: " + data0);
        //}
    }
}