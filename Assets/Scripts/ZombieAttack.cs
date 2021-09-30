using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float velocityX = -2f;

 //   private float changeTime= 0;
    
    public GameObject ZombieObject;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine("Esperar");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
      

    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("paso 5 segundos");
       
        var zombie =   ZombieObject;
        var position = new Vector2(6.76f, -2.6269f);
        var rotation = ZombieObject.transform.rotation;
        
        Instantiate(zombie, position, rotation);
    }
}
