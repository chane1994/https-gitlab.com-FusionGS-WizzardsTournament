using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Prototype
{
    public class SliderHandlr : MonoBehaviour
    {
        Slider slider;
        public Text lossText;

        // Use this for initialization
        void Start()
        {
            slider = GetComponent<Slider>();
            InvokeRepeating("IncreaseSlider", 0,1);
        }

        // Update is called once per frame
        void IncreaseSlider()
        {
            slider.value++;
            if (slider.value == slider.maxValue)
            {
                lossText.gameObject.SetActive(true);
            }
        }
    }

}
