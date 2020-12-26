using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private AudioClip sound;

    private void OnEnable() {
        GameManager.Instance.PlaySound(this.sound, 0.3f);

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
        if (other.CompareTag("Meteor")) {
            other.GetComponent<Meteor>().Destroy();
        }
        
        Destroy(this.gameObject);
    }

    private IEnumerator AutoDestroy() {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}