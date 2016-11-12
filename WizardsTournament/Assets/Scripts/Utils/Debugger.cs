using UnityEngine;

namespace WizardsTournament
{
    public class Debugger
    {
        public static bool print = true;

        public static void Print(string text)
        {
            if (print)
            {
                Debug.Log(text);
            }
        }
    }

}
