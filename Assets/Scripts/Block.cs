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
                newBlock.transform.SetParent(FloorManager.I.transform);
                newBlock.transform.position = new Vector3(0, transform.position.y, 0);
                newBlock.SetActive(true);

                this.transform.position = new Vector3(0, transform.position.y + 4, 0);
            }
            else
            {
                // 돈이부족합니다 팝업창
                PlatformDialog.SetButtonLabel("OK");
                PlatformDialog.Show(
                    "알림",
                    "골드가 부족합니다",
                    PlatformDialog.Type.SubmitOnly,
                    () => {
                        Debug.Log("OK");
                    },
                    null
                                    );
            }
        }
    }
}
