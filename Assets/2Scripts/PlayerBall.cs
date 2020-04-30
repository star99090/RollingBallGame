using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 가져오기 위해 적는다.

public class PlayerBall : MonoBehaviour
{
    public float jumpPower; // public으로 만들면 Unity에서 바로 접근이 가능하다
    public int itemCount;
    public GameManagerLogic manager;
    bool isJump;
    Rigidbody rigid;
    AudioSource audio;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>(); // Rigidbody를 import, 생성자같은 느낌
        audio = GetComponent<AudioSource>();
        // <>안에는 우리가 참조해야할 스크립트 이름을 넣는다.
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")&& !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }

    }
    void FixedUpdate() // 물리요소 접근은 FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h,0,v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision) // 충돌 시 생기는 이벤트
    {
        if (collision.gameObject.tag == "Floor") // 만약 이 스크립트가 적용된 오브젝트가 Floor라는 오브젝트를 만나면 진행
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false); // gameObject는 자기 자신, SetActive : 활성화, 비활성화 나타내는 것
            manager.GetItem(itemCount);
            //other가 아이템일테니 그것의 gameObject는 item이 된다.
        }
        else if(other.tag == "Finish")
        {
            if(itemCount == manager.totalItemCount)
            {
                SceneManager.LoadScene((manager.stage + 1));//Game Clear!!
            }
            else
            {
                SceneManager.LoadScene(manager.stage); //ScenManager : 씬 관리 기본 / LoadScene : 화면 불러오는친구
                //Restart.. 
            }
        }
    }
}
