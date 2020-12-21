using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Player.OnPlayerDie += this.OnPlayerDie;
    }

    void OnDestroy() {
        Player.OnPlayerDie -= this.OnPlayerDie;
    }

    public void BackToLobby() {
        SceneManager.LoadScene("Lobby");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel() {
        Debug.Log("Next level");
    }

    private void OnPlayerDie() {
        UIManager.Instance.DisplayEndView(false);
    }
}
