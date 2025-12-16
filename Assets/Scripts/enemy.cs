using UnityEngine;

public class enemy : MonoBehaviour
{
    public Vector2Int position;



    public float health = 20;
    public float damagePerHit = 2;
    public float hitSpeed = 1.0f; // per sec



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = gameManager.Instance.translateToGlobal(position) /* + new Vector3(.25f / 2, 0, .25f / 2)*/;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
