using UnityEngine;

public class ItemAction : MonoBehaviour, IAction
{
    public void Action()
    {
        GameObject obj = GameObject.Find(this.gameObject.name + "Icon").transform.GetChild(0).gameObject;
        obj.SetActive(true);
        GameManager.Instance.KeyItemCount++;
        Destroy(PlayerController.Instance.HitObject);
    }
}
