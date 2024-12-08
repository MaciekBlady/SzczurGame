using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 1.0f;
    
    private void FixedUpdate()
    {
        transform.position += transform.forward * (m_Speed * Time.deltaTime);
    }
}
