using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 6;
    public float rotate = 500;
    private float h, v, r;

    [HideInInspector]
    public Animation anim;

    void Start() {
        anim = this.gameObject.GetComponent<Animation>();   // 제너릭 타입
        anim.Play("Idle");
    }

    void Update() {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        r = Input.GetAxis("Mouse X");

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);

        transform.Translate(dir.normalized * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotate * Time.deltaTime * r);

        PlayerAnimation();
    }

    void PlayerAnimation() {    // 애니메이션 블렌딩
        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.25f);      // 전진
        }
        else if (v <= -0.1f) {
            anim.CrossFade("RunB", 0.25f);      // 후진
        }
        else if (h >= 0.1f) {
            anim.CrossFade("RunR", 0.25f);      // 우
        }
        else if (h <= -0.1f) {
            anim.CrossFade("RunL", 0.25f);      // 좌
        }
        else {
            anim.CrossFade("Idle", 0.1f);       // 정지
        }
    }
}
