using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract void UseItem(Collider2D owner);

    protected virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
