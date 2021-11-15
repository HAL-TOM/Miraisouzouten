using UnityEngine;
using UnityEditor;
using System.Collections;

public class MassCreate : EditorWindow
{
    private GameObject parent;
    private GameObject prefab;
    private int m_numX = 1;
    private int m_numY = 1;
    private float m_scaleX = 1;
    private float m_scaleY = 1;

    [MenuItem("GameObject/Create Other/MassCreate")]
    static void Init()
    {
        EditorWindow.GetWindow<MassCreate>(true, "MassCreate");
    }

    void OnEnable()
    {
        if (Selection.gameObjects.Length > 0) parent = Selection.gameObjects[0];
    }

    void OnSelectionChange()
    {
        if (Selection.gameObjects.Length > 0) prefab = Selection.gameObjects[0];
        Repaint();
    }

    void OnGUI()
    {
        try
        {
            parent = EditorGUILayout.ObjectField("Parent", parent, typeof(GameObject), true) as GameObject;
            prefab = EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), true) as GameObject;

            GUILayout.Label("X : ", EditorStyles.boldLabel);
            m_numX = int.Parse(EditorGUILayout.TextField("num", m_numX.ToString()));
            m_scaleX = int.Parse(EditorGUILayout.TextField("scale", m_scaleX.ToString()));

            GUILayout.Label("Y : ", EditorStyles.boldLabel);
            m_numY = int.Parse(EditorGUILayout.TextField("num", m_numY.ToString()));
            m_scaleY = int.Parse(EditorGUILayout.TextField("scale", m_scaleY.ToString()));
            

            GUILayout.Label("", EditorStyles.boldLabel);
            if (GUILayout.Button("Create")) Create();
        }
        catch (System.FormatException) { }
    }

    private void Create()
    {
        if (prefab == null) return;
        Vector3 scale = new Vector3(m_scaleX/(float)m_numX, m_scaleY / (float)m_numY, 1);

        Vector3 pos =new Vector3(-m_scaleX/2.0f,m_scaleY/2.0f,0.0f) + (scale/2.0f);
        for (int y = 0; y < m_numY; y++)
        {
            pos.x = -m_scaleX / 2.0f + scale.x / 2.0f;
             for (int x = 0; x < m_numX; x++)
            {
                GameObject obj = Instantiate(prefab, pos, Quaternion.identity) as GameObject;
                obj.transform.localScale = scale;
                obj.name = prefab.name + x.ToString() + y.ToString();
                if (parent) obj.transform.parent = parent.transform;
                Undo.RegisterCreatedObjectUndo(obj, "MassCreate");
                pos.x += scale.x;
            }
            pos.y -= scale.y;

        }
    }
}