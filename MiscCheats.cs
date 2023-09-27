using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Invector.CharacterController;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace JustBad
{
    internal class MiscCheats : MonoBehaviour
    {
        public void Start()
        {
            base.StartCoroutine(FastUpdates());
            base.StartCoroutine(SlowUpdates());
        }
        private static void smethod_0(TextWriter textWriter_0)
        {
            Type typeFromHandle = typeof(Menu);
            FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.Public);
            string[] array = new string[]
            {
                "enemyFirebaseID", "enemyNickname", "selectedSkin", "customNickname", "skinIdList", "mouseAimbot_SmoothingMin", "mouseAimbot_SmoothingMax", "altAimbot_FOVMin", "altAimbot_FOVMax", "normalEnemySize",
                "enemySliderSizeMin", "enemySizeSliderMax", "loadConfigButtonPressed", "saveConfigButtonPressed", "isConfirmScreenShowing", "removeAllFriendsCONFIRMButtonPressed", "removeAllFriendsNOButtonPressed", "removeAllFriendsButtonPressed", "skinChangerButtonPressed", "managePlayerEnabled",
                "kickAllPlayersButtonPressed", "tpToPlayerButtonPressed", "lobbyPlayerOptionsButtonPressed", "customNicknameButtonPressed", "skinIdListButtonPressed", "cheat_UniversalFontStyle", "cheat_UniversalFontSize", "playerToDisplayOptionsOn", "nickname", "isPlayerListShowing",
                "leavePlayerOptionsScreen", "developerFlySpeedMin", "developerFlySpeedMax", "noclipSpeedMin", "noclipSpeedMax"
            };
            foreach (FieldInfo fieldInfo in fields)
            {
                string name = fieldInfo.Name;
                if (!array.Contains(name))
                {
                    object value = fieldInfo.GetValue(null);
                    textWriter_0.WriteLine(string.Format("{0} = {1}", name, value));
                }
            }
        }

        public static string GenerateRandomString(int int_1)
        {
            char[] array = new char[int_1];
            for (int i = 0; i < int_1; i++)
            {
                array[i] = MiscCheats.string_0[MiscCheats.random_1.Next(MiscCheats.string_0.Length)];
            }
            return new string(array);
        }

        private void method_0()
        {
            string text = MiscCheats.GenerateRandomString(MiscCheats.int_0);
            FirebaseManager firebaseManager = UnityEngine.Object.FindObjectOfType<FirebaseManager>();
            firebaseManager.JLPGEKNJLMG.ID = "luv2cheat! " + text;
        }

        private void method_1()
        {
            foreach (vThirdPersonController vThirdPersonController in UnityEngine.Object.FindObjectsOfType<vThirdPersonController>())
            {
                if (!vThirdPersonController.IsMine)
                {
                    PlayerSkinManager component = vThirdPersonController.GetComponent<PlayerSkinManager>();
                    component.ChangeSkinRemote("lol.1v1.playerskins.pack." + random_0.Next(1, 278).ToString());
                }
            }
        }

        private void method_2()
        {
            if (Menu.changeEnemySizeEnabled)
            {
                foreach (vThirdPersonController vThirdPersonController in UnityEngine.Object.FindObjectsOfType<vThirdPersonController>())
                {
                    if (!vThirdPersonController.IsMine)
                    {
                        Vector3 vector = new Vector3(Menu.changeEnemySizeSlider, Menu.changeEnemySizeSlider, Menu.changeEnemySizeSlider);
                        vThirdPersonController._capsuleCollider.transform.localScale = vector;
                    }
                }
            }
        }

        public IEnumerator FastUpdates()
        {
            return null;
        }

        public IEnumerator SlowUpdates()
        {
            return null;
        }
        public void CreateCircleOfBuildings(int int_1, float float_0)
        {
            offset += 2f;
            Vector3 vector = new Vector3(PlayerController.JPIGHMOLDBI.transform.position.x, PlayerController.JPIGHMOLDBI.transform.position.y + offset, PlayerController.JPIGHMOLDBI.transform.position.z);
            float num = 360f / (float)int_1;
            for (int i = 0; i < int_1; i++)
            {
                float num2 = (float)i * num;
                Vector3 vector2 = vector + Quaternion.Euler(0f, num2, 0f) * Vector3.forward * float_0;
                Quaternion quaternion = Quaternion.Euler(0f, num2, 0f);
                BuildingNetworkController.Instance.CreateBuilding(0, vector2, quaternion);
            }
        }

        public void Update()
        {
            if (Menu.skinChangerButtonPressed)
            {
                string text = Menu.selectedSkin.Trim();
                if (!string.IsNullOrWhiteSpace(text))
                {
                    int num;
                    if (!Regex.IsMatch(text, "^\\d+$"))
                    {
                        MiscCheats.wasErrorWithEnteredSkinID = true;
                    }
                    else if (!int.TryParse(text, out num))
                    {
                        MiscCheats.wasErrorWithEnteredSkinID = true;
                    }
                    else
                    {
                        fManager = UnityEngine.Object.FindObjectOfType<FirebaseManager>();
                        fManager.JLPGEKNJLMG.Skins.EquippedCharacterSkin = "lol.1v1.playerskins.pack." + text;
                        uiManager = UnityEngine.Object.FindObjectOfType<UiManager>();
                        uiManager.UpdateProfileInfo();
                    }
                }
            }
            if (Menu.kickAllEnabled)
            {
                list_2.Clear();
                foreach (PartyRoomConnector partyRoomConnector in UnityEngine.Object.FindObjectsOfType<PartyRoomConnector>())
                {
                    list_2.AddRange(PhotonNetwork.PlayerList);
                    foreach (Player player in list_2)
                    {
                        if (!player.IsLocal)
                        {
                            partyRoomConnector.photonView.RPC("KickPlayer", RpcTarget.Others, new object[] { player.UserId });
                        }
                    }
                }
            }
            if (Menu.removeAllFriendsCONFIRMButtonPressed)
            {
                list_1.Clear();
                fManager = UnityEngine.Object.FindObjectOfType<FirebaseManager>();
                list_1.AddRange(fManager.JLPGEKNJLMG.Friends.Friends);
                foreach (FriendEntry friendEntry in list_1)
                {
                    string userId = friendEntry.UserId;
                    fManager.RemoveFriend(userId);
                }
            }
            if (Menu.customNicknameButtonPressed)
            {
                fManager = UnityEngine.Object.FindObjectOfType<FirebaseManager>();
                fManager.SetNickname(Menu.customNickname ?? "");
                uiManager = UnityEngine.Object.FindObjectOfType<UiManager>();
                uiManager.UpdateProfileInfo();
            }
            if (Menu.saveConfigButtonPressed)
            {
                string text2 = "C:\\temp\\JustBad_Config.txt";
                using (StreamWriter streamWriter = new StreamWriter(text2))
                {
                    MiscCheats.smethod_0(streamWriter);
                }
            }
            if (!Menu.loadConfigButtonPressed)
            {
            }
            if (Menu.spawnDomeEnabled && Input.GetKey(KeyCode.U))
            {
                CreateCircleOfBuildings(100, 50f);
            }
            if (Menu.lagEnemiesEnabled)
            {
                foreach (PlayerController playerController in AimbotStuff.list_0)
                {
                    BuildingNetworkController buildingNetworkController = UnityEngine.Object.FindObjectOfType<BuildingNetworkController>();
                    Building building = UnityEngine.Object.FindObjectOfType<Building>();
                    string id = building.KMMHNJACHJC;
                    int creatorId = building.CreatorId;
                    double timeCreated = building.TimeCreated;
                    Quaternion quaternion = new Quaternion(UnityEngine.Random.Range(1f, 150f), UnityEngine.Random.Range(1f, 150f), UnityEngine.Random.Range(1f, 150f), 1f);
                    buildingNetworkController.photonView.RPC("CreateBuildingRemote", 0, new object[]
                    {
                        0,
                        playerController.transform.position,
                        quaternion,
                        id,
                        creatorId,
                        "lol.1v1.buildsmaterial.default",
                        1,
                        timeCreated
                    });
                }
                foreach (Building building2 in UnityEngine.Object.FindObjectsOfType<Building>())
                {
                    building2.DieOnlyMe();
                }
            }
            if (Menu.boogeyBombEnabled)
            {
                foreach (PlayerController playerController2 in AimbotStuff.list_0)
                {
                    EmoteManager component = playerController2.GetComponent<EmoteManager>();
                    PhotonView photonView = PunExtensions.GetPhotonView(component.gameObject);
                    string userId2 = photonView.Owner.UserId;
                    photonView.RPC("PlayEmoteInGame", 0, new object[]
                    {
                        "lol.1v1.playeremotes.pack." + random_0.Next(1, 80).ToString(),
                        userId2
                    });
                }
            }
        }

        private List<FriendEntry> list_0 = new List<FriendEntry>();

        private List<FriendEntry> list_1 = new List<FriendEntry>();

        private List<Player> list_2 = new List<Player>();

        private List<string> list_3 = new List<string>();

        private System.Random random_0 = new System.Random();

        public FirebaseManager fManager;

        public vThirdPersonCamera thirdPersonCamera;

        public UiManager uiManager;

        private static System.Random random_1 = new System.Random();

        private static readonly int int_0 = 10;

        private static readonly string string_0 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static bool wasErrorWithEnteredSkinID;

        public static Dictionary<string, bool> cheatConfig = new Dictionary<string, bool>();

        public float offset;
    }
}
