using UnityEngine;

[CreateAssetMenu(fileName = "FormationData", menuName = "Game/Formation Data")]
public class FormationData : ScriptableObject
{
    public int width = 10;
    public int height = 10;

    public EnemyType[] grid;

    private void OnEnable()
    {
        if (grid == null || grid.Length != width * height)
        {
            grid = new EnemyType[width * height];
        }
    }

    public EnemyType Get(int x, int y)
    {
        int index = y * width + x;
        if (index < 0 || index >= grid.Length)
            return EnemyType.None;

        return grid[index];
    }

    public void Set(int x, int y, EnemyType type)
    {
        int index = y * width + x;
        if (index < 0 || index >= grid.Length)
            return;

        grid[index] = type;
    }
}