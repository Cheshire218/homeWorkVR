using System.Collections;
using UnityEngine;

namespace HTC.UnityPlugin.Vive
{
    public class MyViveTeleport : Teleportable
    {
        [SerializeField] float _speed;
        [SerializeField] float _minDistance;

        public override IEnumerator StartTeleport(Vector3 position, float duration)
        {
            while (true)
            {
                yield return new WaitForFixedUpdate();

                target.position = Vector3.Lerp(target.position, position, _speed * Time.fixedDeltaTime);

                Vector3 v = position;
                v.y = target.position.y;

                if (Vector3.Distance(target.position, v) < _minDistance)
                {
                    teleportCoroutine = null;
                    yield break;
                }
            }
        }
    }
}