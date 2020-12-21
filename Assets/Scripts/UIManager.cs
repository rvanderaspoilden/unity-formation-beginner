using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private GameObject inGamePanel;

    [SerializeField]
    private GameObject endPanel;

    public static UIManager Instance;

    void Awake() {
        if(Instance != null){
            Destroy(this.gameObject);
        }

        Instance = this;
        
        this.DisplayInGameView();
    }

    public void DisplayInGameView() {
        this.inGamePanel.SetActive(true);
        this.endPanel.SetActive(false);
    }

    public void DisplayEndView(bool isSuccess) {
        this.endPanel.SetActive(true);
        this.inGamePanel.SetActive(false);
    }
}
