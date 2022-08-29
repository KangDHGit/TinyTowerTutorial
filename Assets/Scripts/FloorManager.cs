using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class FloorManager : MonoBehaviour
    {
        public static FloorManager I;
        private void Awake()
        {
            I = this;
        }
    }
}
