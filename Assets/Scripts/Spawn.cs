using UnityEngine;

public class Spawn : MonoBehaviour 
{

    public GameObject patientPrefab;

    void Start() 
    {

        Invoke("SpawnPatient", 5.0f);
    }

    void SpawnPatient() 
    {

        Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
        Invoke("SpawnPatient", Random.Range(5.0f, 25.0f));

    }

    void Update() 
    {

    }
}
