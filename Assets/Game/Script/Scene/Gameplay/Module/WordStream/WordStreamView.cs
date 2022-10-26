using System.Collections.Generic;
using System.Linq;
using Agate.MVC.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Shadee.ConTW.Gameplay.WordStream
{
    public class WordStreamView : ObjectView<IWordStreamModel>
    {
        [SerializeField] private TextMeshProUGUI _wordText;
        [SerializeField] private RectTransform _keyContainer;
        [SerializeField] private GameObject _keyTemplate;

        private List<GameObject> pooledObjects = new List<GameObject>();
        private int _amountToPool;

        public GameObject CreateKeyObject(string id, string keyText)
        {
            for(int i = 0; i < pooledObjects.Count; i++)
            {
                int randomizedIndex = Random.Range(i, pooledObjects.Count);
                if(!pooledObjects[randomizedIndex].activeInHierarchy)
                {
                    pooledObjects[randomizedIndex].SetActive(true);
                    pooledObjects[randomizedIndex].GetComponentInChildren<TextMeshProUGUI>().text = keyText;
                    pooledObjects[randomizedIndex].GetComponentInChildren<Button>().name = id;
                    return pooledObjects[randomizedIndex];
                }
            }
            
            return null;
        }

        public void HideKey(string buttonId)
        {
            for(int i = 0; i < pooledObjects.Count; i++)
            {
                if(pooledObjects[i].GetComponentInChildren<Button>().name == buttonId)
                {
                    pooledObjects[i].SetActive(false);
                }
            }
        }

        public void InitPool(int amountToPool)
        {
            for(int i = 0; i < amountToPool; i++)
            {
                GameObject obj = Instantiate(_keyTemplate, _keyContainer);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

        protected override void InitRenderModel(IWordStreamModel model)
        {
            _wordText.text = string.Join("", model.currentWord.ToArray());
        }

        protected override void UpdateRenderModel(IWordStreamModel model)
        {
            _wordText.text = string.Join("", model.currentWord.ToArray());
        }
    }
}
