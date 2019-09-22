using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace whs
{
    public class MoveCamera : MonoBehaviour
    {
        private Vector3 upDis = new Vector3(0, 0.5f, 0);
        private Vector3 resetCamPos = new Vector3(0, 0, -25);

        private void OnEnable()
        {
            BoxGameManager.onLandDele += CameraMove;
            BoxGameManager.onRestartGame += ResetCameraPos;
        }

        private void OnDisable()
        {
            BoxGameManager.onLandDele -= CameraMove;
            BoxGameManager.onRestartGame -= ResetCameraPos;
        }

        private void ResetCameraPos()
        {
            transform.position = resetCamPos;
        }

        private void CameraMove()
        {
            if (Combo.score >= 7)
                transform.position += upDis;
        }
    }
}