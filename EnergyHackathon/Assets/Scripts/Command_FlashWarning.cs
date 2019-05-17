using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

[CommandInfo ("Custom",
    "Apt: Flash Warning",
    "Starts or stops warning flashing at apartment")]
[AddComponentMenu ("")]
public class Command_FlashWarning : Command {

    public ApartmentData targetApt;
    public BooleanData warning;
    public BooleanData evict;
    public override void OnEnter () {
        if (!evict) {
            CrossSectionUI.instance.FlashWarning (targetApt, warning);
        } else {
            CrossSectionUI.instance.EmptyApartment (targetApt, true);
        }
        Continue ();
    }

}