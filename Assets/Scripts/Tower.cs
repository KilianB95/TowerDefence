using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform target;
    public float range = 2f;

    public string enemyTag = "Enemy";

    public Transform PartToRotate;
    public float turnSpeed = 2f;

     void Start()
     {
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f); 
     }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    public Transform targer; 

     void Update()
     {
        if (target == null)
        
            return;
        Vector3 relativePos = target.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
        transform.rotation = rotation;
        
        
     }

     void OnDrawGizmosSelected()
     {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
     }


}
