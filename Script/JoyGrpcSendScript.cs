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


[RequireComponent(typeof(SteamVR_Behaviour_Pose))]
public class JoyGrpcSendScript : MonoBehaviour
{
    public Channel channel;
    public SteamVR_Behaviour_Pose VRpose;

    void Start()
    {
        channel =  new Channel("192.168.0.4:50051", ChannelCredentials.Insecure);
        // call = PoseClient.GetPose();
        
    }

    void Update()
    {
        
        VRpose = gameObject.GetComponent<SteamVR_Behaviour_Pose>();
        VRpose.UpdateTransform();
    
    }

    private async Task SendPosition()
    {
        Vector3 tmp = VRpose.transform.position;
        var px = tmp.x;
        var py = tmp.y;
        var pz = tmp.z;
        var req = new GetPose{Id = "r", x=px, y=  py, z= pz};
        // await call.GetPose.WriteAsync(req);

    }

    
}
