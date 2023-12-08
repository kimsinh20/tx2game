using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    Rigidbody2D rg;
    // Start is called before the first frame update
    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude>10.0f)
        {
            Destroy(gameObject);
        }
    }
    public void Launch(Vector2 vector2, float value)
    {
        rg.AddForce(vector2 * value);
    }
    void OnCollisionEnter2D(Collision2D orther)
    {
        EnemyController enemy = orther.collider.GetComponent<EnemyController>();
        if(enemy!=null)
        {
            enemy.congmau();
            Destroy(gameObject);
        }
        
    }
}
