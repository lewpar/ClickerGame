using Unity.VisualScripting;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public UnitAI AI { get; set; }

    private void Awake()
    {
        if(AI != null)
        {
            AI.Awake();
        }
    }

    private void Update()
    {
        if(AI != null)
        {
            AI.Update();
        }
    }

    private void FixedUpdate()
    {
        if(AI != null)
        {
            AI.FixedUpdate();
        }
    }
}
