using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private Projectile m_ProjectilePrefab = null;
    
    [SerializeField]
    private Transform m_ProjectileSpawnPoint = null;

    [SerializeField] 
    private float m_ShootTime = 1.0f;

    private float m_Timer = 0.0f;

    private void Update()
    {
        m_Timer += Time.deltaTime;

        if (m_Timer >= m_ShootTime)
        {
            m_Timer = 0.0f;
            Instantiate(m_ProjectilePrefab, m_ProjectileSpawnPoint.position, Quaternion.identity);
        }
    }
}
