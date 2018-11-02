using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {

    public Text TextA;
    public Text TextB;

    public bool FlagA = false;
    public bool FlagB = false;

    public void ButtonA()
    {
        FlagA = true;
    }

    public void ButtonB()
    {
        FlagB = true;
    }

}
