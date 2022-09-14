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
        
        public void Init()
        {
            _txt_Name = transform.Find("Txt_ProductName").GetComponent<Text>();
            _txt_Cost = transform.Find("UI_Cost/Txt_Cost").GetComponent<Text>();
            _txt_Time = transform.Find("UI_Cost/Txt_Time").GetComponent<Text>();
            _txt_Quantity = transform.Find("UI_Cost/Txt_Quantity").GetComponent<Text>();
            _img_Product = transform.Find("Img_Product").GetComponent<Image>();
        }

        public void SetData(GameData_Product product)
        {
            _txt_Name.text = product.name;
            _txt_Cost.text = product.cost.ToString();
            _txt_Time.text = product.time.ToString();
            _txt_Quantity.text = product.quantity.ToString();
            _img_Product.sprite = product.sprite;
        }
    }
}
