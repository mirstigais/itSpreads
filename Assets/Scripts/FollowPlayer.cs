using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform playerTransform;
    Vector3 offset;
    Vector3 cameraOrigin;
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
        //offset from player in the beginning should be (-34.8, 32.1, -34.7)
        Debug.Log(offset);
    }


    void LateUpdate()
    {
        //Making the camera tracking work in an abstract way.
        
        transform.position = playerTransform.position + offset;
        //Debug.Log(playerTransform.position);
    }
}
