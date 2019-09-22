using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MJ
{
    public class Attack : MonoBehaviour
    {
        private GameManager gameManager;
        private SoundManager soundManager;
        public GameObject particle;

        // Use this for initialization
        private void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            soundManager = FindObjectOfType<SoundManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log("Enter Trigger");
                gameManager.ScoreUp();

                var tmpGameobject = new GameObject();
                var tmp = other.transform.position;
                tmpGameobject.transform.position = tmp;
                Instantiate(particle, tmpGameobject.transform, false);
                Destroy(tmpGameobject, 1f);

                soundManager.SoundPlay((int)AudioClipName.Punch);

                Destroy(other.gameObject);
            }
        }
    }
}