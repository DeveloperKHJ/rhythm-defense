using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteReceiver : MonoBehaviour
{
    public string noteTag;
    public float detectionRange;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] notes = GameObject.FindGameObjectsWithTag(noteTag);
            float minDistance = Mathf.Infinity;
            GameObject nearestNote = null;
            foreach (GameObject note in notes)
            {
                // 가장 가까운 적들을 찾아 타겟으로 갱신
                float distanceToNote = Vector3.Distance(transform.position, note.transform.position);
                if (distanceToNote < minDistance)
                {
                    minDistance = distanceToNote;
                    nearestNote = note;
                }
            }

            if (nearestNote != null && minDistance <= detectionRange)
            {
                Destroy(nearestNote);
            }
        }
    }
}
