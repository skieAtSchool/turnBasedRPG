using UnityEngine;

public class popupMgr : MonoBehaviour
{
    public string popupState = "none";


    public Transform layout;
    public SpriteRenderer layoutSpriteR;
    public Transform bootBg;
    public SpriteRenderer bootBgSpriteR;
    public Transform swordBg;
    public SpriteRenderer swordBgSpriteR;
    public Transform bootHL;
    public SpriteRenderer bootHLSpriteR;
    public Transform swordHL;
    public SpriteRenderer swordHLSpriteR;
    public Transform bootIco;
    public SpriteRenderer bootIcoSpriteR;
    public Transform swordIco;
    public SpriteRenderer swordIcoSpriteR;

    public bool isVisible = false;

    public Vector3 screenSize;
    public float distanceToUI = 50;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layout = transform.GetChild(0);
        layoutSpriteR = layout.GetComponent<SpriteRenderer>();
        bootBg = transform.GetChild(1);
        bootBgSpriteR = bootBg.GetComponent<SpriteRenderer>();
        swordBg = transform.GetChild(2);
        swordBgSpriteR = swordBg.GetComponent<SpriteRenderer>();
        bootHL = transform.GetChild(3);
        bootHLSpriteR = bootHL.GetComponent<SpriteRenderer>();
        swordHL = transform.GetChild(4);
        swordHLSpriteR = swordHL.GetComponent<SpriteRenderer>();
        bootIco = transform.GetChild(5);
        bootIcoSpriteR = bootIco.GetComponent<SpriteRenderer>();
        swordIco = transform.GetChild(6);
        swordIcoSpriteR = swordIco.GetComponent<SpriteRenderer>();

        screenSize = new Vector3(Screen.height, Screen.width, 0);
        
    }

    public void FixedUpdate()
    {
        if (isVisible)
        {
            Vector2 centerOfUI = Camera.main.WorldToScreenPoint(transform.position);
            
            Vector2 mousePos = Input.mousePosition;
            float angle = Vector2.SignedAngle(mousePos - centerOfUI, Vector2.right);
            if (Vector2.Distance(mousePos, centerOfUI) > distanceToUI) {
                if (-45 > angle && -135 < angle)
                {
                    bootHLSpriteR.enabled = true;
                    bootBgSpriteR.enabled = false;
                    popupState = "move";
                }
                else if ((-135 > angle && -180 < angle) || (135 < angle && 180 > angle))
                {
                    swordHLSpriteR.enabled = true;
                    swordBgSpriteR.enabled = false;
                    popupState = "fight";
                }
                else
                {
                    bootBgSpriteR.enabled = true;
                    bootHLSpriteR.enabled = false;
                    swordBgSpriteR.enabled = true;
                    swordHLSpriteR.enabled = false;
                }
            }
            else
            {
                bootBgSpriteR.enabled = true;
                bootHLSpriteR.enabled = false;
                swordBgSpriteR.enabled = true;
                swordHLSpriteR.enabled = false;
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
        swordBgSpriteR.enabled = value;
        swordIcoSpriteR.enabled = value;
        swordHLSpriteR.enabled = value;
    }

}
