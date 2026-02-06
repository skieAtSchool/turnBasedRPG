using UnityEngine;
using System.Collections.Generic;


public class playerDetailMgr : MonoBehaviour
{
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getPlayer();
        playerValues playerVal = readPlayerValuesFromSave();
        assignPlayerValues(playerVal, GameObject.FindGameObjectWithTag("faceDetailParent"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void getPlayer()
    {

    }

    playerValues readPlayerValuesFromSave()
    {
        playerValues saveValue = new playerValues();
        return saveValue;
    }

    void assignPlayerValues(playerValues value, GameObject faceDetailPts)
    {
        foreach (KeyValuePair<string, ushort?> kvp in value.faceDetailValues)
        {
            GameObject childObj = faceDetailPts.transform.Find(kvp.Key).gameObject;
            if (kvp.Key.Contains("Color")) {
                foreach (Transform child in childObj.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
            else
            {
                if (kvp.Value == null)
                {
                    foreach(Transform child in childObj.transform)
                    {
                        child.gameObject.SetActive(false);
                    }
                }
                else
                {
                    int index = 1;
                    foreach (Transform child in childObj.transform)
                    {
                        if (child.name.Contains("Type " + index))
                        {
                            child.gameObject.SetActive(true);
                        }
                        else
                        {
                            child.gameObject.SetActive(false);
                        }
                        index++;
                    }
                }
            }
            
        }
    }
}
