using UnityEngine;

public class CloudsController : MonoBehaviour
{
    [SerializeField]
    private Transform[] clouds = new Transform[6];

    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private float xLimit = 12.5f;
    

    // Start is 
    // called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < clouds.Length; i++)
        {
            clouds[i].position =
                clouds[i].position + Vector3.right * Time.deltaTime * speed;
            
            if(clouds[i].position.x > xLimit)
            {
                clouds[i].position -= new Vector3(xLimit * 2, 0, 0);
            }
        }
    }
}
