using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int maxHealth = 10;
    public int _currentHealth;
    public GameObject enemy;
    public int BulletDmg = 10;
    public int DamageAmount = 2;


    public EnemyHealthBar healthBar;

    void Start()
    {
        _currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
       if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Bullet")
        {
            _currentHealth -= DamageAmount;
            
        }
    }

}
