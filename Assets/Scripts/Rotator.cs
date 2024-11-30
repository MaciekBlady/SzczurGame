using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_Axis = Vector3.one;

    [SerializeField]
    private float m_Speed = 10.0f;
    
    void Update()
    {
        transform.Rotate(m_Axis, Time.deltaTime * m_Speed);
    }
}
