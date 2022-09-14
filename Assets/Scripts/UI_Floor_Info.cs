using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTower
{
    public class UI_Floor_Info : MonoBehaviour
    {
        Text _txt_FloorName;
        List<UI_Product> _list_UI_Product;

        public void Init()
        {
            _txt_FloorName = transform.Find("Txt_FloorName").GetComponent<Text>();
            _list_UI_Product = new List<UI_Product>(GetComponentsInChildren<UI_Product>());
            foreach (UI_Product ui_product in _list_UI_Product)
            {
                ui_product.Init();
            }
            gameObject.SetActive(false);
        }

        public void OnClickClose()
        {
            UI_Manager.I._ui_Floor_Info.gameObject.SetActive(false);
            StopCoroutine(OpenScreen());
        }
        public void ShowInfo(List<GameData_Product> productDataList)
        {
            _txt_FloorName.text = productDataList[0].floor;
            for (int i = 0; i < productDataList.Count; i++)
            {
                _list_UI_Product[i].SetData(productDataList[i]);
            }
        }



        public IEnumerator OpenScreen()
        {
            Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f);
            Vector3 maxScale = new Vector3(1, 1, 1);
            float speed = 10.0f;
            transform.localScale = minScale;
            while(transform.localScale.x < maxScale.x)
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, maxScale, speed*Time.deltaTime);
                yield return null;
            }
        }
    }
}
