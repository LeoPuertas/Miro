using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Miro.Apis;
using System.Linq;
using System;
using UnityEngine.UI;

public class cargarJSON : MonoBehaviour
{
    public GameObject cube;
    public TextAsset jsonFile;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Iniciando lectura");

        //Cubos cubosEnJSON = JsonUtility.FromJson<Cubos>(jsonFile.text);

        //foreach (Cubo cubo in cubosEnJSON.cubos){
        //GameObject cubotemp = Instantiate(cube);
        //cubotemp.transform.position = new Vector3(cubo.x, cubo.y, cubo.z);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
