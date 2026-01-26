using UnityEngine;

public class player : MonoBehaviour
{
    public Vector2Int pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveToPos(new Vector2Int(0, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.Instance.playerPos != null && gameManager.Instance.playerPos != pos)
        {
            pos = gameManager.Instance.playerPos;
            moveToPos(pos);
            Debug.Log("test");
        }
    }


    void moveToPos(Vector2Int pos)
    {
        transform.position = gameManager.Instance.translateToGlobal(pos);
    }
}
