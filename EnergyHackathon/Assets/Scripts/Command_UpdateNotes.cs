using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

[CommandInfo ("Custom",
    "Update Notes",
    "Updates notes on said apartment")]
[AddComponentMenu ("")]
public class Command_UpdateNotes : Command {

    public ApartmentData targetApt;
    public StringData newNotes;
    public bool open;
    public override void OnEnter () {
        CrossSectionUI.instance.UpdateNotes (targetApt, newNotes);
        Continue ();
    }

}