using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class FloorManager : MonoBehaviour
    {
        public static FloorManager I;
        [SerializeField] GameObject[] _templates;

        GameObject _blockObj;

        public List<GameObject> _floorList;
        private void Awake()
        {
            I = this;
        }

        public void Init()
        {
            string floorList = UserData.I.FloorList;
            _blockObj = transform.Find("Block").gameObject;
            if (string.IsNullOrEmpty(floorList) == false) // 빈 문자열이 아닐때
            {
                string[] floorArr = floorList.Split(",");
                foreach (string floor in floorArr)
                {
                    foreach (GameObject template in _templates)
                    {
                        if(template.name == floor)
                        {
                            _Create(template, _blockObj.transform.position);
                        }
                    }
                }
            }
        }

        public void CreateFloor(Vector3 pos)
        {
            int choice = Random.Range(0, _templates.Length);

            _Create(_templates[choice], pos);
            UserData.I.SaveFloor(_templates[choice].name);
        }
        void _Create(GameObject template, Vector3 pos)
        {
            GameObject newBlock = Instantiate(template);
            newBlock.transform.SetParent(FloorManager.I.transform);
            newBlock.transform.position = new Vector3(0, pos.y, 0);
            newBlock.name = template.name;
            newBlock.SetActive(true);
            _blockObj.GetComponent<Block>().Raise();

            _floorList.Add(newBlock);
        }
    }
}
