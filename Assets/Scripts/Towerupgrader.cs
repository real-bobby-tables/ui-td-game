using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerupgrader : MonoBehaviour
{
    public GameObject tower = null;
    public void UpgradeTower()
    {
        if (tower == null)
        {

        }
        else if (PlayerController.curMoney < tower.GetComponent<Towerscript>().upgradeCost)
        {

        }
        else 
        {
            PlayerController.curMoney -= tower.GetComponent<Towerscript>().upgradeCost;
            tower.GetComponent<Towerscript>().towerDamage *= 1.5f;
            tower.GetComponent<Towerscript>().shootRate *= 1.5f;
            tower.GetComponent<Towerscript>().UpgradeTower();
        }
        gameObject.SetActive(false);

    }
    public void SellTower()
    {
        if (tower == null)
        {

        }
        else
        {
            PlayerController.curMoney += tower.GetComponent<Towerscript>().sell;
            tower.GetComponent<Towerscript>().SellTower();
        }
        gameObject.SetActive(false);
    }
}
