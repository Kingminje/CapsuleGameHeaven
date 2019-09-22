using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOBJ : MonoBehaviour {


    public void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }

}
