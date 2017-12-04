using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell {

    bool IsLooping();
    string GetName();
    void Equip(SpellController controller);
    void UnEquip(SpellController controller);
    void Cast(SpellController controller);
    void Stop(SpellController controller);
    float GetHeat();
}
