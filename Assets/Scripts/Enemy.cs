using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 10f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float speed = 1f;
    private GameObject prev;
    private GameObject next;
    // Start is called before the first frame update
    void Start()
    {
        prev = Pathgenerator.path[0];
        transform.position = prev.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Convert.ToInt32(prev.name) < Pathgenerator.path.Count - 1)
        {
            next = Pathgenerator.path[Convert.ToInt32(prev.name) + 1];
            transform.position += (next.transform.position - transform.position).normalized * Time.deltaTime * speed;
            Quaternion rot = Quaternion.LookRotation((next.transform.position - transform.position).normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 1f);
            if (Vector3.Distance(transform.position, next.transform.position) <= 0.01f)
                prev = next;
        }
        else
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage) 
    {
        health -= damage;
        if (health <= 0)
        {
            PlayerController.curMoney += 10;
            Destroy(gameObject);
        }
    }
}
