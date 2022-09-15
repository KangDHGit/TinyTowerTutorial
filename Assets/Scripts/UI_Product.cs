using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTower
{
    public class UI_Product : MonoBehaviour
    {
        Text _txt_Name;
        Text _txt_Cost;
        Text _txt_Time;
        Text _txt_Quantity;
        Image _img_Product;

        Text _txt_ordering;
        Image _Img_ProgressBar;
        GameData_Product _product;
        GameObject _obj_StartSell;
        GameObject _obj_BlackBg;

        private int _stat = 0; // 0 - 판매대기, 1- 주문중, 2- 판매
        
        public void Init()
        {
            _txt_Name = transform.Find("Txt_ProductName").GetComponent<Text>();
            _txt_Cost = transform.Find("UI_Cost/Txt_Cost").GetComponent<Text>();
            _txt_Time = transform.Find("UI_Cost/Txt_Time").GetComponent<Text>();
            _txt_Quantity = transform.Find("UI_Cost/Txt_Quantity").GetComponent<Text>();
            _img_Product = transform.Find("Img_Product").GetComponent<Image>();
            _Img_ProgressBar = transform.Find("ProgressBar/Img_Fill").GetComponent<Image>();
            _Img_ProgressBar.transform.parent.gameObject.SetActive(false);
            _obj_StartSell = transform.Find("UI_StartSell").gameObject;
            _obj_BlackBg = transform.Find("Img_Bg(Black)").gameObject;

            UI_Manager.I.StartCoroutine(_State_WaitForSelling());
        }

        public void SetData(GameData_Product product)
        {
            _txt_Name.text = product.name;
            _txt_Cost.text = product.cost.ToString();
            _txt_Time.text = product.time.ToString();
            _txt_Quantity.text = product.quantity.ToString();
            _img_Product.sprite = product.sprite;
            _product = product;
        }

        public void OnClick_StartSelling()
        {
            _stat = 1;
        }
        IEnumerator _State_WaitForSelling()
        {
            Debug.Log("판매대기");
            _stat = 0;
            while(true)
            {
                if (_stat != 0)
                    break;
                yield return null;
            }
            StartCoroutine(_State_Ordering());
        }
        IEnumerator _State_Ordering()
        {
            _Img_ProgressBar.transform.parent.gameObject.SetActive(true);

            float totalTime = _product.time;
            float currentTime = _product.time;
                
            while (true)
            {
                Debug.Log("주문중");
                currentTime -= Time.deltaTime;
                _Img_ProgressBar.fillAmount = currentTime / totalTime;

                if (currentTime <= 0)
                {
                    StartCoroutine(_State_Selling());
                    break;
                }
                if (_stat != 1)
                    break;
                yield return null;
            }
        }
        IEnumerator _State_Selling()
        {
            _obj_StartSell.SetActive(false);
            _obj_BlackBg.SetActive(false);
            _Img_ProgressBar.transform.parent.gameObject.SetActive(false);
            yield return null;
        }
    }
}
