using UnityEngine;

public class MoveSection : MonoBehaviour
{
    public Vector3 movingCoordinate;
    public Vector3 destroyGameobject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movingCoordinate * Time.deltaTime;

        if(this.gameObject.transform.position.x <= destroyGameobject.x)
        {
            Destroy(this.gameObject);
        }
    }
}
