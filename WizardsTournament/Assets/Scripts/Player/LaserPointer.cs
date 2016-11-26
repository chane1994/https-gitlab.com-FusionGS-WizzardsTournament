using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    public class LaserPointer : MonoBehaviour
    {
        #region Variables
        public float thickness = 0.002f;
        public GameObject holder;
        public GameObject pointer;
        //The delegate for these events is in SteamVR_LaserPointer
        public event PointerEventHandler PointerIn;
        public event PointerEventHandler PointerOut;
        const string PLATFORM_TAG = "Platform";
        const string POINTER_TAG = "Pointer";
        GameObject previousContact = null;
        #endregion

        #region Methods
        /// <summary>
        /// It will try to inform the platform that it has to remove the teleportation indicator and get the spawning point.
        /// </summary>
        /// <param name="newPosition">New position for which you are going to teleport</param>
        /// <returns>Returns true if the player was pointing to a platform. It returns false otherwise.</returns>
        public virtual bool TryDeactivatePlatformLight(out Vector3 newPosition)
        {
            bool deactivatedLight = false;
            newPosition = Vector3.zero;

            if (previousContact != null)
            {
                deactivatedLight = true;
                Platform platform = previousContact.GetComponent<Platform>();
                newPosition = platform.spawningPosition.position;
                platform.UpdateTeleportationIndicator(false);
                previousContact = null;
            }
           
            gameObject.SetActive(false);
            return deactivatedLight;
        }

        public virtual void OnPointerIn(PointerEventArgs e)
        {
            //check if the pointerIn event handler is not null
            //execute the event handlers

            //todo this is temporal
            e.target.gameObject.GetComponent<Platform>().UpdateTeleportationIndicator(true);
                WizardsTournament.Debugger.Log("enter Target");
        }

        public virtual void OnPointerOut(PointerEventArgs e)
        {
                WizardsTournament.Debugger.Log("left Target");
            e.target.gameObject.GetComponent<Platform>().UpdateTeleportationIndicator(false);
        }

        void Update()
        {

            float dist = 100f;

            SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController>();

            Ray raycast = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            bool bHit = Physics.Raycast(raycast, out hit);

            if ( previousContact && 
                (!hit.transform || !previousContact.Equals( hit.transform.gameObject)&&
                                    !hit.transform.gameObject.tag.Equals(POINTER_TAG)))
            {
                PointerEventArgs args = new PointerEventArgs();
                if (controller != null)
                {
                    args.controllerIndex = controller.controllerIndex;
                }
                args.distance = 0f;
                args.flags = 0;

                args.target = previousContact.transform;
                OnPointerOut(args);
                previousContact = null;
            }

            if (bHit && hit.transform.gameObject.tag.Equals(PLATFORM_TAG) && previousContact != hit.transform.gameObject)
            {
                PointerEventArgs argsIn = new PointerEventArgs();
                if (controller != null)
                {
                    argsIn.controllerIndex = controller.controllerIndex;
                }
                argsIn.distance = hit.distance;
                argsIn.flags = 0;
                argsIn.target = hit.transform;
                OnPointerIn(argsIn);
                previousContact = hit.transform.gameObject;
            }

            if (!bHit)
            {
                previousContact = null;
            }

            if (bHit && hit.distance < 100f)
            {
                dist = hit.distance;
            }

            if (controller != null && controller.triggerPressed)
            {
                pointer.transform.localScale = new Vector3(thickness * 5f, thickness * 5f, dist);
            }
            else
            {
                pointer.transform.localScale = new Vector3(thickness, thickness, dist);
            }
            pointer.transform.localPosition = new Vector3(0f, 0f, dist / 2f);
        }
        #endregion
    }






    //public class PlayerTeleporter : MonoBehaviour
    //{

    //    public Camera Mycamera;
    //    public bool TeleportNow { get; set; }


    //    // Update is called once per frame
    //    void Update()
    //    {
    //        RaycastHit hit;
    //        Ray teleportingHit = new Ray(Mycamera.transform.position, Mycamera.transform.forward);

    //        Debug.DrawRay(Mycamera.transform.position, Mycamera.transform.forward);
    //        if (TeleportNow)
    //        {
    //            TeleportNow = false;

    //            if (Physics.Raycast(teleportingHit, out hit))
    //            {
    //                if (hit.collider.tag.Equals("Platform"))
    //                {
    //                    Transform teleportingPosition = hit.collider.GetComponent<Platform>().spawningPosition;
    //                    transform.position = teleportingPosition.position;
    //                    transform.parent = teleportingPosition;
    //                }
    //                else
    //                {
    //                    Debugger.Log("The tag of the objective has to be Platform");
    //                }
    //            }
    //        }
    //    }
    //}

}
