using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAround : MonoBehaviour
{
    private float speed, impulseForce;
    private Vector2 direccion;

    private Rigidbody2D rgdb;

    private float timing;
    private void Awake()
    {
        RandomDireccion();
        rgdb = this.GetComponent<Rigidbody2D>();
        speed = 10f;
        impulseForce = 10f;

        timing = 2f;
    }

    private void RandomDireccion()
    {
        direccion = new Vector2(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)).normalized;
    }

    private void Start()
    {
        rgdb.velocity = speed * Time.deltaTime * direccion;
        rgdb.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        timing -= Time.deltaTime;

        if(timing <= 0)
        {
            rgdb.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
            timing = 2;
        }
        
    }

    private void FixedUpdate()
    {
        rgdb.velocity = speed * Time.deltaTime * direccion;
    }
}
