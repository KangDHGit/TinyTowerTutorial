using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTower
{
    [Serializable]
    public class GameData_Product
    {
        public string name;
        public string floor;
        public int cost;
        public float time;
        public int quantity;
        public string spriteName;

        public Sprite sprite;
    }
}
