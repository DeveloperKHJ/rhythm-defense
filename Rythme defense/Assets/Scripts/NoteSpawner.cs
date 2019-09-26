using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    // 소환할 Object
    public GameObject note;

    // 소환 interval
    public float timeBetweenWSpawn = 1f;

    // 시간 체크에 필요한 변수
    private float countdown = 1f;



    void Update()
    {
        // 시간이 다 되면 오브젝트를 소환하고 countdown을 reset시킴
        if (countdown <= 0f)
        {
            Spawn(note);
            countdown = timeBetweenWSpawn;
            return;
        }

        // 시간을 빼준다.
        countdown -= Time.deltaTime;

    }


    void Spawn(GameObject obj)
    {
        Instantiate(obj, transform.position, transform.rotation);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one / 4);
    }
}
