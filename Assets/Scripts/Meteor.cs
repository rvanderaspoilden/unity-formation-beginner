using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Meteor : MonoBehaviour {
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotationSpeed;

    private void OnEnable() {
        StartCoroutine(this.AutoDestroy());
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * this.moveSpeed;
        this.transform.Rotate(Vector3.forward * Time.deltaTime * this.rotationSpeed);
    }
    
    public void Destroy() {
        SpawnerManager.Instance.DestroyMeteor(this);
    }

    private IEnumerator AutoDestroy() {
        yield return new WaitForSeconds(10f);
        this.Destroy();
    }
}
