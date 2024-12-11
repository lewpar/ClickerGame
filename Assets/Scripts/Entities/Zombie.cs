using UnityEngine;

public class Zombie : Unit
{
    public Zombie()
    {
        this.AI = new ZombieAI(this);
    }
}
