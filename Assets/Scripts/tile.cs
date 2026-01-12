using Unity.VisualScripting;
using UnityEngine;

public class tileScript : MonoBehaviour
{
    public Vector2Int tilePos; //= new Vector2Int(0, 0);
    public GameObject tileManager;
    public Material baseTileMat;
    public Material yesTileMat;
    public Material noTileMat;
    private Renderer self;

    public string tileState;
    public static string moveable = "moveable";
    public static string unMoveable = "unMoveable";

    public bool isHovered = false;
    public float distanceToPlayer;


    void Start()
    {
        self = GetComponent<Renderer>();
        self.material = baseTileMat;
        transform.position = gameManager.Instance.translateToGlobal(tilePos);
        findState();
        isHovered = false;

    }

    void OnMouseEnter()
    {
        if (gameManager.Instance.holding == false)
        {
            isHovered = true;
            gameManager.Instance.focusedPoint = tilePos;
            if(tileState == moveable)
            {
                gameManager.Instance.focusedIsMovable = true;
            }else if (tileState == unMoveable)
            {
                gameManager.Instance.focusedIsMovable = false;
            }

            distanceToPlayer = gameManager.Instance.DistanceToPlayer(tilePos);

            Debug.Log("enter: " + tilePos + " | hoverstate = " + isHovered + " | tileState = " + tileState + " | distanceToPlayer = " + distanceToPlayer);
        }

        //emit a signal saying 'yo the player clicked on this tile'
        //in the manager script it will test if theres an enemy on that square, if there is it will move onto the same square and 'fight' then move to an adjacent square
    }
    void OnMouseExit()
    {
        self.material = baseTileMat;
        isHovered = false;
    }

    public void Update()
    {
        if (isHovered == true){
            if(tileState == moveable)
            {
                self.material = yesTileMat;
            }
            else 
            {
                self.material = noTileMat;
            }
        }
        else if(self.material != baseTileMat)
        {
            self.material = baseTileMat;
        }
    }

    public void findState()
    {
        if (gameManager.Instance.isThereAObstacleHere(tilePos) == true)
        {
            tileState = unMoveable;
        }
        else {
            tileState = moveable;
        }
    }

}
