using Agate.MVC.Base;

namespace Shadee.ConTW.Bundle.Overlay
{
    public interface IOverlayModel : IBaseModel
    {
        public int Coin { get; }
    }
    public class OverlayModel : BaseModel, IOverlayModel
    {
        public int Coin { get; private set;}

        public void SetCoin(int coin)
        {
            Coin = coin;
            SetDataAsDirty();
        }
    }
}
