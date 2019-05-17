using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

[CommandInfo ("Custom",
    "Update Energy Use",
    "Updates energy use on said apartment")]
[AddComponentMenu ("")]
public class Command_UpdateEnergyUse : Command {

    public ApartmentData targetApt;
    public StringData newNotes;
    public bool open;
    public override void OnEnter () {
        CrossSectionUI.instance.UpdateEnergyUse (targetApt, newNotes);
        Continue ();
    }

}