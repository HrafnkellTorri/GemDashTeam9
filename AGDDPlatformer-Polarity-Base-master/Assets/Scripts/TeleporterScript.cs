using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AGDDPlatformer {
    public class TeleporterScript : MonoBehaviour {
        [SerializeField] GameObject exit;

        private void OnTriggerEnter2D(Collider2D collision) {
            if (exit) {

                PlayerController pc = collision.GetComponent<PlayerController>();

                if (pc) {
                    // Offset so that player shows up at a position that makes sense
                    Vector3 y_offset = new Vector3(0, collision.transform.localScale.y / 2, 0) * pc.gravityModifier;
                    collision.transform.position = exit.transform.position - y_offset + (collision.transform.localScale.y * exit.transform.up);

                    pc.velocity = -pc.velocity;

                    if (exit.transform.up != new Vector3(1, 0) && exit.transform.up != new Vector3(-1, 0))
                        pc.velocity *= exit.transform.up;

                    pc.velocity *= pc.gravityModifier;

                    pc.SetJumpBoost(new Vector2(exit.transform.up.x, 0) * pc.velocity.magnitude * pc.gravityModifier);
                }
            }
        }
    }
}