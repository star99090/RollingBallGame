using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCan : MonoBehaviour
{
    public float rotateSpeed;

    void Update() // 어떠한 사양에서든 동일한 속도로 돌아야해서 Time.deltaTime 곱해줘야함
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);//Rotata(Verctor3) : 매개변수 기준으로 회전시키는 함수
        //뒤에 매개변수로 Space.World(Space.Self)로 월드좌표계(로컬좌표계)를 조정할 수 있다. 로컬은 오브젝트 기준!
    }
}
