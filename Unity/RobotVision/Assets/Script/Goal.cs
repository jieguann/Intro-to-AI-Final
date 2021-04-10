using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;

    private void Start()
    {
        
    }




    void OnTriggerEnter(Collider collider)
        {
        
        if (collider.gameObject.tag == "Player")
            {
            //Destroy(this.gameObject);
            Vector3 position = new Vector3(Random.Range(-8.0F, 8.0F), Random.Range(2.0F, 6.0F), Random.Range(-8.0F, 8.0F));
            cube.transform.position = position;
            }
        }

   

}
