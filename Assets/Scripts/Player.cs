using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Settings")]
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject boosterGO;

    [SerializeField]
    private Transform shieldTransform;

    private Joystick joystick;

    private void Awake() {
        this.joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 movement = new Vector3(this.joystick.Horizontal, this.joystick.Vertical, 0) * Time.deltaTime * this.moveSpeed;
        this.transform.Translate(movement);

        if (movement.magnitude > 0f && !this.boosterGO.activeSelf) {
            this.boosterGO.SetActive(true);
        } else if (movement.magnitude <= 0f && this.boosterGO.activeSelf) {
            this.boosterGO.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(this.gameObject);
    }
}
