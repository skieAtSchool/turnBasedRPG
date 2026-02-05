using UnityEngine;

public class playerDetailMgr : MonoBehaviour
{
    struct playerValues
    {
        //Variable declaration
        //Note: I'm explicitly declaring them as public, but they are public by default. You can use private if you choose.
        public playerDetail nose;
        public playerDetail hair;
        public playerDetail facialHair;
        public playerDetail eye;
        public playerDetail eyebrow;
        public playerDetail ear;

        //Constructor (not necessary, but helpful)
        /*public InventorySlot(bool isFree, string name)
        {
            this.IsFree = isFree;
            this.Name = name;
        }*/
    }


    struct playerDetail
    {
        //Variable declaration
        //Note: I'm explicitly declaring them as public, but they are public by default. You can use private if you choose.
        public string type;
        private bool? _isOn; 
        private int? _value;
        private int? _color;

        // have property expose the "default" if not yet set
        /*public int IsOn
        {
            get { return _isOn ?? false; }
        }

        // remove default, doesn't work
        public playerDetail(bool isOn)
        {
            _isOn = isOn;
        }*/
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
