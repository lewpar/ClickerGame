using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    public void LoadFirstScene()
    {
        SceneManager.LoadScene("Scenes/Levels/Level01");
    }
}
