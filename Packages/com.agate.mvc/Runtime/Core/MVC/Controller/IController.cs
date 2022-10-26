using System.Collections;

namespace Agate.MVC.Core
{
    public interface IController
    {
        IEnumerator Initialize();
        IEnumerator HudController();
        IEnumerator Terminate();
    }
}
