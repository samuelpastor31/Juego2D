using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleShot : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private Collider2D player;
    private float radius = 12f;
    //[SerializeField] private Transform player;
    private Rigidbody2D rb;

    private LayerMask mask;
    

    IEnumerator Start(){
        rb = GetComponent<Rigidbody2D>();
        mask = LayerMask.GetMask("Character");

        player = Physics2D.OverlapCircle(transform.position, radius, mask);
        if(player != null){
            rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y- transform.position.y).normalized*speed;
        }

        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
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
