using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMonster
{

    public List<Person> FightMonsterFactory(int fightNumber)
    {
        List<Person> monsterList = new List<Person>();
        //野猪(2-4)
        if (fightNumber == 1)
        {
            int monsterNumber = Random.Range(2, 4);
            for (int i = 0; i < monsterNumber; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber*100+i,4));
            }

        }//黑野猪(2-4)
        else if(fightNumber == 2)
        {
            int monsterNumber = Random.Range(2, 4);
            for (int i = 0; i < monsterNumber; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i, 5));
            }
        }//劲敌
        else if (fightNumber == 3)
        {

        }//幽灵(2-4)
        else if (fightNumber == 4)
        {
            int monsterNumber = Random.Range(2, 4);
            for (int i = 0; i < monsterNumber; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i,6));
            }
        }//小恶魔(2-4)
        else if (fightNumber == 5)
        {
            int monsterNumber = Random.Range(2, 4);
            for (int i = 0; i < monsterNumber; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i, 7));
            }
        }//士兵甲、乙(2-4)
        else if (fightNumber == 7)
        {
            for(int j = 0; j < 2; j++)
            {
                int monsterNumber = Random.Range(1, 2);
                for (int i = 0; i < monsterNumber; i++)
                {
                    monsterList.Add(MonsterFactory(fightNumber * 100 + i+j, 8+j));
                }
            }
        }//士兵4、将军
        else if (fightNumber == 8)
        {
            monsterList.Add(MonsterFactory(fightNumber * 100, 10));

            for (int i = 0; i < 4; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i+1 , 9));
            }
        }//魔狼（2-4）
        else if (fightNumber == 9)
        {
            int monsterNumber = Random.Range(2, 4);
            for (int i = 0; i < monsterNumber; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i , 11));
            }
        }//魔狼（2-4）龙1
        else if (fightNumber == 10)
        {
            int monsterNumber = Random.Range(2, 4);
            for (int i = 0; i < monsterNumber; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i, 11));
            }
            monsterList.Add(MonsterFactory(fightNumber * 105, 12));
        }//精灵4
        else if (fightNumber == 11)
        {
            for (int i = 0; i < 4; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i, 13));
            }
        }
        return monsterList;
    }

    public Person MonsterFactory(int ID,int type)
    {
        Person person = null;

        if (type == 1)
        {
            person = new Person(ID, "男主一", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "020-Hunter01", 2, 0, 0);
        }
        else if(type == 2)
        {
            person = new Person(ID, "女主一", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "040-Mage08", 2, 0, 0);
        }else if(type == 3)
        {
            person = new Person(ID, "女主二", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "007-Fighter07", 2, 0, 0);
        }
        else if (type == 4)
        {
            person = new Person(ID, "野猪", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "155-Animal05", 1, 8, 10);
        }
        else if (type == 5)
        {
            person = new Person(ID, "黑野猪", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "155-Animal05", 1, 25, 30);
        }
        else if (type == 6)
        {
            person = new Person(ID, "幽灵", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "051-Undead01.png", 2, 50, 50);
        }
        else if (type == 7)
        {
            person = new Person(ID, "小恶魔", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "075-Devil01", 2, 90, 90);
        }
        else if (type == 8)
        {
            person = new Person(ID, "士兵甲", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "049-Soldier01", 2, 150, 150);
        }
        else if (type == 9)
        {
            person = new Person(ID, "士兵乙", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "050-Soldier02", 2, 150, 150);
        }
        else if (type == 10)
        {
            person = new Person(ID, "将军", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "003-Fighter03", 2, 150, 150);
        }
        else if (type == 11)
        {
            person = new Person(ID, "魔狼", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "063-Beast01", 1, 225, 225);
        }
        else if (type == 12)
        {
            person = new Person(ID, "龙", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "099-Monster13", 1, 300, 300);
        }
        else if (type == 13)
        {
            person = new Person(ID, "精灵", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "080-Angel02", 1, 1000, 300);
        }
        return person;
    }

   
}