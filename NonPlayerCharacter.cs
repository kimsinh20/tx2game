using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public GameObject message;
    public float timestatic = 4.0f;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = -1;
        message.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(time>0)
        {
            time -= Time.deltaTime;
            if(time<0)
            {
                message.SetActive(false);
            }
        }
    }
    public void fix()
    {
        message.SetActive(true);
        time = timestatic;
    }
}
