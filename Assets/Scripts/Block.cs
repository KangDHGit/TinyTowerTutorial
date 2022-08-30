using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class Block : MonoBehaviour
    {
        private void OnMouseDown()
        {
            UserData.I.UseGold(Common.COST_SHOP,UseGoldCb);
        }

        void UseGoldCb(bool result)
        {
            if(result)
            {
                Debug.Log(this.name);
                
                FloorManager.I.CreateFloor(transform.position);
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
        public void Raise()
        {
            transform.position = new Vector3(0, transform.position.y + 4, 0);
        }
    }
}
