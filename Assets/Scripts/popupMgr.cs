using UnityEngine;

public class popupMgr : MonoBehaviour
{
    public string popupState = "none";


    public Transform layout;
    public SpriteRenderer layoutSpriteR;
    public Transform bootBg;
    public SpriteRenderer bootBgSpriteR;
    public Transform bootHL;
    public SpriteRenderer bootHLSpriteR;
    public Transform bootIco;
    public SpriteRenderer bootIcoSpriteR;

    public bool isVisible = false;

    public Vector3 screenSize;
    public Camera cam;
    public float distanceToUI = 5;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layout = transform.GetChild(0);
        layoutSpriteR = layout.GetComponent<SpriteRenderer>();
        bootBg = transform.GetChild(1);
        bootBgSpriteR = bootBg.GetComponent<SpriteRenderer>();
        bootHL = transform.GetChild(2);
        bootHLSpriteR = bootHL.GetComponent<SpriteRenderer>();
        bootIco = transform.GetChild(3);
        bootIcoSpriteR = bootIco.GetComponent<SpriteRenderer>();

        cam = GameObject.FindGameObjectWithTag("cam").GetComponent<Camera>();

        screenSize = new Vector3(Screen.height, Screen.width, 0);

    }

    public void FixedUpdate()
    {
        if (isVisible)
        {
            Vector2 centerOfUI = Camera.main.WorldToScreenPoint(transform.position);
            
            Vector2 mousePos = Input.mousePosition;
            float angle = Vector2.Angle(mousePos - centerOfUI, Vector2.right);
            Debug.Log(angle);
            Debug.Log(Vector2.Distance(mousePos, centerOfUI));
            if (Vector2.Distance(mousePos, centerOfUI) > distanceToUI) {
                if (-45 > angle && -135 < angle)
                {
                    bootHLSpriteR.enabled = true;
                    popupState = "move";
                }
                else
                {
                    bootHLSpriteR.enabled = false;
                }
            }
        }
    }

    public string hidePopup()
    {
        setAll(false);
        isVisible = false;
        return "move";
    }
    public void showPopup()
    {
        setAll(true);
        isVisible = true;
    }

    private void setAll(bool value)
    {
        layoutSpriteR.enabled = value;
        bootBgSpriteR.enabled = value;
        bootIcoSpriteR.enabled = value;
        bootHLSpriteR.enabled = value;
    }

}
