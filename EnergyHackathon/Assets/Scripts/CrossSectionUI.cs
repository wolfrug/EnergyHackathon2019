using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossSectionUI : MonoBehaviour {
    public static CrossSectionUI instance;

    public GameObject infopanel;
    public Text t_aptnr;
    public Text t_size;
    public Text t_name;
    public Text t_dob;
    public Text t_notes;
    public Text t_energyUse;

    public Button b_sendletter;
    public Button b_visit;
    public Button b_discipline;

    public ApartmentButton[] aptButtons;

    public ApartmentData emptyApartment;

    public ApartmentButton selectedApartment;
    void Awake () {
        if (instance == null) {
            instance = this;
        } else {
            Destroy (this);
        }
    }
    // Start is called before the first frame update
    void Start () {
        infopanel.SetActive (false);
        b_sendletter.onClick.AddListener (ClickLetter);
        b_visit.onClick.AddListener (ClickVisit);
        b_discipline.onClick.AddListener (ClickWarning);
        aptButtons = GetComponentsInChildren<ApartmentButton> ();
    }

    public void UpdateNotes (ApartmentData data, string newNotes) {
        foreach (ApartmentButton aptb in aptButtons) {
            if (aptb.data == data) {
                aptb.UpdateNotes (newNotes);
                if (aptb == selectedApartment) {
                    UpdateInfoPanel (selectedApartment);
                }
            }
        }
    }
    public void UpdateEnergyUse (ApartmentData data, string newUse) {
        foreach (ApartmentButton aptb in aptButtons) {
            if (aptb.data == data) {
                aptb.UpdateEnergyUse (newUse);
                if (aptb == selectedApartment) {
                    UpdateInfoPanel (selectedApartment);
                }
            }
        }
    }

    public void FlashWarning (ApartmentData data, bool flash) {
        foreach (ApartmentButton aptb in aptButtons) {
            if (aptb.data == data) {
                if (flash) {
                    aptb.animator.SetTrigger ("red");
                } else {
                    aptb.animator.SetTrigger ("green");
                }
            }
        }
    }
    public void EmptyApartment (ApartmentData data, bool evict) {
        foreach (ApartmentButton aptb in aptButtons) {
            if (aptb.data == data) {
                if (evict) {
                    aptb.animator.SetTrigger ("empty");
                    aptb.EmptyApartment ();
                    UpdateInfoPanel (aptb);
                } else {
                    aptb.animator.SetTrigger ("green");
                }
            }
        }
    }
    public void OpenApartment (ApartmentButton button, bool enablePanel = true) {
        infopanel.SetActive (enablePanel);
        selectedApartment = button;
        if (enablePanel) {
            Fungus.FungusManager.Instance.EventDispatcher.Raise (new Eventhandler_OpenApartment.Custom_EventHandlerEvent () { targetButton = selectedApartment });
        };
        UpdateInfoPanel (button, enablePanel);
    }
    public void UpdateInfoPanel (ApartmentButton button, bool enablePanel = true) {
        if (!button.empty) {
            t_aptnr.text = button.data.apartmentNumber;
            t_size.text = button.data.size;
            t_name.text = button.data.residents[0];
            t_dob.text = button.data.dobs[0];
        } else {
            t_aptnr.text = button.emptyData.apartmentNumber;
            t_size.text = button.emptyData.size;
            t_name.text = button.emptyData.residents[0];
            t_dob.text = button.emptyData.dobs[0];
        }
        t_notes.text = button.updatednotes;
        t_energyUse.text = button.updatedEnergyUse;
    }
    public void ClickLetter () {
        Fungus.FungusManager.Instance.EventDispatcher.Raise (new Eventhandler_LetterClick.Custom_EventHandlerEvent () { targetButton = selectedApartment });
    }
    public void ClickVisit () {
        Fungus.FungusManager.Instance.EventDispatcher.Raise (new Eventhandler_VisitClick.Custom_EventHandlerEvent () { targetButton = selectedApartment });
    }
    public void ClickWarning () {
        Fungus.FungusManager.Instance.EventDispatcher.Raise (new Eventhandler_DisciplineClick.Custom_EventHandlerEvent () { targetButton = selectedApartment });
    }

    // Update is called once per frame
    void Update () {

    }
}