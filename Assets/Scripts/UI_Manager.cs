using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTower
{
    public class UI_Manager : MonoBehaviour
    {
        [SerializeField] Text _txt_Gold;
        [SerializeField] Text _txt_population;

        public static UI_Manager I; // 싱글턴 인스턴스를 의미
        private void Awake()
        {
            I = this;
        }
        public void Init()
        {
            _txt_Gold = transform.Find("UI_TopBar/Coin/Txt_Coin").GetComponent<Text>();
            _txt_population = transform.Find("UI_TopBar/Population/Txt_Population").GetComponent<Text>();
            Refresh_Gold_UI();
        }

        void Refresh_Gold_UI()
        {
            _txt_Gold.text = UserData.I.Gold.ToString();
            _txt_population.text = UserData.I.Population.ToString();
        }
        
        void Update()
        {
            
        }
    }
}
