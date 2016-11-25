using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    public class LaserPointer : MonoBehaviour
    {
       // public bool active = true;
      //  public Color color;
        public float thickness = 0.002f;
        public GameObject holder;
        public GameObject pointer;
       // bool isActive = false;
       // public bool addRigidBody = false;
       // public Transform reference;
        public event PointerEventHandler PointerIn;
        public event PointerEventHandler PointerOut;
        const string PLATFORM_TAG = "Platform";
        const string POINTER_TAG = "Pointer";
        // Transform previousContact = null;
        GameObject previousContact = null;

        public virtual void OnPointerIn(PointerEventArgs e)
        {
            //if (PointerIn != null)
            if (previousContact == null)
            {
                //previousContact = e.target;
                WizardsTournament.Debugger.Log("enter Target");
                // PointerIn(this, e);

            }
        }

        public virtual void OnPointerOut(PointerEventArgs e)
        {
            //   if (PointerOut != null)

            {
                WizardsTournament.Debugger.Log("left Target");
                //   PointerOut(this, e);


            }

        }


        // Update is called once per frame
        /* void Update()
        {
            //if (!isActive)
            //{
            //    isActive = true;
            //    this.transform.GetChild(0).gameObject.SetActive(true);
            //}

            float dist = 100f;

            SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController>();

            Ray raycast = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            bool bHit = Physics.Raycast(raycast, out hit);

            if (previousContact && previousContact != hit.transform)
            {
                PointerEventArgs args = new PointerEventArgs();
                if (controller != null)
                {
                    args.controllerIndex = controller.controllerIndex;
                }
                args.distance = 0f;
                args.flags = 0;
                args.target = previousContact;
                OnPointerOut(args);
                previousContact = null;
            }

            if (bHit && previousContact != hit.transform)
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
                previousContact = hit.transform;
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
        }*/

        void Update()
        {
            //if (!isActive)
            //{
            //    isActive = true;
            //    this.transform.GetChild(0).gameObject.SetActive(true);
            //}

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
