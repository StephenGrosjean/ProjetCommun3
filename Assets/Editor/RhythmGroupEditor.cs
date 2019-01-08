using UnityEngine;
using UnityEditor;


//[CustomEditor(typeof(RhythmGroup))]
public class RhythmGroupEditor : Editor {

    private bool Top_Right   , Top_Middle   , Top_Left;
    private bool Middle_Right, Middle_Middle, Middle_Left;
    private bool Bottom_Right, Bottom_Middle, Bottom_Left;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        RhythmGroup rhythmGroup = (RhythmGroup)target;

        GUILayout.Space(20);

        GUILayout.BeginHorizontal();

        GUILayout.Toggle(rhythmGroup.NoSpawner, "");
        if (GUILayout.Button("No Spawner"))
        {
            rhythmGroup.NoSpawner = !rhythmGroup.NoSpawner;

        }
        GUILayout.EndHorizontal();
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        if (rhythmGroup.NoSpawner) {
            if (GUILayout.Button("-Refresh-"))
            {
                UpdateValues(rhythmGroup);
            }

            if (GUILayout.Button("-Reset-"))
            {
                Reset();
            }

            GUILayout.BeginHorizontal();
            GUILayout.Toggle(Top_Left, ""); if (GUILayout.Button("")) { Top_Left = !Top_Left; UpdateValues(rhythmGroup); }
            GUILayout.Toggle(Top_Middle, ""); if (GUILayout.Button("")) { Top_Middle = !Top_Middle; UpdateValues(rhythmGroup); }
            GUILayout.Toggle(Top_Right, ""); if (GUILayout.Button("")) { Top_Right = !Top_Right; UpdateValues(rhythmGroup); }
            GUILayout.EndHorizontal();


            GUILayout.BeginHorizontal();
            GUILayout.Toggle(Middle_Left, ""); if (GUILayout.Button("")) { Middle_Left = !Middle_Left; UpdateValues(rhythmGroup); }
            GUILayout.Toggle(Middle_Middle, ""); if (GUILayout.Button("")) { Middle_Middle = !Middle_Middle; UpdateValues(rhythmGroup); }
            GUILayout.Toggle(Middle_Right, ""); if (GUILayout.Button("")) { Middle_Right = !Middle_Right; UpdateValues(rhythmGroup); }
            GUILayout.EndHorizontal();


            GUILayout.BeginHorizontal();
            GUILayout.Toggle(Bottom_Left, ""); if (GUILayout.Button("")) { Bottom_Left = !Bottom_Left; UpdateValues(rhythmGroup); }
            GUILayout.Toggle(Bottom_Middle, ""); if (GUILayout.Button("")) { Bottom_Middle = !Bottom_Middle; UpdateValues(rhythmGroup); }
            GUILayout.Toggle(Bottom_Right, ""); if (GUILayout.Button("")) { Bottom_Right = !Bottom_Right; UpdateValues(rhythmGroup); }
            GUILayout.EndHorizontal();


        }
    }


    void Reset()
    {
        Top_Left = false;
        Middle_Left = false;
        Bottom_Left = false;

        Top_Right = false;
        Middle_Right = false;
        Bottom_Right = false;

        Top_Middle = false;
        Middle_Middle = false;
        Bottom_Middle = false;
    }

    void UpdateValues(RhythmGroup rg)
    {
        /*if (rg.Top_LeftG != null)
        {
            rg.Top_LeftG.transform.position = new Vector3(-rg.Range, rg.Range, 0);
        }
        if (rg.Top_MiddleG != null)
        {
            rg.Top_MiddleG.transform.position = new Vector3(0, rg.Range, 0);
        }
        if (rg.Top_RightG != null)
        {
            rg.Top_RightG.transform.position = new Vector3(rg.Range, rg.Range, 0);
        }



        if (rg.Middle_LeftG != null)
        {
            rg.Middle_LeftG.transform.position = new Vector3(-rg.Range, 0, 0);
        }
        if (rg.Middle_MiddleG != null)
        {
            rg.Middle_MiddleG.transform.position = new Vector3(0, 0, 0);
        }
        if (rg.Middle_RightG != null)
        {
            rg.Middle_RightG.transform.position = new Vector3(rg.Range, 0, 0);
        }

        if (rg.Bottom_LeftG != null)
        {
            rg.Bottom_LeftG.transform.position = new Vector3(-rg.Range, -rg.Range, 0);
        }
        if (rg.Bottom_MiddleG != null)
        {
            rg.Bottom_MiddleG.transform.position = new Vector3(0, -rg.Range, 0);
        }

        if (rg.Bottom_RightG != null)
        {
            rg.Bottom_RightG.transform.position = new Vector3(rg.Range, -rg.Range, 0);
        }*/
    }
}
