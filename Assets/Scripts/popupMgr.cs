using UnityEngine;

public class popupMgr : MonoBehaviour
{

    public bool hidden = true;
    private GameObject[] children;
    private GameObject[] childrenImages;
    private GameObject[] childrenButtons;
    private TextMesh[] childrenTMP;

    private void Start()
    {
        hidden = true;

        for(int childrenVar = 0; childrenVar == transform.childCount - 1; childrenVar++)
        {
            try
            {
                Transform childTransform = transform.GetChild(childrenVar);
                children[childrenVar] = childTransform.gameObject;

                Debug.Log("Child name: " + children[childrenVar].name);
            }
            catch
            {
                Debug.LogError("WEIRD ERROR POPUP MANAGER! FIX IMMEDIATELY!");
            }
        }
    }

    public void show()
    {
        Debug.Log("showing menu");   
    }
    public void hide()
    {
        Debug.Log("hiding menu");
    }
}
