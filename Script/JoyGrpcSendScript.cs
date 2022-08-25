using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grpc.Core;
using UnityEngine.Events;
using Google.Protobuf;
using System.Threading;
using System.Threading.Tasks;
using RobotPose;
using Valve.VR;



public class JoyGrpcSendScript : MonoBehaviour
{
    private void FixedUpdate()
    {
        GetData();

    }

    public SteamVR_Action_Pose poseActionR = SteamVR_Input.GetAction<SteamVR_Action_Pose>("Pose");
    public Channel channel;
    public Vector3 vPosition;
    public Quaternion qRotation;
    void GetData()
    {

     vPosition = poseActionR[SteamVR_Input_Sources.RightHand].localPosition;
     qRotation = poseActionR[SteamVR_Input_Sources.RightHand].localRotation;
    Debug.Log(vPosition);
    Debug.Log(qRotation);
    }




    void Start()
    {
        channel =  new Channel("192.168.0.4:50051", ChannelCredentials.Insecure);
        // call = PoseClient.GetPose();
        
    }



    private async Task SendPosition()
    {
        Vector3 tmp = vPosition;
        var px = tmp.x;
        var py = tmp.y;
        var pz = tmp.z;
        Debug.Log(px);
        // await call.GetPose.WriteAsync(req);

    }

    
}
