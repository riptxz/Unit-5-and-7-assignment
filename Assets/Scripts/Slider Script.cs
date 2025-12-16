using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    public Slider slider;
    [SerializeField] private TextMeshProUGUI slidertext;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.onValueChanged.AddListener((v) => {
            slidertext.text = v.ToString("0%");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
