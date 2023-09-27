using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JustBad
{
    internal class CombatCheats : MonoBehaviour
    {
        public void Start()
        {
            base.StartCoroutine(this.method_0());
        }

        // Token: 0x06000029 RID: 41 RVA: 0x0000229B File Offset: 0x0000049B
        private IEnumerator method_0()
        {
            return null;
        }

        // Token: 0x0600002A RID: 42 RVA: 0x000035F0 File Offset: 0x000017F0
        private void gwfdrnioh()
        {
            foreach (PlayerController playerController in AimbotStuff.list_0)
            {
                if (playerController != null)
                {
                    WeaponsController weapons = playerController.OFGEHBLDKHD;
                    weapons.photonView.RPC("FireWeaponRemote", 0, new object[]
                    {
                        weapons.LJKOFCFAHEC.point,
                        true,
                        1
                    });
                }
            }
        }

        // Token: 0x0600002B RID: 43 RVA: 0x00003694 File Offset: 0x00001894
        public void Update()
        {
            if (Menu.onlyHeadshotsEnabled)
            {
                this.list_0.Clear();
                foreach (PlayerController playerController in UnityEngine.Object.FindObjectsOfType<PlayerController>())
                {
                    if (!playerController.IsMine(false))
                    {
                        this.list_0.AddRange(playerController.BEPNKGCPMGH.CHBGLCCMNAG.PlayerColliders);
                        foreach (Collider collider in this.list_0)
                        {
                            if (!(collider.name != "HeadCollider"))
                            {
                                SphereCollider sphereCollider = collider as SphereCollider;
                                if (!(sphereCollider == null))
                                {
                                    sphereCollider.radius = 250f;
                                }
                                else
                                {
                                    CapsuleCollider capsuleCollider = collider as CapsuleCollider;
                                    if (capsuleCollider != null)
                                    {
                                        capsuleCollider.radius = 250f;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (Menu.killAllPlayersEnabled && Input.GetKey(KeyCode.P))
            {
                if (Menu.changeEnemySkinsEnabled)
                {
                    Menu.changeEnemySkinsEnabled = false;
                }
                foreach (PlayerController playerController2 in AimbotStuff.list_0)
                {
                    if (Input.GetKey(KeyCode.P))
                    {
                        playerController2.LBFGDDPCNOJ.photonView.RPC("TakeHit", 0, new object[]
                        {
                            999,
                            playerController2.LBFGDDPCNOJ.transform.position,
                            playerController2.LBFGDDPCNOJ.photonView.CreatorActorNr,
                            true
                        });
                    }
                }
            }
            if (Menu.aimAssistControllerOnlyEnabled)
            {
                ControllerSettings.AimAssistSettings.FollowerAimAssist.FollowForceX = 40f;
                ControllerSettings.AimAssistSettings.FollowerAimAssist.FollowForceY = 46.6f;
                ControllerSettings.AimAssistSettings.FollowerAimAssist.DragForceX = 0.01f;
                ControllerSettings.AimAssistSettings.FollowerAimAssist.DragForceY = 0.01f;
                ControllerSettings.AimAssistSettings.FollowerAimAssist.MaxFollow = 2f;
                ControllerSettings.AimAssistSettings.FollowerAimAssist.MaxEnemyDistance = 500f;
                ControllerSettings.AimAssistSettings.FollowerAimAssist.MaxAimAssistRadius = 250f;
                ControllerSettings.AimAssistSettings.FollowerAimAssist.MagnetForce = 37.3f;
            }
            if (Menu.rapidFireEnabled && Input.GetKey(KeyCode.Mouse0))
            {
                WeaponsController weapons = PlayerController.JPIGHMOLDBI.OFGEHBLDKHD;
                weapons.photonView.RPC("FireWeaponRemote", 0, new object[]
                {
                    weapons.LJKOFCFAHEC.point,
                    true,
                    1
                });
            }
            if (Menu.materialsAndAmmoEnabled)
            {
                PlayerController.JPIGHMOLDBI.OFGEHBLDKHD.KOBBJGHNHKE.SetCurrentMagazineAmount(50);
                PlayerController.JPIGHMOLDBI.PlayerBuildingManager.AddBuildingAmmo(5);
            }
            if (Menu.godmodeEnabled)
            {
                PlayerController.JPIGHMOLDBI.LBFGDDPCNOJ.SetHealthLocally(300, 300);
            }
            if (Menu.destroyAllBuildsEnabled && Input.GetKey(KeyCode.V))
            {
                foreach (Building building in UnityEngine.Object.FindObjectsOfType<Building>())
                {
                    building.Die();
                }
            }
            if (Menu.removeEnemyWeaponsEnabled && Input.GetKey(KeyCode.K))
            {
                this.list_1.Clear();
                foreach (PlayerController playerController3 in AimbotStuff.list_0)
                {
                    string id = playerController3.OFGEHBLDKHD.KOBBJGHNHKE.HPDLLFCCEAJ;
                    int num = playerController3.OFGEHBLDKHD.HLIBOOFDDIM;
                    this.list_1 = playerController3.OFGEHBLDKHD.KHCENPLGNJF;
                    for (int k = 0; k < this.list_1.Count; k++)
                    {
                        if (this.list_1[k] != null && this.list_1[k].CEPCLNLIOKE)
                        {
                            num = k;
                            playerController3.photonView.RPC("DropWeaponRemote", 0, new object[]
                            {
                                id,
                                num,
                                playerController3.transform.forward,
                                playerController3.transform.forward
                            });
                        }
                    }
                }
            }
            if (Menu.farmWinsEnabled)
            {
                GameStarter.IsSearchingForGame = true;
            }
        }

        private List<Collider> list_0 = new List<Collider>();

        private List<WeaponModel> list_1;
    }
}
