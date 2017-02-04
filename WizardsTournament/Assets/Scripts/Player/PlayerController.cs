using UnityEngine;
using System.Collections;
using System;

namespace WizardsTournament
{
    /// <summary>
    /// It is responsible for the actions of the player. It will distribute the orders to different classes depending on what needs to be done. This class will keep everything in order if the player changes avatars.
    /// </summary>
   // [RequireComponent(typeof(PlayerTeleporter))]
    public class PlayerController : MonoBehaviour// This class is independent of the avatar. 
    {
        #region Variables
   
        public Transform leftController;
        public Transform rightController;
        [SerializeField]
        Transform _spellSealSpawningPoint;
        [SerializeField]
        Transform _head;
        Character _character;
      //  PlayerTeleporter _teleporter;
        
        //state
        #endregion

        #region Properties
        public static PlayerController Instance { get; private set; }

        public Transform GetSpellSealSpawningPoint { get { return _spellSealSpawningPoint; } }

        public Transform GetHead { get { return _head; } }
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
            //_teleporter = GetComponent<PlayerTeleporter>();
            _character = new Honovi();//new Character(IOManager.Instance.GetCharacterJSONNode(CharacterName.Honovi));
            StartCoroutine("SetUpBody");
        }

        public Collider[] GetHandColliders()
        {
            Collider[] handColliders = new Collider[2];
            handColliders[0] = _character.leftSpellCaster.GetComponent<Collider>();
            handColliders[1] = _character.rightSpellCaster.GetComponent<Collider>();
            return handColliders;
        }

        public void UpdateHandColliders(bool enable)
        {
            Collider[] handColliders = GetHandColliders();
            for (int i = 0; i < handColliders.Length; i++)
            {
                handColliders[i].enabled = enable;
            }
        }

        /// <summary>
        /// Instantiates and positions the parts of the body of the selected character
        /// </summary>
        /// <returns></returns>
        IEnumerator SetUpBody()
        {
            GameObject leftArm = Resources.Load<GameObject>(_character.LeftArmPath);
            GameObject rightArm = Resources.Load<GameObject>(_character.RightArmPath);
            yield return new WaitForSeconds(0.3f);
            leftArm = Instantiate(leftArm);
            rightArm = Instantiate(rightArm);
            yield return new WaitForSeconds(0.1f);
            leftArm.transform.parent = leftController.transform;
            rightArm.transform.parent = rightController.transform;
            bool handsReady = false;

            #region Correcting hand position and rotation
            while (!handsReady)
            {
                yield return new WaitForSeconds(0.1f);
                try
                {
                    leftController.GetComponent<HandPositionCorrecter>().UpdateHandRotationAndPosition((CharacterName)Enum.Parse(typeof(CharacterName), _character.Name)); //correcting angles and positioning
                    rightController.GetComponent<HandPositionCorrecter>().UpdateHandRotationAndPosition((CharacterName)Enum.Parse(typeof(CharacterName), _character.Name)); //correcting angles and positioning
                    handsReady = true;
                }
                catch (Exception ex)
                {
                    Debugger.Log("Hands are not ready. " + ex.Message);
                }
            }
            #endregion

            yield return new WaitForSeconds(0.1f);

            _character.leftSpellCaster = leftArm.GetComponent<SpellCaster>();
            _character.rightSpellCaster = rightArm.GetComponent<SpellCaster>();
        }

        /// <summary>
        /// Receives the information from the inputhandler and sends it to the statemachine to be processed
        /// </summary>
        /// <param name="inputCommand"></param>
        public void ProcessInput(InputCommand inputCommand, Hand hand)
        {
            _character.ProcessInputCommand(inputCommand,hand);
        }

        public void Teleport(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
        #endregion
    }
}

