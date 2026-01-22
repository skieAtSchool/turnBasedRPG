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
    public bool focusedIsMovable;

    public Vector2Int playerPos;

    public popupMgr popup;
    public Vector2 mousePos;
    private GameObject popupMgrObj;
    private popupMgr popupMgrScript;

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
    public float DistanceToPlayer(Vector2Int currentPos)
    {
        float x, y;
        x = currentPos.x - playerPos.x;
        y = currentPos.y - playerPos.y;

        x = Mathf.Abs(x);
        y = Mathf.Abs(y);

        x = Mathf.Pow(x, 2);
        y = Mathf.Pow(y, 2);

        float fin = Mathf.Sqrt(x + y);

        return fin;
    }

    private void onMouseDown()
    {
        mousePos = Input.mousePosition;
        popupMgrObj.transform.position = translateToGlobal(focusedPoint);
        popupMgrScript.showPopup();
        holding = true;
    }
    private void onMouseUp()
    {
        if (popupState == move)
        {

            if (focusedIsMovable == true)
            {
                Debug.Log("move to " + focusedPoint);
                playerPos = focusedPoint;
            }
            else
            {
                Debug.Log(focusedPoint + " is occupied, cannot move");
            }
        }
        else if (popupState == none)
        {

        }
        popupMgrScript.hidePopup();
        holding = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onMouseDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            onMouseUp();
        }
    }

    private void Start()
    {
        try
        {
            popupMgrObj = GameObject.FindGameObjectWithTag("popupMgr");
            popupMgrScript = popupMgrObj.GetComponent<popupMgr>();
        }
        catch { Debug.LogError("popupNotFound"); }
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
