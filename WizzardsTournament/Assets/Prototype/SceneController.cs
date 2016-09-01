using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Prototype
{
    public class SceneController : MonoBehaviour
    {
        public Text finished;
        public Slider slider;
        static int count = 0;

        public static void IncreaseCount()
        {
            count++;
        }

        private void Update()
        {
            if (SceneController.count == 15)
            {
                string adj = "slow";
                if (slider.value < 61)
                    adj = "fast";

                if(slider.value > 60 && slider.value < 121)
                    adj = "average";
                float a = slider.value;
                finished.text = "You finished in " + a + " seconds. You are " + adj;
                finished.gameObject.SetActive(true);
            }
        }


    }

}
