using UnityEngine;
using System.Collections;
using SimpleJSON;
namespace WizardsTournament
{
    /// <summary>
    /// Gets all the information from the harddrive, JSONfiles, PlayerPrefs, and more.
    /// </summary>
    public class IOManager : MonoBehaviour
    {
        #region Variables and Constants
        public const string JSON_METADATA_PATH = "JSONFiles/Metadata";
        JSONNode _charactersDataFilesDirectory;
        #endregion

        #region Properties
        public static IOManager Instance { get; private set; }
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
            //Getting the directory of JSON Files that will be used to populate the characters later
            _charactersDataFilesDirectory = JSON.Parse(((TextAsset)Resources.Load(JSON_METADATA_PATH)).text);
        }

        public JSONNode GetCharacterJSONNode(CharacterName characterName)
        {
            string JSONfilePath = _charactersDataFilesDirectory[characterName.ToString()];
            return JSON.Parse(((TextAsset)Resources.Load(JSONfilePath)).text);
        }
        #endregion
    }

}
