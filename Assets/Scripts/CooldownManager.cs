using System;
using System.Collections;
using UnityEngine;

public static class CooldownManager
{
    public static IEnumerator Cooldown (float cooldownDuration, Action action)
    {
        yield return new WaitForSeconds (cooldownDuration);
        action.Invoke ();
    }

    public static IEnumerator Cooldown<T> (float cooldownDuration, Action<T> action, T parameter)
    {
        yield return new WaitForSeconds (cooldownDuration);
        action.Invoke (parameter);
    }

    public static IEnumerator Cooldown<T, U> (float cooldownDuration, Action<T, U> action, T parameter1, U parameter2)
    {
        yield return new WaitForSeconds (cooldownDuration);
        action.Invoke (parameter1, parameter2);
    }

    public static IEnumerator Cooldown<T, U, X> (float cooldownDuration, Action<T, U, X> action, T parameter1, U parameter2, X parameter3)
    {
        yield return new WaitForSeconds (cooldownDuration);
        action.Invoke (parameter1, parameter2, parameter3);
    }
}
