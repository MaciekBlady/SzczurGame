using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private float m_FollowSpeed = 10.0f;

    [SerializeField] 
    private Vector3 m_Offset = new Vector3(-5.0f, 5.0f, 0.0f);

    private Vector3 m_CurrentVelocity;

    [SerializeField] 
    private Bounds m_GlobalCameraBounds;
    

    private void FixedUpdate()
    {
        if (m_Target == null)
        {
            return;
        }
        
        Vector3 newPosition =  Vector3.SmoothDamp(
            transform.position, 
            m_Target.position + m_Offset,
            ref m_CurrentVelocity,
            m_FollowSpeed);

        
        newPosition = new Vector3(
            Mathf.Clamp(newPosition.x, m_GlobalCameraBounds.min.x, m_GlobalCameraBounds.max.x),
            Mathf.Clamp(newPosition.y, m_GlobalCameraBounds.min.y, m_GlobalCameraBounds.max.y),
            Mathf.Clamp(newPosition.z, m_GlobalCameraBounds.min.z, m_GlobalCameraBounds.max.z)
            );
        
        transform.position = newPosition;
    }
}
