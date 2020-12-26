using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public void SpawnMeteors(float threshold) {
        foreach (Transform spawner in this.spawnerTransforms) {
            if (Random.Range(0f, 1f) >= threshold) {
                this.meteorPool.GetOne().transform.position = spawner.position;
            }
        }
    }

    public void DestroyMeteor(Meteor meteor) {
        this.meteorPool.Destroy(meteor);
    }
}