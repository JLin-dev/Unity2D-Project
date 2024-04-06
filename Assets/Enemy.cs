using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyPack;
    public Transform PosA, PosB;
    public float speed;
    Vector2 nextPos;

    public float HP;
    public float damage;
    
    void Start()
    {
        float number = Random.Range(0, 2);

        if (number == 0) 
        { nextPos = PosA.position; }
        else 
        { nextPos = PosB.position; }
    }

    
    void FixedUpdate()
    {
        if (transform.position.x == PosA.position.x)
        { nextPos = PosB.position; }
        if (transform.position.x == PosB.position.x)
        { nextPos = PosA.position; }

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(nextPos.x, transform.position.y), speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)//當觸發器進入自身範圍
    {
        if (collision.tag == "weapon")
        {
            float dmg = collision.GetComponent<weapon>().damage;
            
            gethurt(dmg);
        }
    }

    public void gethurt(float damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            FindObjectOfType<Audio_Set>().PlaySfx(2);
            Destroy(EnemyPack);
        }
    }
}
