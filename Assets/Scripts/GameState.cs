using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public int Gold { get; set; } = 0;

    public bool GameLost { get; set; } = false;

    [SerializeField]
    private int startingGold;

    [SerializeField]
    private TextMeshProUGUI goldText;

    [SerializeField]
    private GameObject loserUI;

    public void UpdateGold(int amount)
    {
        Gold += amount;
        goldText.text = $"Gold: {Gold}";
    }

    public void Update()
    {
        if(GameLost)
        {
            loserUI?.SetActive(true);

            if(Input.GetKeyUp(KeyCode.Space))
            {
                // Reload the scene / game
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public static GameState Instance { get; set; }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        UpdateGold(startingGold);
    }
}
