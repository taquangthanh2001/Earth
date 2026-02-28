using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    public float Gold { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddGold(float amount)
    {
        Gold += amount;
    }
}