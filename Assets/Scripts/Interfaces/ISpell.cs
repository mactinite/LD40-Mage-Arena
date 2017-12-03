using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell {

    bool IsLooping();
    void Equip(SpellController controller);
    void UnEquip(SpellController controller);
    void Cast(SpellController controller);
    void Stop(SpellController controller);
}
