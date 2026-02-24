using UnityEngine;

public class ShipController : ShipData
{
    [SerializeField] private ShipBase[] shipBases;

    private void Awake()
    {
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
