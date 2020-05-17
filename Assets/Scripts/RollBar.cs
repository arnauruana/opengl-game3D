using UnityEngine;
using UnityEngine.UI;

public class RollBar : MonoBehaviour
{
    public Slider slider;
    public Image rollbar;
    public bool rollup;
    // Start is called before the first frame update
    void Start()
    {
        RollUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rollup)
        {
            ++slider.value;
            if (slider.value == slider.maxValue) RollUp();
        }

    }

    public void RollDown()
    {
        rollup = false;
        slider.value = 0;
        rollbar.color = new Color32(248, 255, 191, 255);
    }

    public void RollUp()
    {
        slider.value = slider.maxValue;
        rollup = true;
        rollbar.color = new Color32(27, 136, 229, 255);
    }
}
