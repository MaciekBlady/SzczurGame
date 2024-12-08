using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private List<Transform> m_Waypoints;

    [SerializeField]
    private float m_Speed = 2.0f;

    [SerializeField]
    private float m_WaypointDistanceThreshold = 0.1f;
    
    private int m_CurrentWaypointIndex = 0;

    private Vector3 m_CurrentVelocity;
    
    private void FixedUpdate()
    {
        Transform targetWaypoint = m_Waypoints[m_CurrentWaypointIndex];
        
        transform.position = Vector3.SmoothDamp(
            transform.position, 
            targetWaypoint.position,
            ref m_CurrentVelocity,
            (1.0f / m_Speed) * Time.deltaTime);

        
        if (Vector3.Distance(targetWaypoint.position, transform.position) <= m_WaypointDistanceThreshold)
        {
            m_CurrentWaypointIndex = (++m_CurrentWaypointIndex % m_Waypoints.Count);
        }
    }
}
