using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {
    [SerializeField]
    private List<Transform> spawnerTransforms;

    [SerializeField]
    private Meteor meteorPrefab;

    [SerializeField]
    private Pool<Meteor> meteorPool;

    public static SpawnerManager Instance;

    private void Awake() {
        if (Instance != null) {
            Destroy(this.gameObject);
        }

        Instance = this;
        
        this.meteorPool = new Pool<Meteor>(() => Instantiate(meteorPrefab), 10);
    }

    private void Start() {
        StartCoroutine(this.SpawnMeteors());
    }

    public void DestroyMeteor(Meteor meteor) {
        this.meteorPool.Destroy(meteor);
    }

    private IEnumerator SpawnMeteors() {
        while (true) {
            foreach (Transform spawner in this.spawnerTransforms) {
                this.meteorPool.GetOne().transform.position = spawner.position;
            }
            yield return new WaitForSeconds(5f);
        }
    }
}
