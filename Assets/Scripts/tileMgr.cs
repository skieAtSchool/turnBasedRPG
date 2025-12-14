using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class tileMgr : MonoBehaviour
{

	public GameObject tile;
	public Vector2Int arenaSize;

	void Start()
	{
		int vertical;
		int horizontal;
		vertical = Mathf.Abs(arenaSize.x);
		horizontal = Mathf.Abs(arenaSize.y);

		while(vertical != 0)
		{
			while(horizontal != 0)
			{
                moveToTile tileScript = tile.GetComponent<moveToTile>();
                /*if (tileScript != null)
                {
                    Debug.LogError("cannot get script of tile (" + horizontal + ", " + vertical + ")");
                }*/

                tileScript.tile = new Vector2Int(horizontal, vertical);

                Instantiate(tile, transform.position, transform.rotation, transform);

				horizontal -= 1;
			}
			horizontal = arenaSize.y;
			vertical -= 1;
		}


	}
}
