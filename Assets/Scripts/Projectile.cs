using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 1.0f;
    
    [SerializeField]
    private float m_Lifetime = 4.0f;

    private void Start()
    {
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(m_Lifetime);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * (m_Speed * Time.deltaTime);
    }
}
