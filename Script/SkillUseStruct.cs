using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillUseStruct : MonoBehaviour
{
    private Person me;
    private Skill s;
    private List<Person> targets;

    public SkillUseStruct(Person me, Skill s, List<Person> targets)
    {
        this.me = me;
        this.s = s;
        this.targets = targets;
    }

    public Person Me
    {
        get
        {
            return me;
        }

        set
        {
            me = value;
        }
    }

    public Skill S
    {
        get
        {
            return s;
        }

        set
        {
            s = value;
        }
    }

    public List<Person> Targets
    {
        get
        {
            return targets;
        }

        set
        {
            targets = value;
        }
    }

    
}

