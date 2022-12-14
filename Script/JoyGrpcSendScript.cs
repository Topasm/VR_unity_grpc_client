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
        Start();
        GetData();
        SendPosition();

    }

    public SteamVR_Action_Pose poseActionR = SteamVR_Input.GetAction<SteamVR_Action_Pose>("Pose");
    public Channel channel;
    public Vector3 vPosition;
    public Vector3 qRotation;
    

    void GetData()
    {

     vPosition = velocity[SteamVR_Input_Sources.RightHand].velocity;
     qRotation = angularVelocity[SteamVR_Input_Sources.RightHand].angularVelocity;

    }




    void Start()
    {
        
        //var responce = await client.GetPoseAck();

        // call = PoseClient.GetPose();
        
    }



    private async Task SendPosition()
    {
        channel =  new Channel("192.168.0.4:50051", ChannelCredentials.Insecure);
        var client = new Position.PositionClient(channel);
        Vector3 tmpPose = vPosition;
        var px = tmpPose.x;
        var py = tmpPose.y;
        var pz = tmpPose.z;
        Vector3 tmpRot = qRotation;
        var rx = tmpRot.x;
        var ry = tmpRot.y;
        var rz = tmpRot.z;
        #var rw = tmpRot.w;
        var send = new RobotPose.GetPoseSend{Id = "unity", X = px, Y = py, Z= pz, Qx= rx, Qy=ry, Qz= rz, Qw =  0};
        var responce = await client.GetPoseAsync(send);
        Debug.Log(px);
       

    }

    
}
