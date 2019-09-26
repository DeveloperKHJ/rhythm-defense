using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    public bool isLeft;
    private Transform target;
    private int waypointIndex = 0;
    Transform[] Waypoint = new Transform[4];
    public Transform left;
    public Transform right;
    public Transform up;
    public Transform bottom;

    private Enemy enemy;

    void Start()
    {
        // isLeft는 Wave Spawner에서 지정
        if(isLeft)
        {
            Waypoint[0] = bottom;
            Waypoint[1] = right;
            Waypoint[2] = up;
            Waypoint[3] = left;
        } else
        {
            Waypoint[0] = bottom;
            Waypoint[1] = left;
            Waypoint[2] = up;
            Waypoint[3] = right;
        }


        enemy = GetComponent<Enemy>();
        target = Waypoint[0];
        
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        // Enemy와 웨이포인트와의 거리가 0.2 포인트 이하면 웨이포인트 스위치
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }


    void GetNextWaypoint()
    {
        // 마지막 웨이포인트에 도착했다면 인덱스 리셋하여 처음부터 반복 (회전초밥)
        if (waypointIndex >= Waypoint.Length - 1)
        {
            waypointIndex = -1;
            return;
        }

        waypointIndex++;
        target = Waypoint[waypointIndex];
      
    }

    //void EndPath()
    //{
    //    PlayerStats.Lives--;
    //    PlayerStats.Lives = Mathf.Clamp(PlayerStats.Lives, 0, 999);

    //    WaveSpawner.enemiesAlive--;
    //    Destroy(gameObject);
    //}
}
