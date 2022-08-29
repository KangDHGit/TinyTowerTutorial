using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TinyTower
{
    [CustomEditor(typeof(GameManager))]
    public class GameManagerInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Data Reset"))
            {
                PlayerPrefs.DeleteAll();
            }
            if (GUILayout.Button("Gold"))
            {
                UserData.I.AddGold(10000);
            }
            base.OnInspectorGUI();
        }
    }
}
