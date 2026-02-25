using UnityEngine;

public class ShipController : ShipData
{
    [SerializeField] private ShipBase[] shipBases;

    protected override void Awake()
    {
        base.Awake();
        InitShipBase();
    }
    private void InitShipBase()
    {
        foreach (var ship in shipBases)
        {
            ship.InitShipController(this);
        }
    }
}
