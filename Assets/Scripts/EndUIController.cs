using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndUIController : MonoBehaviour {
    [Header("Settings")]
    [SerializeField]
    private TextMeshProUGUI resultTitle;

    [SerializeField]
    private Button nextStageBtn;

    [SerializeField]
    private Button restartBtn;

    public void Init(bool isSuccess) {
        this.resultTitle.text = isSuccess ? "Stage finished" : "Stage failed";
        this.nextStageBtn.gameObject.SetActive(isSuccess);
        this.restartBtn.gameObject.SetActive(!isSuccess);
    }
}
