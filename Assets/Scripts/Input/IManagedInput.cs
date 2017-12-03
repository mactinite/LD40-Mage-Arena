using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManagedInput {

    bool GetButtonInput(string name);
    float GetAxisInput(string name);
    //TODO: Add method to get all inputs in associate interface implementation
}
