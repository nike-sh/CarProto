using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTriggersDestruct : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("CarCollider"))
        {
            Destroy(gameObject);
        }
    }
}
