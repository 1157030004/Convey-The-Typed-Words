using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;
using System.Linq;

namespace Shadee.ConTW.Gameplay.WordStream
{
    public interface IWordStreamModel : IBaseModel
    {
        public LinkedList<char> currentWord { get; }
        public Queue<string> wordQueue { get; }
    }
    public class WordStreamModel : BaseModel, IWordStreamModel
    {
        public LinkedList<char> currentWord {get; private set;} = new LinkedList<char>();

        public Queue<string> wordQueue {get; private set;} = new Queue<string>();

        public void SetNewWord(string word)
        {
            currentWord = new LinkedList<char>(word);
            SetDataAsDirty();
        }

        public void SetWordQueue(Queue<string> queue)
        {
            wordQueue = queue;
            SetDataAsDirty();
        }

        public bool CheckCharacter(char inputChar)
        {
            if(currentWord.First.Value == inputChar)
            {
                currentWord.RemoveFirst();
                SetDataAsDirty();
                return true;
            }

            SetDataAsDirty();
            return false;
        }

        public bool CheckKey(string letter)
        {
            if(currentWord.First.Value.ToString() == letter)
            {
                currentWord.RemoveFirst();
                SetDataAsDirty();
                return true;
            }

            SetDataAsDirty();
            return false;
        }
    }
}
