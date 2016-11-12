﻿using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// It is the interface component between the game and the Vive.
    /// </summary>
    [RequireComponent(typeof(SteamVR_TrackedObject))]
    public class PlayerInputHandler : MonoBehaviour
    {
        public Hand hand;
        private SteamVR_TrackedObject _trackedObj;
        private SteamVR_Controller.Device _device;


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
                if (hand.Equals(Hand.Left))
                {
                    Player.Instance.ProcessInput(InputCommand.LeftTriggerPressed);
                }
                else
                {
                    Player.Instance.ProcessInput(InputCommand.RightTriggerPressed);
                }
                
            }

            if (_device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                if (hand.Equals(Hand.Left))
                {
                    Player.Instance.ProcessInput(InputCommand.LeftTriggerReleased);
                }
                else
                {
                    Player.Instance.ProcessInput(InputCommand.RightTriggerReleased);
                }
            }

            if (_device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                OnGripPressed();
            }

            if (_device.GetPressDown( SteamVR_Controller.ButtonMask.Touchpad))
            {
                OnTouchpadPressed();
            }

            if (_device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                OnTouchpadReleased();
            }

        }

        #region Trigger
        private void OnTriggerPressed()
        {
            //convert the trigger to the correct enum in the game and pass it to the player
            Debug.Log("Trigger Pressed");
        }

        private void OnTriggerReleased()
        {
            //convert the trigger to the correct enum in the game and pass it to the player
            Debug.Log("Trigger Released");
        }
        #endregion

        #region Touchpad
        private void OnTouchpadPressed()
        {
            //convert the trigger to the correct enum in the game and pass it to the player
            Debug.Log("Touchpad Pressed");
        }

        private void OnTouchpadReleased()
        {
            //convert the trigger to the correct enum in the game and pass it to the player
            Debug.Log("Touchpad Released");
        }
        #endregion

        #region Grip
        private void OnGripPressed()
        {
            //convert the trigger to the correct enum in the game and pass it to the player
            Debug.Log("Grip Pressed");
        }

        #endregion

        #endregion
    }

}
