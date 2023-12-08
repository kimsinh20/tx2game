using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rg;
    public float speed = 3.0f;
    float horizontal;
    float vertical;
    public int maxhp = 10;
    public float currenthp;
    public GameObject dan;
    public LayerMask m;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Vector2 lookDection = new Vector2(1, 0);
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        currenthp =(float)( maxhp / 2);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            launch();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D raycast = Physics2D.Raycast(rg.position + Vector2.up * 0.2f, lookDection, 3.0f, m);
            if(raycast.collider!=null)
            {
                NonPlayerCharacter nonPlayer = raycast.collider.GetComponent<NonPlayerCharacter>();
                if (nonPlayer != null)
                {
                    nonPlayer.fix();
                }
            }
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rg.position;
        position.x += speed * horizontal * Time.deltaTime; 
        position.y += speed * vertical * Time.deltaTime;
        rg.MovePosition(position);
    }
    public void changeHp(int hp)
    {
        if (hp < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currenthp = Mathf.Clamp(currenthp + hp, 0, maxhp);
        UIHealthBar.instance.SetValue(currenthp / (float)maxhp);
    }
    void launch()
    {
        GameObject danObject = Instantiate(dan, rg.position + Vector2.up * 0.5f, Quaternion.identity);
        ProjectTile p = danObject.GetComponent<ProjectTile>();
        p.Launch(lookDection, 300);
    }
}

