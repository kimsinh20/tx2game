using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trumau : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        if (controller != null)
        {
            controller.changeHp(-1);
        }
    }
}
