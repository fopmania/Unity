using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {
    public GameObject fruitSlicedPrefab;

    public float startForce = 15f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blade")
        {
            
            Vector3 dir = (collision.transform.position - transform.position).normalized;

            Quaternion rot = Quaternion.LookRotation(dir);

            GameObject go =  Instantiate(fruitSlicedPrefab, transform.position, rot );
            Destroy(go, 3f);

            Destroy(gameObject);

        }
    }
}
