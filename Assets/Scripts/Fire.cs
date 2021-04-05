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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Indestrutivel")
        {
            Destroy(gameObject);
        }
    }


        
}
   