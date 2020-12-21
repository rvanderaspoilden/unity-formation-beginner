using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Settings")]
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject boosterGO;

    [SerializeField]
    private Transform shieldTransform;

    [SerializeField]
    private Transform bulletSpawner;

    [SerializeField]
    private Projectile projectilePrefab;

    private Joystick joystick;

    public delegate void PlayerStateChanged();
    
    public static event PlayerStateChanged OnPlayerDie;

    private void Awake() {
        this.joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update() {
        this.ManageMovement();
        this.ManageShoot();
    }

    public void Shoot() {
        Instantiate(this.projectilePrefab, this.bulletSpawner.position, this.bulletSpawner.rotation);
    }

    private void ManageShoot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            this.Shoot();
        }
    }

    private void ManageMovement() {
        Vector3 movement = new Vector3(this.joystick.Horizontal, this.joystick.Vertical, 0) * Time.deltaTime * this.moveSpeed;
        
        this.transform.Translate(movement);

        if (movement.magnitude > 0f && !this.boosterGO.activeSelf) {
            this.boosterGO.SetActive(true);
        } else if (movement.magnitude <= 0f && this.boosterGO.activeSelf) {
            this.boosterGO.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Border")) {
            OnPlayerDie?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
