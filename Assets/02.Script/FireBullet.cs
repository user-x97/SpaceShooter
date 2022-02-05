using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
