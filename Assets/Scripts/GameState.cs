using System;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public int Gold { get; set; } = 0;
    public int Life { get; set; } = 0;

    public bool GameLost { get; set; } = false;

    [SerializeField]
    private int startingGold;

    [SerializeField]
    private int startingLife;

    [SerializeField]
    private TextMeshProUGUI goldText;

    [SerializeField]
    private TextMeshProUGUI lifeText;

    [SerializeField]
    private GameObject loserUI;

    public void UpdateGold(int amount)
    {
        Gold += amount;
        goldText.text = $"{Gold}";
    }

    public void UpdateLife(int amount)
    {
        Life += amount;
        Life = Math.Clamp(Life, 0, startingLife);
        lifeText.text = $"{Life}";

        if(Life <= 0)
        {
            GameLost = true;
        }
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
        UpdateLife(startingLife);
    }
}
