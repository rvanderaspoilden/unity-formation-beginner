using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Meteor : MonoBehaviour {
    [SerializeField]
    private Sprite[] sprites;
    
    [SerializeField]
    private ParticleSystem explosionParticle;

    [SerializeField]
    private AudioClip explosionSound;
    
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotationSpeed;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = this.sprites[Random.Range(0, this.sprites.Length)];
        gameObject.AddComponent<PolygonCollider2D>();
    }

    private void OnEnable() {
        StartCoroutine(this.AutoDestroy());
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update() {
        this.transform.position += Vector3.down * Time.deltaTime * this.moveSpeed;
        this.transform.Rotate(Vector3.forward * Time.deltaTime * this.rotationSpeed);
    }

    public void Destroy(bool particle = true) {
        if (particle) {
            ParticleSystem explosion = Instantiate(this.explosionParticle, this.transform.position, this.explosionParticle.transform.rotation);
            ParticleSystem.TextureSheetAnimationModule sheetAnimation = explosion.textureSheetAnimation;
            sheetAnimation.SetSprite(0, this.spriteRenderer.sprite);
            GameManager.Instance.PlaySound(this.explosionSound, 0.1f);
        }

        SpawnerManager.Instance.DestroyMeteor(this);
    }

    private IEnumerator AutoDestroy() {
        yield return new WaitForSeconds(10f);
        this.Destroy(false);
    }
}