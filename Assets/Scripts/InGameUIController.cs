using TMPro;
using UnityEngine;

public class InGameUIController : MonoBehaviour {

    [Header("Settings")]
    [SerializeField]
    private TextMeshProUGUI timer;

    public void SetTimer(int value) {
        this.timer.text = value + "s";
    }
}
