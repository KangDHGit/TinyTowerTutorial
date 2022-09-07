using System;
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
            GameData.I.Init();

            UserData.I.Init();

            // 플로어매니저 초기화
            FloorManager.I.Init();

            UI_Manager.I.Init();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        private void OnApplicationQuit()
        {
            string stopTime = DateTime.Now.ToString();
            PlayerPrefs.SetString("game_stop_time", stopTime);
        }
    }
}
