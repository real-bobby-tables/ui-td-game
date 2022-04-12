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
            towerLocation.GetComponent<Towergenerator>().tower = Instantiate(towerPrefab, towerLocation.transform.position, Quaternion.identity);
            towerLocation.GetComponent<Towergenerator>().hasTower = true;
        }
        gameObject.SetActive(false);
    }
}
