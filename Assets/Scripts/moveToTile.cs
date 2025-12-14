using Unity.VisualScripting;
using UnityEngine;

public class moveToTile : MonoBehaviour
{
    public Vector2Int tile = new Vector2Int(0, 0);
    public GameObject tileManager;
    public Material baseTileMat;
    public Material yesTileMat;
    public Material noTileMat;
    private Renderer self;

    void Start()
    {
        self = GetComponent<Renderer>();
        self.material = baseTileMat;
        transform.position = gameManager.Instance.translateToGlobal(tile);

    }

    void OnMouseEnter()
    {
        Debug.Log("enter: " + tile);
        if (gameManager.Instance.isThereAObstacleHere(tile))
        {
            self.material = noTileMat;
        }
        else
        {
            self.material = yesTileMat;
        }

        //emit a signal saying 'yo the player clicked on this tile'
        //in the manager script it will test if theres an enemy on that square, if there is it will move onto the same square and 'fight' then move to an adjacent square
    }
    void OnMouseExit()
    {
        self.material = baseTileMat;
    }

}
