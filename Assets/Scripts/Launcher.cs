using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Main");
    }
}
