using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKlakier : MonoBehaviour
{
    public GameObject Spawn(GameObject Klakier){
        GameObject K = Instantiate(Klakier, this.transform.position + Vector3.right, Quaternion.identity);
        return K;
    }
}
