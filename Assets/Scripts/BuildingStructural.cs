using UnityEngine;

public class BuildingStructural : MonoBehaviour
{
    [SerializeField] GameObject[] building;

    int activeSection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StructuralBuilding();
    }

    public void StructuralBuilding()
    {
        activeSection = 0;

        for (int i = 0; i < building.Length; i++)
        {
            //building[i].gameObject.SetActive(i == activeSection);
            if (i == activeSection)
            {
                building[i].gameObject.SetActive(true);
            }
            else
            {
                building[i].gameObject.SetActive(false);
            }
        }

        activeSection++;

        if(activeSection >= building.Length)
        {
            activeSection=0;
        }
    }
}
