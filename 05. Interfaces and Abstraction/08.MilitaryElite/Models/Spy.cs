﻿using System;
using System.Collections.Generic;
using System.Text;

public class Spy : Soldier, ISpy
{
    public int CodeNumber { get; private set; }

    public Spy(string id, string firstName, string lastName, int codeNumber) 
        :base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(base.ToString())
            .AppendLine($"Code Number: {this.CodeNumber}");

        return sb.ToString().TrimEnd();
    }
}

