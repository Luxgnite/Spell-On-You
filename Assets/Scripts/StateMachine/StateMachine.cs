using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    /// <summary>
    /// Getter / Setter de l'état actuellement chargé.
    /// </summary>
    public virtual State CurrentState
    {
        get { return _currentState; }
        set { Transition(value); }
    }

    //État actuellement chargé par la State Machine
    protected State _currentState;
    //Si la State Machine est en train d'effectuer une transition vers un autre état. Nécessaire pour sécuriser l'asynchronicité inhérente à la State Machine.
    protected bool _inTransition;

    /// <summary>
    /// Retourne un Composant correspondant au State en argument présent sur le GameObject de la State Machine. Créer le composant s'il n'existe pas.
    /// </summary>
    /// <typeparam name="T">Objet héritant de State dont on veut récupérer le Composant sur le State Machine</typeparam>
    /// <returns></returns>
    public virtual T GetState<T>() where T : State
    {
        //Comme State hérite de Monobehavior, il est obligé d'être créé en tant que Composant sur un GameObject. De ce fait, on vérifie s'il existe déjà...
        T target = GetComponent<T>();
        //... et dans le cas où il n'existe pas, alors on le créer.
        if (target == null)
            target = gameObject.AddComponent<T>();
        return target;
    }

    /// <summary>
    /// Change l'état actuel de la State Machine par le State proposé en argument
    /// </summary>
    /// <typeparam name="T">Objet héritant de State dont on veut qu'il devienne le State actuel</typeparam>
    public virtual void ChangeState<T>() where T : State
    {
        /* On cherche en premier un Composant correspondant au State en argument.
         * Ensuite, on envoie ce composant vers Transition() pour que la State Machine
         * fasse la transition entre le State argument et le State actuel. */
        CurrentState = GetState<T>();
    }

    /// <summary>
    /// Effectuer la transition du State actuel au State en argument.
    /// </summary>
    /// <param name="value">Objet State vers lequel on veut effectuer la transition</param>
    protected virtual void Transition(State value)
    {
        /* On vérifie si le State vers lequel on doit effectuer la transition est le même que l'actuel State,
         * ou que le State Machine est déjà en transition.
         * Si l'une des deux conditions est vrai, alors on interrompt la transition. */
        if (_currentState == value || _inTransition)
            return;
        //Sinon, on initie la transition
        Debug.Log("Transition...");
        //On indique que la State Machine est en cours de transition
        _inTransition = true;
        /* Vérification de sécurité pour éviter une exception : 
         * s'il y a bien référence à un State comme State actuel, alors on le "décharge".*/
        if (_currentState != null)
            _currentState.Exit();
        //On référence le State vers lequel on effectue la transition comme State actuel.
        _currentState = value;
        /* Vérification de sécurité pour une éviter une exception : 
         * s'il y a bien référence à un State comme State vers lequel on effectue la transition, 
         * alors on le "charge".*/
        if (_currentState != null)
            _currentState.Enter();

        //On indique que la State Machine à terminé la transition.
        _inTransition = false;
        Debug.Log("Transition ended");
    }
}
