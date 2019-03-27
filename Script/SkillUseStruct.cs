using UnityEngine;
using System.Collections;

public class SkillUseStruct : MonoBehaviour
{
	public Person me;
	public Skill s;
	public Person[] targets;
	public SkillUseStruct(Person me,Skill s,Person[] targets){
		this.me = me;
		this.s = s;
		this.targets = targets;
	}
}

