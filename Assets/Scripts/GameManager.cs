using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [Header("Settings")]
    [SerializeField]
    private int stageDuration;

    [SerializeField]
    private float spawnInterval;

    [SerializeField]
    private float spawnThreshold;

    [Header("Debug")]
    [SerializeField]
    private int timer;

    private AudioSource audioSource;

    private Coroutine spawnMeteorsCoroutine;

    public static GameManager Instance;

    private void Awake() {
        if (Instance != null) {
            Destroy(this.gameObject);
        }

        Instance = this;
        
        this.audioSource = GetComponent<AudioSource>();
    }

    void Start() {
        Player.OnPlayerDie += this.OnPlayerDie;
        
        this.StartLevel();
    }

    void OnDestroy() {
        Player.OnPlayerDie -= this.OnPlayerDie;
        
        StopAllCoroutines();
    }

    public void BackToLobby() {
        SceneManager.LoadScene("Lobby");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlaySound(AudioClip sound, float volume) {
        this.audioSource.volume = volume;
        this.audioSource.PlayOneShot(sound);
    }

    public void NextLevel() {
        Debug.Log("Next level");
    }

    private void OnPlayerDie() {
        UIManager.Instance.DisplayEndView(false);
    }

    private void StartLevel() {
        StartCoroutine(this.StartTimer());
        this.spawnMeteorsCoroutine = StartCoroutine(this.SpawnMeteors());
    }

    private IEnumerator SpawnMeteors() {
        while (true) {
            SpawnerManager.Instance.SpawnMeteors(spawnThreshold);
            yield return new WaitForSeconds(spawnInterval);

            if (this.spawnInterval >= 2f) {
                this.spawnInterval = this.spawnInterval / 1.5f;
            }
        }
    }

    private IEnumerator StartTimer() {
        this.timer = this.stageDuration;

        UIManager.Instance.SetTimer(this.timer);
        while (this.timer > 0f) {
            yield return new WaitForSeconds(1f);
            this.timer--;
            UIManager.Instance.SetTimer(this.timer);
        }
        
        StopCoroutine(this.spawnMeteorsCoroutine);
        
        foreach (Meteor meteor in FindObjectsOfType<Meteor>()) {
            SpawnerManager.Instance.DestroyMeteor(meteor);
        }
        
        UIManager.Instance.DisplayEndView(true);
    }
}