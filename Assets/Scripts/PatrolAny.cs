using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAny : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    private int currentTargetIndex;

    [SerializeField] private float moveSpeed=5;

    private void FixedUpdate()
    {
        
        Patrol();
    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            patrolPoints[currentTargetIndex].position,
            moveSpeed * Time.deltaTime);

       
        if (Vector3.Distance(transform.position, patrolPoints[currentTargetIndex].position) < 0.1f)
        {
            MoveToNextPoint();
        }
    }

    private void MoveToNextPoint()
    {
        currentTargetIndex++;
        currentTargetIndex %= patrolPoints.Length;
        float direction = patrolPoints[currentTargetIndex].position.x - transform.position.x;
        //UpdateFacingDirection(direction);
        transform.rotation=patrolPoints[currentTargetIndex].rotation;
    }

    private void UpdateFacingDirection(float inputValue)
    {
        
            float targetRotation = inputValue > 0 ? 0f : 180f;
            transform.rotation = Quaternion.Euler(0f, targetRotation, 0f);        
    }
}
