using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private AudioClip sound;

    private AudioSource audioSource;

    private void Awake() {
        this.audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() {
        this.audioSource.PlayOneShot(this.sound);

        StartCoroutine(this.AutoDestroy());
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update() {
        this.transform.Translate(Vector3.up * Time.deltaTime * this.moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }

    private IEnumerator AutoDestroy() {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}