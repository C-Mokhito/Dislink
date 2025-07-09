# Dislink

Dislink is a lightweight system for Broke Protocol that automatically detects and blocks links on the chat.

# Default settings

| Flag       | Param              | Type          | Effect                                         | Note                                                                 |
|------------|--------------------|---------------|------------------------------------------------|----------------------------------------------------------------------|
| nosteal    |                    | ShEntity      | Viewing the inventory is disabled              |                                                                      |
| anim       | animName           | ShEntity      | Force to play the animation animName           |                                                                      |
| godmode    |                    | ShDamageable  | Damages are disabled                           |                                                                      |
| nomount    |                    | ShMountable   | Mounting this entity is disabled               |                                                                      |
| norotate   |                    | ShPlayer      | Auto-rotation is disabled                      |                                                                      |
| noai       |                    | ShPlayer      | AI is disabled                                 |                                                                      |
| norestrain |                    | ShPlayer      | Cuffing the NPC is disabled                    |                                                                      |
| mount      | seatIndex (optional) | ShPlayer    | Mounts the closest available mountable at seatIndex | Without seatIndex, the NPC will mount any seat of the closest available mountable |

