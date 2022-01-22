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

        // Debug.Log("dir=" + dir.magnitude + "   n=" + dir.normalized);
    }
}
