using System;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Settings")]
    [SerializeField]
    private float moveSpeed;

    private Joystick joystick;

    private void Awake() {
        this.joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 movement = new Vector3(this.joystick.Horizontal, this.joystick.Vertical, 0) * Time.deltaTime * this.moveSpeed;
        this.transform.Translate(movement);
    }
}
