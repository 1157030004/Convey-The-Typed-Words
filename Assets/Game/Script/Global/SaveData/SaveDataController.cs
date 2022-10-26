using System.Collections;
using System.IO;
using Agate.MVC.Base;
using UnityEngine;

namespace Shadee.ConTW
{
    public class SaveDataController : DataController<SaveDataController, SaveDataModel, ISaveDataModel>
    {
        public void SaveData()
        {
            Save();
        }

        public void LoadData()
        {
            Load();
        }

        private void Save()
        {
            string path = $"{Application.persistentDataPath}/Save/savefile.json";
            string saveData = JsonUtility.ToJson(_model.Progress);
            File.WriteAllText(path, saveData);

            Debug.Log($"Save data to {path}");
        }

        private void Load()
        {
            string directory = Path.Combine(Application.persistentDataPath, "Save");
            string path = Path.Combine(directory, "savefile.json");
            if(File.Exists(path))
            {
                string saveData = File.ReadAllText(path);
                Progress progress = JsonUtility.FromJson<Progress>(saveData);
                _model.SetProgressData(progress);
                // _model.GetCoinData();
            }
            else
            {
                Directory.CreateDirectory(directory);
                InitSaveData();
            }
        }

        private void InitSaveData()
        {
            TextAsset initSaveFile = Resources.Load<TextAsset>(@"Data/SaveData/InitSaveData");
            Progress progress = JsonUtility.FromJson<Progress>(initSaveFile.text);
            _model.SetProgressData(progress);
            Save();
        }

        public bool IsBundleUnlocked(string id)
        {
            return _model.Progress.UnlockedBundle.Contains(id);
        }

        public bool IsBundleCompleted(string id)
        {
            return _model.Progress.CompletedBundle.Contains(id);
        }

        public void SetCoinData(int coin)
        {
            _model.SetCoinData(coin);
            Save();
        }

        public void SetBundlePickedID(string id)
        {
            _model.SetPickedBundleID(id);
        }

        public void UnlockBundle(string id, int coin)
        {
            bool isUnlocked = IsBundleUnlocked(id);

            if(isUnlocked)
            {
                Debug.Log($"Bundle {id} is already unlocked");
                return;
            }

            _model.AddUnlockedBundle(id);
            _model.SetCoinData(coin);
            Save();
        }

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            LoadData();
        }
    }
}
