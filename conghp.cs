using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conghp : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D orther) 
    {
        RubyController ruby = orther.GetComponent<RubyController>();
        if(ruby!=null)
        {
            ruby.changeHp(1);
            Destroy(gameObject);
        }
    }

}
