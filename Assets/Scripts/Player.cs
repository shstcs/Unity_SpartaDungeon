using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string UserName {  get; private set; }
    public int Level {  get; private set; }
    public int Exp {  get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int HP { get; set; }
    public int Critical { get; set; }

    private List<Item> inven = new List<Item>();

    public Player(string _userName)
    {
        UserName = _userName;
        Level = 1;
        Exp = 0;
        Atk = 5;
        Def = 5;
        HP = 100;
        Critical = 0;
    }

    public void AddItem(Item item)
    {
        if (item == null) return;
        inven.Add(item);
    }

    public Item[] ShowInven()
    {
        return inven.ToArray();
    }

    public void LevelUp()
    {
        Level++;
        Exp = 0;
    }
}
