using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Small : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3.0f;

    private void Awake()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        int r = Random.Range(0, 4);
        renderer.flipX = ((r & 0b_01) != 0);
        // ((r & 0b_01)  : r의 제일 오른쪽 비트가 0인지 1인지 확인하는 작업!
        //((r & 0b_01) != 0 : r의 제일 오른쪽 비트가 1이면 true, 0이면 false
        renderer.flipY = ((r & 0b_10) != 0);
    }


    private void Update()
    {
        transform.Translate(Time.deltaTime * moveSpeed * Vector3.up);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            

                Destroy(this.gameObject);
            }
        }
    }
