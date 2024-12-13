using UnityEngine;

public abstract class Unit : GridUnit
{
    public UnitAI AI { get; set; }
    public UnitFaction Faction { get; set; }
    
    [SerializeField]
    private AudioClip[] destroySounds;

    [SerializeField]
    private int destroyGoldReward;

    [SerializeField]
    private int lifeDamage;

    public override void OnAwake()
    {
        if(AI != null)
        {
            AI.Awake();
        }
    }

    public override void OnUpdate()
    {
        if(AI != null)
        {
            AI.Update();
        }
    }

    public override void OnFixedUpdate()
    {
        if(AI != null)
        {
            AI.FixedUpdate();
        }

        // Needed for cell updates
        base.OnFixedUpdate();
    }

    public void DestroySafe(bool playSound = true, bool rewardGold = true)
    {
        if(playSound)
        {
            AudioSource.PlayClipAtPoint(GetRandomDestroySound(), Camera.main.transform.position, 0.25f);
        }

        if(rewardGold && destroyGoldReward > 0)
        {
            GameState.Instance.UpdateGold(destroyGoldReward);
        }

        CurrentCell.Remove(this);
        Destroy(this.gameObject);
    }

    private AudioClip GetRandomDestroySound()
    {
        return destroySounds[Random.Range(0, destroySounds.Length - 1)];
    }

    public int GetLifeDamage()
    {
        return lifeDamage;
    }
}
