using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster{
    private Dictionary<int, Person> monsterDict;

    public Monster()
    {
        
        monsterDict = new Dictionary<int, Person>
        {
            {1,new Person(1, "男主一", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "020-Hunter01",1) },
            {2,new Person(2, "女主一", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "040-Mage08",1) },
            {3,new Person(3, "女主二", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "007-Fighter07",1) },
            {4,new Person(4, "野猪", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "155-Animal05",1) },
            {5,new Person(5, "黑野猪", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "155-Animal05",1) },
            {6,new Person(6, "幽灵", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "051-Undead01.png",1) },
            {7,new Person(7, "小恶魔", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "075-Devil01",1) },
            {8,new Person(8, "士兵甲", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "049-Soldier01",1) },
            {9,new Person(9, "士兵乙", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "050-Soldier02",1) },
            {10,new Person(10, "将军", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "003-Fighter03",1) },
            {11,new Person(11, "魔狼", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "063-Beast01",1) },
            {12,new Person(12, "龙", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "099-Monster13",1) },
            {13,new Person(13, "精灵", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "080-Angel02",1) },
        };
    }

    public Person GetPerson(int personID)
    {
        return monsterDict[personID];
    }

    public Dictionary<int, Person> MonsterDict
    {
        get
        {
            return monsterDict;
        }

        set
        {
            monsterDict = value;
        }
    }
}


public class FightMonster
{
    private Dictionary<int, List<Person>> fightDict;

    public FightMonster()
    {
        fightDict = new Dictionary<int, List<Person>> {
            { 1,new List<Person>{ } },

        };
    }

    public Dictionary<int, List<Person>> FightDict
    {
        get
        {
            return fightDict;
        }

        set
        {
            fightDict = value;
        }
    }
}