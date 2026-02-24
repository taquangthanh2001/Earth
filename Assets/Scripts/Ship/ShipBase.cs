using UnityEngine;

public class ShipBase : MonoBehaviour
{
    protected ShipController shipController;
    public virtual void InitShipController(ShipController shipController)
    {
        this.shipController = shipController;
    }
}
