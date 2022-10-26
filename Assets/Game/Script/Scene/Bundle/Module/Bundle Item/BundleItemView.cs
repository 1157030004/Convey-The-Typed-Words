using Agate.MVC.Base;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Shadee.ConTW.Bundle
{
    public class BundleItemView : ObjectView<IBundleItemModel>
    {

        [SerializeField] private TextMeshProUGUI _bundleNameText;
        [SerializeField] private Image _isBundleCompletedImage;
        [SerializeField] private Image _isBundleLockedImage;
        [SerializeField] private Button _unlockButton;
        [SerializeField] private TextMeshProUGUI _unlockCostText;
        [SerializeField] private Button _openBundleButton;

        public void Init(UnityAction onBundleClick)
        {
            _unlockButton.onClick.RemoveAllListeners();
            _unlockButton.onClick.AddListener(onBundleClick);
        }

        public void OpenBundle(UnityAction onBundleClick)
        {
            _openBundleButton.onClick.RemoveAllListeners();
            _openBundleButton.onClick.AddListener(onBundleClick);
        }

        public void SetLockState(bool isLocked)
        {
            _isBundleLockedImage.gameObject.SetActive(isLocked);
            _unlockButton.gameObject.SetActive(isLocked);
        }
        protected override void InitRenderModel(IBundleItemModel model)
        {
            _bundleNameText.text = model.Bundle.Name;
            _isBundleCompletedImage.gameObject.SetActive(model.IsCompleted);
            _isBundleLockedImage.gameObject.SetActive(model.IsLocked);
            _unlockCostText.text = model.UnlockCost.ToString();
            _unlockButton.gameObject.SetActive(model.IsLocked);
        }

        protected override void UpdateRenderModel(IBundleItemModel model)
        {
            _isBundleCompletedImage.gameObject.SetActive(model.IsCompleted);
            _isBundleLockedImage.gameObject.SetActive(model.IsLocked);
            _unlockCostText.text = model.UnlockCost.ToString();
            _unlockButton.gameObject.SetActive(model.IsLocked);
        }
    }
}
