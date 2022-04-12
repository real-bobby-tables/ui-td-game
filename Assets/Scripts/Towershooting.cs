using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Towerscript))]

public class Towershooting : MonoBehaviour
{
    [SerializeField] private LineRenderer laser;
    [SerializeField] private Transform fireLocation;
    [SerializeField] private GameObject towerHead;
    private Towerscript tower;
    public GameObject target;
    private float nextShootTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Towerscript>();
        InvokeRepeating("SelectedTarget", 0, 0.5f);    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            laser.enabled = false;
            return;
        }
        LockOnTarget();
        ShootTarget();
    }

    private void SelectedTarget() 
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDist = Mathf.Infinity;
        int selectedEnemy = -1;
        for (int i = 0; i < allEnemies.Length; i++) 
        {
            float dist = Vector3.Distance(transform.position, allEnemies[i].transform.position);
            if (dist < minDist) 
            {
                minDist = dist;
                selectedEnemy = i;
            }

        }
        if (selectedEnemy != -1 && minDist <= tower.towerRange)
            target = allEnemies[selectedEnemy];
        else
            target = null;
    }

    private void ShootTarget() 
    {
        if (Time.time > nextShootTime)
        {
            switch (tower.towerType) 
            {
                case TOWER_TYPE.LASER:
                    ShootLaaser();
                    break;
                case TOWER_TYPE.GUN:
                    laser.enabled = false;
                    ShootGun();
                    break;
                case TOWER_TYPE.MISSILE:
                    laser.enabled = false;
                    ShootMissile();
                    break;
                default:
                    break;
            }
            nextShootTime = Time.time + 1 / tower.shootRate;
        }

    }

    private void ShootMissile()
    {
        throw new NotImplementedException();
    }

    private void ShootGun()
    {
        throw new NotImplementedException();
    }

    private void ShootLaaser()
    {
        laser.enabled = true;
        laser.SetPosition(0, fireLocation.position);
        laser.SetPosition(1, target.transform.position);
        target.GetComponent<Enemy>().TakeDamage(tower.towerDamage);
    }

    private void LockOnTarget() 
    {
        towerHead.transform.rotation = Quaternion.LookRotation(target.transform.position - fireLocation.position);
    }

}
