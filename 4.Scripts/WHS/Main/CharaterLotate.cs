using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class CharaterLotate : MonoBehaviour
    {
        public Quaternion characterLoatate;

        private void Start()
        {
            //     if (characterLoatate == Quaternion.identity)
            characterLoatate = SelectCharacter.tmpTr;

            transform.rotation = characterLoatate;
            Debug.Log("CharacterLotate >> Start");
        }

        private void Update()
        {
            transform.Rotate(Vector3.up, 50 * Time.deltaTime);
            characterLoatate = transform.rotation;
        }
    }
}