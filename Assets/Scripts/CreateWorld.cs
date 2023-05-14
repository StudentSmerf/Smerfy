using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWorld : MonoBehaviour
{
    public GameObject Water;
    //[SerializeField] private GameObject Tree;
    //[SerializeField] private GameObject Grass;
    //[SerializeField] private GameObject Stone;
    
    

    public void Create(float Width, float Height){
        GameObject up = Instantiate(Water,new Vector3(Width/2, Height + 1.2f, 0), Quaternion.identity);
        up.transform.localScale = new Vector3(Width+2, 1, 1);
        GameObject down = Instantiate(Water,new Vector3(Width/2, -1.2f, 0), Quaternion.identity);
        down.transform.localScale = new Vector3(Width+2, 1, 1);
        GameObject right = Instantiate(Water,new Vector3(Width + 1.2f, Height/2, 0), Quaternion.identity);
        right.transform.localScale = new Vector3(1, Height+2, 1);
        GameObject left = Instantiate(Water,new Vector3(-1.2f, Height/2, 0), Quaternion.identity);
        left.transform.localScale = new Vector3(1, Height+2, 1);
    }
    
}
