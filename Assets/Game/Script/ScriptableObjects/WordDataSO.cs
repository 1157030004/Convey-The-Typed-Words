using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shadee.ConTW
{
    public enum FileType
    {
        Txt,
        Json,
        Html,
    }

    [CreateAssetMenu(fileName = "WordData", menuName = "Game/WordData")]
    public class WordDataSO : ScriptableObject
    {
        [SerializeField] private TextAsset wordFile;
        [SerializeField] private FileType fileType;

        public TextAsset WordFile => wordFile;
        public FileType FileType => fileType;
    }
}
