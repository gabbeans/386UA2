using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public FloatingHealthBar healthBar;
    public int damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemyComponent)) {
            enemyComponent.TakeDamage(damage);
        }
    }
}
