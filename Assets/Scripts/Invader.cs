using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField]
    GameObject Fire;

    [SerializeField]
    float cadencia = 2.5f;

    [SerializeField]
    int VidasInvasores = 10;

    [SerializeField]
    float probTiro = 0.015f;

    float tempoQuePassou = 0f;

    private void Update()
    {
        tempoQuePassou += Time.deltaTime;
        if (tag == "Destrutivel")
        {
            
            if (tempoQuePassou >= cadencia)
            {
                if (Random.value <= probTiro)
                {
                    Instantiate(Fire, transform.position, transform.rotation);
                }
                tempoQuePassou = 0f;
            }
        }
 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (tag == "Destrutivel")
        {
            if (collision.gameObject.tag == "Fogo_amigo")
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }

        else 
        {
            if (collision.gameObject.tag == "Fogo_amigo")
            {
                VidasInvasores -= 1;

                if (VidasInvasores <= 0)
                {
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }

            }
                
        }
      
    }

}
