using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class CameraDrag : MonoBehaviour
    {
        Vector3 _dragStartPos;
        public float _dragSpeed;
        [SerializeField] float _yMin = 20.0f;
        [SerializeField] float _yMax = 60.0f;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0)) // 마우스가 클릭됨(드래그 시작)
            {
                _dragStartPos = Input.mousePosition;
            }
            else if(Input.GetMouseButton(0)) // 마우스가 계속 눌려지고 있는 상태
            {
                Vector3 currentPos = Input.mousePosition;

                // 이때 카메라를 움직여주기
                Vector3 dir = currentPos - _dragStartPos;

                Vector3 worldDir = Camera.main.ScreenToViewportPoint(dir);

                Vector3 move = new Vector3(0, -worldDir.y * _dragSpeed, 0) * Time.deltaTime;

                if( move.y > 0)
                {
                    if(transform.position.y < _yMax)
                        transform.Translate(move);
                }
                if (move.y < 0)
                {
                    if(transform.position.y > _yMin)
                        transform.Translate(move);
                }

                _dragStartPos += dir * 2.0f * Time.deltaTime;
            }
        }
    }
}
