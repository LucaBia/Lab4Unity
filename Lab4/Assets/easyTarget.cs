using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easyTarget : MonoBehaviour
{
    public float health = 10f;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + new Vector3(Mathf.Sin(Time.time),0,0);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
