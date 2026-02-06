using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class playerValues : MonoBehaviour
{
    //face values:
    public Dictionary<string, ushort?> faceDetailValues = new Dictionary<string, ushort?>
    {
        {"Nose", 2},
        {"Hair", null},
        {"HairColor", 1},
        {"FacialHair", null},
        {"FacialHairColor", 1},
        {"Eyebrow", null},
        {"EyebrowColor", 1},
        {"Eye", null},
        {"EyeColor", 1},
        {"Ear", null},
    };
}
