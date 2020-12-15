using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    /// <summary>
    /// Appelée lorsque l'état doit être chargé. Abonne l'objet aux événements liés.
    /// </summary>  
    public virtual void Enter()
    {
        //Quand un état est "chargé" par la State Machine, on le fait s'abonner à tous les événements associés
        AddListeners();
    }

    /// <summary>
    /// Appelée lorsque l'état doit être déchargé. Désabonne l'objet aux événements liés.
    /// </summary>
    public virtual void Exit()
    {
        //Quand un état est "déchargé" par la State Machine, on le fait se désabonner à tous les événements associés
        RemoveListeners();
    }

    //Par sécurité, on désabonne l'état aux événements liés lorsque l'objet est détruit
    protected virtual void OnDestroy()
    {
        RemoveListeners();
    }

    /// <summary>
    /// Le modèle de la fonction qui abonne aux événements. Peut, mais n'est pas obligée d'être implémentée par les enfants (virtual). Vide par défaut.
    /// </summary>
    protected virtual void AddListeners()
    {

    }

    /// <summary>
    /// Le modèle de la fonction qui désabonne aux événements. Peut, mais n'est pas obligée d'être implémentée par les enfants (virtual). Vide par défaut.
    /// </summary>
    protected virtual void RemoveListeners()
    {

    }
}
