using Unity.VisualScripting;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }
    public bool holding = false;
    public static State none;
    public static State move;

    public State popupState = none;

    public Vector2Int focusedPoint;

    public Vector3 translateToGlobal(Vector2Int localPos)
    {
        Vector2 localPosCalc = (Vector2)localPos;

        localPosCalc.x *= 2.5f;
        localPosCalc.y *= 2.5f;

        localPosCalc.x -= 2.5f;
        localPosCalc.y -= 2.5f;


        Vector3 globalPos;

        globalPos.x = localPosCalc.x;
        globalPos.z = localPosCalc.y;
        globalPos.y = -5;

        return globalPos;
    }


    public bool isThereAObstacleHere(Vector2Int position)
    {
        for (int i = 0; i < enemyMgr.enemyPositions.Length; i++)
        {
            if (position == enemyMgr.enemyPositions[i])
            {
                return true;
            }
        }
        return false;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            holding = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(popupState == move)
            {
                GameObject popup = GameObject.Find("popup");
                popupMgr popupMgrScript = popup.GetComponent<popupMgr>();
                popupMgrScript.hide();
                Debug.Log("move to " + focusedPoint);

            }
            holding = false;

        }
    }


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
