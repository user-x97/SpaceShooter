using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;
    void OnCollisionEnter(Collision call){
        if (call.gameObject.tag == "BULLET"){

            // 오브젝트 제거
            Destroy(call.gameObject);

            // 스파크 생성
            ContactPoint cp = call.GetContact(0);
            Vector3 pos = cp.point;
            Vector3 contactNormal = -cp.normal;
            Quaternion rot = Quaternion.LookRotation(contactNormal);
            GameObject obj = Instantiate(sparkEffect, pos, rot);
            Destroy(obj, 0.4f);
        }
    }
}

/*
    < 출돌 콜백 함수 >

    1. 양쪽 다 Collider 컴포넌트 존재
    2. 이동하는 물체에 Rigidbody 콤포넌트 존재

    OnCollisionEnter    1 번
    OnCollisionStay     n 번
    OnCollisionExit     1 번

    * IsTrigger일 경우
    OnTriggerEnter
    OnTriggerStay
    OnTriggerExit
*/