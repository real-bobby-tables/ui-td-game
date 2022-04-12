using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towergenerator : MonoBehaviour
{
    [SerializeField] private GameObject towerSelectionPanel;
    [SerializeField] private GameObject TowerUpgradePanel;
    public GameObject tower;
    public bool hasTower = false;
    // Start is called before the first frame update
    void Awake()
    {
        towerSelectionPanel = GameObject.Find("TowerSelectionPanel");
        TowerUpgradePanel = GameObject.Find("TowerUpgradePanel");
    }
    private void Start()
    {
        TowerUpgradePanel.SetActive(false);
        towerSelectionPanel.SetActive(false);
    }
    // Update is called once per frame
    public void SelectTower()
    {
        if (hasTower)
        {
            towerSelectionPanel.SetActive(false);
            TowerUpgradePanel.SetActive(true);
            TowerUpgradePanel.GetComponent<Towerupgrader>().tower = tower;
        }
        else
        {
        TowerUpgradePanel.SetActive(false);
        towerSelectionPanel.SetActive(true);
        towerSelectionPanel.GetComponent<Towerselector>().towerLocation = gameObject;
        }
    }

   }
