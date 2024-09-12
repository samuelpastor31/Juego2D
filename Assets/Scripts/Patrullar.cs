using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullar : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private Transform firePoint;
    private int numeroAleatorio;
    private SpriteRenderer spriteRenderer;
    private Transform player;

    [SerializeField] private GameObject bulletPrefab;
    private float shootRange = 12f; //should match radius of trigger on shot script
    [SerializeField] private float shootCD = 3f;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        InvokeRepeating("Shoot", 0f, shootCD);
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position, velocidadMovimiento * Time.deltaTime);
        if (Vector2.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciaMinima)
        {

            numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
            Girar();
        }
    }

    private void Shoot() {
        if(Vector2.Distance(player.position, firePoint.position) < shootRange) {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    private void Girar()
    {
        if (transform.position.x < puntosMovimiento[numeroAleatorio].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
                // Pasa la posición del primer punto de contacto al método TomarDaño
                other.GetComponent<CharacterController2D>().TomarDaño(1);
            
        }
    }

}
