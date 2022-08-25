using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class UserData : MonoBehaviour
    {
        public static UserData I;

        const string KEY_GOLD = "user_data_gold";
        const int INIT_GOLD = 10000;

        const string KEY_POPULATION = "user_data_population";
        const int INIT_POPULATION = 1;

        [SerializeField] int _gold = 0;
        [SerializeField] int _population = 0;
        public int Gold { get { return _gold; } }
        public int Population { get { return _population; } }

        private void Awake()
        {
            I = this;
        }

        public void Init()
        {
            // 앱을 처음 실행하는 것이라면 자금을 주고 시작
            if (!PlayerPrefs.HasKey(KEY_GOLD))
            {
                PlayerPrefs.SetInt(KEY_GOLD, INIT_GOLD);
            }
            if(!PlayerPrefs.HasKey(KEY_POPULATION))
            {
                PlayerPrefs.SetInt(KEY_POPULATION, INIT_POPULATION);
            }
            // 이미 실행한 적이 있다면 저장되어있는 자금을 로드
            _gold = PlayerPrefs.GetInt(KEY_GOLD);
            _population = PlayerPrefs.GetInt(KEY_POPULATION);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
