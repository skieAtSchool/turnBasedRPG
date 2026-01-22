using UnityEngine;

public class popupMgr : MonoBehaviour
{
    public Transform layout;
    public SpriteRenderer layoutSpriteR;
    public Transform bootBg;
    public SpriteRenderer bootBgSpriteR;
    public Transform bootHL;
    public SpriteRenderer bootHLSpriteR;
    public Transform bootIco;
    public SpriteRenderer bootIcoSpriteR;




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

    }

    public string hidePopup()
    {
        setAll(false);
        return "move";
    }
    public void showPopup()
    {
        setAll(true);
    }

    private void setAll(bool value)
    {
        layoutSpriteR.enabled = value;
        bootBgSpriteR.enabled = value;
        bootIcoSpriteR.enabled = value;
        bootHLSpriteR.enabled = value;
    }
}
