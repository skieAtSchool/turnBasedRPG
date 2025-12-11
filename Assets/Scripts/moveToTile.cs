using UnityEngine;

public class moveToTile : MonoBehaviour
{
    public Vector2Int tile = new Vector2Int(0, 0);
    private GameObject tileManager;

    void Start()
    {
        // set transform.position based on tile
        //get the tileMgr for refrencing
    }

    private void FixedUpdate()
    {
        //test for mouse hover using MonoBehavior.onMouseHover()

        //emit a signal saying 'yo the player clicked on this tile'
        //in the manager script it will test if theres an enemy on that square, if there is it will move onto the same square and 'fight' then move to an adjacent square
    }

}
