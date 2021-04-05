using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaders : MonoBehaviour
{

    [SerializeField]
    GameObject[] invasores;

    [SerializeField]
    GameObject[] invasoresIndestrutiveis;

    [SerializeField]
    int nInvasores = 7;

    [SerializeField]
    float xMin = -3f;

    [SerializeField]
    float yMin = 0f;

    [SerializeField]
    float yInc = 0.5f;

    [SerializeField]
    float probabilidadeDeIndestrutivel = 0.00000001f;

    float xMinimo, xMaximo;

    bool mov = true;

    bool verticalMov = true;

    [SerializeField]
    float velocidade = 0.005f;

    void Awake()
    {
        float y = yMin;
        for (int line = 0; line < invasores.Length; line++)
        {
            float x = xMin;
            for (int i = 1; i <= nInvasores; i++) //for {inicio, fim, e como chega lá}
            {
                if(Random.value <= probabilidadeDeIndestrutivel)
                {
                    GameObject newInvader = Instantiate(invasoresIndestrutiveis[line], transform);
                    newInvader.transform.position = new Vector3(x, y, 0f);
                    x += 1f;
                }
                else
                {
                    GameObject newInvader = Instantiate(invasores[line], transform);
                    newInvader.transform.position = new Vector3(x, y, 0f);
                    x += 1f;
                }

            }
            y += yInc;
        }

        /*
         * "Pega" neste objecto, duplica e coloca-o "naquele" sítio
         */

        //float x = xMin;
        //for( int i = 1; i <= nInvasores; i++ )
        //{
        //    GameObject newInvader = Instantiate(invasorA, transform);
        //    newInvader.transform.position = new Vector3(x, -1.5f, 0f);
        //    x += 1f;
        //}

        //float x2 = xMin;
        //for (int i = 1; i <= nInvasores; i++)
        //{
        //    GameObject newInvader = Instantiate(invasorA, transform);
        //    newInvader.transform.position = new Vector3(x2, -0.5f, 0f);
        //    x2 += 1f;
        //}

        //float x3 = xMin;
        //for (int i = 1; i <= nInvasores; i++)
        //{
        //    GameObject newInvader = Instantiate(invasorB, transform);
        //    newInvader.transform.position = new Vector3(x3, 0.5f, 0f);
        //    x3 += 1f;
        //}

        //float x4 = xMin;
        //for (int i = 1; i <= nInvasores; i++)
        //{
        //    GameObject newInvader = Instantiate(invasorB, transform);
        //    newInvader.transform.position = new Vector3(x4, 1.5f, 0f);
        //    x4 += 1f;
        //}

        //float x5 = xMin;
        //for (int i = 1; i <= nInvasores; i++)
        //{
        //{
        //    GameObject newInvader = Instantiate(invasorC, transform);
        //    newInvader.transform.position = new Vector3(x5, 2.5f, 0f);
        //    x5 += 1f;
        //}
    }

    private void Start()
    {
        xMaximo = Camera.main.ViewportToWorldPoint(Vector2.one).x - 3.3f;
        xMinimo = Camera.main.ViewportToWorldPoint(Vector2.zero).x + 3.3f;
    }
    private void Update()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, xMinimo, xMaximo);
        transform.position = position;

        if (mov == true)
        {

            transform.position += velocidade * Vector3.right;
            if (position.x == xMaximo && verticalMov == true)
            {
                if (position.y <= -2)
                {
                    verticalMov = false;
                }
                else
                {
                    transform.position += 0.2f * Vector3.down;
                }
            }
            if (position.x == xMaximo)
            {
                mov = false;
            }

        }
        if (mov == false)
        {
            transform.position -= velocidade * Vector3.right;
            if (position.x == xMinimo && verticalMov == true)
            {
                if (position.y <= -2)
                {
                    verticalMov = false;
                }
                else
                {
                    transform.position += 0.2f * Vector3.down;
                }
            }
            if (position.x == xMinimo)
            {
                mov = true;
            }
        }
       
    }
}

    //if (hMov != 0f)
    //    {
    //        transform.position += hMov* velocidade * Vector3.right* Time.deltaTime;

    //Vector3 position = transform.position;
    //position.x = Mathf.Clamp(position.x, xMin, xMax);
    //        transform.position = position;
    //    }

