using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaders : MonoBehaviour
{

    [SerializeField]
    GameObject invasorA;

    [SerializeField]
    GameObject invasorB;

    [SerializeField]
    GameObject invasorC;

    [SerializeField]
    int nInvasores = 7;

    [SerializeField]
    float xMin = -3f;

    void Awake()
    {
        /*
         * "Pega" neste objecto, duplica e coloca-o "naquele" sítio
         */

        float x = xMin;
        for( int i = 1; i <= nInvasores; i++ )
        {
            GameObject newInvader = Instantiate(invasorA, transform);
            newInvader.transform.position = new Vector3(x, -1.5f, 0f);
            x += 1f;
        }

        float x2 = xMin;
        for (int i = 1; i <= nInvasores; i++)
        {
            GameObject newInvader = Instantiate(invasorA, transform);
            newInvader.transform.position = new Vector3(x2, -0.5f, 0f);
            x2 += 1f;
        }

        float x3 = xMin;
        for (int i = 1; i <= nInvasores; i++)
        {
            GameObject newInvader = Instantiate(invasorB, transform);
            newInvader.transform.position = new Vector3(x3, 0.5f, 0f);
            x3 += 1f;
        }

        float x4 = xMin;
        for (int i = 1; i <= nInvasores; i++)
        {
            GameObject newInvader = Instantiate(invasorB, transform);
            newInvader.transform.position = new Vector3(x4, 1.5f, 0f);
            x4 += 1f;
        }

        float x5 = xMin;
        for (int i = 1; i <= nInvasores; i++)
        {
            GameObject newInvader = Instantiate(invasorC, transform);
            newInvader.transform.position = new Vector3(x5, 2.5f, 0f);
            x5 += 1f;
        }
    }
}
