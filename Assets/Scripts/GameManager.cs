using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager I;
        private void Awake()
        {
            I = this;
        }
        void Start()
        {
            UserData.I.Init();

            // 플로어매니저 초기화
            FloorManager.I.Init();

            UI_Manager.I.Init();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
