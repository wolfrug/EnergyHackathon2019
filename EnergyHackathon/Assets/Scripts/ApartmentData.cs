using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ApartmentData", order = 1)]
public class ApartmentData : ScriptableObjectBase
{
public string apartmentNumber;
public string size = "1 m²";
public string[] residents;
public string[] dobs;
[Multiline]
public string notes;
public string energyUse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
