using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// It is the interface component between the game and the Vive.
    /// </summary>
    [RequireComponent(typeof(SteamVR_TrackedObject))]
    public class PlayerInputHandler : MonoBehaviour
    {
        #region Variables
        public Hand hand;
        private SteamVR_TrackedObject _trackedObj;
        private SteamVR_Controller.Device _device;
        #endregion

        #region Methods
        private void Awake()
        {
            _trackedObj = GetComponent<SteamVR_TrackedObject>();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            _device = SteamVR_Controller.Input((int)_trackedObj.index);
            if (_device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
               // _device.TriggerHapticPulse(750);
                PlayerController.Instance.ProcessInput(InputCommand.TriggerPressed, hand);
            }

            if (_device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                PlayerController.Instance.ProcessInput(InputCommand.TriggerReleased, hand);
            }

            if (_device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                PlayerController.Instance.ProcessInput(InputCommand.GripPressed, hand);
            }

            if (_device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
            {
                PlayerController.Instance.ProcessInput(InputCommand.GripReleased, hand);
            }

            if (_device.GetPressDown( SteamVR_Controller.ButtonMask.Touchpad))
            {
                PlayerController.Instance.ProcessInput(InputCommand.TouchpadPressed, hand);
            }

            if (_device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                PlayerController.Instance.ProcessInput(InputCommand.TouchpadReleased, hand);
            }

        }
        #endregion
    }

}
