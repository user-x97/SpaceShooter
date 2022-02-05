using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;
    public AudioClip fireSFX;
    [System.NonSerialized]
    public new AudioSource audio;
    public MeshRenderer muzzleFlash;

    void Start() {
        audio = GetComponent<AudioSource>();
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        muzzleFlash.enabled = false;
    }

    void Update()
    {
        Fire();
    }

    void Fire(){
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            audio.PlayOneShot(fireSFX, 0.5f);
            StartCoroutine(ShowMuzzleFlash());
        }
    }

    IEnumerator ShowMuzzleFlash(){
        float angle = Random.Range(0, 360);
        float scale = Random.Range(1.0f, 3.0f);
        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f;

        muzzleFlash.transform.localRotation = Quaternion.Euler(0, 0, angle);
        muzzleFlash.transform.localScale = Vector3.one * scale;
        muzzleFlash.material.mainTextureOffset = offset;

        muzzleFlash.enabled = true;

        yield return new WaitForSeconds(0.02f);

        muzzleFlash.enabled = false;
    }
}
