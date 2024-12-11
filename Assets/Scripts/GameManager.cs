using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float currentTime = 0;

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > 1)
        {
            currentTime = 0;
            GameState.Instance.UpdateGold(GameState.Instance.GoldPerSecond);
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AddGold1()
    {
        GameState.Instance.UpdateGold(1);
    }

    public void BuyItem1()
    {
        if(GameState.Instance.Gold >= 10)
        {
            GameState.Instance.UpdateGoldPerSecond(1);
            GameState.Instance.UpdateGold(-10);
        }
    }
}
