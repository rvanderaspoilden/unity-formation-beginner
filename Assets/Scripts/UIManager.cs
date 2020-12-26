using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private InGameUIController inGameUIController;

    [SerializeField]
    private EndUIController endUIController;

    public static UIManager Instance;

    void Awake() {
        if(Instance != null){
            Destroy(this.gameObject);
        }

        Instance = this;
        
        this.DisplayInGameView();
    }

    public void DisplayInGameView() {
        this.inGameUIController.gameObject.SetActive(true);
        this.endUIController.gameObject.SetActive(false);
    }

    public void DisplayEndView(bool isSuccess) {
        this.endUIController.Init(isSuccess);
        this.endUIController.gameObject.SetActive(true);
        this.inGameUIController.gameObject.SetActive(false);
    }

    public void SetTimer(int value) {
        this.inGameUIController.SetTimer(value);
    }
}
