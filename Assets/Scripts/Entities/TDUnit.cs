public class TDUnit : Unit
{
    public TDUnit()
    {
        this.AI = new TDUnitAI(this);
        this.Faction = UnitFaction.Enemy;
    }
}
