using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class Block : MonoBehaviour
    {
        [SerializeField] GameObject[] _templates;

        private void OnMouseDown()
        {
            UserData.I.UseGold(Common.COST_SHOP,UseGoldCb);
        }

        void UseGoldCb(bool result)
        {
            if(result)
            {
                Debug.Log(this.name);
                int choice = Random.Range(0, _templates.Length);

                GameObject newBlock = Instantiate(_templates[choice]);
                newBlock.transform.SetParent(transform.parent);
                newBlock.transform.position = new Vector3(0, transform.position.y, 0);
                newBlock.SetActive(true);

                this.transform.position = new Vector3(0, transform.position.y + 4, 0);
            }
            else
            {
                // 돈이부족합니다 팝업창
            }
        }
    }
}
