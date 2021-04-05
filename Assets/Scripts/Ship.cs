using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject Fire;

    [SerializeField]
    Transform nozzle;

    [SerializeField]
    float velocidade = 5f;

    [SerializeField]
    int Vidas = 3;

    float xMin, xMax;
    void Start()
    {
        xMax = Camera.main.ViewportToWorldPoint(Vector2.one).x - 0.5f;
        xMin = Camera.main.ViewportToWorldPoint(Vector2.zero).x + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Fire, nozzle.position, nozzle.rotation);
        }

        MoveShip();

     
    }

    private void MoveShip()
    {
        float hMov = Input.GetAxis("Horizontal");

        if (hMov != 0f)
        {
            transform.position += hMov * velocidade * Vector3.right * Time.deltaTime;

            Vector3 position = transform.position;
            position.x = Mathf.Clamp(position.x, xMin, xMax);
            transform.position = position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fogo_Inimigo")
        {
            Vidas -= 1;
            if(Vidas <= 0)
            {
                Destroy(gameObject);
            }

        }

    }
}
