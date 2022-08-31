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
        float _nextTime = 1.0f;

        public void CollectGold()
        {
            _nowTime = Time.time;
            if (_nowTime > _nextTime)
            {
                UserData.I.AddGold(1);
                _nextTime += 1.0f;
            }
        }

        public void ShowInfo()
        {
            float nowTime = Time.time;
            if(nowTime > _nextTime)
            Debug.Log(_type + " " + name);
        }

        private void Update()
        {
            CollectGold();
        }
        private void OnMouseDown()
        {
            ShowInfo();
        }
    }
}
