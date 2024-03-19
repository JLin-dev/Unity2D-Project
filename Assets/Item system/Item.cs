using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ItemSystem/Item")]
public class item : ScriptableObject
{
    public int ItemID;
    public string ItemName;
    public Sprite ItemImage;

    public virtual void UseItem()
    {



    }

}


