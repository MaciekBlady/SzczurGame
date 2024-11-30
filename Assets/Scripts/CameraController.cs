using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [FormerlySerializedAs("m_CameraTarget")] [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private float m_FollowSpeed = 10.0f;

    [FormerlySerializedAs("m_TargetOffset")] [SerializeField] 
    private Vector3 m_Offset = new Vector3(-5.0f, 5.0f, 0.0f);

    private Vector3 m_CurrentVelocity;

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position, 
            m_Target.position + m_Offset,
            ref m_CurrentVelocity,
            m_FollowSpeed);
    }
}