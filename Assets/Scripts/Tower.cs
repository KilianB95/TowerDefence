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

    public GameObject BulletPrefab;

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
                Shoot();
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
    void Shoot()
    {
        if (target)
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().target = target.gameObject;
            
        }
        
    }

     void Update()
     {
        transform.LookAt(target, Vector3.left);
        
     }

     void OnDrawGizmosSelected()
     {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
     }


}
