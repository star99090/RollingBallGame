using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    Vector3 Offset;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position;
    }
    
    void LateUpdate() // Update() 이후에 실행되는 업데이트, 주로 UI나 카메라 이동에 대한 것은 여기서 이루어짐
    {
        transform.position = playerTransform.position + Offset;
    }
}
