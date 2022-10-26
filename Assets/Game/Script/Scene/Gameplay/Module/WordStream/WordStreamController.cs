using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Agate.MVC.Base;
using Shadee.ConTW.Gameplay.Typer;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Shadee.ConTW.Gameplay.WordStream
{
    public class WordStreamController : ObjectController<WordStreamController, WordStreamModel, IWordStreamModel, WordStreamView>
    {
        private char _currentChar;
        private AsyncOperationHandle handle;
        private GameObject _keyObject;
        public override void SetView(WordStreamView view)
        {
            base.SetView(view);
            LoadWordData();
            _view.InitPool(10);

        }

        private async void LoadWordData()
        {
            handle = Addressables.LoadAssetAsync<TextAsset>("wordData");
            await handle.Task;
            if(handle.Status == AsyncOperationStatus.Succeeded)
            {
                TextAsset textAsset = (TextAsset)handle.Result;
                string[] words = textAsset.text.Split(new char[0]);
                _model.SetWordQueue(PrepareWords(words));
                SetNewWord();
            }
        }

        private Queue<string> PrepareWords(string[] words)
        {
            List<string> preparedWords = words.Where(word => word.Length < 10).ToList();
            preparedWords = ShuffleList(preparedWords);
            return new Queue<string>(preparedWords);
        }

        private List<string> ShuffleList(List<string> words)
        {
            List<string> temporaryList = new List<string>(words);
            for (int i = 0; i < words.Count; i++)
            {
                string temporaryWord = words[i];
                int randomIndex = Random.Range(i, words.Count);
                temporaryList[i] = temporaryList[randomIndex];
                temporaryList[randomIndex] = temporaryWord;
            }
            return temporaryList;
        }

        private void SetNewWord()
        {
            _model.SetNewWord(_model.wordQueue.Dequeue());
            string word = string.Join("", _model.currentWord.ToArray());

            foreach(var key in word)
            {
                ShowKeys(key);
            }
        }

        private void ShowKeys(char key)
        {
            TyperModel typerModel = new TyperModel();
            _keyObject = _view.CreateKeyObject(Guid.NewGuid().ToString(), key.ToString());
        
            TyperView typerView = _keyObject.GetComponent<TyperView>();
            TyperController typerController = new TyperController();
            InjectDependencies(typerController);
            typerController.Init(typerModel, typerView);
        }

        public void CheckKey(KeySelectedMessage message)
        {
            if (_model.CheckKey(message.SelectedKey))
            {
                _view.HideKey(message.ButtonId);
                if (_model.currentWord.Count <= 0)
                {
                    SetNewWord();
                    // Play correct sound
                }
                else
                {
                    // Play correct sound
                }
            }
            else
            {
                // Play wrong sound
            }
        }


        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
        }

        public override IEnumerator Terminate()
        {
            Addressables.Release(handle);
            return base.Terminate();
        }
    }

}
