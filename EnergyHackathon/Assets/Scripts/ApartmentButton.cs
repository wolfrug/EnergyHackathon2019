using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApartmentButton : MonoBehaviour {
    public ApartmentData data;
    public ApartmentData emptyData;
    public string updatednotes;
    public string updatedEnergyUse;
    public bool empty = false;

    public Animator animator;
    // Start is called before the first frame update
    void Start () {
        updatednotes = data.notes;
        updatedEnergyUse = data.energyUse;
        GetComponent<Button> ().onClick.AddListener (() => CrossSectionUI.instance.OpenApartment (this, true));
        animator = GetComponentInChildren<Animator>();
    }

    public void UpdateNotes (string newNotes) {
        updatednotes = newNotes;
    }
    public void UpdateEnergyUse (string newUse) {
        updatedEnergyUse = newUse;
    }

    public void EmptyApartment(){
        updatednotes = emptyData.notes;
        updatedEnergyUse = emptyData.energyUse;
        empty = true;
    }

    // Update is called once per frame
    void Update () {

    }
}