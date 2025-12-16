using UnityEngine;

public class enemyMgr : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public static Vector2Int[] enemyPositions;

    private void Start()
    {
        int x = 4;
        while (x > 0)
        {
            int enemyPrefabNum = Mathf.RoundToInt(Random.Range(0, enemyPrefabs.Length));

            enemy enemyScipt = enemyPrefabs[enemyPrefabNum].GetComponent<enemy>();
            /*if (tileScript != null)
            {
                Debug.LogError("cannot get script of tile (" + horizontal + ", " + vertical + ")");
            }*/

            enemyScipt.position = new Vector2Int(Random.Range(1, 10),Random.Range(1, 10));
            enemyPositions[x] = enemyScipt.position;

            Instantiate(enemyPrefabs[enemyPrefabNum], transform.position, transform.rotation, transform);


            x -= 1;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }


    
}
