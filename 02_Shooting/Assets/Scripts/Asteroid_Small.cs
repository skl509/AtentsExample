using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Small : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    GameObject explosion;

    private void Awake()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, 4);
        sprite.flipX = ((rand & 0b_01) != 0);
        sprite.flipY = ((rand & 0b_10) != 0);

        explosion = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * moveSpeed * Vector3.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if(explosion != null)
            {
                explosion.transform.parent = null;
                explosion.SetActive(true);
            }
            Destroy(this.gameObject);
        }
    }
}
