using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Family
{
    private List<Person> familyMembers;

    public List<Person> FamilyMembers
    {
        get { return familyMembers; }
        set { familyMembers = value; }
    }

    public Family()
    {
        this.FamilyMembers = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.FamilyMembers.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.FamilyMembers.OrderByDescending(p => p.Age).First();
    }
}

