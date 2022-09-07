using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace TinyTower
{
    public class GameData : MonoBehaviour
    {
        public static GameData I;

        // 상품데이터 관리
        public TextAsset _product_csv;                      // csv파일 자체
        public List<GameData_Product> _product_dataList;

        private void Awake()
        {
            I = this;
        }

        public void Init()
        {
            Init_ProductData();
        }

        void Init_ProductData()
        {
            string text = _product_csv.text;

            //StringReader : System.IO의 클래스, 파일로부터 문자열 읽게 해줌
            using(StringReader reader = new StringReader(text))
            {
                string firstline = reader.ReadLine(); // 컬럼명(불필요)
                if(firstline != null) // 빈파일이 아닐경우
                {
                    string line = null;
                    while((line = reader.ReadLine()) != null)
                    {
                        string[] record = line.Split(',');
                        Debug.Assert(record.Length == 5);

                        GameData_Product temp = new GameData_Product();
                        temp.name = record[0];
                        temp.floor = record[1];
                        temp.cost = Convert.ToInt32(record[2]);
                        temp.time = Convert.ToSingle(record[3]);
                        temp.quantity = Convert.ToInt32(record[4]);
                        _product_dataList.Add(temp);
                    }
                }
            }
        }
    }
}
