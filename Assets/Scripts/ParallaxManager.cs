using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    public float parallaxSpeed;

    [SerializeField] private GameObject[] parallaxLayers;

    Vector3 endPos;
    Vector3 startPos;
    public Vector3 offside; 

    // Start is called before the first frame update
    void Start()
    {
        endPos = parallaxLayers[0].transform.localPosition;
        startPos = parallaxLayers[parallaxLayers.Length - 1].transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject layer in parallaxLayers)
        {
            layer.transform.Translate(Vector3.left * parallaxSpeed * Time.deltaTime);

            if (layer.transform.localPosition.x <= endPos.x)
            {
                layer.transform.localPosition = startPos + offside;
                layer.GetComponent<BuildingRandomizer>().RandomBuilding();
            }
        }
    }
}
