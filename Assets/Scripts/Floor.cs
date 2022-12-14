using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public enum FloorType
    {
        RESIDENTIAL,    //주거
        FOOD_STORE,     //음식점
        SERVICE,        //서비스 스토어
        CULTURE,        //문화시설
        CREATIVE,       //예술, 창작
        RETAIL,         //각종판매점
        BUSINESS        //사무실, 사업장
    }

    public interface IIncomeCollector
    {
        void CollectGold();
    }

    public class Floor : MonoBehaviour, IIncomeCollector
    {
        public FloorType _type;
        float _nowTime = 0.0f;
        float _coolTime = 1.0f;
        int _income = 1;
        string _stopTime;

        public void Init()
        {
            if(PlayerPrefs.HasKey("game_stop_time"))
            {
                string lastGameTime = PlayerPrefs.GetString("game_stop_time");
                DateTime now = DateTime.Now;
                DateTime stopTime = DateTime.Parse(lastGameTime);
                TimeSpan span = now - stopTime;
                int incomeTotal = (int)(span.TotalSeconds / _coolTime * _income);
                UserData.I.AddGold(incomeTotal, null, false);
            }
        }

        public void CollectGold()
        {
            _nowTime += Time.deltaTime;
            if (_nowTime > _coolTime)
            {
                UserData.I.AddGold(_income);
                _nowTime = 0.0f;
            }
        }

        
        private void Update()
        {
            CollectGold();
        }
       
        private void OnMouseUp()
        {
            if (!UI_Manager.I.CheckClickUI())
            {
                List<GameData_Product> datalist = new List<GameData_Product>();

                foreach (GameData_Product data in GameData.I._product_dataList)
                {
                    if (data.floor == gameObject.name)
                    {
                        datalist.Add(data);
                    }
                }
                UI_Manager.I._ui_Floor_Info.ShowInfo(datalist);
                UI_Manager.I._ui_Floor_Info.gameObject.SetActive(true);
                StartCoroutine(UI_Manager.I._ui_Floor_Info.OpenScreen());
            }
        }
    }
}
