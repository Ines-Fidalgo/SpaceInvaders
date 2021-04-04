using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float força = 500f;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce  (Vector2.up * força);
    }
}
   