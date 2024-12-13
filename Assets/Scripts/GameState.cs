using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public float Gold { get; set; } = 0;

    public float GoldPerSecond { get; set; } = 0;

    public bool GameLost { get; set; } = false;

    [SerializeField]
    private TextMeshProUGUI goldText;

    [SerializeField]
    private TextMeshProUGUI goldPerSecondText;

    [SerializeField]
    private GameObject loserUI;

    public void UpdateGold(float amount)
    {
        Gold += amount;
        goldText.text = $"Gold: {Gold}";
    }

    public void UpdateGoldPerSecond(float amount)
    {
        GoldPerSecond += amount;
        goldPerSecondText.text = $"Gold /s: {GoldPerSecond}";
    }

    public void Update()
    {
        if(GameLost)
        {
            loserUI?.SetActive(true);

            if(Input.GetKeyUp(KeyCode.Space))
            {
                // Reload the scene / game
                SceneManager.LoadScene("Scenes/SampleScene");
            }
        }
    }

    public static GameState Instance { get; set; }
    public static PlayerController Player { get; set; }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        if(Player == null)
        {
            Player = GameObject.FindAnyObjectByType<PlayerController>();
        }
    }
}
