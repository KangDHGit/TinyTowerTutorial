using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public delegate void callback(bool result);
    public class UserData : MonoBehaviour
    {
        public static UserData I;

        const string KEY_GOLD = "user_data_gold";
        const string KEY_POPULATION = "user_data_population";
        const string KEY_FLOOR_LIST = "user data_floor_list";

        const int INIT_POPULATION = 1;

        [SerializeField] int _gold = 0;
        [SerializeField] int _population = 0;
        [SerializeField] string _floorList;
        public int Gold { get { return _gold; } }
        public int Population { get { return _population; } }

        public string FloorList { get { return _floorList; } }

        private void Awake()
        {
            I = this;
        }

        public void Init()
        {
            #region LOAD_DATA
            LoadGold();
            LoadFloor();
            LoadPopulation();
            #endregion
        }

        public void ResetData()
        {
            PlayerPrefs.SetInt(KEY_GOLD, Common.INIT_GOLD);
            PlayerPrefs.SetInt(KEY_POPULATION, INIT_POPULATION);
        }

        public void UseGold(int cost, callback cb)
        {
            if (_gold >= cost)
            {
                _gold -= cost;
                PlayerPrefs.SetInt(KEY_GOLD, _gold);
                UI_Manager.I.Refresh_Gold_UI();

                // 결과를 알려주도록 함수를 호출
                cb(true);
            }
            else
            {
                cb(false);
            }
        }

        public void AddGold(int cost, callback cb = null, bool refredhUI = true)
        {
            _gold += cost;
            PlayerPrefs.SetInt(KEY_GOLD, _gold);
            if (refredhUI)
            {
                UI_Manager.I.Refresh_Gold_UI();
            }
            if (cb != null)
                cb(true);
        }

        public void SaveFloor(string floorName)
        {
            if (PlayerPrefs.HasKey(KEY_FLOOR_LIST))
            {
                // 이미 저장된 정보가 있다면 콤마로 이어붙이기
                _floorList = PlayerPrefs.GetString(KEY_FLOOR_LIST);
                _floorList += "," + floorName;
                PlayerPrefs.SetString(KEY_FLOOR_LIST, _floorList);
            }
            else
            {
                PlayerPrefs.SetString(KEY_FLOOR_LIST, floorName);
            }
        }
        void LoadFloor()
        {
            if (PlayerPrefs.HasKey(KEY_FLOOR_LIST))
            {
                _floorList = PlayerPrefs.GetString(KEY_FLOOR_LIST);
            }
        }
        void LoadGold()
        {
            if (!PlayerPrefs.HasKey(KEY_GOLD))
            {
                PlayerPrefs.SetInt(KEY_GOLD, Common.INIT_GOLD);
            }
            _gold = PlayerPrefs.GetInt(KEY_GOLD);
        }
        void LoadPopulation()
        {
            if (!PlayerPrefs.HasKey(KEY_POPULATION))
            {
                PlayerPrefs.SetInt(KEY_POPULATION, INIT_POPULATION);
            }
            _population = PlayerPrefs.GetInt(KEY_POPULATION);
        }
    }
}
