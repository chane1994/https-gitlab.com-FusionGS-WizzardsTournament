using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// It is responsible for the actions of the player. It will distribute the orders to different classes depending on what needs to be done. This class will keep everything in order if the player changes avatars.
    /// </summary>
    public class Player : MonoBehaviour// This class is independent of the avatar. 
    {
        #region Variables
        Character _character;
        public Transform leftController;
        public Transform rightController;
        //state
        #endregion

        #region Properties
        public static Player Instance { get; private set; }
        #endregion

        #region Methods
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
               
            }
            else
            {
                Destroy(gameObject);
            }
            
        }

        void Start()
        {
            _character = new Character(IOManager.Instance.GetCharacterJSONNode(CharacterName.Honovi));
            StartCoroutine("SetUpBody");
        }

       


        IEnumerator SetUpBody()
        {

            GameObject leftArm = Resources.Load<GameObject>(_character.LeftArmPath);
            yield return new WaitForSeconds(0.1f);
            leftArm = Instantiate(leftArm);
            // yield return new WaitForSeconds(0.3f);
            leftArm.transform.parent = leftController.transform;
            // yield return new WaitForSeconds(0.1f);
            leftArm.transform.localPosition = Vector3.zero;

            yield return new WaitForSeconds(0.1f);
            GameObject rightArm = Resources.Load<GameObject>(_character.RightArmPath);
            yield return new WaitForSeconds(0.1f);
            rightArm = Instantiate(rightArm);
            // yield return new WaitForSeconds(0.3f);
            rightArm.transform.parent = rightController.transform;
         //   yield return new WaitForSeconds(0.1f);
            rightArm.transform.localPosition = Vector3.zero;


          

          

            yield return new WaitForSeconds(0.1f);

            _character.leftSpellCaster = leftArm.GetComponent<SpellCaster>();
            _character.rightSpellCaster = rightArm.GetComponent<SpellCaster>();
        }


        /// <summary>
        /// Receives the information from the inputhandler and sends it to the statemachine to be processed
        /// </summary>
        /// <param name="inputCommand"></param>
        public void ProcessInput(InputCommand inputCommand)
        {
            #region Dummy code for fast setup
            switch (inputCommand)
            {
                case InputCommand.LeftTriggerPressed:
                    _character.ProcessInputCommand(inputCommand);
                    break;
                case InputCommand.LeftTriggerReleased:
                    break;
                case InputCommand.RightTriggerPressed:
                    _character.ProcessInputCommand(inputCommand);
                    break;
                case InputCommand.RightTriggerReleased:
                    break;
                case InputCommand.LeftTouchpadPressed:
                    break;
                case InputCommand.LeftTouchpadReleased:
                    break;
                case InputCommand.RightTouchpadPressed:
                    break;
                case InputCommand.RightTouchpadReleased:
                    break;
                case InputCommand.LeftGripPressed:
                    break;
                case InputCommand.RightGripPressed:
                    break;
                default:
                    break;
            }
            #endregion
        }
        #endregion
    }
}

