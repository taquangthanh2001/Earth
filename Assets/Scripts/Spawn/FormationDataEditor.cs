using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FormationData))]
public class FormationDataEditor : Editor
{
    private FormationData data;

    private const int cellSize = 25;

    private void OnEnable()
    {
        data = (FormationData)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Formation Grid", EditorStyles.boldLabel);

        if (data.grid == null || data.grid.Length != data.width * data.height)
        {
            data.grid = new EnemyType[data.width * data.height];
        }

        for (int y = 0; y < data.height; y++)
        {
            EditorGUILayout.BeginHorizontal();

            for (int x = 0; x < data.width; x++)
            {
                EnemyType current = data.Get(x, y);

                GUI.backgroundColor = GetColor(current);

                if (GUILayout.Button(GetLabel(current), GUILayout.Width(cellSize), GUILayout.Height(cellSize)))
                {
                    EnemyType next = GetNext(current);
                    data.Set(x, y, next);
                    EditorUtility.SetDirty(data);
                }
            }

            EditorGUILayout.EndHorizontal();
        }

        GUI.backgroundColor = Color.white;
    }

    private EnemyType GetNext(EnemyType type)
    {
        int next = ((int)type + 1) % System.Enum.GetValues(typeof(EnemyType)).Length;
        return (EnemyType)next;
    }

    private string GetLabel(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Normal: return "N";
            case EnemyType.Elite: return "E";
            case EnemyType.Boss: return "B";
            case EnemyType.SuperBot: return "S";
            default: return ".";
        }
    }

    private Color GetColor(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Normal: return Color.white;
            case EnemyType.Elite: return Color.yellow;
            case EnemyType.Boss: return Color.red;
            case EnemyType.SuperBot: return Color.cyan;
            default: return Color.gray;
        }
    }
}