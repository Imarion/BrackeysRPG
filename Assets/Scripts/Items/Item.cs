
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item"; // new is to overwrite the "name" keyword all objects have
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use() {

        // Use item
        // something might happen

        Debug.Log("Using " + name);

    }

}
