using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class ColorData : MonoBehaviour
    {
        public string colorName = "Red";

        private void Awake()
        {
            colorName = gameObject.name;
        }
    }
}