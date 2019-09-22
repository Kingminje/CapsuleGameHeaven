using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MJ
{
    public class GameIconManger : MonoBehaviour
    {
        public GameObject upIcon;
        public GameObject downIcon;

        public void UpShow()
        {
            if (upIcon.activeSelf == true)
            {
                return;
            }
            upIcon.SetActive(true);
            downIcon.SetActive(false);
        }

        public void DownShow()
        {
            if (downIcon.activeSelf == true)
            {
                return;
            }
            upIcon.SetActive(false);
            downIcon.SetActive(true);
        }
    }
}