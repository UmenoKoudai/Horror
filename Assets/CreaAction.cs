using UnityEngine;

public class CreaAction : MonoBehaviour, IAction
{
    public void Action()
    {
        if(GameManager.Instance.KeyItemCount == 5)
        {
            SceneSystem.Instance.SceneChange("Clear");
        }
    }
}
