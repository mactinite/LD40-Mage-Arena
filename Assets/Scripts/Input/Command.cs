using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Command<T> {
    readonly string name;
    private T state;

    public delegate T CommandDelegate();
    private CommandDelegate command;

    public string Name
    {
        get
        {
            return name;
        }
    }

    public T State
    {
        get
        {
            this.state = this.command();
            return state;
        }
    }

    public Command(string name, T state, CommandDelegate f)
    {
        this.name = name;
        this.state = state;
        this.command = f;
    }

    public Command(string name, CommandDelegate f)
    {
        this.name = name;
        this.state = default(T);
        this.command = f;
    }

}
