using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TOWER_TYPE {GUN, LASER, MISSILE, TOWER_COUNT};

public class Towerscript : MonoBehaviour
{
    public TOWER_TYPE towerType = TOWER_TYPE.LASER;
    public float shootRate = 50f;
    public float towerDamage = 10f;
    public float towerRange = 5f;
    public int purchaseCost = 50;
    public int upgradeCost = 25;
    public int sell = 25;
    public GameObject towerLocation;
    public void UpgradeTower()
    {
        upgradeCost *= 2;
    }

    public void SellTower()
    {
        towerLocation.GetComponent<Towergenerator>().hasTower = false;
        Destroy(gameObject);
    }
   }
