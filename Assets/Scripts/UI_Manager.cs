using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TinyTower
{
    public class UI_Manager : MonoBehaviour
    {
        [SerializeField] Text _txt_Gold;
        [SerializeField] Text _txt_population;
        public UI_Floor_Info _ui_Floor_Info;
        private GraphicRaycaster _gRayCaster; //UI Raycast

        public static UI_Manager I; // 싱글턴 인스턴스를 의미
        private void Awake()
        {
            I = this;
        }
        public void Init()
        {
            _txt_Gold = transform.Find("UI_TopBar/Coin/Txt_Coin").GetComponent<Text>();
            _txt_population = transform.Find("UI_TopBar/Population/Txt_Population").GetComponent<Text>();
            _ui_Floor_Info = transform.Find("UI_Floor_Info").GetComponent<UI_Floor_Info>();
            _gRayCaster = GetComponent<GraphicRaycaster>();
            if (_ui_Floor_Info != null)
                _ui_Floor_Info.Init();
            Refresh_Gold_UI();
        }

        public void Refresh_Gold_UI()
        {
            _txt_Gold.text = UserData.I.Gold.ToString();
            _txt_population.text = UserData.I.Population.ToString();
        }
        
        void Update()
        {
            
        }

        public bool CheckClickUI()
        {
            PointerEventData data = new PointerEventData(EventSystem.current);
            // EventSystem.current : 씬에있는 현재 이벤트 시스템
            data.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            _gRayCaster.Raycast(data, results);

            if (results.Count > 0)
            {
                foreach (var item in results)
                {
                    Debug.Log(item.gameObject.name);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
