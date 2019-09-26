using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float speed = 1.0f;

    void FixedUpdate()
    {
        transform.position -= new Vector3(0f, speed * Time.fixedDeltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        // 접촉한 오브젝트가 waterBottle이면 습득
        if (other.gameObject.CompareTag("Tower"))
        {
            Destroy(gameObject);
        }

    }
}
