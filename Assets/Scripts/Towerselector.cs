using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerselector : MonoBehaviour
{
    public GameObject towerLocation;
    //[SerializeField] GameObject towerPrefab;
    public void AddTower1(GameObject towerPrefab)
    {
        if (PlayerController.curMoney < towerPrefab.GetComponent<Towerscript>().purchaseCost)
        {

        }
        else
        {
            PlayerController.curMoney -= towerPrefab.GetComponent<Towerscript>().purchaseCost;

            Towergenerator generator = towerLocation.GetComponent<Towergenerator>();
            GameObject tower = Instantiate(towerPrefab, towerLocation.transform.position, Quaternion.identity);
            tower.GetComponent<Towerscript>().towerLocation = towerLocation;

            // towerLocation.GetComponent<Towergenerator>().tower = Instantiate(towerPrefab, towerLocation.transform.position, Quaternion.identity);
            // towerLocation.GetComponent<Towergenerator>().hasTower = true;
            
            generator.tower = tower;
            generator.hasTower = true;
        }
        gameObject.SetActive(false);
    }
}
