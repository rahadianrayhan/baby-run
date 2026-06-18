using System;
using UnityEngine;

public class BuildingRandomizer : MonoBehaviour
{
    [SerializeField] GameObject[] building;

    int activeSection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomBuilding();
    }

    public void RandomBuilding()
    {
        activeSection = UnityEngine.Random.Range(0, building.Length);

        for (int i = 0; i < building.Length; i++)
        {
            if (i == activeSection)
            {
                building[i].gameObject.SetActive(true);
            }
            else
            {
                building[i].gameObject.SetActive(false);
            }
        }
    }
}
